import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { CreateProjectDto } from 'src/shared/models/groups/ProjectModels';

@Component({
  selector: 'app-create-project-dialog',
  templateUrl: './create-project-dialog.component.html',
  styleUrls: ['./create-project-dialog.component.css']
})
export class CreateProjectDialogComponent implements OnInit {

  myGroup!: FormGroup;
  createGroupDto : CreateProjectDto = new CreateProjectDto()
  constructor(private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<CreateProjectDialogComponent>) { }

  ngOnInit(): void {
    this.myGroup = this.formBuilder.group({
      projectName: new FormControl({ value: null}, [Validators.required]),
      groupName: new FormControl({ value: null}, [Validators.required]),
    });
  }


  createProject() {
    this.dialogRef.close(this.createGroupDto);
  }


}
