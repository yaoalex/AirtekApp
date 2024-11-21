using System.Text.Json;

namespace AirtekApp;

public class OrderLoader
{
    public List<Order> LoadOrders(string filePath)
    {
        string jsonContent = File.ReadAllText(filePath);
        var rawOrders = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(jsonContent);

        return rawOrders.Select(order =>
            new Order(order.Key, order.Value["destination"])).ToList();
    }
}

