using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Stop_Watch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int seconds;
        private int minutes;
        private int hours;

        DispatcherTimer dt = new DispatcherTimer();
    

        public MainWindow()
        {
            InitializeComponent();
            seconds = minutes = hours = 0;
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += dTimer;
            Hours.IsIndeterminate = false;
            Minutes.IsIndeterminate = false;
            Secs.IsIndeterminate = false;
            txt_second.Text = (0).ToString();
            txt_minute.Text = (0).ToString();
            txt_hour.Text = (0).ToString();

        }
        private void dTimer(object sender,EventArgs e) 
        {
            seconds++;
            if (seconds > 59)
            {
                minutes++;
                seconds = 0;
              
            }

            if (minutes > 59)
            {
                hours++;
                minutes = 0;
            
            }
            txt_second.Text = Change(seconds);
            txt_minute.Text = Change(minutes);
            txt_hour.Text = Change(hours);
           
        }
        private string Change(int value)
        {
            if (value <= 9)
                return "0" + value;
            else
                return value.ToString();
        }

        private void play_button_Click(object sender, RoutedEventArgs e)
        {
            dt.Start();
            Secs.IsIndeterminate = true;
            Minutes.IsIndeterminate = true;
            Hours.IsIndeterminate = true;
            System.Media.SystemSounds.Beep.Play();
        }

        private void pause_button_Click(object sender, RoutedEventArgs e)
        {
            dt.Stop();
            Hours.IsIndeterminate = false;
            Minutes.IsIndeterminate = false;
            Secs.IsIndeterminate = false;
            System.Media.SystemSounds.Hand.Play();
        }

        private void stop_button_Click(object sender, RoutedEventArgs e)
        {
            dt.Stop();
            seconds = minutes = hours = 0;
            txt_second.Text = Change(seconds);
            txt_minute.Text = Change(minutes);
            txt_hour.Text = Change(hours);
            Hours.IsIndeterminate = false;
            Minutes.IsIndeterminate = false;
            Secs.IsIndeterminate = false;
            System.Media.SystemSounds.Beep.Play();
        }
    }
}
