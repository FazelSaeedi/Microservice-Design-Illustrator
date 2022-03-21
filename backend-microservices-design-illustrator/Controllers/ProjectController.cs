using FakeTehranFavaServer.Repositories;
using MH.DDD.Core.Types;
using microservices_design_illustrator.Domain;
using Microsoft.AspNetCore.Mvc;

namespace microservices_design_illustrator.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase , IDisposable
    {



        private readonly ILogger<ProjectController> _logger;
        private readonly IRepository _repository;




        public ProjectController(ILogger<ProjectController> logger, IRepository repository)
        {
            _logger = logger;
            this._repository = repository;
        }






        [HttpPost("")]
        public Task<ServiceResult<string>> Create(ProjectEntity entity)
        {



            if(!_repository.Groups.Any(x => x.Id == entity.GroupId)) 
                return ServiceResult.Empty.SetError("GroupNotFound" , 400).To<string>().ToAsync();




            if(_repository.Projects.Any(x => x.Name == entity.Name))
                return ServiceResult.Empty.SetError("ProjectIsExists").To<string>().ToAsync();



            entity.Id = Guid.NewGuid().ToString();
            _repository.Projects.Add(entity);
            return ServiceResult.Create<string>(entity.Id).ToAsync();



        }






        [HttpGet("GetAll")]
        public Task<ServiceResult<List<ProjectEntity>>> GetAll()
        {
            return ServiceResult.Create<List<ProjectEntity>>(_repository.Projects.ToList()).ToAsync();
        }






        [HttpGet("{id}")]
        public Task<ServiceResult<ProjectEntity>> GetById(string id)
        {
            return ServiceResult.Create<ProjectEntity>(_repository.Projects.FirstOrDefault(x => x.Id == id)).ToAsync();
        }
        
        


        

        [HttpPut("{id}")]
        public void EditById(string id)
        {
            throw new NotImplementedException();
        }






        [HttpDelete("{id}")]
        public Task<ServiceResult<string>> DeleteById(string id)
        {

            var entity = _repository.Projects.FirstOrDefault(x => x.Id == id);



            if(entity == null)
                return ServiceResult.Empty.SetError("" , 400).To<string>().ToAsync();


            _repository.Projects.Remove(entity);
            return ServiceResult.Create<string>(entity.Id).ToAsync();

        }





        public void Dispose()
        {
            DbRepo.Save(this._repository);
        }




    }
}