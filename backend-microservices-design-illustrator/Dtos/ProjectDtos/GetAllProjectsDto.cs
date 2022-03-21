namespace backend_microservices_design_illustrator.Dtos.ProjectDtos
{
    public class GetAllProjectsDto
    {
        public GetAllProjectsDto(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        
        
    }
}