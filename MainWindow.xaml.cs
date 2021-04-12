using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

using System.IO;

using System.Windows.Forms;

using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using System.Windows.Controls.Primitives;

using Microsoft.Win32;
using ad2ex1.Model;
using ad2ex1.ViewModel;


namespace ad2ex1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ViewModelController controllerViewModel;
        TimeSpan _position;
        private MInterfaceClient clientModel;
        DispatcherTimer _timer = new DispatcherTimer();
        //////private bool mediaPlayerIsPlaying = false;
        private bool userIsDraggingSlider = false;
        public MainWindow()
        {
            InitializeComponent();
            ////  _timer.Interval = TimeSpan.FromMilliseconds(1000);
            ////   _timer.Tick += new EventHandler(ticktock);
            ////   _timer.Start();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
            List<User> items = new List<User>();
            items.Add(new User() { Name = "altimeter", Data = 42 });
            items.Add(new User() { Name = "airspeed", Data = 39 });
            items.Add(new User() { Name = "flight direction", Data = 7 });
            items.Add(new User() { Name = "roll", Data = 10 });
            items.Add(new User() { Name = "yaw", Data = +5 });
            items.Add(new User() { Name = "pitch", Data = -2 });
            lvUsers.ItemsSource = items;

            Mclient c = new Mclient("localhost", 5400);
            clientModel = c;
            controllerViewModel = new ViewModelController(c);
           /// controllerViewModel.VM_XMLPath = "C:\\Program Files\\FlightGear 2020.3.6\\data\\Protocol\\playback_small.xml";
          ////  controllerViewModel.xmlPraser();
            controllerViewModel.VM_FGPath = "C:\\Program Files\\FlightGear 2020.3.6";
            ///   controllerViewModel = new ViewModelController(c);
            ///  this.DataContext = controllerViewModel;
            //checking if FG folder is in the "normal" place
        }


        private void timer_Tick(object sender, EventArgs e)
        {
            if ((Media.Source != null) && (Media.NaturalDuration.HasTimeSpan) && (!userIsDraggingSlider))
            {
                sliProgress.Minimum = 0;
                sliderSeek.Minimum = 0;
                sliderSeek.Maximum = Media.NaturalDuration.TimeSpan.TotalSeconds;

                sliProgress.Maximum = Media.NaturalDuration.TimeSpan.TotalSeconds;
                sliProgress.Value = Media.Position.TotalSeconds;
            }
        }
        void ticktock(object sender, EventArgs e)
        {
            if (!sliderSeek.IsMouseCaptureWithin)
            {
                sliderSeek.Value = Media.Position.TotalSeconds;
            }
        }

        private void RectangleHeight_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void myJostick_Loaded(object sender, RoutedEventArgs e)
        {

        }


        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Title = "Choose Media";
            if (dialog.ShowDialog() == true)
            {
                Media.Source = new Uri(dialog.FileName);
                MediaName.Text = dialog.FileName;

            }

        }
        private void readCSVfile()
        {
            String[] csvLine = File.ReadAllLines(controllerViewModel.VM_fpath);
            controllerViewModel.VM_CSVcopy = csvLine;
        }
        private void LoadCSV_Click(object sender, RoutedEventArgs e)
        {
          
         
            var dialog1 = new OpenFileDialog();
            dialog1.Title = "Choose CSV";
            if (dialog1.ShowDialog() == true)
            {
                controllerViewModel.VM_fpath = dialog1.FileName;
                
            }
            readCSVfile();
            controllerViewModel.splitAtt();
            PlayButton_Click(this, null);
            
        }

        private void LoadXML_Click(object sender, RoutedEventArgs e)
        {
           //// controllerViewModel.VM_XMLPath = "C:\\Program Files\\FlightGear 2020.3.6\\data\\Protocol\\playback_small.xml";
            ////  
            var dialog2 = new OpenFileDialog();
            dialog2.Title = "Choose XML";
            if (dialog2.ShowDialog() == true)
            {
                controllerViewModel.VM_XMLPath = dialog2.FileName;

            }
            controllerViewModel.xmlPraser();
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            if (Media.Source != null)
                Media.Play();
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            if (Media.CanPause)
                Media.Pause();
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            if (Media.Source != null)
                Media.Stop();
        }

        private void MuteButton_Click(object sender, RoutedEventArgs e)
        {
            Media.IsMuted = !Media.IsMuted;
        }


        private void VolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Media.Volume = VolumeSlider.Value;
        }

      /*  private void Balance_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Media.Balance = BalanceSlider.Value;
        }*/

        private void Speed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Media.SpeedRatio = SpeedSlider.Value;
        }

        private void Media_MediaOpened(object sender, RoutedEventArgs e)
        {
          ////  Status.Fill = Brushes.Green;
            _position = Media.NaturalDuration.TimeSpan;
            sliderSeek.Minimum = 0;
            sliderSeek.Maximum = _position.TotalSeconds;

        }

    /*    private void Media_MediaEnded(object sender, RoutedEventArgs e)
        {
            Status.Fill = Brushes.Blue;
        }

        private void Media_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            Status.Fill = Brushes.Red;
        }
    */


        private void sliderSeek_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int pos = Convert.ToInt32(sliderSeek.Value);
            Media.Position = new TimeSpan(0, 0, 0, pos, 0);
        }

        private void sliderSeek_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int pos = Convert.ToInt32(sliderSeek.Value);
            Media.Position = new TimeSpan(0, 0, 0, pos, 0);
        }

        private void sliderSeek_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (sliderSeek.IsMouseCaptureWithin)
            {
                int pos = Convert.ToInt32(sliderSeek.Value);
                Media.Position = new TimeSpan(0, 0, 0, pos, 0);
            }
        }
        private void sliProgress_DragStarted(object sender, DragStartedEventArgs e)
        {
            userIsDraggingSlider = true;
        }

        private void sliProgress_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            userIsDraggingSlider = false;
           Media.Position = TimeSpan.FromSeconds(sliProgress.Value);
        }

        private void sliProgress_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lblProgressStatus.Text = TimeSpan.FromSeconds(sliProgress.Value).ToString(@"hh\:mm\:ss");
        }

        private void Grid_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            Media.Volume += (e.Delta > 0) ? 0.1 : -0.1;
        }

        private void pbVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        public class User
        {
            public string Name { get; set; }

            public int Data{ get; set; }

           //// public string Mail { get; set; }
        }

        private void sliderSeek_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
}
