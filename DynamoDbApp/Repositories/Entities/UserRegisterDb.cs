
using Amazon.DynamoDBv2.DataModel;

namespace DynamoDbApp.Repositories.Entities
{
    [DynamoDBTable("MauiAppTable")]
    public class UserRegisterDb 
    {
        [DynamoDBHashKey]
        public string PK { get; set; }
        [DynamoDBGlobalSecondaryIndexHashKey]
        public string SK { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
    }
}
