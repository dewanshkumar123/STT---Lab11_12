using System;
using System.Threading;

namespace AlarmClockApp
{
    public delegate void AlarmEventHandler();

    class AlarmClock
    {
        public event AlarmEventHandler raiseAlarm;
        private string userTime;

        public AlarmClock(string time)
        {
            userTime = time;
        }

        public void Start()
        {
            Console.WriteLine("Alarm Clock is running... Waiting for the set time.");
            while (true)
            {
                string currentTime = DateTime.Now.ToString("HH:mm:ss");
                if (currentTime == userTime)
                {
                    OnRaiseAlarm();
                    break;
                }
                Thread.Sleep(1000);
            }
        }

        protected virtual void OnRaiseAlarm()
        {
            if (raiseAlarm != null)
                raiseAlarm.Invoke();
        }
    }

    class AlarmHandler
    {
        public void Ring_alarm()
        {
            Console.WriteLine("Time Matched with system time ...Alarm Ringing! Time is up!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string inputTime;
            while (true)
            {
                Console.Write("Enter alarm time (HH:mm:ss): ");
                inputTime = Console.ReadLine();

                if (DateTime.TryParseExact(inputTime, "HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out _))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid format! Please enter time in HH:mm:ss format.\n");
                }
            }

            AlarmClock alarm = new AlarmClock(inputTime);
            AlarmHandler handler = new AlarmHandler();
            alarm.raiseAlarm += handler.Ring_alarm;
            alarm.Start();
            Console.WriteLine("Program Ended.");
        }
    }
}
