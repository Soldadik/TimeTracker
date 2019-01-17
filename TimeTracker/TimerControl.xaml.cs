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
        int i = 0;
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
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            i++;
            textBlock_current.Text = i.ToString();
        }

        private void ReadInfoFromFile()
        {
            StreamReader ReadFile = File.OpenText("time_tracker.cfg");
            ReadFile.Close();

        }

        private void WriteInfoToFile()
        {
            StreamWriter WriteFile = new StreamWriter("time_tracker.cfg");
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
        }
    }
}