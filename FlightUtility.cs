namespace AirtekApp;

public static class FlightUtility
{
    public static List<Flight> LoadFlightsFromString(string flightScheduleInput)
    {
        var flights = new List<Flight>();
        var lines = flightScheduleInput.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        foreach (var line in lines)
        {
            // Parse each line in the format: "Day X, Flight Y, YUL to YYZ"
            var parts = line.Split(',', StringSplitOptions.TrimEntries);

            if (parts.Length >= 3)
            {
                // Extract details
                int day = int.Parse(parts[0].Split(' ')[1]);
                int flightNumber = int.Parse(parts[1].Split(' ')[1]);
                var route = parts[2].Split("to", StringSplitOptions.TrimEntries);
                string departureCity = route[0];
                string arrivalCity = route[1];

                // Create Flight object
                flights.Add(new Flight(flightNumber, departureCity, arrivalCity, day: day));
            }
        }

        return flights;
    }

}