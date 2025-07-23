import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TaskComponent } from './task.component';
import {AddUpdateComponent} from "./components/add-update/add-update.component";

const routes: Routes = [
  { path: "", component: TaskComponent },
  { path: "add", component: AddUpdateComponent },
  { path: "detail/:id", component: AddUpdateComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TaskRoutingModule { }
