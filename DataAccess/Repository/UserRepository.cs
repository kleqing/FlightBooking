using Microsoft.EntityFrameworkCore;
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

	public async Task<User> AddUser(User? user)
	{
		try
		{
			var users = await _db.User.AddAsync(user);
			await _db.SaveChangesAsync();
			return users.Entity;
		}
		catch (Exception e)
		{
			return null;
		}
	}
	
	public async Task<User> GetUserById(Guid Id)
	{
		return await _db.User.FirstOrDefaultAsync(u => u.Id == Id);
	}

	public async Task<User> UpdateUser(User user, Guid Id)
	{
		var users = await GetUserById(Id);
		if (users == null)
		{
			return null;
		}
		users.UserName = user.UserName;
		users.Email = user.Email;
		users.PhoneNumber = user.PhoneNumber;
		users.DateOfBirth = user.DateOfBirth;
		users.Address = user.Address;
		await _db.SaveChangesAsync();
		return users;
	}

	public async Task<User> DeleteUser(Guid id)
	{
		var users = await GetUserById(id);
		if (users == null)
		{
			return null;
		}
		_db.User.Remove(users);
		await _db.SaveChangesAsync();
		return users;
	}
}