namespace backend_microservices_design_illustrator.Dtos.ProjectDtos
{
    public class GetProjectDetailDto
    {
        public GetProjectDetailDto(string id, string name, string groupName, List<ProjectControllerDto> controllers, List<ProjectEventDto> events, List<ProjectPageDto> pages)
        {
            Id = id;
            Name = name;
            GroupName = groupName;
            Controllers = controllers;
            Events = events;
            Pages = pages;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string GroupName { get; set; }
        

        public List<ProjectControllerDto> Controllers { get; set; }
        public List<ProjectEventDto> Events { get; set; }
        public List<ProjectPageDto> Pages { get; set; }

        
           
    }



    public class ProjectControllerDto
    {
        public ProjectControllerDto(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Id { get; set; }
        public string Name { get; set; }

    }
    

    public class ProjectPageDto
    {
        public ProjectPageDto(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Id { get; set; }
        public string Name { get; set; }

    }
    

    public class ProjectEventDto
    {
        public ProjectEventDto(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        
    }


}