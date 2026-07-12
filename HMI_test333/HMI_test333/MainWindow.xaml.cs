using System;
using System.Drawing;
using System.IO.Ports;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;



namespace HMI_test333
{
    public partial class MainWindow : Window
    {
        private bool isRunning = false;
        private bool isAutoMode = false;
        private DispatcherTimer timer;

        SerialPort port = new SerialPort("COM3", 9600);
        public MainWindow()
        {
            InitializeComponent();
           // SetStopState();
          // port.Open();
            port.DataReceived += Port_DataReceived;

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }
         
        private void Timer_Tick(object seder, EventArgs e)
        {
           // txtTime.Text = DateTime.Now.ToString("HH:mm:ss");
           // txtDate.Text = DateTime.Now.ToString("dddd, dd:MM:yyyyy");
        }

        private void Port_DataReceived(object render, SerialDataReceivedEventArgs e)
        {
            string data = port.ReadLine().Trim();

           /* Dispatcher.Invoke(() =>
             {
                 if (data == "LIMIT+")
                 {
                     ledLimitPlus.Fill = Brushes.Green;
                    // MessageBox.Show(data);
                 }
                 if (data == "LIMIT-")
                 {
                     ledLimitMinus.Fill = Brushes.Green;
                    // MessageBox.Show(data);
                 }
                 if (data == "HOME")
                 {

                     ledHome.Fill = Brushes.Green;
                     MessageBox.Show(data);
                 }
                 if (data == "HOMEH")
                 {

                     ledHome.Fill = Brushes.LightGray;
                     MessageBox.Show(data);
                 }
                 if (data == "STOPH")
                 {
                    // MessageBox.Show(data);
                     ledLimitMinus.Fill = Brushes.LightGray;
                     ledLimitPlus.Fill = Brushes.LightGray;

                 }
                 if (data == "ON")
                 {
                     btnStart.Background = Brushes.Green;
                     btnStop.Background = Brushes.LightGray;
                     MessageBox.Show(data);
                 }
                 if (data == "OFF")
                 {
                     SetStopState();
                     MessageBox.Show(data);
                 }

             });*/
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        // ================= START / STOP =================

        /* private void BtnStart_Click(object sender, RoutedEventArgs e)
         {
             isRunning = true;
             btnStart.Background = Brushes.Green;
             btnStop.Background = Brushes.LightGray;

             port.WriteLine("1");

         }

         private void BtnStop_Click(object sender, RoutedEventArgs e)
         {
             isRunning = false;
             SetStopState();

             port.WriteLine("0");

         }

         private void SetStopState()
         {
             btnStop.Background = Brushes.Red;
             btnStart.Background = Brushes.LightGray;
         }

         // ================= AUTO / MANUAL =================

         private void BtnAuto_Click(object sender, RoutedEventArgs e)
         {
             isAutoMode = true;
             btnAuto.Background = Brushes.LimeGreen;
             btnManual.Background = Brushes.LightGray;
             btnStop.Background = Brushes.LightGray;
         }

         private void BtnManual_Click(object sender, RoutedEventArgs e)
         {
             isAutoMode = false;
             btnManual.Background = Brushes.Gold;
             btnAuto.Background = Brushes.LightGray;
         }

         // ================= JOG CONTROL =================

         private void BtnJogPlus_Down(object sender, MouseButtonEventArgs e)
         {
             if (!isRunning || isAutoMode) return;
             btnJogPlus.CaptureMouse();

             port.WriteLine("JOG+");

         }

         private void BtnJogMinus_Down(object sender, MouseButtonEventArgs e)
         {

             if (!isRunning || isAutoMode) return;
             btnJogMinus.CaptureMouse();

             port.WriteLine("JOG-");
         }

         private void BtnJogPlus_Up(object sender, MouseButtonEventArgs e)
         {

             btnJogPlus.ReleaseMouseCapture();
             port.WriteLine("STOP");
             Console.WriteLine("SEND STOP");
         }

         private void BtnJogMinus_Up(object sender, MouseButtonEventArgs e)
         {


             btnJogMinus.ReleaseMouseCapture();
             port.WriteLine("STOP");
         }*/

    }
}