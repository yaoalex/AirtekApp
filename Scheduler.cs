namespace AirtekApp;

public class Scheduler
{
    private readonly List<Flight> _flights;

    public Scheduler(List<Flight> flights)
    {
        _flights = flights;
    }

    public void ScheduleOrders(List<Order> orders)
    {
        foreach (var order in orders.OrderBy(o => o.OrderId)) // Orders already sorted by priority
        {
            var availableFlight = _flights.FirstOrDefault(f =>
                f.DepartureCity == order.DepartureCity &&
                f.ArrivalCity == order.ArrivalCity &&
                f.Capacity > 0);

            if (availableFlight != null)
            {
                order.Scheduled = true;
                order.FlightNumber = availableFlight.FlightNumber;
                order.Day = availableFlight.Day;
                availableFlight.Capacity--;
            }
        }
    }
}