using FakeTehranFavaServer.Repositories;
using MH.DDD.Core.Types;
using microservices_design_illustrator.Domain;
using Microsoft.AspNetCore.Mvc;

namespace microservices_design_illustrator.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {



        private readonly ILogger<EventController> _logger;
        private readonly IRepository _repository;



        public EventController(ILogger<EventController> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }





        [HttpPost("")]
        public Task<ServiceResult<string>> Create(EventEntity entity)
        {
            


            if(!_repository.Projects.Any(x => x.Name == entity.PublisherProjectId))
                return ServiceResult.Empty.SetError("ProjectNotFound").To<string>().ToAsync();
            




            if(_repository.Events.Any(x => x.Name == entity.Name))
                return ServiceResult.Empty.SetError("EventIsExists").To<string>().ToAsync();





            entity.Id = Guid.NewGuid().ToString();
            _repository.Events.Add(entity);
            return ServiceResult.Create<string>(entity.Id).ToAsync();
        


        }




        [HttpGet("GetAll")]
        public  Task<ServiceResult<List<EventEntity>>> GetAll()
        {
            return ServiceResult.Create<List<EventEntity>>(_repository.Events.ToList()).ToAsync();
        }





        [HttpGet("{id}")]
        public Task<ServiceResult<EventEntity>> GetById(string id)
        {
            return ServiceResult.Create<EventEntity>(_repository.Events.FirstOrDefault(x => x.Id == id)).ToAsync();
        }
        




        [HttpPut("{id}")]
        public void EditById(string id)
        {
            throw new NotImplementedException();
        }





        [HttpDelete("{id}")]
        public Task<ServiceResult<string>> DeleteById(string id)
        {


             var entity = _repository.Events.FirstOrDefault(x => x.Id == id);




            if(entity == null)
                return ServiceResult.Empty.SetError("" , 400).To<string>().ToAsync();



            _repository.Events.Remove(entity);
            return ServiceResult.Create<string>(entity.Id).ToAsync();


        }




    }

}