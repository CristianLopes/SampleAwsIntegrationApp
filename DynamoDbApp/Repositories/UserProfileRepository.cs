using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;
using DynamoDbApp.Repositories.Entities;

namespace DynamoDbApp.Repositories
{
    public class UserProfileRepository
    {
        private readonly IDynamoDBContext _context;

        public UserProfileRepository(IAmazonDynamoDB dynamoDbClient)
        {
            _context = new DynamoDBContext(dynamoDbClient);
        }

        public async Task<IEnumerable<UserProfileDb>> GetAllProfiles()
        {
            return await _context.ScanAsync<UserProfileDb>(new List<ScanCondition>()).GetRemainingAsync();
        }

        public async Task<UserProfileDb> GetProfile(string userName)
        {
            return await _context.LoadAsync<UserProfileDb>($"USER#{userName}", $"PROFILE#{userName}");
        }
    }
}
