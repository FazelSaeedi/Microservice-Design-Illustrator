
export class GetAllProjectDto {
  id! : string;
  name! : string;
  group! : GroupProjectDto;
}


export class GroupProjectDto{
  id! : string ;
  name! : string ;
}


export class CreateProjectDto{
  name! : string ;
  groupId! : string
}

export class CreateControllerDto{
  name! : string ;
  projectId! : string ;
}

export class CreateEventrDto{

  name! : string ;
  publisherProjectId! : string ;
  inputDto! : string ;
}
