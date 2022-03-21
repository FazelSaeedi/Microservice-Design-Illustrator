using System.Text.Json;
using microservices_design_illustrator.Domain;

namespace FakeTehranFavaServer.Repositories
{
    public class DbSetList<T> : List<T>
    {

        public new void Add(T item)
        {
            base.Add(item);
        }

        public int Save(Predicate<T> predicate, T item)
        {
            var index = this.FindIndex(predicate);
            if (index < 0)
                return -1;
            this[index] = item;
            return index;
        }
    }
    public class DbRepo : IRepository
    {

        

        public DbSetList<ProjectEntity> Projects { get; set; }
        public DbSetList<GroupEntity> Groups { get; set; }
        public DbSetList<ControllerEntity> Controllers {get; set;}
        public DbSetList<PageEntity> Pages {get; set;}
        public DbSetList<ServiceEntity> Services {get; set;}
        public DbSetList<EventEntity> Events {get; set;}



        public DbRepo()
        {
            Projects = new DbSetList<ProjectEntity>();
            Groups = new DbSetList<GroupEntity>();
            Controllers = new  DbSetList<ControllerEntity>();
            Pages = new DbSetList<PageEntity>();
            Services = new  DbSetList<ServiceEntity>();
            Events = new  DbSetList<EventEntity>();
        }




        public static void Load(IRepository repo)
        {
            if (!File.Exists("db.txt"))
                return;
            var strraw = File.ReadAllText("db.txt");
            var data = (DbRepo)repo;
            var db = JsonSerializer.Deserialize<DbRepo>(strraw);
            if (db is null)
                return;
            repo.Projects = db.Projects ?? new DbSetList<ProjectEntity>();
            repo.Groups = db.Groups ?? new DbSetList<GroupEntity>();
            repo.Controllers = db.Controllers ?? new DbSetList<ControllerEntity>();
            repo.Pages = db.Pages ?? new DbSetList<PageEntity>();
            repo.Services = db.Services ?? new DbSetList<ServiceEntity>();
            repo.Events = db.Events ?? new DbSetList<EventEntity>();
        }

        public static void Save(IRepository repo)
        {
            var alltext = "";
            var fileDeleted = false;
            try
            {
                var result = JsonSerializer.Serialize(repo);
                var hasChanged = true;
                if (File.Exists("db.txt"))
                {
                    alltext = File.ReadAllText("db.txt");
                    hasChanged = alltext.Length != (result?.Length ?? 0);
                    if (hasChanged)
                    {
                        File.Delete("db.txt");
                        fileDeleted = true;
                    }
                }
                if (hasChanged)
                    File.WriteAllText("db.txt", result);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"cound not write innto db , {ex}");
                if (fileDeleted)
                    File.WriteAllText("db.txt", alltext);
            }
        }
    }
}