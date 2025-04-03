namespace Models.Models;

public class Transit
{
	public Guid TransitId { get; set; }
	public Guid FlightId { get; set; }
	public Guid AirportId { get; set; }
	public int TransitOrder { get; set; }
	public string TransitNote { get; set; }
	public bool isTransitAvailable { get; set; }
	public virtual Flight Flight { get; set; }
	public virtual Airport Airport { get; set; }
}