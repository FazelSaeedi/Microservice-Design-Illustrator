namespace backend_microservices_design_illustrator.Dtos.ProjectDtos
{
    public class GetAllProjectsDto
    {
        public GetAllProjectsDto(string id, string name, ProjectGroupDto projectGroupDto)
        {
            Id = id;
            Name = name;
            this.Group = projectGroupDto;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public ProjectGroupDto Group {get; set;}
    }

    public class ProjectGroupDto
    {
        public ProjectGroupDto(string id)
        {
            this.id = id;
        }

        public string id { get; set; }
        public string Name { get; set; }
    }
}