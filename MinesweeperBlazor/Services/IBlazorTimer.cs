using System;

namespace MinesweeperBlazor.Services
{
    public interface IBlazorTimer
    {
        void Start();
        void Stop();
        void SetInterval(int intervalInMiliseconds);

        event Action OnTimerTicked;
    }
}
