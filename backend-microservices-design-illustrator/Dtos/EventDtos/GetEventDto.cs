using backend_microservices_design_illustrator.Dtos.PageDtos;

namespace backend_microservices_design_illustrator.Dtos.EventDtos
{
    public class GetEventDto
    {
        public GetEventDto(string id, string name, string groupName, string projectName, List<EventProjectDto> services)
        {
            Id = id;
            Name = name;
            GroupName = groupName;
            ProjectName = projectName;
            Services = services;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string GroupName { get; set; }
        public string ProjectName { get; set; }
        public List<EventProjectDto> Services { get; set; }
    }

    public class EventProjectDto : PageServiceDto
    {
        public EventProjectDto(string id, string name) : base(id, name)
        {
        }
    }
}