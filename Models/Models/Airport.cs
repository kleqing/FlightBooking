namespace Models.Models;

public class Airport
{
	public Guid AirportId { get; set; }
	public string AirportName { get; set; }
	public Guid CityId { get; set; }
	public DateTime TimeZone { get; set; }
	public virtual City City { get; set; }
	public virtual IEnumerable<Transit> Transits { get; set; }
	public virtual IEnumerable<Flight> Flights { get; set; }
}