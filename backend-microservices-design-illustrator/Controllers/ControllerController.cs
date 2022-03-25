using backend_microservices_design_illustrator.Dtos.ControllerDtos;
using FakeTehranFavaServer.Repositories;
using MH.DDD.Core.Types;
using microservices_design_illustrator.Domain;
using Microsoft.AspNetCore.Mvc;

namespace microservices_design_illustrator.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ControllerController : ControllerBase , IDisposable
    {

        
        private readonly ILogger<ControllerController> _logger;
        private readonly IRepository _repository;



        public ControllerController(ILogger<ControllerController> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }





        [HttpPost("")]
        public  Task<ServiceResult<string>> Create(ControllerEntity entity)
        {


            if(!_repository.Projects.Any(x => x.Id == entity.ProjectId)) 
                return ServiceResult.Empty.SetError("ProjectNotFound" , 400).To<string>().ToAsync();




            if(_repository.Controllers.Any(x => x.Name == entity.Name))
                return ServiceResult.Empty.SetError("ControllerIsExists").To<string>().ToAsync();




            entity.Id = Guid.NewGuid().ToString();
            _repository.Controllers.Add(entity);
            return ServiceResult.Create<string>(entity.Id).ToAsync();


        }






        [HttpGet("GetAll/{projectId}")]
        public Task<ServiceResult<List<ControllerEntity>>> GetAll(string projectId)
        {

            if(!_repository.Controllers.Any(x => x.ProjectId == projectId))
                return ServiceResult.Empty.SetError("ProjectNotFound" , 400).To<List<ControllerEntity>>().ToAsync();
            
            
            return ServiceResult.Create<List<ControllerEntity>>(_repository.Controllers.Where(x => x.ProjectId == projectId ).ToList()).ToAsync();

        }






        [HttpGet("{id}")]
        public Task<ServiceResult<GetControllerDetail>> GetById(string id)
        {
            



            var controller = _repository.Controllers.FirstOrDefault(x => x.Id == id);
            if( controller == null )
                return ServiceResult.Empty.SetError("ControllerNotFound").To<GetControllerDetail>().ToAsync();





            var project = _repository.Projects.FirstOrDefault(x => x.Id == controller.ProjectId);
            if(project == null )
                return ServiceResult.Empty.SetError("ProjectNotFound" , 404).To<GetControllerDetail>().ToAsync();





            var group = _repository.Groups.FirstOrDefault(x => x.Id == project.GroupId);
            if(group == null )
                return ServiceResult.Empty.SetError("GroupNotFound" , 404).To<GetControllerDetail>().ToAsync();




            var services = _repository.Services.Where(x => x.controllerId == id).ToList();



            var getControllerDetail = new GetControllerDetail(
                controller.Id ,
                controller.Name ,
                group.Name ,
                project.Name ,
                services.Select(x => new ControllerServiceDto(x.Id , x.Name)).ToList()
                );


            return ServiceResult.Create<GetControllerDetail>(getControllerDetail).ToAsync();


        }
        




        
        [HttpPut("{id}")]
        public void EditById(string id)
        {
            throw new NotImplementedException();    
        }





        
        [HttpDelete("{id}")]
        public Task<ServiceResult<string>> DeleteById(string id)
        {


            var entity = _repository.Controllers.FirstOrDefault(x => x.Id == id);




            if(entity == null)
                return ServiceResult.Empty.SetError("ControllerNotFound" , 400).To<string>().ToAsync();



            _repository.Controllers.Remove(entity);
            return ServiceResult.Create<string>(entity.Id).ToAsync();
        }




        public void Dispose()
        {
            DbRepo.Save(this._repository);
        }



    }
}