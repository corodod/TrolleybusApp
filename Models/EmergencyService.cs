using System;
using System.Threading;
using System.Threading.Tasks;

namespace TrolleybusApp.Models
{
    public class EmergencyService : IEmergencyService
    {
        public void FixBreakdown(Trolleybus trolleybus)
        {
            Task.Run(() =>
            {
                Console.WriteLine($"Аварийная служба выехала к троллейбусу {trolleybus.Number}");
                Thread.Sleep(3000); // Имитация времени на ремонт
                trolleybus.Fix();
                Console.WriteLine($"Троллейбус {trolleybus.Number} починен");
            });
        }
    }
}