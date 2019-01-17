namespace TimeTracker
{
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for TimerControl.
    /// </summary>
    public partial class TimerControl : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TimerControl"/> class.
        /// </summary>
        public TimerControl()
        {
            this.InitializeComponent();
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

        }

        private void button_stop_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}