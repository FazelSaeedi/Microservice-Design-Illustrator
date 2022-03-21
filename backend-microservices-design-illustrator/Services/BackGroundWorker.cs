using System;
using System.Threading.Channels;
using System.Threading.Tasks;
using FakeTehranFavaServer.Repositories;

namespace FakeTehranFavaServer.Services
{
    public class BackGroundWorker
    {
        private static BackGroundWorker _instance;
        public static BackGroundWorker GetInstance()
        => _instance ?? (_instance = new BackGroundWorker());
        public BackGroundWorker()
        {
            RepoChannel = Channel.CreateUnbounded<IRepository>();
            readData();
        }

        private void readData()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    var res = await RepoChannel.Reader.WaitToReadAsync();
                    if (res)
                    {
                        var repo = await RepoChannel.Reader.ReadAsync();
                        DbRepo.Save(repo);
                    }
                    await Task.Delay(TimeSpan.FromSeconds(1));
                    
                }
            });
        }

        public Channel<IRepository> RepoChannel { get; private set; }

        public void Write(IRepository repo)
        {
            Console.WriteLine("some things wrotten in db");
            RepoChannel.Writer.TryWrite(repo);
        }
    }
}