/*
* FILE : MainWindow.cs
* PROJECT : PROG3165 - User Interface Design  - A04
* PROGRAMMERS : Lev Cocarell and Bobby Vu
* FIRST VERSION : 2018-04-12
* DESCRIPTION :
* This file contains the source code for the HMI demo, for user interace design. 
* It is a WPF and shows controls user would use for a paint line productio system.
*/

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

namespace HMI
{
    
    public partial class MainWindow : Window
    {
        // values for demonstration
        int incre = 0;
        int vol = 0;
        int weight = 0;
        string timeStart = "";

        public MainWindow()
        {
            InitializeComponent();
            // Automatically resize height and width relative to content
            this.SizeToContent = SizeToContent.WidthAndHeight;
            tabItem_Manual.IsEnabled = false;
            tabItem_SHUTDOWN.IsEnabled = false;
         
            initiliazeHMI();


        }

        // user clicks stop
        private void button_stop_Click(object sender, RoutedEventArgs e)
        {
            humanTriggeredFault();
            // grey out control buttons
            button_StartProcess_the2nd.Background = Brushes.LightGray;

            button_stop_the2nd.Background = Brushes.LightGray;

            button_shutDownProcess_the2nd.Background = Brushes.LightGray;

            button_shutDownProcess_the2nd.IsEnabled = false;


            button_StartProcess.IsEnabled = false;
            button_StartProcess_the2nd.IsEnabled = false;


            button_stop_the2nd.IsEnabled = false;
            tabItem_Line.IsEnabled   = false;
            tabItem_Manual.IsEnabled = true;
            this.tabItem_Manual.Focus();

        }

