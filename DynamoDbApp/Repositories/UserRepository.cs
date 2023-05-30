using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;
using DynamoDbApp.Repositories.Entities;
using Amazon.DynamoDBv2.DocumentModel;

namespace DynamoDbApp.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDynamoDBContext _context;

        public UserRepository(IAmazonDynamoDB dynamoDbClient)
        {
            _context = new DynamoDBContext(dynamoDbClient);
        }

        public async Task<UserLoginDb> Login(string userName, string password)
        {
            var config = new DynamoDBOperationConfig
            {
                QueryFilter = new List<ScanCondition>
                {
                    new ScanCondition("Password", ScanOperator.Equal, password)
                }
            };

            return await _context.LoadAsync<UserLoginDb>($"#USERS#", $"{userName}", config);
        }

        public async Task Register(UserRegisterDb userRegisterDb)
        {
            await _context.SaveAsync<UserRegisterDb>(userRegisterDb);
        }
    }
}
