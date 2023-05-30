
using Amazon.DynamoDBv2.DataModel;

namespace DynamoDbApp.Repositories.Entities
{
    [DynamoDBTable("MauiAppTable")]
    public class UserLoginDb 
    {
        [DynamoDBHashKey]
        [DynamoDBProperty("PK")]
        public string PK { get; set; }

        [DynamoDBGlobalSecondaryIndexHashKey]
        [DynamoDBProperty("SK")]
        public string SK { get; set; }
        public string UserId { get; set; }
    }
}
