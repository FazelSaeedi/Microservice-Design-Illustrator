import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ControllerService } from 'src/shared/http-services/controller.service';
import { PageService } from 'src/shared/http-services/page.service';

@Component({
  selector: 'app-page-detail',
  templateUrl: './page-detail.component.html',
  styleUrls: ['./page-detail.component.css']
})
export class PageDetailComponent implements OnInit {


  PageId : any ;
  data : any ;
  header : any[] = [
    {key : 'id' , value : 'id'} ,
    {key : 'name' , value : 'name'},
  ];

  constructor(private pageService : PageService , private activatedRoute: ActivatedRoute ) { }

  ngOnInit(): void {


    this.activatedRoute.params.subscribe(param => {
      //console.log(param['id']);
      this.PageId = param['id'];
    })

    this.pageService.getPageDetail(this.PageId).subscribe( (response : any) => {
      console.log(response);
      this.data = response.result;
    });


  }

}
