using Amazon.DynamoDBv2.DataModel;

namespace DynamoDbApp.Repositories.Entities
{
    public class OrderItemDb 
    {
        public string OrderId { get; set; }
        public string ItemId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
