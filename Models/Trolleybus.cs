#nullable enable

using System;
using System.Threading;
using System.Threading.Tasks;

namespace TrolleybusApp.Models
{
    public class Trolleybus
    {
        public int Number { get; }
        public int Speed { get; private set; }
        public string Status { get; private set; } = "Работает";

        public event Action<Trolleybus>? OnBreakdown = null; // Явная инициализация
        public event Action<Trolleybus>? OnPolesSlipped = null; // Явная инициализация

        private readonly Random _random = new Random();

        public Trolleybus(int number)
        {
            Number = number;
        }

        public void Start()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    Move();
                    Thread.Sleep(1000); // Задержка для имитации движения
                }
            });
        }

        private void Move()
        {
            Speed = _random.Next(20, 60);
            Status = "Движется";

            // Случайная поломка
            if (_random.Next(100) < 5) // 5% вероятность поломки
            {
                Breakdown();
            }

            // Случайное соскакивание штанг
            if (_random.Next(100) < 10) // 10% вероятность соскакивания штанг
            {
                PolesSlipped();
            }
        }

        private void Breakdown()
        {
            Status = "Сломан";
            OnBreakdown?.Invoke(this);
        }

        private void PolesSlipped()
        {
            Status = "Штанги соскочили";
            OnPolesSlipped?.Invoke(this);
        }

        public void Fix()
        {
            Status = "Работает";
        }
    }
}