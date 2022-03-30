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
import { ServiceDetailComponent } from './service-detail/service-detail.component';




import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import {MatMenuModule} from '@angular/material/menu';
import {MatButtonModule} from '@angular/material/button'
import {MatIconModule} from '@angular/material/icon';
import {MatCardModule} from '@angular/material/card';
import {MatTabsModule} from '@angular/material/tabs';
import { MatDatepickerModule } from "@angular/material/datepicker";
import { MatDialogModule } from "@angular/material/dialog";
import { MatInputModule } from "@angular/material/input";
import { MatListModule } from "@angular/material/list";
import { MatPaginatorModule } from "@angular/material/paginator";
import { MatProgressSpinnerModule } from "@angular/material/progress-spinner";
import { MatSelectModule } from "@angular/material/select";
import { MatSidenavModule } from "@angular/material/sidenav";
import { MatSortModule } from "@angular/material/sort";
import { MatTableModule } from "@angular/material/table";
import { MatToolbarModule } from "@angular/material/toolbar";
import {HttpClientModule} from "@angular/common/http";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import { DialogComponent } from '../dialog/dialog.component';



@NgModule({
  declarations: [
    GroupComponent,
    ProjectComponent,
    ProjectDetailComponent,
    GroupProjectComponent,
    ControllerDetailComponent,
    PageDetailComponent,
    EventDetailComponent,
    ServiceDetailComponent,
    DialogComponent
  ],
  imports: [
    CommonModule,
    LayoutRoutingModule,
    MatMenuModule ,
    MatButtonModule ,
    MatIconModule ,
    MatCardModule ,
    MatTabsModule ,
    MatDatepickerModule ,
    MatDialogModule ,
    MatInputModule ,
    MatListModule ,
    MatPaginatorModule ,
    MatProgressSpinnerModule ,
    MatSelectModule ,
    MatSidenavModule ,
    MatSortModule ,
    MatTableModule ,
    MatToolbarModule ,
    HttpClientModule ,
    ReactiveFormsModule ,
    FormsModule ,

  ]
})
export class LayoutModule { }
