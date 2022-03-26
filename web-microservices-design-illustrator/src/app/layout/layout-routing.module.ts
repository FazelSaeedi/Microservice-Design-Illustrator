import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GroupProjectComponent } from './group-project/group-project.component';
import { GroupComponent } from './group/group.component';
import { LayoutComponent } from './layout.component';
import { ProjectDetailComponent } from './project-detail/project-detail.component';
import { ProjectComponent } from './project/project.component';

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
          path: 'projects',
          component : ProjectComponent
        },
        {
          path: 'projects/:id',
          component : ProjectDetailComponent
        }
      ],
   }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LayoutRoutingModule { }
