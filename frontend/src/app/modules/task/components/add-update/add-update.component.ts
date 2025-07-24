import {Component, Input, OnDestroy, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {ActivatedRoute, Router} from "@angular/router";
import {ErrorHandlerService} from "../../../shared/services/error-handler/error-handler.service";
import {TaskInfo} from "../../../../models/task";
import {TaskService} from "../../../shared/services/task/task.service";
import {Subscription, throwError} from "rxjs";
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-add-update',
  templateUrl: './add-update.component.html',
  styleUrls: ['./add-update.component.css']
})
export class AddUpdateComponent implements OnInit, OnDestroy {

  taskForm: FormGroup;
  title: string = "";
  isReload: boolean = false;
  body: string = "";
  errorMsg: string = "";
  @Input()
  id: string = "";
  task: TaskInfo = {};
  validationMessages: any = {
    "title": {
      "required": "Required"
    }
  };
  formErrors: any = {
    "title": ""
  };
  subscriptions: Subscription[] = [];

  constructor(private taskService: TaskService,
              private formBuilder: FormBuilder,
              private route: ActivatedRoute,
              private errorHandler: ErrorHandlerService,
              public activeModal: NgbActiveModal,
              private router: Router) {
    this.taskForm = this.formBuilder.group({
      id: [''],
      title: ['', Validators.required],
      description: [''],
    });
  }

  ngOnDestroy() {
    this.subscriptions.forEach(s => s.unsubscribe());
  }

  ngOnInit(): void {
    this.subscriptions.push(
      this.route.params.subscribe(
        value => {
          if (this.id === undefined) {
            this.title = "ADD TASK";
          } else {
            this.title = "UPDATE TASK";
            this.taskService.getTask(this.id).subscribe(
              value => {
                this.task = value;
                this.taskForm.setValue(this.task);
              },
              error => {
                this.errorHandler.handleError(error);
                this.errorMsg = this.errorHandler.errMsg;
              }
            );
          }
        }
      )
    );

    this.subscriptions.push(
      this.taskForm.valueChanges.subscribe(
        data => this.checkValidation()
      )
    );
  }

  checkValidation(): void {
    Object.keys(this.taskForm.controls).forEach(value => {
        this.formErrors[value] = "";
        let control = this.taskForm.get(value);
        if (control?.invalid && control?.touched) {
          let messages = this.validationMessages[value];
          for (let errorKey in control.errors) {
            this.formErrors[value] = messages[errorKey];
          }
        }
      }
    );
  }

  submit(): void {
    if (this.taskForm.valid) {
      this.task = this.taskForm.value;
      if (this.id === undefined) {
        this.task.id = '';
        this.subscriptions.push(
          this.taskService.createTask(this.task).subscribe(
            data => {
              this.closeModal(true);
            },
            error => {
              this.errorHandler.handleError(error);
              this.errorMsg = this.errorHandler.errMsg;
              this.title = "ERROR MESSAGE";
              $("#errorModal").show();
            }
          )
        );
      } else {
        this.subscriptions.push(
          this.taskService.updateTask(this.id, this.task).subscribe(
            data => {
              this.closeModal(true);
            },
            error => {
              this.errorHandler.handleError(error);
              this.errorMsg = this.errorHandler.errMsg;
              this.title = "ERROR MESSAGE";
              $("#errorModal").show();
            }
          )
        );
      }
    }
  }

  close(): void {
    this.closeModal(false);
  }

  closeModal(sendData: boolean | undefined):void {
    this.activeModal.close(sendData);
  }
}
