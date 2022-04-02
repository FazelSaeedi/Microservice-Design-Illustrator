import { Component, OnInit , Input } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { TServiceResult } from 'src/shared/helper/t-service-result';
import { ProjectService } from 'src/shared/http-services/project.service';
import { CreateProjectDto, GetAllProjectDto } from 'src/shared/models/groups/ProjectModels';
import { CreateProjectDialogComponent } from './create-project-dialog/create-project-dialog.component';

@Component({
  selector: 'app-project',
  templateUrl: './project.component.html',
  styleUrls: ['./project.component.css']
})
export class ProjectComponent implements OnInit {

  constructor(private ProjectService : ProjectService ,  public dialog: MatDialog) { }

  @Input() data : GetAllProjectDto[] = [];
  @Input() header : any[] = [];

  ngOnInit(): void {

    this.header.push(
      {key : 'id' , value : 'id'} ,
      {key : 'name' , value : 'name'},
      {key : 'name' , value : 'groupName'},
    );


    this.ProjectService.getAllProjects().subscribe( (response : any) => {
      this.data = response.result
      console.log(response);
    });
  }


  deleteProject(item : GetAllProjectDto){
      console.log(item);

      this.ProjectService.deleteProject(item.id).subscribe( (res) =>{
        if(res.hasError == true)
        alert(res.error.message)
     else
       this.ProjectService.getAllProjects().subscribe( (response : any) => {
         this.data = response.result
       });
      });
    }

  addNewProject(){
    const dialogRef = this.dialog.open(CreateProjectDialogComponent, {
      width: '600px',
      height: '550px',
      disableClose: true,
    });


  dialogRef.afterClosed().subscribe( (res : CreateProjectDto) => {
    console.log(res);

    this.ProjectService.addProject(res).subscribe((res : TServiceResult<string>) =>{
      if(res.hasError == true)
        alert(res.error.message)
      else
        this.ProjectService.getAllProjects().subscribe( (response : any) => {
        this.data = response.result
       });
    });

  });
  }
}
