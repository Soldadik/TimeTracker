namespace TimeTracker
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for TimerControl.
    /// </summary>
    public partial class TimerControl : UserControl
    {
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        string time_total;
        DateTime date = new DateTime();
        DateTime date_total = new DateTime();

        /// <summary>
        /// Initializes a new instance of the <see cref="TimerControl"/> class.
        /// </summary>
        public TimerControl()
        {
            this.InitializeComponent();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();

            ReadInfoFromFile();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            string time = "";
            string time_t = "";

            date = date.AddSeconds(1);
            date_total = date_total.AddSeconds(1);

            int hh = date.Hour;
            int mm = date.Minute;
            int ss = date.Second;

            int hht = date_total.Hour;
            int mmt = date_total.Minute;
            int sst = date_total.Second;

            //Часы
            if (hh < 10)
            {
                time += "0" + hh;
            }
            else
            {
                time += hh;
            }

            if (hht < 10)
            {
                time_t += "0" + hht;
            }
            else
            {
                time_t += hht;
            }
            time += ":";
            time_t += ":";

            //Минуты
            if (mm < 10)
            {
                time += "0" + mm;
            }
            else
            {
                time += mm;
            }

            if (mmt < 10)
            {
                time_t += "0" + mmt;
            }
            else
            {
                time_t += mmt;
            }
            time += ":";
            time_t += ":";

            //Секунды
            if (ss < 10)
            {
                time += "0" + ss;
            }
            else
            {
                time += ss;
            }

            if (sst < 10)
            {
                time_t += "0" + sst;
            }
            else
            {
                time_t += sst;
            }

            textBlock_current.Text = time;
            textBlock_total.Text = time_t;
        }

        private void ReadInfoFromFile()
        {
            StreamReader ReadFile = File.OpenText("time_tracker.cfg");
            string[] lines = ReadFile.ReadToEnd().Split('\n');
            ReadFile.Close();
            date_total = DateTime.MinValue;

            time_total = lines[0];
            textBlock_total.Text = lines[0];
            textBlock_last.Text = lines[1];

            TimeSpan ts = new TimeSpan();
            ts = TimeSpan.Parse(time_total);
            date_total = date_total.Date + ts;
            ReadFile.Close();

        }

        private void WriteInfoToFile()
        {
            StreamWriter WriteFile = new StreamWriter("time_tracker.cfg");
            WriteFile.WriteLine(textBlock_total.Text);
            WriteFile.WriteLine(textBlock_current.Text);
            WriteFile.Close();
        }

        /// <summary>
        /// Handles click on the button by displaying a message box.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event args.</param>
        [SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions", Justification = "Sample code")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Default event handler naming pattern")]

        private void button_start_Click(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Start();
        }

        private void button_stop_Click(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Stop();
            WriteInfoToFile();
        }
    }
}