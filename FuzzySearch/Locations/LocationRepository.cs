namespace FuzzySearch.Locations;

public interface ILocationRepository
{
    IEnumerable<Location> GetLocations();
}

public class LocationRepository : ILocationRepository
{
    public IEnumerable<Location> GetLocations()
    {
        var locations = new List<Location>();
        var lines = File.ReadAllLines("Locations.txt");
        foreach (var line in lines)
        {
            var values = line.Split('\t');
            locations.Add(new Location { 
                GeoNameId = values[0],
                Name = values[1].Trim(),
                Latitude = values[4],
                Longitude = values[5],
                FeatureClass = values[6],
                CountryCode = values[8]
            });
        }

        return locations;
    }
}