        // if stop button is caused by  user clicking error button
        public void humanTriggeredFault()
        {
            textBox_SourceProblem.Text = "HUMAN TRIGGERED";
            textBox_NameStation.Text = "ALL STATIONS";
            textBox_status.Text = "DOWN";
            textBox_StartTime.Text = timeStart;
            string timeStop = DateTime.Now.ToString("HH:mm:ss", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            textBox_StopTime.Text = timeStop;
            textBox_eventDuration.Text = timeStart + " to " + timeStop;
            textBox_DownTime.Text = "ASSEMBLY LINE HAS BEEN SHUT DOWN MANUALLY. PLEASE DETERMINE REASON AND RECTIFY SITUATION.";
        }

        // if stop button is caused by clicking start process button - trigger error
        public void machineCausedFault()
        {
            string timeStop = DateTime.Now.ToString("HH:mm:ss", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            // grey out control buttons
            button_StartProcess_the2nd.Background = Brushes.LightGray;
            button_stop_the2nd.Background = Brushes.LightGray;
            button_shutDownProcess_the2nd.Background = Brushes.LightGray;
        
            button_shutDownProcess_the2nd.IsEnabled = false;
            button_StartProcess.IsEnabled = false;
            button_StartProcess_the2nd.IsEnabled = false;
            button_stop_the2nd.IsEnabled = false;
            tabItem_Line.IsEnabled = false;
            tabItem_Manual.IsEnabled = true;
            this.tabItem_Manual.Focus();


            textBox_DownTime.Text = "CASE PACKER HAS BEEN JAMMED. ASSEMBLY LINE IS JAMMED AND REQUIRES ATTENTION.";
            textBox_SourceProblem.Text = "MACHINE TRIGGERED";
            textBox_NameStation.Text = "CASE PACKER STATION";
            textBox_status.Text = "DOWN";


            textBox_StartTime.Text = timeStart;
            textBox_StopTime.Text = timeStop;
            textBox_eventDuration.Text = timeStart + " to " + timeStop;

        }
 

        // Initialize components for HMI once user has clicked 
        public void initiliazeHMI()
        {
            timeStart = DateTime.Now.ToString("HH:mm:ss", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            button_resolveProblem.Visibility = Visibility.Hidden;
            button_warning_hopper.Background = Brushes.White;
            button_warning_fill_heads.Background = Brushes.White;
            button_warning_weight_station.Background = Brushes.White;
            button_warning_sealer.Background = Brushes.White;
            button_warning_labeler.Background = Brushes.White;
            button_warning_case_packer.Background = Brushes.White;
           
            vol = 20000;
            incre = 120;

        }

        // When user clicks process - fill text box to demonstrate usability 
        private void button_StartProcess_Click(object sender, RoutedEventArgs e)
        {
            textBox_FillHeadsCount.Text = vol.ToString();
            vol = vol - 1000;
            incre = incre - 10;
            textBox_LabelsPresent.Text = "YES";
            textBox_FillHeadLocation.Text = "UP";
            textBox_CanWeight.Text = "3900";
            textBox_Sealer.Text = "10";
            textBox_PackerStatus.Text = "Clear";
            textBox_CasePacker.Text = "1";
            textBox_PalletStatus.Text = "Found";

            textBox_LabelsPresent_Copy.Text = "YES";
            textBox_FillHeadLocation_Copy.Text = "UP";
            textBox_CanWeight_Copy.Text = "3900";
            textBox_Sealer_Copy.Text = "10";
            textBox_PackerStatus_Copy.Text = "Clear";
            textBox_CasePacker_Copy.Text = "1";
            textBox_PalletStatus_Copy.Text = "Found";

            textBox_CanCount.Text = incre.ToString();

            button_warning_hopper.Background = Brushes.Chartreuse;
            button_warning_fill_heads.Background = Brushes.Chartreuse;
            button_warning_weight_station.Background = Brushes.Chartreuse;
            button_warning_sealer.Background = Brushes.Chartreuse;
            button_warning_labeler.Background = Brushes.Chartreuse;
            button_warning_case_packer.Background = Brushes.Chartreuse;

            button_warning_hopper.Content = "RUNNING";
            button_warning_fill_heads.Content = "RUNNING";
            button_warning_weight_station.Content = "RUNNING";
            button_warning_sealer.Content = "RUNNING";
            button_warning_labeler.Content = "RUNNING";
            button_warning_case_packer.Content = "RUNNING";

            // display warnings and trigger error
            switch (incre)
            {
                case int incre when (incre <= 40):

                    button_warning_hopper.Content = "WARNING";

                    button_warning_hopper.Background = Brushes.Yellow;

                    button_warning_case_packer.Background = Brushes.Red;

                    textBox_PalletStatus.Text = "JAMMED";

                    button_warning_hopper.Content = "WARNING";

                    button_resolveProblem.Visibility = Visibility.Visible;

                    button_warning_case_packer.Content = "STOPPED";

                    button_StartProcess.IsEnabled = false;

                    break;
            }
        }

       
        // shut down process - change tabs 
        private void button_shutDownProcess_Click(object sender, RoutedEventArgs e)
        {
            tabItem_Line.IsEnabled = false;
            tabItem_Manual.IsEnabled = false;
            tabItem_SHUTDOWN.IsEnabled = true;
            this.tabItem_SHUTDOWN.Focus();

        }

        // shut down process - from shut down screen location
        private void button_StartProcess_ShutDownScreen_Click(object sender, RoutedEventArgs e)
        {
            tabItem_Line.IsEnabled = true;
            tabItem_Manual.IsEnabled = false;
            tabItem_SHUTDOWN.IsEnabled = false;
            this.tabItem_Line.Focus();
            initiliazeHMI();
        }

        // shut down - other example of button 
        private void button_shutDownProcess_the2nd_Click(object sender, RoutedEventArgs e)
        {
            tabItem_Line.IsEnabled = false;
            tabItem_Manual.IsEnabled = false;
            tabItem_SHUTDOWN.IsEnabled = true;
            this.tabItem_SHUTDOWN.Focus();
        }


        // when user confirms changes
        private void button_confirmation_Click(object sender, RoutedEventArgs e)
        {
            tabItem_Manual.IsEnabled = false;
            button_StartProcess.IsEnabled = true;
            tabItem_Line.IsEnabled = true;
            button_stop_the2nd.IsEnabled = true;
            this.tabItem_Line.Focus();
        }

  
        private void button_resolveProblem_Click_1(object sender, RoutedEventArgs e)
        {
            machineCausedFault();
        }


        private void textBox_status_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button_confirmation_2_Click(object sender, RoutedEventArgs e)
        {
            button_confirmation_2.IsEnabled = false;
        }
    }
}
