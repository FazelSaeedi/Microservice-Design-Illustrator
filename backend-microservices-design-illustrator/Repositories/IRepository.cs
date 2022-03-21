using System.Text.RegularExpressions;
using System.Collections.Generic;
using microservices_design_illustrator.Domain;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FakeTehranFavaServer.Repositories
{
    public interface IRepository
    {

        DbSetList<ProjectEntity> Projects { get; set; }
        DbSetList<GroupEntity> Groups { get; set; }
        DbSetList<ControllerEntity> Controllers { get; set; }
        DbSetList<PageEntity> Pages { get; set; }
        DbSetList<ServiceEntity> Services { get; set; }
        DbSetList<EventEntity> Events { get; set; }

    }
}