﻿using Microsoft.EntityFrameworkCore;
using Models.DTO;
using Models.Models;
using Utility.Utils;
using DbContext = Models.DbContext;

namespace DataAccess.Repository;

public class UserRepository : IUserRepository
{
	private readonly DbContext _db;
	
	public UserRepository(DbContext db)
	{
		_db = db;
	}
	
	public async Task<List<User>> GetAllUsers()
	{
		return await _db.User.ToListAsync();
	}

	public async Task<UserResponseDTO> AddUser(User? user)
	{
		try
		{
			await _db.User.AddAsync(user);
			await _db.SaveChangesAsync();
			return new UserResponseDTO
			{
				Success = true,
				Message = Constant.UserErrorType.CreateSuccess.GetDescription(),
				User = user
			};
		}
		catch (Exception e)
		{
			return new UserResponseDTO
			{
				Success = false,
				Message = Constant.UserErrorType.CreateFailed.GetDescription(),
				User = null
			};
		}
	}
	
	public async Task<User> GetUserById(Guid Id)
	{
		return await _db.User.FirstOrDefaultAsync(u => u.Id == Id);
	}

	public async Task<UserResponseDTO> UpdateUser(User user, Guid Id)
	{
		var users = await GetUserById(Id);
		if (users == null)
		{
			return new UserResponseDTO
			{
				Success = false,
				Message = Constant.UserErrorType.UpdateFailed.GetDescription(),
				User = null
			};
		}
		users.UserName = user.UserName;
		users.Email = user.Email;
		users.PhoneNumber = user.PhoneNumber;
		users.DateOfBirth = user.DateOfBirth;
		users.Address = user.Address;
		await _db.SaveChangesAsync();
		return new UserResponseDTO
		{
			Success = true,
			Message = Constant.UserErrorType.UpdateSuccess.GetDescription(),
			User = users
		};
	}

	public async Task<User> DeleteUser(Guid id)
	{
		var users = await _db.User.FirstOrDefaultAsync(u => u.Id == id);
		_db.User.Remove(users);
		await _db.SaveChangesAsync();
		return users;
	}
}