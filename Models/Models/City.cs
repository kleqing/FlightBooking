namespace Models.Models;

public class City
{
	public Guid CityId { get; set; }
	public string CityName { get; set; }
	public string Country { get; set; }
	public virtual IEnumerable<Airport> Airports { get; set; }
}