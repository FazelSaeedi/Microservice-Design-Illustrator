import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LayoutRoutingModule } from './layout-routing.module';
import { GroupComponent } from './group/group.component';
import { ProjectComponent } from './project/project.component';
import { ProjectDetailComponent } from './project-detail/project-detail.component';
import { GroupProjectComponent } from './group-project/group-project.component';
import { ControllerDetailComponent } from './controller-detail/controller-detail.component';
import { PageDetailComponent } from './page-detail/page-detail.component';
import { EventDetailComponent } from './event-detail/event-detail.component';


@NgModule({
  declarations: [
    GroupComponent,
    ProjectComponent,
    ProjectDetailComponent,
    GroupProjectComponent,
    ControllerDetailComponent,
    PageDetailComponent,
    EventDetailComponent
  ],
  imports: [
    CommonModule,
    LayoutRoutingModule
  ]
})
export class LayoutModule { }
