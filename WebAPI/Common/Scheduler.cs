using System.Timers;

namespace WebAPI.Common
{
    /// <summary>
    /// Singleton class used for scheduling tasks.
    /// </summary>
    public class Scheduler
    {
        public static Scheduler Instance => new Scheduler();

        public Timer Timer
        {
            get
            {
                return new Timer
                {
                    Interval = 3600000, //1hr
                    AutoReset = true,
                    Enabled = true
                };
            }
        }

        private Scheduler()
        {
        }
    }
}