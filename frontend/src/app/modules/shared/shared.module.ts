import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {NotFoundComponent} from "./components/not-found/not-found.component";
import {InternalServerComponent} from "./components/internal-server/internal-server.component";
import {SuccessComponent} from "./components/success/success.component";
import {ErrorComponent} from "./components/error/error.component";

@NgModule({
  declarations: [
    NotFoundComponent,
    InternalServerComponent,
    SuccessComponent,
    ErrorComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    NotFoundComponent,
    InternalServerComponent,
    SuccessComponent,
    ErrorComponent
  ],
  providers: [],
})
export class SharedModule { }
