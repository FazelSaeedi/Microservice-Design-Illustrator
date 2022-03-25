using backend_microservices_design_illustrator.Dtos.ProjectDtos;
using FakeTehranFavaServer.Repositories;
using MH.DDD.Core.Types;
using microservices_design_illustrator.Domain;
using Microsoft.AspNetCore.Mvc;

namespace microservices_design_illustrator.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
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
                return ServiceResult.Empty.SetError("GroupNotFound" , 404).To<string>().ToAsync();




            if(_repository.Projects.Any(x => x.Name == entity.Name))
                return ServiceResult.Empty.SetError("ProjectIsExists" , 400).To<string>().ToAsync();



            entity.Id = Guid.NewGuid().ToString();
            _repository.Projects.Add(entity);
            return ServiceResult.Create<string>(entity.Id).ToAsync();



        }






        [HttpGet("GetAllGroupProjects/{groupId}")]
        public Task<ServiceResult<List<GetAllGroupProjectsDto>>> GetAll(string groupId)
        {

            if(!_repository.Groups.Any(x => x.Id == groupId))
                 return ServiceResult.Empty.SetError("GroupNotFound" , 400).To<List<GetAllGroupProjectsDto>>().ToAsync();



            var projects = _repository.Projects.Where(x => x.GroupId == groupId ).ToList();

            var getAllProjectsDto = projects.Select(x => new GetAllGroupProjectsDto(x.Id , x.Name)).ToList();
            return ServiceResult.Create<List<GetAllGroupProjectsDto>>(getAllProjectsDto).ToAsync();
        }






        [HttpGet("{id}")]
        public Task<ServiceResult<GetProjectDetailDto>> GetById(string id)
        {

            
            if(!_repository.Projects.Any(x => x.Id == id))
                 return ServiceResult.Empty.SetError("ProjectNotFound" , 400).To<GetProjectDetailDto>().ToAsync();



            var projects = _repository.Projects.FirstOrDefault(x => x.Id == id);  
            var group = _repository.Groups.FirstOrDefault(x => x.Id == projects.GroupId );  
            var controllers = _repository.Controllers.Where(x => x.ProjectId == id).ToList();            
            var pages = _repository.Pages.Where(x => x.ProjectId == id).ToList();            
            var evnts = _repository.Events.Where(x => x.PublisherProjectId == id).ToList();



            var getProjectDetailDto = new GetProjectDetailDto(
                    projects.Id ,
                    projects.Name ,
                    group.Name ,
                    controllers.Select(x => new ProjectControllerDto(x.Id , x.Name , x.servicesId.Count)).ToList(),
                    evnts.Select(x => new ProjectEventDto(x.Id , x.Name)).ToList() ,
                    pages.Select(x => new ProjectPageDto(x.Id , x.Name)).ToList()
                ); 
            

            return ServiceResult.Create<GetProjectDetailDto>(getProjectDetailDto).ToAsync();
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