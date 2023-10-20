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
            var values = line.Split(',');
            locations.AddRange(values.Select(value => new Location { Name = value.Trim() }));
        }

        return locations;
    }
}