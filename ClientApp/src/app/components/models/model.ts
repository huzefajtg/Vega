

export interface KeyValuePairResource{
    id:number;
    name:string;
}
export interface KeyValuePairResource2{
    id:number;
    models:any[];
    name:string;
}

export interface SaveVehicleResource{
    id:number;
    modelId:number;
    MakeId:number;
    Contact:ContactResource;
    isRegistered:boolean;
    vehicleFeature:number[];
}

export interface ContactResource{
    Name:string;
    Phone:string;
    Email:string;
}

export interface VehicleResource{
    id:number;
    model:KeyValuePairResource;
    contact:ContactResource;
    make:KeyValuePairResource;
    isRegistered:boolean;
    lastUpdate:string;
    features:KeyValuePairResource[];
}