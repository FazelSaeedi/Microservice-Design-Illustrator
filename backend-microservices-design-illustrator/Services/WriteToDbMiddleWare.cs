using System.Threading.Tasks;
using FakeTehranFavaServer.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FakeTehranFavaServer.Services
{
    public class WriteToDbMiddleWare
    {
        private readonly ILogger<WriteToDbMiddleWare> _logger;
        private readonly RequestDelegate _next;

        public WriteToDbMiddleWare(RequestDelegate next,
            ILogger<WriteToDbMiddleWare> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext context, IHostEnvironment env)
        {

            try
            {
                await _next(context);
                IRepository repo = context.RequestServices.GetService(typeof(IRepository)) as IRepository;
                
                BackGroundWorker.GetInstance().Write(repo);
                
            }
            catch (System.Exception exp)
            {
            }
        }


    }
}