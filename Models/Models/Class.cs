namespace Models.Models;

public class Class
{
	public Guid ClassId { get; set; }
	public string ClassName { get; set; }
	public decimal Price { get; set; }
	public virtual IEnumerable<Ticket> Tickets { get; set; }
}