import { NgModule } from '@angular/core';
import {CommonModule, DatePipe} from '@angular/common';

import { TaskRoutingModule } from './task-routing.module';
import { TaskComponent } from './task.component';
import {SharedModule} from "../shared/shared.module";
import { AddUpdateComponent } from './components/add-update/add-update.component';
import {ReactiveFormsModule} from "@angular/forms";


@NgModule({
  declarations: [
    TaskComponent,
    AddUpdateComponent
  ],
  imports: [
    CommonModule,
    TaskRoutingModule,
    SharedModule,
    ReactiveFormsModule
  ],
  providers:[
    DatePipe
  ]
})
export class TaskModule { }
