using Microsoft.EntityFrameworkCore;
using TaskSystem.Data;
using TaskSystem.Models;
using TaskSystem.Repositories.Interfaces;

namespace TaskSystem.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskSystemDBContext _dbContext;
        public UserRepository(TaskSystemDBContext taskSystemDBContext) 
        {
            _dbContext = taskSystemDBContext;
        }

        //aqui esta assinando os contratos
        public async Task<List<UserModel>> SearchAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> SearchPerId(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

        }
        public async Task<UserModel> Add(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }
        public async Task<UserModel> Update(UserModel user, int id)
        {
            UserModel userPerId = await SearchPerId(id);
            if(SearchPerId == null)
            {
                throw new Exception($"User per ID:{id} Not!");
            }
            userPerId.Name = user.Name;
            userPerId.Email = user.Email;
            _dbContext.Users.Update(userPerId);
            await _dbContext.SaveChangesAsync();
            return userPerId;
        }
        public async Task<bool> Delete(int id)
        {
            UserModel userPerId = await SearchPerId(id);
            if (SearchPerId == null)
            {
                throw new Exception($"User per ID:{id} Not!");
            }
            _dbContext.Users.Remove(userPerId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
