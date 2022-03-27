using backend_microservices_design_illustrator.Dtos.EventDtos;
using backend_microservices_design_illustrator.Dtos.ServiceDtos;
using FakeTehranFavaServer.Repositories;
using MH.DDD.Core.Types;
using microservices_design_illustrator.Domain;
using Microsoft.AspNetCore.Mvc;

namespace microservices_design_illustrator.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ServiceController : ControllerBase , IDisposable
    {



        private readonly ILogger<ServiceController> _logger;
        private readonly IRepository _repository;




        public ServiceController(ILogger<ServiceController> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }




        [HttpPost("")]
        public Task<ServiceResult<string>> Create(ServiceEntity entity)
        {

            
            var controller = _repository.Controllers.FirstOrDefault(x => x.Id == entity.controllerId);



            if( controller == null ) 
                return ServiceResult.Empty.SetError("ControllerNotFound" , 400).To<string>().ToAsync();




            if(_repository.Services.Any(x => x.Name == entity.Name))
                return ServiceResult.Empty.SetError("ServiceIsExists").To<string>().ToAsync();



            entity.Id = Guid.NewGuid().ToString();
            _repository.Services.Add(entity);
            controller.servicesId = new List<string>();
            controller.servicesId.Add(entity.Id);
            return ServiceResult.Create<string>(entity.Id).ToAsync();


        }
        




        [HttpGet("GetAll")]
        public Task<ServiceResult<List<ServiceEntity>>> GetAll()
        {
            return ServiceResult.Create<List<ServiceEntity>>(_repository.Services.ToList()).ToAsync();
        }





        [HttpGet("{id}")]
        public Task<ServiceResult<GetServiceDetailDto>> GetById(string id)
        {


            var service = _repository.Services.FirstOrDefault(x => x.Id == id);
            if( service == null )
                return ServiceResult.Empty.SetError("ServiceNotFound").To<GetServiceDetailDto>().ToAsync();




            var controller = _repository.Controllers.FirstOrDefault(x => x.Id == service.controllerId);
            if(controller == null )
                return ServiceResult.Empty.SetError("ControllerNotFound" , 404).To<GetServiceDetailDto>().ToAsync();




            var project = _repository.Projects.FirstOrDefault(x => x.Id == controller.ProjectId );
            if(project == null )
                return ServiceResult.Empty.SetError("ProjectNotFound" , 404).To<GetServiceDetailDto>().ToAsync();




            var group = _repository.Groups.FirstOrDefault(x => x.Id == project.GroupId);
            if(group == null )
                return ServiceResult.Empty.SetError("GroupNotFound" , 404).To<GetServiceDetailDto>().ToAsync();




            List<ServiceEntity> serviceEntity = null ;
            if(service.ServiceConsumersId != null)
            {
                serviceEntity =  _repository.Services.Where(x => service.ServiceConsumersId.Contains(x.Id)).ToList();   
            }



            var getEventDetail = new GetServiceDetailDto(
                service.Id ,
                service.Name ,
                group.Name ,
                project.Name ,
                serviceEntity == null ? null : serviceEntity.Select(x => new ServiceServiceDto(x.Id , x.Name)).ToList() ,
                service.InputDto ,
                service.OutPutDto
                );


            return ServiceResult.Create<GetServiceDetailDto>(getEventDetail).ToAsync();  
        }
        




        [HttpPut("{id}")]
        public void EditById(string id)
        {
            throw new NotImplementedException();
        }





        [HttpDelete("{id}")]
        public Task<ServiceResult<string>> DeleteById(string id)
        {


            var entity = _repository.Services.FirstOrDefault(x => x.Id == id);




            if(entity == null)
                return ServiceResult.Empty.SetError("" , 400).To<string>().ToAsync();



            _repository.Services.Remove(entity);
            return ServiceResult.Create<string>(entity.Id).ToAsync();

        }




        public void Dispose()
        {
            DbRepo.Save(this._repository);
        }



    }
}