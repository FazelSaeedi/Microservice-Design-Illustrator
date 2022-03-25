import { Component, OnInit , Input } from '@angular/core';
import { ProjectService } from 'src/shared/http-services/project.service';

@Component({
  selector: 'app-project',
  templateUrl: './project.component.html',
  styleUrls: ['./project.component.css']
})
export class ProjectComponent implements OnInit {

  constructor(private ProjectService : ProjectService ) { }

  @Input() data : any[] = [];
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

    });;
  }

}
