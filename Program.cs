namespace AirtekApp;

class Program
{
    static void Main(string[] args)
    {
        string orderFilePath = "coding-assignment-orders.json";

        // Sample flight schedule input
        string flightScheduleInput = @"
Day 1, Flight 1, YUL to YYZ
Day 1, Flight 2, YUL to YYC 
Day 1, Flight 3, YUL to YVR
Day 2, Flight 4, YUL to YYZ
Day 2, Flight 5, YUL to YYC
Day 2, Flight 6, YUL to YVR
";
        var flights = FlightUtility.LoadFlightsFromString(flightScheduleInput);
        // Display loaded flights
        foreach (var flight in flights)
        {
            Console.WriteLine(flight);
        }

        // Load orders from JSON
        var orderLoader = new OrderLoader();
        var orders = orderLoader.LoadOrders(orderFilePath);

        // Schedule orders
        var scheduler = new Scheduler(flights);
        scheduler.ScheduleOrders(orders);

        // Display results
        foreach (var order in orders)
        {
            Console.WriteLine(order);
        }
    }
}

