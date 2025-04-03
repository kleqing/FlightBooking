using Microsoft.AspNetCore.Identity;

namespace Models.Models;

public class User : IdentityUser<Guid>
{
	public string UserName { get; set; }
	public string Email { get; set; }
	public DateTime DateOfBirth { get; set; }
	public string PhoneNumber { get; set; }
	public string Address { get; set; }
	public DateTime CreatedDate { get; set; } = DateTime.Now;
}
