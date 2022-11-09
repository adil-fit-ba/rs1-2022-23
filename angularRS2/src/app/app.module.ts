import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import {FormsModule} from "@angular/forms";
import {HttpClientModule} from "@angular/common/http";
import { PredmetiComponent } from './predmeti/predmeti.component';
import { DrzaveComponent } from './drzave/drzave.component';
import { OpstineComponent } from './opstine/opstine.component';
import { Proba1Component } from './proba1/proba1.component';
import { Proba2Component } from './proba2/proba2.component';
import { StudentiComponent } from './studenti/studenti.component';

@NgModule({
  declarations: [
    AppComponent,
    PredmetiComponent,
    DrzaveComponent,
    OpstineComponent,
    Proba1Component,
    Proba2Component,
    StudentiComponent
  ],
    imports: [
        BrowserModule,
        FormsModule,
      HttpClientModule
    ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
