using System.Collections;
using FuzzySharp;

namespace FuzzySearch.Locations;

public class LocationFuzzySearchService
{
    private readonly ILocationRepository _locationRepository;

    public LocationFuzzySearchService(ILocationRepository locationRepository)
    {
        _locationRepository = locationRepository;
    }
    
    public IEnumerable<string> GetLocations(string query)
    {
        var locations = GetNorwegianLocations(_locationRepository.GetLocations());
        var results = locations
            .Select(location => new
            {
                Location = location,
                Score = Fuzz.Ratio(query.ToLower(), location.Name.ToLower())
            })
            .OrderByDescending(result => result.Score)
            .Take(20)
            .Select(result => result.Location.Name);

        return results;
    }

    private IEnumerable<Location> GetNorwegianLocations(IEnumerable<Location> locations)
    {
        return locations.Where(l => l is { CountryCode: "NO", FeatureClass: "A" or "P" });
    }
}

