using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace TrolleybusApp.Models
{
    public class Trolleybus : INotifyPropertyChanged
    {
        public int Id { get; }
        private bool _isBroken;
        private bool _arePolesOff;
        public Driver? CurrentDriver { get; private set; }

        public bool IsBroken
        {
            get => _isBroken;
            private set
            {
                if (_isBroken != value)
                {
                    _isBroken = value;
                    OnPropertyChanged(nameof(IsBroken));
                }
            }
        }

        public bool ArePolesOff
        {
            get => _arePolesOff;
            private set
            {
                if (_arePolesOff != value)
                {
                    _arePolesOff = value;
                    OnPropertyChanged(nameof(ArePolesOff));
                }
            }
        }

        public event Action<Trolleybus>? OnBreakdown;
        public event Action<Trolleybus>? OnPolesOff;
        public event PropertyChangedEventHandler? PropertyChanged;

        public Trolleybus(int id)
        {
            Id = id;
            IsBroken = false;
            ArePolesOff = false;
        }

        public void AssignDriver(Driver driver)
        {
            CurrentDriver = driver;
        }

        public void StartMoving()
        {
            Task.Run(() =>
            {
                Random random = new Random();
                while (true)
                {
                    Thread.Sleep(1000); // Имитация движения
                    if (random.Next(100) < 5) // 5% вероятность поломки
                    {
                        IsBroken = true;
                        OnBreakdown?.Invoke(this);
                    }
                    if (random.Next(100) < 10) // 10% вероятность соскакивания штанг
                    {
                        ArePolesOff = true;
                        OnPolesOff?.Invoke(this);
                    }
                }
            });
        }

        public void Fix()
        {
            IsBroken = false;
        }

        public void FixPoles()
        {
            ArePolesOff = false;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}