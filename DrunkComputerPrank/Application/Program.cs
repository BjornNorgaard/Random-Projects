using System;
using System.Drawing.Configuration;
using System.Threading;
using System.Windows.Forms;
using System.Media;
using System.Runtime.InteropServices;

namespace Application
{
    class Program
    {
        #region Declarations

        public static int _startupDelaySeconds = 3;
        public static int _totalDurationSeconds = 12;

        public static Random _random = new Random();

        static Thread _drunkMouseThread = new Thread(DrunkMouseThread);
        static Thread _drunkKeyboardThread = new Thread(DrunkKeyboardThread);
        static Thread _drunkSoundThread = new Thread(DrunkSoundThread);
        static Thread _drunkPopupThread = new Thread(DrunkPopupThread);
        static Thread _threadKillerThread = new Thread(ThreadKillerThread);

        #endregion

        #region Main method

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Drunk PC Application, by Norgaard\n");

            if (args.Length >= 2)
            {
                _startupDelaySeconds = Convert.ToInt32(args[0]);
                _totalDurationSeconds = Convert.ToInt32(args[1]);
            }

            StartThreads();
            Console.WriteLine("Program terminated\n");
        }

        #endregion

        #region Thread Utilities

        public static void StartThreads()
        {
            Thread.Sleep(_startupDelaySeconds * 1000);

            _drunkMouseThread.Start();
            _drunkKeyboardThread.Start();
            _drunkSoundThread.Start();
            _drunkPopupThread.Start();
            _threadKillerThread.Start(); // responsible for aborting all threads, DONT REMOVE!
        }

        public static void ThreadKillerThread()
        {
            Thread.Sleep(_totalDurationSeconds * 1000);

            _drunkMouseThread.Abort();
            _drunkKeyboardThread.Abort();
            _drunkSoundThread.Abort();
            _drunkPopupThread.Abort();
            _threadKillerThread.Abort();
        }

        #endregion

        #region Thread Functions

        public static void DrunkMouseThread()
        {
            Console.WriteLine("Started Thread: Mouse");

            int moveX = 0, moveY = 0, vigor = 10;

            while (true)
            {
                moveX = _random.Next(vigor) - (vigor / 2);
                moveY = _random.Next(vigor) - (vigor / 2);

                Cursor.Position = new System.Drawing.Point(Cursor.Position.X - moveX, Cursor.Position.Y - moveY);
                Thread.Sleep(50);
            }
        }

        public static void DrunkKeyboardThread()
        {
            Console.WriteLine("Started Thread: Keyboard");

            while (true)
            {
                if (_random.Next(100) > 20)
                {
                    char key = (char)(_random.Next(25) + 65);

                    if (_random.Next(2) == 0)
                        key = Char.ToLower(key);

                    SendKeys.SendWait(key.ToString());
                }

                Thread.Sleep(_random.Next(5000));
            }
        }

        public static void DrunkSoundThread()
        {
            Console.WriteLine("Started Thread: Sound");

            while (true)
            {
                if (_random.Next(100) > 80)
                {
                    switch (_random.Next(5))
                    {
                        case 0:
                            SystemSounds.Asterisk.Play();
                            break;
                        case 1:
                            SystemSounds.Beep.Play();
                            break;
                        case 2:
                            SystemSounds.Exclamation.Play();
                            break;
                        case 3:
                            SystemSounds.Hand.Play();
                            break;
                        case 4:
                            SystemSounds.Question.Play();
                            break;
                        default:
                            Console.WriteLine("Default");
                            break;
                    }
                }

                Thread.Sleep(1000);
            }
        }

        public static void DrunkPopupThread()
        {
            Console.WriteLine("Started Thread: Popup");

            while (true)
            {
                if (_random.Next(100) > 30)
                {
                    switch (_random.Next(2))
                    {
                        case 0:
                            MessageBox.Show("Internet explorer has stopped working", "Internet Explorer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case 1:
                            MessageBox.Show("Your system is running low on ressources", "Microsoft Windows", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                    }
                }

                Thread.Sleep(10000);
            }
        }

        #endregion
    }
}
