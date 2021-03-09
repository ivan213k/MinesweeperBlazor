using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
