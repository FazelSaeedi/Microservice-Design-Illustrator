namespace backend_microservices_design_illustrator.Dtos.ProjectDtos
{
    public class GetAllProjectsDto
    {
        public GetAllProjectsDto(string id, string name, string groupName)
        {
            Id = id;
            Name = name;
            GroupName = groupName;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string GroupName { get; set; }
        
    }
}