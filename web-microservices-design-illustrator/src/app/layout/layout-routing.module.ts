import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GroupComponent } from './group/group.component';
import { LayoutComponent } from './layout.component';

const routes: Routes = [
   {
     path: '' ,
     component : LayoutComponent  ,
     children: [
        {
          path: 'groups',
          component : GroupComponent
        }
      ],
   }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LayoutRoutingModule { }
