namespace backend_microservices_design_illustrator.Dtos.ControllerDtos
{
    public class GetControllerDetail
    {
        public GetControllerDetail(string id, string name, string groupName, string projectName, List<ControllerServiceDto> services)
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
        public List<ControllerServiceDto> Services { get; set; }

        
    }


    public class ControllerServiceDto
    {
        public ControllerServiceDto(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Id { get; set; }
        public string Name { get; set; }

    }

}