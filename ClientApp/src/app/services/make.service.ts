import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import 'rxjs/add/operator/map';   //map from angular/http is of observable type
                                  //and will show error if rxjs not included

@Injectable()
export class MakeService {

  constructor(private _http: HttpClient) { }

  getMakes()
  {
    return this._http.get('/api/makes');
  }

  //DO NOT USE

  /*
   * constructor(private http:Http, @Inject('ORIGIN_URL') private originUrl: string) { }
 getMakes(){
 return this.http.get(`${this.originUrl}/api/makes`).map(res => res.json());
 }
 */

}
