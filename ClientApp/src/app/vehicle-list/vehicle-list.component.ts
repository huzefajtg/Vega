import { MakeService } from './../services/make.service';
import { VehicleService } from './../services/vehicle-services.service';
import { VehicleResource, KeyValuePairResource } from './../components/models/model';
import { Component, OnInit } from '@angular/core';
import { isDefaultChangeDetectionStrategy } from '@angular/core/src/change_detection/constants';

@Component({
  selector: 'app-vehicle-list',
  templateUrl: './vehicle-list.component.html',
  styleUrls: ['./vehicle-list.component.css']
})
export class VehicleListComponent implements OnInit {

  vList:any={};
  query:any={
    pageSize:3,
  };
  makes:KeyValuePairResource[];
  columns=[
    {title:'id'},
    {title:'Make',key:'make',isSortable:true},
    {title:'Model',key:'model',isSortable:true},
    {title:'Contact Name',key:'conName',isSortable:true},
    {}//for View
  ]
  constructor(private vService:VehicleService) { }

  ngOnInit() {
    this.vService.getMakes().subscribe(res=>{var temp
      temp=res
      this.makes=temp;
    });

    this.populateVehicles();
  }

  private populateVehicles()
  {
    this.vService.getVehicleList(this.query)
        .subscribe(res=>{
          var temp
          temp=res;
          this.vList=temp;
          console.log("List of Vehicles",this.vList)
        }
      );
    console.log("Filters Selected  ",this.query.makeId)
  }

  onFilterChange(){
    this.query.page=1;
    this.populateVehicles();
  }

  callSorter(item){
    if(this.query.sortBy===item){
      this.query.isAsce=!this.query.isAsce
      //this.vList.reverse();   //=>for client side reverse sorting
    }
    else{
      this.query.sortBy=item
      this.query.isAsce=true
      //this.populateVehicles();    //=>for client side reverse sorting
  }
  this.populateVehicles();
  console.log("Query",this.query)

  }


  onPageChanged(page){
    this.query.page=page
    this.populateVehicles();
  }

  OnRest()
  {
    this.query={
      page:1,
      pageSize:3
    };
    this.onFilterChange();
  }

}
