import { BrowserModule } from '@angular/platform-browser';
import { NgModule, Component, ErrorHandler } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';


import { AppComponent } from './app.component';
import{AppErrorHandler} from './app-ErrHandler';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { VehicleFormComponent } from './components/vehicle-form/vehicle-form.component';
import { MakeService } from './services/make.service';
import { VehicleService } from './services/vehicle-services.service';
import { VehicleListComponent } from './vehicle-list/vehicle-list.component';
import { PaginationComponent } from './components/pagination.component';
import { ViewVehicleComponent } from './components/vehicle-view/view-vehicle';
import { AsdComponent } from './asd/asd.component';
import { QweComponent } from './qwe/qwe.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    PaginationComponent,
    ViewVehicleComponent,
    VehicleFormComponent,
    VehicleListComponent,
    AsdComponent,
    QweComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,

    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },

      { path: 'vehicles/new', component: VehicleFormComponent },
      { path: 'vehicles', component: VehicleListComponent },
      { path: 'viewer/:id', component: ViewVehicleComponent },

      { path: 'vehicles/:id', component: VehicleFormComponent },

      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
    ])
  ],
  providers: [
    {provide:ErrorHandler,useClass:AppErrorHandler},
    MakeService,
    VehicleService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
