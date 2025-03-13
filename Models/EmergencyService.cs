namespace TrolleybusApp.Models
{
    public class EmergencyService : IEmergencyService
    {
        public void FixBreakdown(Trolleybus trolleybus)
        {
            trolleybus.Fix();
        }
    }
}