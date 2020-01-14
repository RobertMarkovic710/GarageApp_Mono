import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";

import { AppComponent } from './app.component';
import { GarageComponent } from './garage/garage.component';
import { VehicleComponent } from './garage/vehicle/vehicle.component';
import { VehicleListComponent } from './garage/vehicle-list/vehicle-list.component';
import { VehicleService } from './shared/vehicle.service';

@NgModule({
  declarations: [
    AppComponent,
    GarageComponent,
    VehicleComponent,
    VehicleListComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [VehicleService],
  bootstrap: [AppComponent]
})
export class AppModule { }
