using Amazon.DynamoDBv2.DataModel;

namespace DynamoDbApp.Repositories.Entities
{
    public class OrderDb 
    {
        public string Id { get; set; }
        public string Status { get; set; }
        public double Total { get; set; }
    }
}
