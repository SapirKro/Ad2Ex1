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

using System.ComponentModel;
using System.Collections.ObjectModel;


using System.IO;
using System.Net.Sockets;
using System.Threading;


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
        int i = 1;
        int myline;
        private MInterfaceClient clientModel;
        DispatcherTimer _timer = new DispatcherTimer();
        //////private bool mediaPlayerIsPlaying = false;
        private bool userIsDraggingSlider = false;
        private ObservableCollection<User> users1 = new ObservableCollection<User>();
        private ObservableCollection<User> users = new ObservableCollection<User>();
        private Mclient c = new Mclient("localhost", 5400);
        
        public MainWindow()
        {
            InitializeComponent();
            
          
            ////  _timer.Interval = TimeSpan.FromMilliseconds(1000);
            ////   _timer.Tick += new EventHandler(ticktock);
            ////   _timer.Start();

            ///  DispatcherTimer timer = new DispatcherTimer();
            ///  timer.Interval = TimeSpan.FromSeconds(1);
            /// timer.Tick += timer_Tick;
            ////  timer.Start();
            ////  List<User> items = new List<User>();

            ////
            ///
            users.Add(new User() { Name = "altimeter" });
          users.Add(new User() { Name = "airspeed" });
         users.Add(new User() { Name = "flight direction" });
           users.Add(new User() { Name = "roll" });

            users1.Add(new User() { Data = 0 });
            users1.Add(new User() { Data = 0 });
           /// users1.Add(new User() { Name = "flight direction" });
           /// users1.Add(new User() { Name = "roll" });
              users.Add(new User() { Name = "yaw" } );
              users.Add(new User() { Name = "pitch" });


       /////lbvvvvvUsers.ItemsSource = users1;
            lbUsers.ItemsSource = users;
          ////  users.Add(new User() { Name = "John Doe" });
         ///   users.Add(new User() { Name = "Jane Doe" });
        ///   items1.Add(new User() { Name = "altimeter" });
            /// items.Add(new User() { Name = "airspeed", Data = 39 });
            /// items.Add(new User() { Name = "flight direction", Data = 7 });
            ///  items.Add(new User() { Name = "roll", Data = 10 });
            /// items.Add(new User() { Name = "yaw", Data = +5 });
            /// items.Add(new User() { Name = "pitch", Data = -2 });
         ///   lvUsers.ItemsSource = items;
          ////  lvUsers.ItemsSource = users;

          
        ///    controllerViewModel = new ViewModelController(c);
            clientModel = c;
            controllerViewModel = new ViewModelController(c);
           //// this.DataContext = controllerViewModel;
            this.DataContext = new viewModelJoystick (c);
            ///   controllerViewModel = new ViewModelController(c);
            ////  this.DataContext = controllerViewModel;
            /// controllerViewModel.VM_XMLPath = "C:\\Program Files\\FlightGear 2020.3.6\\data\\Protocol\\playback_small.xml";
            ////  controllerViewModel.xmlPraser();
            controllerViewModel.VM_FGPath = "C:\\Program Files\\FlightGear 2020.3.6";
            controllerViewModel.VM_XMLPath = "C:\\Program Files\\FlightGear 2020.3.6\\data\\Protocol\\playback_small.xml";
           controllerViewModel.VM_fpath= "C:\\Program Files\\FlightGear 2020.3.6\\data\\Protocol\\reg_flight.csv";
            readCSVfile();
         
            controllerViewModel.splitAtt();
            controllerViewModel.xmlPraser();
            
            ThreadStart thread_Delegate = new ThreadStart(c.connect);
            Thread thread = new Thread(thread_Delegate);
            thread.Start();
           ///
         ///   a.Data = c.Altimeter;
        ///    items.Add(a);
            PlayButton_Click(this, null);
            ////sliderSeek.Maximum = c.RowsNumber;
            ///   controllerViewModel = new ViewModelController(c);
            ///  this.DataContext = controllerViewModel;
            //checking if FG folder is in the "normal" place
        }

   /*     private void btnChangeUser_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<User> usersnew = new ObservableCollection<User>();
            User altimeter0 = new User() { Name = "altimeter" };
            altimeter0.Data = c.Altimeter;
            User airspeed1 = new User() { Name = "airspeed" };
            airspeed1.Data = c.Airspeed;
            User flight_direction2 = new User() { Name = "flight direction" };
            flight_direction2.Data = (c.Flight_direction)*10;
            User roll3 = new User() { Name = "roll" };
            roll3.Data = (c.Roll)*10;
            User yaw4 = new User() { Name = "yaw" };
            yaw4.Data = (c.Yaw )* 10;
            User pitch5 = new User() { Name = "pitch" };
            pitch5.Data = (c.Pitch)*10;
            usersnew.Add(altimeter0);
            usersnew.Add(airspeed1);
         ///   usersnew.Add(flight_direction2);
         ///   usersnew.Add(roll3);
            /// users[0] = altimeter0;
            /// users[1] = airspeed1;
            /* users[2] = flight_direction2;
             users[3] = roll3;
             users[4] = yaw4;
             users[5] = pitch5;

          ////  lbUsers.ItemsSource = usersnew;
            ////lbvvvvvUsers.ItemsSource = usersnew;
            /* if (lbUsers.SelectedItem != null)
             {
                 //// (lbUsers.SelectedItem as User).Name = "Random Name";
                 (lbUsers.SelectedItem as User).Data = c.Altimeter;

             }*/

       /// }




        /*  private void timer_Tick(object sender, EventArgs e)
           {
               if ( (!userIsDraggingSlider))
               {

                   sliderSeek.Minimum = 0;
                   sliderSeek.Maximum = c.RowsNumber;


               }
           }*/
        void ticktock(object sender, EventArgs e)
        {
          /*if (!sliderSeek.IsMouseCaptureWithin)
            {
                sliderSeek.Value = Media.Position.TotalSeconds;
            }*/
        }

        private void Thorrule_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Thorrule.Value = (c.Throttle*10);
        }
        private void rudder_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            rudderSlider.Value = (c.Rudder*10);
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


        /// <summary>
        //////MEDIA LOAD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
   /*     private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Title = "Choose Media";
            if (dialog.ShowDialog() == true)
            {
                Media.Source = new Uri(dialog.FileName);
                MediaName.Text = dialog.FileName;

            }*/

        
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
            c.toPlay();
            /*if (Media.Source != null)
                Media.Play();*/
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            c.toStop();
           /* if (Media.CanPause)
                Media.Pause();*/
        }

     /*   private void StopButton_Click(object sender, RoutedEventArgs e)
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
        }*/

      /*  private void Balance_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Media.Balance = BalanceSlider.Value;
        }*/

        private void Speed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double x = SpeedSlider.Value;
            c.SleepTime = (int)(100 /x);



        }

        /* private void Media_MediaOpened(object sender, RoutedEventArgs e)
         {
           ////  Status.Fill = Brushes.Green;
            /* _position = Media.NaturalDuration.TimeSpan;
             sliderSeek.Minimum = 0;
             sliderSeek.Maximum = _position.TotalSeconds;

         }
        */

        /*    private void Media_MediaEnded(object sender, RoutedEventArgs e)
            {
                Status.Fill = Brushes.Blue;
            }

            private void Media_MediaFailed(object sender, ExceptionRoutedEventArgs e)
            {
                Status.Fill = Brushes.Red;
            }



            private void sliderSeek_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
            {
               /* int pos = Convert.ToInt32(sliderSeek.Value);
                Media.Position = new TimeSpan(0, 0, 0, pos, 0);*/
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        public int MyLine
        {
            get { return c.CurrentLineNumber; }
            set
            {
                if (this.myline != value)
                {
                    this.myline = value;
                    this.NotifyPropertyChanged("myline");
                }
            }
        }


        private void sliderSeek_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
        /* int pos = Convert.ToInt32(sliderSeek.Value);
        Media.Position = new TimeSpan(0, 0, 0, pos, 0);*/
    }

        private void sliderSeek_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }


        private void sliderSeek_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            c.CurrentLineNumber = (int)(sliderSeek.Value);

           /* if (sliderSeek.IsMouseCaptureWithin)
            {
               
            }*/
             /*   int pos = Convert.ToInt32();
                Media.Position = new TimeSpan(0, 0, 0, pos, 0); */
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_3(object sender, TextChangedEventArgs e)
        {

        }

        private void lbUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
    /*    private void sliProgress_DragStarted(object sender, DragStartedEventArgs e)
        {
           //// userIsDraggingSlider = true;
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

        }*/




    public class User : INotifyPropertyChanged
    {
        private string name;
        private float data;
        public string Name
        {
            get { return this.name; }
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    this.NotifyPropertyChanged("Name");
                }
            }
        }


        public float Data
        {
            get { return this.data; }
            set
            {
                if (this.data != value)
                {
                    this.data = value;
                    this.NotifyPropertyChanged("Data");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }












}
