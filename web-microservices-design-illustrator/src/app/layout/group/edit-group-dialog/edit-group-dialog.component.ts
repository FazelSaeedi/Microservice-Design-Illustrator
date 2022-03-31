import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { createGroupDto } from 'src/shared/models/groups/GroupModels';

@Component({
  selector: 'app-edit-group-dialog',
  templateUrl: './edit-group-dialog.component.html',
  styleUrls: ['./edit-group-dialog.component.scss']
})
export class EditGroupDialogComponent implements OnInit {

  myGroup!: FormGroup;
  createGroupDto : createGroupDto = new createGroupDto()
  constructor(private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<EditGroupDialogComponent>) { }

  ngOnInit(): void {
    this.myGroup = this.formBuilder.group({
      name: new FormControl({ value: null}, [Validators.required]),
    });
  }


  createCollectTime() {
    this.dialogRef.close(this.createGroupDto);
  }

}
