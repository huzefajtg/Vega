using AutoMapper;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vega2.Controllers.Resources;
using Vega2.Models;

namespace Vega2.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to API Resources
            CreateMap(typeof(QueryResult<>), typeof(QueryResultResources<>));
            CreateMap<VehicleQueryResource, VehicleQuery>();
            CreateMap<Make, MakesResources>();
            CreateMap<Make, KeyValuePairResource>();
            CreateMap<Model, KeyValuePairResource>();
            CreateMap<Model, ModelsResources>();
            CreateMap<Features, KeyValuePairResource>();
            CreateMap<Vehicle, SaveVehicleResource>()
                .ForMember(vr => vr.Contact, opt => opt.MapFrom
                    (v => new ContactResource { Name = v.ConName, Phone = v.ConPhone, Email = v.ConEmail }))
                .ForMember(vr => vr.VehicleFeature, opt => opt.MapFrom
                       (v => v.VehicleFeature.Select(vf => vf.FeatureId)));


            CreateMap<Vehicle, VehicleResource>()
                .ForMember(vr => vr.Make, opt => opt.MapFrom(v => v.Model.Make))
              .ForMember(vr => vr.Contact, opt => opt
                .MapFrom(v => new ContactResource
                { Name = v.ConName, Email = v.ConEmail, Phone = v.ConPhone }))
              .ForMember(vr => vr.Features, opt => opt
                .MapFrom(v => v.VehicleFeature
                  .Select(vf => new KeyValuePairResource { Id = vf.Feature.Id, Name = vf.Feature.Name })));

            //API Resource to Domain
            CreateMap<SaveVehicleResource, Vehicle>()
                .ForMember(v => v.Id, opt => opt.Ignore())              //1
                .ForMember(v => v.ConName, opt => opt.MapFrom(vr => vr.Contact.Name))
                .ForMember(v => v.ConPhone, opt => opt.MapFrom(vr => vr.Contact.Phone))
                .ForMember(v => v.ConEmail, opt => opt.MapFrom(vr => vr.Contact.Email))
                .ForMember(v => v.VehicleFeature, opt =>
                    opt.MapFrom(vr => vr.VehicleFeature.Select(id => new VehicleFeature { FeatureId = id })))
                //.ForMember(v => v.VehicleFeature, opt => opt.Ignore())  //2
                .AfterMap((vr, v) =>
                {
                    var removedList = v.VehicleFeature                  //3
                                        .Where(f => !vr.VehicleFeature.Contains(f.FeatureId)).ToList();
                    foreach (var f in removedList)
                        v.VehicleFeature.Remove(f);

                    var addList = vr.VehicleFeature                     //4
                                    .Where(id => !v.VehicleFeature.Any(f => f.FeatureId == id))
                                        .Select(id => new VehicleFeature { FeatureId = id }).ToList();
                    foreach (var f in addList)
                        v.VehicleFeature.Add(f);
                    
                });

            /*
                1.EF does not allow the id of a primary key to be changed hence we ignore that
                2.We ignore making changes because we do it AfterMap
                    assume we already have featureId 1 present
                    while updating due to our algo we will add featureId  again
                    hence it will show error that 1 is added again

                3.We create a list of all the features that are not there in vehicleResource
                    and then later we finally remove them from the vehicle(Model).
                4.We create a list of all the features that are to be added in vehicleResource
                    and then later we finally add them to the vehicle(Model).

                Why are we doing this?
                    We do this because:
                        1.While updating certain features may be added or removed
                            and we can not use normal mapping because if new features are added it will show error
                            or if features are removed it will show error {runtime error}
                            The vehicle Resource is coming from the user which will have updated data in it
                            this update data may be changed i.e. features reduced or increased
                            hence new features{add or remove} or old data will have to be updated
                            mapping updated data and data recieved from the Database i.e. vehicle{Model}
                            this will cause error because model changes will cause error due to Ef structure
             */
        }
    }
}
