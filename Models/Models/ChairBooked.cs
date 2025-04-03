namespace Models.Models;

public class ChairBooked
{
	public Guid ChairBookedId { get; set; }
	public Guid FlightTimeId { get; set; }
	public string ChairNumber { get; set; }
	public virtual FlightTime FlightTime { get; set; }
}