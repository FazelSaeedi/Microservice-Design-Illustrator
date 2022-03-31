using FakeTehranFavaServer.Repositories;
using MH.DDD.Core.Types;
using microservices_design_illustrator.Domain;
using Microsoft.AspNetCore.Mvc;

namespace microservices_design_illustrator.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class GroupController : ControllerBase , IDisposable
    {



        private readonly ILogger<GroupController> _logger;
        private readonly IRepository _repository;




        public GroupController(ILogger<GroupController> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }





        [HttpPost("")]
        public Task<ServiceResult<string>> Create(GroupEntity entity)
        {

            
            if(_repository.Groups.Any(x => x.Name == entity.Name))
                return ServiceResult.Empty.SetError("GroupIsExists").To<string>().ToAsync();


            entity.Id = Guid.NewGuid().ToString();
            _repository.Groups.Add(entity);
            return ServiceResult.Create<string>(entity.Id).ToAsync();
        }






        [HttpGet("GetAll")]
        public  Task<ServiceResult<List<GroupEntity>>> GetAll()
        {
            return ServiceResult.Create<List<GroupEntity>>(_repository.Groups.ToList()).ToAsync();
        }






        [HttpGet("{id}")]
        public Task<ServiceResult<GroupEntity>> GetById(string id)
        {
            return ServiceResult.Create<GroupEntity>(_repository.Groups.FirstOrDefault(x => x.Id == id)).ToAsync();
        }
        




        
        [HttpPut("{id}")]
        public void EditById(string id)
        {
            throw new NotImplementedException();
        }






        [HttpDelete("{id}")]
        public Task<ServiceResult<string>> DeleteById(string id)
        {
             var entity = _repository.Groups.FirstOrDefault(x => x.Id == id);



            if(entity == null)
                return ServiceResult.Empty.SetError("GroupIsNotExist" , 400).To<string>().ToAsync();



            if(_repository.Projects.Any(x => x.GroupId == id))
                return ServiceResult.Empty.SetError("GroupHasProject" , 400).To<string>().ToAsync();




            _repository.Groups.Remove(entity);
            return ServiceResult.Create<string>(entity.Id).ToAsync();
        }






        public void Dispose()
        {
            DbRepo.Save(this._repository);
        }






    }
}