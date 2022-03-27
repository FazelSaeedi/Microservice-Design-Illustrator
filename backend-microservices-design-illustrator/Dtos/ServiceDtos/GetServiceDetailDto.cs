using backend_microservices_design_illustrator.Dtos.PageDtos;

namespace backend_microservices_design_illustrator.Dtos.ServiceDtos
{
    public class GetServiceDetailDto
    {
        public GetServiceDetailDto(string id, string name, string groupName, string projectName, List<ServiceServiceDto> services, string inputDto, string outputDto)
        {
            Id = id;
            Name = name;
            GroupName = groupName;
            ProjectName = projectName;
            Services = services;
            InputDto = inputDto;
            OutputDto = outputDto;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string GroupName { get; set; }
        public string ProjectName { get; set; }
        public string InputDto { get; set; }
        public string OutputDto { get; set; }
        public List<ServiceServiceDto> Services { get; set; }
    }

    public class ServiceServiceDto : PageServiceDto
    {
        public ServiceServiceDto(string id, string name) : base(id, name)
        {
        }
    }

}