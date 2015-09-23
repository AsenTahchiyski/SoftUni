namespace AsyncTimer
{
    using System;
    using System.Threading;

    class AsyncTimer
    {
        public Action<int> Action { get; set; }

        public int Ticks { get; set; }

        public int Interval { get; set; }

        public AsyncTimer(Action<int> action, int ticks, int interval)
        {
            this.Action = action;
            this.Ticks = ticks;
            this.Interval = interval;
        }

        public void Start()
        {
            Thread thread = new Thread(() =>
            {
                for (int i = 0; i < this.Ticks; i++)
                {
                    this.Action(i + 1);
                    Thread.Sleep(this.Interval);
                }
            });
            thread.Start();
        }
    }
}
