namespace Models.Models;

public class FlightTime
{
	public Guid FlightTimeId { get; set; }
	public Guid FlightId { get; set; }
	public DateTime DepartureTime { get; set; }
	public DateTime ArrivalTime { get; set; }
	public int AmmoutBooked { get; set; }
	public virtual Flight Flight { get; set; }
	public virtual IEnumerable<ChairBooked> ChairBooked { get; set; }
	public virtual IEnumerable<Ticket> Tickets { get; set; }
}