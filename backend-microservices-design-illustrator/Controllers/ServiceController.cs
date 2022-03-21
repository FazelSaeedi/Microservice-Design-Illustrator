using FakeTehranFavaServer.Repositories;
using MH.DDD.Core.Types;
using microservices_design_illustrator.Domain;
using Microsoft.AspNetCore.Mvc;

namespace microservices_design_illustrator.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ServiceController : ControllerBase
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


            if(!_repository.Controllers.Any(x => x.Id == entity.controllerId)) 
                return ServiceResult.Empty.SetError("ControllerNotFound" , 400).To<string>().ToAsync();




            if(_repository.Projects.Any(x => x.Name == entity.Name))
                return ServiceResult.Empty.SetError("ServiceIsExists").To<string>().ToAsync();



            entity.Id = Guid.NewGuid().ToString();
            _repository.Services.Add(entity);
            return ServiceResult.Create<string>(entity.Id).ToAsync();


        }
        




        [HttpGet("GetAll")]
        public Task<ServiceResult<List<ServiceEntity>>> GetAll()
        {
            return ServiceResult.Create<List<ServiceEntity>>(_repository.Services.ToList()).ToAsync();
        }





        [HttpGet("{id}")]
        public Task<ServiceResult<ServiceEntity>> GetById(string id)
        {
            return ServiceResult.Create<ServiceEntity>(_repository.Services.FirstOrDefault(x => x.Id == id)).ToAsync();
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
    }
}