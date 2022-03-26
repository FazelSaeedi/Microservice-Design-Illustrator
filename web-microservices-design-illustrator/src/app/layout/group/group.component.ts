import { Component, OnInit , Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { GroupService } from '../../../shared/http-services/group.service'
@Component({
  selector: 'app-group',
  templateUrl: './group.component.html',
  styleUrls: ['./group.component.css']
})

export class GroupComponent implements OnInit {

  constructor(private GroupService : GroupService , private router: Router, private activatedRoute: ActivatedRoute ) { }

  @Input() data : any[] = [];
  @Input() header : any[] = [];


  ngOnInit(): void {

    

    this.activatedRoute.params.subscribe(param => {
      console.log(param['id']);
    })

    console.log(this.router.url)

    this.header.push(
      {key : 'id' , value : 'id'} ,
      {key : 'name' , value : 'name'},
    );

    this.GroupService.getAllGroups().subscribe( (response : any) => {
      this.data = response.result
    });;


  }

}
