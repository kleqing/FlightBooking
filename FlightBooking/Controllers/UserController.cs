using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Models.Models;

namespace FlightBooking.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
	private readonly IUserRepository _userRepository;

	public UserController(IUserRepository userRepository)
	{
		_userRepository = userRepository;
	}

	[HttpPost]
	public async Task<IActionResult> CreateUser([FromBody] User user)
	{
		var response = await _userRepository.AddUser(user);
		if (!response.Success)
		{
			return BadRequest(response);
		}
		return Ok(response);
	}

	[HttpGet]
	public async Task<IActionResult> GetAllUsers()
	{
		var allUser = await _userRepository.GetAllUsers();
		if (allUser == null)
		{
			return NotFound();
		}
		return Ok(allUser);
	}

	[HttpPost("{Id}")]
	public async Task<IActionResult> UpdateUser([FromBody] User user, Guid Id)
	{
		var response = await _userRepository.UpdateUser(user, Id);
		if (!response.Success)
		{
			return BadRequest(response);
		}
		return Ok(response);
	}
}