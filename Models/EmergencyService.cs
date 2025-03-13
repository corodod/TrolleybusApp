using System;
using System.Threading.Tasks;

namespace TrolleybusApp.Models
{
    public class EmergencyService
    {
        public async void FixBreakdown(Trolleybus trolleybus)
        {
            // Add a delay of 1 second to simulate the emergency service arriving
            await Task.Delay(1000);

            trolleybus.Fix();
            Console.WriteLine($"Emergency service fixed trolleybus {trolleybus.Id}");
        }
    }
}