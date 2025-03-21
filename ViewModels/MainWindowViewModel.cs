﻿using System;
using System.Collections.ObjectModel;
using TrolleybusApp.Models;

namespace TrolleybusApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Trolleybus> Trolleybuses { get; } = new ObservableCollection<Trolleybus>();

        public MainWindowViewModel()
        {
            var emergencyService = new EmergencyService();

            string[] driverNames = { "Ivan Ivanov", "Petr Petrov", "Sergey Sergeev" };

            for (int i = 1; i <= 3; i++)
            {
                var trolleybus = new Trolleybus(i);
                var driver = new Driver(driverNames[i - 1]); 

                trolleybus.OnBreakdown += emergencyService.FixBreakdown;
                driver.AssignTrolleybus(trolleybus);
                Trolleybuses.Add(trolleybus);
                trolleybus.StartMoving();

                Console.WriteLine($"Added trolleybus №{trolleybus.Id} with driver {driver.Name}");
            }

            Console.WriteLine($"Total trolleybuses: {Trolleybuses.Count}");
        }
    }
}