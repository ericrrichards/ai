namespace WestWorld2 {
    using System;
    using System.Diagnostics;

    public class Clock {
        private static readonly Lazy<Clock> Lazy = new Lazy<Clock>(()=>new Clock());
        public Clock() { _stopwatch.Start();}
        public static Clock GlobalClock { get { return Lazy.Value; } }

        private readonly Stopwatch _stopwatch = new Stopwatch();

        public double GetCurrentTime() { return _stopwatch.Elapsed.TotalSeconds; }
    }
}