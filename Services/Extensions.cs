namespace SeniorLearnSystem.Services;
using Mapster;
using MapsterMapper;
using SeniorLearnSystem.Data;
using SeniorLearnSystem.Models;


//Static class not to be instantiated but methods referenced 
public static class Extensions
{

    //Mapster service config
    public static IServiceCollection AddMapster(this IServiceCollection services)
    {
        var config = new TypeAdapterConfig();

        //Peter uses fully scoped namespace here for self documentation (?)
        //Consider use of a statecheck method?  Must review before implementation
        //Note that methods can be used to provide useful information for readout
        TypeAdapterConfig<Member, MemberDTO>
            .NewConfig()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.FullName, src => src.FirstName + " " + src.LastName)
            .Map(dest => dest.Email, (src) => src.Email)
            .Map(dest => dest.Phone, src => src.Phone)
            .Map(dest => dest.RegistrationDate, src => src.RegistrationDate)
            .Map(dest => dest.MembershipStartDate, src => src.MembershipStartDate)
        .Map(dest => dest.RenewalDate, src => src.RenewalDate);
       
        //Add Mapster Config to DI Services as Singleton
        services.AddSingleton(config);
        //TODO:b 149. Add Mapper DI to DI Services (Scoped to HTTP Context, Request, Response)
        services.AddScoped<IMapper, ServiceMapper>();
        return services;
    }





}
