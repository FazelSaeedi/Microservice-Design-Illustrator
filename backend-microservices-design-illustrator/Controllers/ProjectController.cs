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






        [HttpGet("GetAll")]
        public Task<ServiceResult<List<GetAllProjectsDto>>> GetAll()
        {
            var projects = _repository.Projects.ToList();
            var groups = _repository.Groups.ToList();


            var dto = projects.Select(x => new GetAllProjectsDto(x.Id , x.Name , new ProjectGroupDto(x.GroupId))).ToList();

            dto.ForEach(x => 
            {
                var group = _repository.Groups.FirstOrDefault(d => d.Id == x.Group.id);
                x.Group.Name = group.Name ;
            });

            return ServiceResult.Create<List<GetAllProjectsDto>>(dto).ToAsync();
        }



        [HttpGet("GetAllGroupProjects/{groupId}")]
        public Task<ServiceResult<List<GetAllGroupProjectsDto>>> GetAllGroupProjects(string groupId)
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
                    controllers.Count == 0 ? new List<ProjectControllerDto>() : controllers.Select(x => new ProjectControllerDto(x.Id , x.Name , x.servicesId == null ? 0 : x.servicesId.Count)).ToList(),
                    evnts.Count == 0 ? new List<ProjectEventDto>() : evnts.Select(x => new ProjectEventDto(x.Id , x.Name)).ToList() ,
                    pages.Count == 0 ? new List<ProjectPageDto>() : pages.Select(x => new ProjectPageDto(x.Id , x.Name)).ToList()
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



            if(_repository.Controllers.Any(x => x.ProjectId == id))
                return ServiceResult.Empty.SetError("ProjectHasController" , 400).To<string>().ToAsync();



            if(_repository.Events.Any(x => x.PublisherProjectId == id))
                return ServiceResult.Empty.SetError("ProjectHasEvents" , 400).To<string>().ToAsync();



            if(_repository.Pages.Any(x => x.ProjectId == id))
                return ServiceResult.Empty.SetError("ProjectHasPages" , 400).To<string>().ToAsync();



            if(entity == null)
                return ServiceResult.Empty.SetError("ProjectNotFound" , 400).To<string>().ToAsync();


            _repository.Projects.Remove(entity);
            return ServiceResult.Create<string>(entity.Id).ToAsync();

        }





        public void Dispose()
        {
            DbRepo.Save(this._repository);
        }




    }
}