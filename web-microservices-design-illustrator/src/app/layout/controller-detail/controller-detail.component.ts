import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ControllerService } from 'src/shared/http-services/controller.service';

@Component({
  selector: 'app-controller-detail',
  templateUrl: './controller-detail.component.html',
  styleUrls: ['./controller-detail.component.css']
})
export class ControllerDetailComponent implements OnInit {

  constructor(private controllerService : ControllerService , private activatedRoute: ActivatedRoute ) { }


  controllerId : any ;
  data : any ;
  header : any[] = [
    {key : 'id' , value : 'id'} ,
    {key : 'name' , value : 'name'},
];

  ngOnInit(): void {
    // getControllerDetail


    this.activatedRoute.params.subscribe(param => {
      //console.log(param['id']);
      this.controllerId = param['id'];
    })

    this.controllerService.getControllerDetail(this.controllerId).subscribe( (response : any) => {
      console.log(response);
      this.data = response.result;
    });


  }

}
