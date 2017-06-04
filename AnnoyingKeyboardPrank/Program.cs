using System;
using System.Windows.Forms;
using System.Speech.Synthesis;



namespace AnnoyingKeyboardPrank
{
    public class Program
    {

        [STAThread]
        static void Main()
        {

            var kh = new KeyboardHook(true);
            kh.KeyDown += Kh_KeyDown;

            while (true)
            {


                Application.Run();
                System.Threading.Thread.Sleep(100);
            }

            Console.ReadKey();
        }
        private static string getUserName = Environment.UserName;

        private static void Kh_KeyDown(Keys key, bool Shift, bool Ctrl, bool Alt)
        {
            //private static void Kh_KeyDown(Keys key, bool Ctrl)
            //{
            string getKeyType = string.Empty;



            Console.WriteLine("The Key: " + key);

            getKeyType = key.ToString();

            bool matchCaseCtlLeft = getKeyType.StartsWith("LControlKey");
            bool matchCaseCtlRight = getKeyType.StartsWith("RControlKey");

            bool matchCaseShiftButton = getKeyType.StartsWith("LShift") | getKeyType.StartsWith("RShift");
            bool matchCaseSpaceBar = getKeyType.StartsWith("Space");
            bool matchCaseCaps = getKeyType.StartsWith("Capital");

            if (matchCaseCtlLeft)
            {
                // Console.WriteLine(getKeyType);

                Clipboard.SetText($"Hello {getUserName} Why cant you Copy?  Morpheus ");

            }
            if (matchCaseCtlRight)
            {
                Clipboard.SetText($"Hello {getUserName} Your Computer is hacked be aware of your surrounding's !! Morpheus ");

            }
            //if the keyboard shift button is pressed play a random system sound
            if (matchCaseShiftButton)
            {


                DialogResult result = MessageBox.Show("Hello Neo , this is Morpheus  , hit Yes to see how far this rabbit hole goes and No for you want to go home", "Get Out Now", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

                if (result == DialogResult.Yes)
                {
                    Random rand = new Random();
                    int randNumber = rand.Next(000000000, 123456789);

                    string randomString = randNumber.ToString();

                    MessageBox.Show("Does this number mean anything to you? " + randomString, "Morpheus");
                }
                if (result == DialogResult.No)
                {

                    MessageBox.Show("Bye Bye for now!!");
                }
            }
            //if the keyboard space bar button is pressed play a random system sound
            if (matchCaseSpaceBar)
            {

                Random rand = new Random();

                int switchSound = rand.Next(0, 4);

                switch (switchSound)
                {
                    case 0:
                        System.Media.SystemSounds.Asterisk.Play();
                        break;
                    case 1:
                        System.Media.SystemSounds.Beep.Play();
                        break;
                    case 2:
                        System.Media.SystemSounds.Exclamation.Play();
                        break;
                    case 3:
                        System.Media.SystemSounds.Hand.Play();
                        break;
                    case 4:
                        System.Media.SystemSounds.Question.Play();
                        break;
                    default:
                        break;
                }

            }

            if (matchCaseCaps)
            {
                SpeechSynthesizer synth = new SpeechSynthesizer();
                synth.SetOutputToDefaultAudioDevice();

                Random rand = new Random();

                int switchIt = rand.Next(0, 5);

                switch (switchIt)
                {
                    case 0:
                        break;
                    case 1:
                        synth.Speak("Hello " + getUserName + ", this is Morpheus , Do you want to know , how deep the rabbit hole goes ? ");
                        break;
                    case 2:

                        break;
                    case 3:
                        synth.Speak("Hello " + getUserName + " , this is Morpheus , you are in danger , You must listen to ME , GET OUT, NOW!!!");
                        break;
                    default:
                        break;
                }



            }
        }

    }

}
