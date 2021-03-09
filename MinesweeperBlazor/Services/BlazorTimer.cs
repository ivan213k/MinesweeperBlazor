using System;
using System.Timers;

namespace MinesweeperBlazor.Services
{
    public class BlazorTimer : IBlazorTimer
    {
        private Timer _timer;

        public event Action OnTimerTicked;

        public void SetInterval(int intervalInMiliseconds)
        {
            _timer = new Timer(intervalInMiliseconds);
            _timer.Elapsed += NotifyTimerElapsed;
            _timer.AutoReset = true;
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }
        private void NotifyTimerElapsed(Object source, ElapsedEventArgs e)
        {
            OnTimerTicked?.Invoke();
        }
    }
}
