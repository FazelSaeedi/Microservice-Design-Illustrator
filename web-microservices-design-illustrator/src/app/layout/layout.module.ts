import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LayoutRoutingModule } from './layout-routing.module';
import { GroupComponent } from './group/group.component';
import { ProjectComponent } from './project/project.component';


@NgModule({
  declarations: [
    GroupComponent,
    ProjectComponent
  ],
  imports: [
    CommonModule,
    LayoutRoutingModule
  ]
})
export class LayoutModule { }
