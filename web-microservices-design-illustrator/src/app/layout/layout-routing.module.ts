import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ControllerDetailComponent } from './controller-detail/controller-detail.component';
import { EventDetailComponent } from './event-detail/event-detail.component';
import { GroupProjectComponent } from './group-project/group-project.component';
import { GroupComponent } from './group/group.component';
import { LayoutComponent } from './layout.component';
import { PageDetailComponent } from './page-detail/page-detail.component';
import { ProjectDetailComponent } from './project-detail/project-detail.component';
import { ProjectComponent } from './project/project.component';
import { ServiceDetailComponent } from './service-detail/service-detail.component';

const routes: Routes = [
   {
     path: '' ,
     component : LayoutComponent  ,
     children: [
        {
          path: 'groups',
          component : GroupComponent ,
        },
        {
          path: 'groups/:id',
          component : GroupProjectComponent ,
        },
        {
          path: 'project',
          component : ProjectComponent
        },
        {
          path: 'project/:id',
          component : ProjectDetailComponent
        }],
      },
      {
        path: 'controller/:id',
        component : ControllerDetailComponent ,
      },
      {
        path: 'page/:id',
        component : PageDetailComponent ,
      },
      {
        path: 'event/:id',
        component : EventDetailComponent ,
      },
      {
        path: 'service/:id',
        component : ServiceDetailComponent ,
      },
    ];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LayoutRoutingModule { }
