using DynamoDbApp.Repositories.Entities;

namespace DynamoDbApp.Repositories
{
    public interface IUserRepository
    {
        Task<bool> UserExists(string userName);
        Task<UserLoginDb> Login(string userName, string password);
        Task Register(UserRegisterDb userRegisterDb);
    }
}