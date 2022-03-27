using backend_microservices_design_illustrator.Dtos.ControllerDtos;

namespace backend_microservices_design_illustrator.Dtos.PageDtos
{
    public class GetPageDetail
    {
        public GetPageDetail(string id, string name, string groupName, string projectName, List<PageServiceDto> services)
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
        public List<PageServiceDto> Services { get; set; }

    }


    public class PageServiceDto : ControllerServiceDto
    {
        public PageServiceDto(string id, string name) : base(id, name)
        {
        }
    }
}