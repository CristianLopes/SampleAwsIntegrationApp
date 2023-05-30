using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;
using DynamoDbApp.Repositories.Entities;
using Amazon.DynamoDBv2.DocumentModel;

namespace DynamoDbApp.Repositories
{
    public class OrderRepository
    {
        private readonly IDynamoDBContext _context;

        public OrderRepository(IAmazonDynamoDB dynamoDbClient)
        {
            _context = new DynamoDBContext(dynamoDbClient);
        }

        public async Task<IEnumerable<OrderDb>> GetAllOrders(string userId)
        {
            var config = new DynamoDBOperationConfig
            {
                QueryFilter = new List<ScanCondition>
                {
                    new ScanCondition("Sk", ScanOperator.BeginsWith, "ORDER#")
                }
            };

            return await _context.QueryAsync<OrderDb>($"USER#{userId}", config).GetRemainingAsync();
        }

        public async Task<OrderDb> GetOrder(string userId, string orderId)
        {
            return await _context.LoadAsync<OrderDb>($"USER#{userId}", $"ORDER#{orderId}");
        }

        public async Task<IEnumerable<OrderItemDb>> GetAllOrderItems(string orderId)
        {
            var config = new DynamoDBOperationConfig
            {
                //IndexName = "SK-PK-index",
                QueryFilter = new List<ScanCondition>
                {
                    new ScanCondition("Sk", ScanOperator.BeginsWith, "ITEM#")
                }
            };

            return await _context.QueryAsync<OrderItemDb>($"ORDER#{orderId}", operationConfig: config).GetRemainingAsync();
        }

        public async Task<OrderItemDb> GetOrderItems(string orderId, string itemId)
        {
            return await _context.LoadAsync<OrderItemDb>($"ORDER#{orderId}", $"ITEM#{itemId}");
        }
    }
}
