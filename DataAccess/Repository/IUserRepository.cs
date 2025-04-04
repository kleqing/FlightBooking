using System.Linq.Expressions;
using Models.DTO;
using Models.Models;

namespace DataAccess.Repository;

public interface IUserRepository
{
	Task<List<User?>> GetAllUsers();
	Task<User> GetUserById(Guid Id);
	Task<User> AddUser(User? user);
	Task<User> UpdateUser(User user, Guid Id);
	Task<User> DeleteUser(Guid id);
}