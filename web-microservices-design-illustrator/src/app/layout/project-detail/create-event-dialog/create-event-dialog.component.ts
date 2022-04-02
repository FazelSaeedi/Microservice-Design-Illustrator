import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { CreateEventrDto } from 'src/shared/models/groups/ProjectModels';

@Component({
  selector: 'app-create-event-dialog',
  templateUrl: './create-event-dialog.component.html',
  styleUrls: ['./create-event-dialog.component.css']
})
export class CreateEventDialogComponent implements OnInit {


  myGroup!: FormGroup;
  createEventDto : CreateEventrDto = new CreateEventrDto() ;

  constructor(private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<CreateEventDialogComponent>) { }

  ngOnInit(): void {
    this.myGroup = this.formBuilder.group({
      name: new FormControl({ value: null}, [Validators.required]),
    });
  }

  createEvent(){
    this.dialogRef.close(this.createEventDto);
  }

}
