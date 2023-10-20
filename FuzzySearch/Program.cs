using FuzzySearch.Locations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<LocationFuzzySearchService>();

var app = builder.Build();

app.MapGet("/search", (LocationFuzzySearchService locationFuzzySearchService, string q) => locationFuzzySearchService.GetLocations(q));

app.Run();