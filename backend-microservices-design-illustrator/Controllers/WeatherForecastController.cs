using FakeTehranFavaServer.Repositories;
using microservices_design_illustrator.Domain;
using Microsoft.AspNetCore.Mvc;

namespace microservices_design_illustrator.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IRepository repository;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IRepository repository)
    {
        _logger = logger;
        this.repository = repository;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpGet("test")]
    public void test()
    {


        var Group = new GroupEntity()
        {
            Id = Guid.NewGuid().ToString()  ,
            Name = "Booxell"
        };



        var project = new ProjectEntity()
        {
            Id = Guid.NewGuid().ToString()  ,
            Name = "CustomerApi" ,
            GroupId = Group.Id
        };



        var project1 = new ProjectEntity()
        {
            Id = Guid.NewGuid().ToString()  ,
            Name = "web-client-customer" ,
            GroupId = Group.Id
        };



        var controller = new ControllerEntity()
        {
            servicesId =  new List<string>(){} ,
            Id = Guid.NewGuid().ToString()  ,
            Name = "CustomerEntity" ,
            ProjectId = project.Id  
        };



        var service = new ServiceEntity()
        {
            Id = Guid.NewGuid().ToString()  ,
            Name = "Register" ,
            InputDto = "" ,
            OutPutDto = "" , 
            ServiceConsumersId =  new List<string>(){} 
        };


        
        var service1 = new ServiceEntity()
        {
            Id = Guid.NewGuid().ToString()  ,
            Name = "GetAll" ,
            InputDto = "" ,
            OutPutDto = "" ,
            ServiceConsumersId =  new List<string>(){ service.Id } 
        };


        var page = new PageEntity()
        {
            Id = Guid.NewGuid().ToString()  ,
            Name = "Layout" ,
            ProjectId = project1.Id ,
            ServiceIds = new List<string>(){ service.Id  , service1.Id }
        };

        var @event = new EventEntity()
        {
            Id = Guid.NewGuid().ToString()  ,
            Name = "TestCreatedEvent" ,
            InputDto = "" ,
            PublisherProjectId = project.Id ,
            SubcriberProjectIds = new List<string>{ project1.Id } ,
        };



        controller.servicesId.Add(service1.Id);
        controller.servicesId.Add(service.Id);


        repository.Groups.Add(Group);
        repository.Projects.Add(project);
        repository.Projects.Add(project1);
        repository.Controllers.Add(controller);
        repository.Services.Add(service);
        repository.Services.Add(service1);
        repository.Pages.Add(page);
        repository.Events.Add(@event);


        DbRepo.Save(repository);


    }
}
