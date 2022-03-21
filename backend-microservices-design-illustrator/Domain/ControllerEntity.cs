namespace microservices_design_illustrator.Domain
{
    public class ControllerEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ProjectId {get ; set;}
        public List<string> servicesId {get ; set;}
    }
}