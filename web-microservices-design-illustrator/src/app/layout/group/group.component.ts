import { Component, OnInit , Input } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { TServiceResult } from 'src/shared/helper/t-service-result';
import { createGroupDto, GetAllGroupDto } from 'src/shared/models/groups/GroupModels';
import { GroupService } from '../../../shared/http-services/group.service'
import { EditGroupDialogComponent } from './edit-group-dialog/edit-group-dialog.component';
@Component({
  selector: 'app-group',
  templateUrl: './group.component.html',
  styleUrls: ['./group.component.css']
})

export class GroupComponent implements OnInit {

  constructor(private GroupService : GroupService , private router: Router, private activatedRoute: ActivatedRoute ,    public dialog: MatDialog,
    ) { }

  @Input() data : GetAllGroupDto[] = [];
  @Input() header : any[] = [];
  ShowModal : boolean = false ;


  ngOnInit(): void {

    this.activatedRoute.params.subscribe(param => {
      console.log(param['id']);
    })

    console.log(this.router.url)

    this.header.push(
      {key : 'id' , value : 'id'} ,
      {key : 'name' , value : 'name'},
      {key : 'delete' , value : 'delete'},
    );

    this.GroupService.getAllGroups().subscribe( (response : any) => {
      this.data = response.result
    });;
  }


  addNewGroup() : void{
    const dialogRef = this.dialog.open(EditGroupDialogComponent, {
      width: '600px',
      height: '550px',
      disableClose: true,
    });


    dialogRef.afterClosed().subscribe( (res : createGroupDto) => {
       console.log(res);

       this.GroupService.addGroup(res).subscribe(x =>{
         console.log(x);
         this.data.push({id : x.result , name : res.name});
       });

    });
  }


  deleteCategory(item : GetAllGroupDto){
       this.GroupService.deleteGroup(item.id).subscribe( (res : TServiceResult<string>) => {
           if(res.hasError == true)
             alert(res.error.message)
          else
            this.GroupService.getAllGroups().subscribe( (response : any) => {
              this.data = response.result
            });
       });
    }

  countChangedHandler(count: number) {
    console.log('event called');

    console.log(count);
  }

  OnChangeModal() : void {
    this.ShowModal = !this.ShowModal ;
 }

}
