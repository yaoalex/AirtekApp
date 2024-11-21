namespace AirtekApp;

public class Order
{
    public string OrderId { get; set; }
    public string DepartureCity { get; set; } = "YUL"; // Montreal is the default departure city
    public string ArrivalCity { get; set; }
    public bool Scheduled { get; set; } = false;
    public int? FlightNumber { get; set; }
    public int? Day { get; set; }

    public Order(string orderId, string arrivalCity)
    {
        OrderId = orderId;
        ArrivalCity = arrivalCity;
    }

    public override string ToString()
    {
        if (Scheduled)
            return $"order: {OrderId}, flightNumber: {FlightNumber}, departure: {DepartureCity}, arrival: {ArrivalCity}, day: {Day}";
        else
            return $"order: {OrderId}, flightNumber: not scheduled";
    }
}
