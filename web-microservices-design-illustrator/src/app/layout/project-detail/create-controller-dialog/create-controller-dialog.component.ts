import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { CreateControllerDto } from 'src/shared/models/groups/ProjectModels';

@Component({
  selector: 'app-create-controller-dialog',
  templateUrl: './create-controller-dialog.component.html',
  styleUrls: ['./create-controller-dialog.component.css']
})
export class CreateControllerDialogComponent implements OnInit {

  myGroup!: FormGroup;
  createControllerDto : CreateControllerDto = new CreateControllerDto() ;

  constructor(private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<CreateControllerDialogComponent>) { }

  ngOnInit(): void {
    this.myGroup = this.formBuilder.group({
      name: new FormControl({ value: null}, [Validators.required]),
    });
  }

  createController(){
    this.dialogRef.close(this.createControllerDto);
  }
}
