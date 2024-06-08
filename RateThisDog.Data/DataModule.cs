using Microsoft.Extensions.DependencyInjection;
using RateThisDog.Abstractions;
using RateThisDog.Data.Dto;

namespace RateThisDog.Data;

public static class DataModule
{
    public static void AddAppDataServices(this IServiceCollection services)
    {
        services.AddTransient<IDogDto, Dog>();
        services.AddTransient<IDogRatingDto, DogRating>();
        services.AddTransient<IDogRatingRepository, DogRatingRepository>();
    }
}