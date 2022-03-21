namespace microservices_design_illustrator.Domain
{
    public class ServiceEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string controllerId { get; set; }
        public string InputDto {get; set;}
        public string OutPutDto {get; set;}
        public List<string> ServiceConsumersId {get; set;}
    }
}