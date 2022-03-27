import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ServiceService } from 'src/shared/http-services/service.service';

@Component({
  selector: 'app-service-detail',
  templateUrl: './service-detail.component.html',
  styleUrls: ['./service-detail.component.css']
})
export class ServiceDetailComponent implements OnInit {

  constructor(private serviceService : ServiceService , private activatedRoute: ActivatedRoute ) { }


  serviceId : any ;
  data : any ;
  header : any[] = [
    {key : 'id' , value : 'id'} ,
    {key : 'name' , value : 'name'},
  ];
  ngOnInit(): void {

    this.activatedRoute.params.subscribe(param => {
      //console.log(param['id']);
      this.serviceId = param['id'];
    })

    this.serviceService.getServiceDetail(this.serviceId).subscribe( (response : any) => {
      console.log(response);
      this.data = response.result;
    });


  }

}
