using Models.Models;

namespace Models.DTO;

public class UserResponseDTO
{
	public bool Success { get; set; }
	public string Message { get; set; }
	public User? User { get; set; }
}