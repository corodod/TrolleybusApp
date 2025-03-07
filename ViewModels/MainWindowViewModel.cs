using System;
using System.Collections.ObjectModel;
using TrolleybusApp.Models;

namespace TrolleybusApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Trolleybus> Trolleybuses { get; } = new ObservableCollection<Trolleybus>();

        public MainWindowViewModel()
        {
            var driver = new Driver("Иван Иванов");
            var emergencyService = new EmergencyService();

            for (int i = 1; i <= 3; i++)
            {
                var trolleybus = new Trolleybus(i);
                trolleybus.OnBreakdown += emergencyService.FixBreakdown;
                driver.AssignTrolleybus(trolleybus);
                Trolleybuses.Add(trolleybus);
                trolleybus.Start();

                Console.WriteLine($"Добавлен троллейбус №{trolleybus.Number}");
            }

            Console.WriteLine($"Всего троллейбусов: {Trolleybuses.Count}");
        }
    }
}