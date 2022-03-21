using FakeTehranFavaServer.Repositories;
using MH.DDD.Core.Types;
using microservices_design_illustrator.Domain;
using Microsoft.AspNetCore.Mvc;

namespace microservices_design_illustrator.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PageController : ControllerBase , IDisposable
    {
        private readonly ILogger<PageController> _logger;
        private readonly IRepository _repository;

        public PageController(ILogger<PageController> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpPost("")]
        public  Task<ServiceResult<string>> Create(PageEntity entity)
        {


            if(!_repository.Projects.Any(x => x.Id == entity.ProjectId)) 
                return ServiceResult.Empty.SetError("ProjectNotFound" , 400).To<string>().ToAsync();




            if(_repository.Pages.Any(x => x.Name == entity.Name))
                return ServiceResult.Empty.SetError("PageIsExists").To<string>().ToAsync();




            entity.Id = Guid.NewGuid().ToString();
            _repository.Pages.Add(entity);
            return ServiceResult.Create<string>(entity.Id).ToAsync();


        }
        

        [HttpGet("GetAll/{projectId}")]
        public Task<ServiceResult<List<PageEntity>>> GetAll(string projectId)
        {

            if(!_repository.Projects.Any(x => x.Id == projectId))
                return ServiceResult.Empty.SetError("ProjectNotFound" , 400).To<List<PageEntity>>().ToAsync();
            
            
            return ServiceResult.Create<List<PageEntity>>(_repository.Pages.Where(x => x.ProjectId == projectId ).ToList()).ToAsync();

        }


        [HttpGet("{id}")]
        public Task<ServiceResult<PageEntity>> GetById(string id)
        {
            return ServiceResult.Create<PageEntity>(_repository.Pages.FirstOrDefault(x => x.Id == id)).ToAsync();
        }
        
        
        [HttpPut("{id}")]
        public void EditById(string id)
        {
            throw new NotImplementedException();
        }



        [HttpDelete("{id}")]
        public Task<ServiceResult<string>> DeleteById(string id)
        {


            var entity = _repository.Pages.FirstOrDefault(x => x.Id == id);




            if(entity == null)
                return ServiceResult.Empty.SetError("PageNotFound" , 400).To<string>().ToAsync();



            _repository.Pages.Remove(entity);
            return ServiceResult.Create<string>(entity.Id).ToAsync();


        }





        public void Dispose()
        {
            DbRepo.Save(this._repository);
        }


    }
}