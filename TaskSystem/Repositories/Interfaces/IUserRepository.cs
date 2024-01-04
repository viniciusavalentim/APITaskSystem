using TaskSystem.Models;

namespace TaskSystem.Repositories.Interfaces
{
    public interface IUserRepository
    {
        //contratos
        Task<List<UserModel>> SearchAllUsers();
        Task<UserModel> SearchPerId(int id);
        Task<UserModel> Add(UserModel user);
        Task<UserModel> Update(UserModel user, int id);
        Task<bool> Delete(int id);
    }
}
