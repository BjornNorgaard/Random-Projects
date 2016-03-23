using System;
using System.Media;
using System.Threading;
using System.Windows.Forms;

namespace AnnoyingDevices
{
    public abstract class AnnoyDevice
    {
        public abstract void Run();
    }

    class AnnoyPopup : AnnoyDevice
    {
        Random _random = new Random();

        public override void Run()
        {
            Console.WriteLine("Started Thread: Popup");

            while (true)
            {
                if (_random.Next(100) > 20)
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
    }

    public class AnnoySounds : AnnoyDevice
    {
        Random _random = new Random();

        public override void Run()
        {
            Console.WriteLine("Started: Sound");

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
    }

    public class AnnoyKeyboard : AnnoyDevice
    {
        Random _random = new Random();
        
        public override void Run()
        {
            Console.WriteLine("Started: Keyboard");

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
    }

    public class AnnoyMouse : AnnoyDevice
    {
        Random _random = new Random();

        public override void Run()
        {
            Console.WriteLine("Started: Mouse");

            int vigor = 50;

            while (true)
            {
                var moveX = _random.Next(vigor) - (vigor / 2);
                var moveY = _random.Next(vigor) - (vigor / 2);

                Cursor.Position = new System.Drawing.Point(Cursor.Position.X - moveX, Cursor.Position.Y - moveY);
                Thread.Sleep(50);
            }
        }
    }
}