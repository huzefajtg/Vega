import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import 'rxjs/add/operator/map';   //map from angular/http is of observable type
                                  //and will show error if rxjs not included

@Injectable()
export class VehicleService {

  constructor(private _http: HttpClient) { }

  getMakes() {

    return this._http.get('/api/makes');
  }

  getFeatures() {
    return this._http.get('/api/features');
  }

  create(vehicle){
    return this._http.post('/api/vehicles',vehicle).map(res=>res);
  }

  getVehicle(id){
    return this._http.get('/api/vehicles/'+id)
      .map(res=>res);
  }

  updateVehicle(vehicle){
    return this._http.put('/api/vehicles/'+vehicle.id,vehicle)
              .map(res=>res);
  }

  getVehicleList(filter){
    return this._http.get('/api/vehicles'+'?'+this.toQueryString(filter))
              .map(res=>res);
  }

  toQueryString(obj){
    var parts=[];
    for(var prop in obj)
    {
      var val=obj[prop];
      if(val!=null || val!=undefined)
        parts.push(encodeURIComponent(prop)+'='+encodeURIComponent(val))
    }

    return parts.join('&');
  }

  delete(id){
    return null;
  }

}
