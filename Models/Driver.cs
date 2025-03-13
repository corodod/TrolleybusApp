#nullable enable

using System;
using System.Threading.Tasks;

namespace TrolleybusApp.Models
{
    public class Driver
    {
        public string Name { get; }
        public Trolleybus? CurrentTrolleybus { get; private set; } = null;

        public Driver(string name)
        {
            Name = name;
        }

        public void AssignTrolleybus(Trolleybus trolleybus)
        {
            CurrentTrolleybus = trolleybus;
            trolleybus.OnPolesOff += FixPoles;
        }

        private async void FixPoles(Trolleybus trolleybus)
        {
            await Task.Delay(500);

            trolleybus.FixPoles();
            Console.WriteLine($"{Name} put the poles back in place for trolleybus {trolleybus.Id}");
        }
    }
}