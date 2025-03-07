#nullable enable

using System;

namespace TrolleybusApp.Models
{
    public class Driver
    {
        public string Name { get; }
        public Trolleybus? CurrentTrolleybus { get; private set; } = null; // Явная инициализация

        public Driver(string name)
        {
            Name = name;
        }

        public void AssignTrolleybus(Trolleybus trolleybus)
        {
            CurrentTrolleybus = trolleybus;
            trolleybus.OnPolesSlipped += FixPoles;
        }

        private void FixPoles(Trolleybus trolleybus)
        {
            trolleybus.Fix();
            Console.WriteLine($"{Name} поставил штанги на место для троллейбуса {trolleybus.Number}");
        }
    }
}