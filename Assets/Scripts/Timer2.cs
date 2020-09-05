namespace Utils {
    public class Timer {
        float timerLength;

        System.Timers.Timer timer;

        public delegate void OnTimerDepleteCallback();
        public OnTimerDepleteCallback onTimerDepleteCallback;

        public delegate void OnTimerToggleCallback(bool isTimerRunning);
        public OnTimerToggleCallback onTimerToggleCallback;

        public Timer(float timerLength, OnTimerDepleteCallback depleteCallback, TimerType timerType = TimerType.Single) {

        }
    }

    public enum TimerType { Single, Continuous };
}