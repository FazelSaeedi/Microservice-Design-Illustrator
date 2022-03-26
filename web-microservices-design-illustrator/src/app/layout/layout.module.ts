import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LayoutRoutingModule } from './layout-routing.module';
import { GroupComponent } from './group/group.component';
import { ProjectComponent } from './project/project.component';
import { ProjectDetailComponent } from './project-detail/project-detail.component';
import { GroupProjectComponent } from './group-project/group-project.component';


@NgModule({
  declarations: [
    GroupComponent,
    ProjectComponent,
    ProjectDetailComponent,
    GroupProjectComponent
  ],
  imports: [
    CommonModule,
    LayoutRoutingModule
  ]
})
export class LayoutModule { }
