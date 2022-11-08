import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import {FormsModule} from "@angular/forms";
import {HttpClientModule} from "@angular/common/http";
import { Proba1Component } from './proba1/proba1.component';
import { StudentiComponent } from './studenti/studenti.component';
import {RouterModule} from "@angular/router";

@NgModule({
  declarations: [
    AppComponent,
    Proba1Component,
    StudentiComponent
  ],
    imports: [
        BrowserModule,
      RouterModule.forRoot([
        {path: 'studenti', component: StudentiComponent},
        {path: 'proba1', component: Proba1Component},
      ]),
        FormsModule,
      HttpClientModule
    ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
