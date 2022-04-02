import { Component, OnInit ,  } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { ControllerService } from 'src/shared/http-services/controller.service';
import { ProjectService } from 'src/shared/http-services/project.service';
import { CreateControllerDto } from 'src/shared/models/groups/ProjectModels';
import { CreateControllerDialogComponent } from './create-controller-dialog/create-controller-dialog.component';

@Component({
  selector: 'app-project-detail',
  templateUrl: './project-detail.component.html',
  styleUrls: ['./project-detail.component.css']
})
export class ProjectDetailComponent implements OnInit {

  constructor(private controllerService : ControllerService , private projectService : ProjectService , private activatedRoute: ActivatedRoute ,  public dialog: MatDialog) { }
  projectId : string = '' ;
  data : any ;



  eventHeaders : any[] = [
      {key : 'id' , value : 'id'} ,
      {key : 'name' , value : 'name'},
  ];



  controllertHeaders : any[] = [
    {key : 'id' , value : 'id'} ,
    {key : 'name' , value : 'name'},
    {key : 'serviceCount' , value : 'serviceCount'},
  ] ;



  pagetHeaders : any[] = [
    {key : 'id' , value : 'id'} ,
    {key : 'name' , value : 'name'},
  ] ;



  ngOnInit(): void {


    this.activatedRoute.params.subscribe(param => {
      //console.log(param['id']);
      this.projectId = param['id'];
    })

    this.projectService.getProjectDetails(this.projectId).subscribe( (response : any) => {
      console.log(response);
      this.data = response.result;
    });




  }

  addController()
  {
    const dialogRef = this.dialog.open(CreateControllerDialogComponent, {
      width: '600px',
      height: '550px',
      disableClose: true,
    });


    dialogRef.afterClosed().subscribe( (res : CreateControllerDto) => {
       console.log(res);
       res.projectId = this.projectId ;
       this.controllerService.addController(res).subscribe( (res : any )=>{

        if(res.hasError == true)
          alert(res.error.message)
        else
          this.projectService.getProjectDetails(this.projectId).subscribe( (response : any) => {
            console.log(response);
            this.data = response.result;
          });
       });

    });
  }

  addEvent()
  {

  }

  addPage()
  {

  }


}
