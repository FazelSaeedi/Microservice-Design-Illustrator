using backend_microservices_design_illustrator.Dtos.EventDtos;
using backend_microservices_design_illustrator.Dtos.PageDtos;
using FakeTehranFavaServer.Repositories;
using MH.DDD.Core.Types;
using microservices_design_illustrator.Domain;
using Microsoft.AspNetCore.Mvc;

namespace microservices_design_illustrator.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase , IDisposable
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
            


            if(!_repository.Projects.Any(x => x.Id == entity.PublisherProjectId))
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
        public Task<ServiceResult<GetEventDto>> GetById(string id)
        {



                var @event = _repository.Events.FirstOrDefault(x => x.Id == id);
                if( @event == null )
                    return ServiceResult.Empty.SetError("EventNotFound").To<GetEventDto>().ToAsync();





                var project = _repository.Projects.FirstOrDefault(x => x.Id == @event.PublisherProjectId);
                if(project == null )
                    return ServiceResult.Empty.SetError("ProjectNotFound" , 404).To<GetEventDto>().ToAsync();





                var group = _repository.Groups.FirstOrDefault(x => x.Id == project.GroupId);
                if(group == null )
                    return ServiceResult.Empty.SetError("GroupNotFound" , 404).To<GetEventDto>().ToAsync();



                List<ProjectEntity> PublisherProjects = null ;
                if(@event.SubcriberProjectIds != null)
                {
                    PublisherProjects =  _repository.Projects.Where(x => @event.PublisherProjectId.Contains(x.Id)).ToList();   
                }



                var getEventDetail = new GetEventDto(
                    @event.Id ,
                    @event.Name ,
                    group.Name ,
                    project.Name ,
                    PublisherProjects == null ? null : PublisherProjects.Select(x => new EventProjectDto(x.Id , x.Name)).ToList()
                    );


                return ServiceResult.Create<GetEventDto>(getEventDetail).ToAsync();  
        
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





        public void Dispose()
        {
            DbRepo.Save(this._repository);
        }




    }

}