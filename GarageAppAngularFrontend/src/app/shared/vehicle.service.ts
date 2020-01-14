import { Injectable } from '@angular/core';
import { Vehicle } from './vehicle.=model';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class VehicleService {

  formData : Vehicle
  readonly rootURL="https://localhost:44392"
  constructor(private http : HttpClient) { }

  postVehicle(formData : Vehicle){
    return this.http.post(this.rootURL, formData);
  }
}
