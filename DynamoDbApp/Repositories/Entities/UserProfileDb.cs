using Amazon.DynamoDBv2.DataModel;

namespace DynamoDbApp.Repositories.Entities
{
    public record Address(string StreetAddress, string State);
    [DynamoDBTable("MauiAppTable")]
    public class UserProfileDb
    {
        [DynamoDBHashKey]
        [DynamoDBProperty("PK")]
        public string Pk { get; set; }

        [DynamoDBGlobalSecondaryIndexHashKey]
        [DynamoDBProperty("SK")]
        public string Sk { get; set; }
        public string CreatedAt { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public Dictionary<string, string> Addresses { get; set; }

        public List<Address> ListAddresses => GetAddresses();

        private List<Address> GetAddresses()
        {
            if (Addresses?.Count == 0)
            {
                return new();
            }

            var addresses = new List<Address>();

            foreach (var address in Addresses)
            {
                var item = System.Text.Json.JsonSerializer.Deserialize<Address>(address.Value);
                addresses.Add(item);
            }

            return addresses;
        }

        public override string ToString()
        {
            return FullName;
        }
    }
}
