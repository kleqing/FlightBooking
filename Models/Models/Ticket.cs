namespace Models.Models;

public class Ticket
{
	public Guid TicketId { get; set; }
	public Guid FlightTimeId { get; set; }
	public Guid ClassId { get; set; }
	public Guid PassengerId { get; set; }
	public DateTime PurchaseDate { get; set; }
	public bool isPaid { get; set; }
	public DateTime DepartureTime { get; set; }
	public virtual FlightTime FlightTime { get; set; }
	public virtual Passenger Passenger { get; set; }
	public virtual Class Class { get; set; }
}