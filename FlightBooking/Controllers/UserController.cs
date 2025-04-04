using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Models.Models;
using Utility.Constants;

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
		var result = new BaseResultResponse<User>();
		var addUser = await _userRepository.AddUser(user);
		
		if (addUser == null)
		{
			result.Success = false;
			result.Message = UserConstant.UserCreated;
			return BadRequest(result);
		}
		return Ok(result);
	}

	[HttpGet]
	public async Task<IActionResult> GetAllUsers()
	{
		var result = new BaseResultResponse<List<User>>();
		var allUser = await _userRepository.GetAllUsers();
		
		if (allUser == null)
		{
			result.Success = false;
			result.Message = UserConstant.UserNotFound;
			return NotFound(result);
		}
		result.Success = true;
		result.Message = UserConstant.GetAllUserSuccess;
		result.Data = allUser;
		
		return Ok(result);
	}

	[HttpPost("{Id}")]
	public async Task<IActionResult> UpdateUser([FromBody] User user, Guid Id)
	{
		var response = await _userRepository.UpdateUser(user, Id);
		
		return Ok(response);
	}
	
	[HttpDelete("{Id}")]
	public async Task<IActionResult> DeleteUser(Guid Id)
	{
		var result = new BaseResultResponse<User>();
		var response = await _userRepository.DeleteUser(Id);
		
		if (response == null)
		{
			result.Success = false;
			result.Message = UserConstant.UserNotFound;
			return NotFound(result);
		}
		
		result.Success = true;
		result.Message = UserConstant.UserDeleted;
		
		return Ok(result);
	}
}