import { Component, OnInit } from '@angular/core';
import { VehicleService } from 'src/app/shared/vehicle.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-vehicle',
  templateUrl: './vehicle.component.html',
  styleUrls: ['./vehicle.component.css']
})
export class VehicleComponent implements OnInit {

  constructor(private service : VehicleService) { }

  ngOnInit() {
    this.resetForm();
  }  

  resetForm(form? : NgForm){
    if(form!=null)
      form.resetForm();
      
    this.service.formData = {
      VehicleID : null,
      Make  : '',
      Model : '', 
      Year  : null,
      EngineSpecs : '' 
    }
  }
 
  onSubmit(form : NgForm){ 
    this.insertRecord(form);
  }

  insertRecord(form : NgForm){
    this.service.postVehicle(form.value).subscribe(res => {
      this.resetForm(form)
    });
  }
}
