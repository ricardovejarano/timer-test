using System;
using System.Timers;

namespace Timer_Test
{
    class Program
    {
        private static System.Timers.Timer aTimer;
        public static int hour = 16;
        public static int min = 56;
        public static int sec = 30;
        public static string hourFinal = "";
        public static bool validHour;
        public static bool validMin;
        public static bool validSec;

        static void Main(string[] args)
        {
            validHour = HourValid(hour);
            validMin = MinutValid(min);
            validSec = SecondValid(sec);

            CheckMessagesForHourValid();
            if (validHour && validMin && validSec) {
                SetHour();
            } else
            {
                Console.WriteLine("invalid value of hour");
            }
      
            SetTimer();
            Console.WriteLine("\nPress the Enter key to exit the application...\n");
            Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
            Console.ReadLine();
            

            Console.WriteLine("Terminating the application...");
        }

        private static void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(200);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine(e.SignalTime.ToString().Split(' ')[1]);
            if(e.SignalTime.ToString().Split(' ')[1] == hourFinal)
            {
                Console.Write("Event to entry");
                aTimer.Stop();
                aTimer.Dispose();
            }
            
        }


        public static void SetHour()
        {
            hourFinal = getStringFromNumber(hour) + ":" + getStringFromNumber(min) + ":" + getStringFromNumber(sec);
            Console.WriteLine("Time typped, {0}", hourFinal);
            
        }

        public static bool HourValid(int hourTest)
        {
            return hourTest >= 0  && hourTest <= 24;
        }

        public static bool MinutValid(int minutTest)
        {
            return minutTest >= 0 && minutTest <= 59;
        }

        public static bool SecondValid(int secondTest)
        {
            return secondTest >= 0 && secondTest <= 59;
        }

        public static void CheckMessagesForHourValid()
        {
            // TODO: error messages if there is not a value hour, minu or second
        }

        public static string getStringFromNumber(int time)
        {
            string newHour;
            if (time.ToString().Length == 1)
            {
                newHour = "0" + time;
            }
            else
            {
                newHour = time.ToString();
            }
            return newHour;
        }

    }
}
