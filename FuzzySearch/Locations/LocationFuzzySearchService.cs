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
        var locations = _locationRepository.GetLocations();
        var results = locations
            .Select(location => new
            {
                Location = location,
                Score = Fuzz.Ratio(query, location.Name)
            })
            .OrderByDescending(result => result.Score)
            .Take(5)
            .Select(result => result.Location.Name);

        return results;
    }
}

