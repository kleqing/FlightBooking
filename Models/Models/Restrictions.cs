namespace Models.Models;

public class Restrictions
{
	public TimeOnly MinDuration { get; set; }
	public TimeOnly MaxDuration { get; set; }
	public TimeOnly MinTransitTime { get; set; }
	public TimeOnly MaxTransitTime { get; set; }
	public DateTime LatestBookingTime { get; set; }
	public DateTime LatestCancelingTime { get; set; }
}