import { element } from 'protractor';
import { KeyValuePairResource, KeyValuePairResource2 } from './../models/model';

import { forkJoin } from 'rxjs/observable/forkJoin';
import { VehicleService } from './../../services/vehicle-services.service';
import { Component, OnInit } from '@angular/core';
import { MakeService } from '../../services/make.service';
import { Router, ActivatedRoute } from '@angular/router';
import { SaveVehicleResource, VehicleResource } from '../models/model';


@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css'],
  providers: [MakeService]
})
export class VehicleFormComponent implements OnInit {

  makes: any=[];
  models:Array<KeyValuePairResource>=[];
  features;
  vehicle: SaveVehicleResource = {
    id:null,
    modelId:0,
    MakeId:null,
    Contact:{Name:'',Phone:'',Email:''},
    isRegistered:false,
    vehicleFeature:[]
  };

  updateModel:KeyValuePairResource={
    id:null,
    name:''
  }

  //vehicle=ngModel

  constructor(
                private vechiclesService: VehicleService,
                private route:ActivatedRoute,
                private router:Router
    
    ) {
        route.params.subscribe(v=>{this.vehicle.id=+v['id']? +v['id']:0;
        if(v['id']!=null)
          console.log("Recieved parameter Id=",this.vehicle.id );
      });

     }

ngOnInit() {
  var forkList= [
                  this.vechiclesService.getFeatures(),
                  this.vechiclesService.getMakes()
                ];
  
  if(this.vehicle.id!=0){
    console.log("inside the caller part");
      forkList.push(this.vechiclesService.getVehicle(this.vehicle.id))

  }

  var asd=forkJoin(forkList)
    .subscribe(data =>
      {
      console.log("inside the subscribe part");
      this.features=data[0];
      this.makes=data[1];

      if(this.vehicle.id!=0){
          this.setVehicleValues(<VehicleResource>data[2]);
          this.popModels();
        }
      },
      err=>
      {
        if(err.status==404)
          console.log("Error has occured");
      }
    )
  
  }

  private setVehicleValues(v:VehicleResource){
    
    this.vehicle.id=v.id;
    this.vehicle.MakeId=v.make.id;
    this.vehicle.modelId=v.model.id;
    this.vehicle.isRegistered=v.isRegistered;
    this.vehicle.Contact=v.contact;
    this.vehicle.vehicleFeature= v.features.map(f => f.id);
    console.log("Set Values:",this.vehicle);

    this.updateModel.id=v.model.id;
    this.updateModel.name=v.model.name;
  }


  onMakeChange() {
    if(this.vehicle.MakeId!=null){
      this.popModels();
    }
      else
        delete this.models;

      
  }

  private popModels()
  {

    /*var Tempmodels : any=[{}];
    Tempmodels.push(this.makes.find(m => m.id == this.vehicle.MakeId));
    console.log("Tempmodels",Tempmodels)

    if(Tempmodels!=[])
    {
      if(this.updateModel.id!=null){
        this.models.push(this.updateModel)
        console.log("Model Values",this.models);
      }

      Tempmodels.forEach(tm => {
        if(this.updateModel.id!=null && this.updateModel.id!=tm.id){
          console.log(tm);
          this.models.push(tm);
        }
      });
      //this.models = Tempmodels ? Tempmodels.models : [];
      
    }
    console.log("popModels",this.models);
    this.vehicle.modelId=Tempmodels[0].models[0].id;*/

    console.log("Makes",this.makes)
    if(this.vehicle.MakeId.toString()==""){
      this.models.splice(0,this.models.length)
      console.log("Makes is null",this.vehicle.MakeId)
    }
    else{
      console.log("Makes is null",this.vehicle.MakeId.toString())
      this.models.splice(0,this.models.length)
      var TempModel:Array<KeyValuePairResource2>=[]
      TempModel.push(this.makes.find(m => m.id == this.vehicle.MakeId));
        var temp:Array<KeyValuePairResource>=TempModel[0].models;
        console.log("temp",temp)
        //this.models=TempModel[0].models;
        console.log("Models",this.models)
        for(let i=0;i<temp.length;i++)
        {
          if(temp[i].id!=this.updateModel.id)
            this.models.push(temp[i]);
        }

        console.log("Models",this.models)
  }

    
  }

  OnCheckFeature(featureId, $event) {

    if ($event.target.checked)
      {
        this.vehicle.vehicleFeature.push(featureId);
        console.log("checked ",featureId);
      }
      else
        {
          var index = this.vehicle.vehicleFeature.indexOf(featureId);
          this.vehicle.vehicleFeature.splice(index, 1);
          console.log("unchecked ",this.vehicle.vehicleFeature);
        }
  }

  submit()
  {
    if(this.vehicle.id!=0){
      console.log("checked ",this.vehicle);
        this.vechiclesService.updateVehicle(this.vehicle)
          .subscribe(s=>console.log(s));
      }
      else
      {

        this.vechiclesService.create(this.vehicle)
          .subscribe(
            x=>console.log(x),
      );
    }
  }   

}
