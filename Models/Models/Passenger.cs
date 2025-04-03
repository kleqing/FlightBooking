namespace Models.Models;

public class Passenger
{
	public Guid PassengerId { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string PhoneNumber { get; set; }
	public string Email { get; set; }
	public string PassengerIdCard { get; set; }
	public virtual IEnumerable<Ticket> Tickets { get; set; }
}