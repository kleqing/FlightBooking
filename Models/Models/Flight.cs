namespace Models.Models;

public class Flight
{
	public Guid FlightId { get; set; }
	public Guid AirportId { get; set; }
	public decimal FlightPrice { get; set; }
	public int TotalFlightSeats { get; set; }
	public string OriginAirport { get; set; }
	public string DestinationAirport { get; set; }
	public bool isFlightAvailable { get; set; }
	public virtual Airport Airport { get; set; }
	public virtual IEnumerable<Transit> Transits { get; set; }
	public virtual IEnumerable<FlightTime> FlightTimes { get; set; }
}