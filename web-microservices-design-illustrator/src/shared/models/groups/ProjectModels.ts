
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
