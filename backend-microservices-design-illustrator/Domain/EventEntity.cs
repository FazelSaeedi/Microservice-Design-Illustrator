namespace microservices_design_illustrator.Domain
{
    public class EventEntity
    {
    
        public string Id { get; set; }
        public string Name { get; set; }
        public string PublisherProjectId {get; set; }
        public List<string> SubcriberProjectIds {get; set;}
        public string InputDto {get; set;}

    }
}