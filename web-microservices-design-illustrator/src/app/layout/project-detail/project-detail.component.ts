import { Component, OnInit ,  } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProjectService } from 'src/shared/http-services/project.service';

@Component({
  selector: 'app-project-detail',
  templateUrl: './project-detail.component.html',
  styleUrls: ['./project-detail.component.css']
})
export class ProjectDetailComponent implements OnInit {

  constructor(private projectService : ProjectService , private activatedRoute: ActivatedRoute ) { }
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




}
