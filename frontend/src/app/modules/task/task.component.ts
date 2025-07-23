import {Component, OnDestroy, OnInit} from '@angular/core';
import {TaskInfo} from "../../models/task";
import {ErrorHandlerService} from "../shared/services/error-handler/error-handler.service";
import {TaskService} from "../shared/services/task/task.service";
import {Subscription} from "rxjs";
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AddUpdateComponent } from './components/add-update/add-update.component';

@Component({
  selector: 'app-task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.css']
})
export class TaskComponent implements OnInit, OnDestroy {

  tasks: TaskInfo[] = [];
  title: string = "";
  body: string = "";
  errMsg: string = "";
  subscriptions: Subscription[] = [];

  constructor(private taskService: TaskService,
              private errorHandler: ErrorHandlerService,
              private popupModal: NgbModal) { }

  ngOnDestroy() {
    this.subscriptions.forEach(s => s.unsubscribe());
  }

  ngOnInit(): void {
    this.getAllTasks();
  }

  updateStatus(id: number | undefined, isCompleted : boolean | undefined): void{
    this.subscriptions.push(
      this.taskService.updateTaskStatus(id!, isCompleted!).subscribe(
        value => {
        },
        err => {
          this.errorHandler.handleError(err);
          this.errMsg = this.errorHandler.errMsg;
          this.title = "ERROR MESSAGE";
          $("#errorModal").show();
        }
      )
    )
  };

  openEditTask(id: number | undefined) : void{
    const taskEditForm = this.popupModal.open(AddUpdateComponent,{
      windowClass: "dialogue",
      size: "lg"
    });

    taskEditForm.componentInstance.id = id;
    taskEditForm.result.then((isReload: boolean) => {
      if(isReload){
        this.getAllTasks();
      }
    }, (reason) => {
    });
  };

  openAddTask() : void{
    const taskAddNew = this.popupModal.open(AddUpdateComponent,{
      windowClass: "dialogue",
      size: "lg"
    });

    taskAddNew.componentInstance.id = undefined;
    taskAddNew.result.then((isReload: boolean) => {
      if(isReload){
        this.getAllTasks();
      }
    }, (reason) => {
    });
  }

  getAllTasks(): void {
    this.subscriptions.push(
      this.taskService.getTasks().subscribe(
        value => this.tasks = value,
        err => {
          this.errorHandler.handleError(err);
          this.errMsg = this.errorHandler.errMsg;
          this.title = "ERROR MESSAGE";
          $("#errorModal").show();
        }
      )
    );
    $("#successModal").hide();
  }

  delete(id: number | undefined): void {
    this.subscriptions.push(
      this.taskService.deleteTask(id!).subscribe(
        value => {
          this.title = "DELETE MESSAGE";
          this.body = "Deleting Successfully";
          $("#successModal").show();
        },
        err => {
          this.errorHandler.handleError(err);
          this.errMsg = this.errorHandler.errMsg;
          this.title = "ERROR MESSAGE";
          $("#errorModal").show();
        }
      )
    );
  }
}
