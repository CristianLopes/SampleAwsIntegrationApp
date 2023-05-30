using DynamoDbApp.Repositories.Entities;

namespace DynamoDbApp.Repositories
{
    public interface IUserRepository
    {
        Task<UserLoginDb> Login(string userName, string password);
        Task Register(UserRegisterDb userRegisterDb);
    }
}