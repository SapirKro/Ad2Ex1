using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;using System.Windows;
using System.Windows.Forms;
using DialogResult = System.Windows.Forms.DialogResult;

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

using MessageBox = System.Windows.Forms.MessageBox;

using System.IO;
using System.Net.Sockets;
using System.Threading;




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
        public interfaceViewModel controllerVM;
    /////    TimeSpan _position;
        int i = 1;
        int myline;
        private MInterfaceClient myClient;
        DispatcherTimer _timer = new DispatcherTimer();
        //////private bool mediaPlayerIsPlaying = false;
       //////// private bool userIsDraggingSlider = false;
        private ObservableCollection<User> users1 = new ObservableCollection<User>();
        private ObservableCollection<User> users = new ObservableCollection<User>();
        private Mclient c = new Mclient("localhost", 5400);
        
        public MainWindow()
        {

            myClient = c;
            controllerVM = new ControlVM(myClient);
            this.DataContext = controllerVM;
            //// this.DataContext = controllerVM;
            JoystickVM m = new JoystickVM(myClient);
            this.DataContext = m;

            InitializeComponent();
            ////  _timer.Interval = TimeSpan.FromMilliseconds(1000);
           
            users.Add(new User() { Name = "altimeter" });
          users.Add(new User() { Name = "airspeed" });
         users.Add(new User() { Name = "flight direction" });
           users.Add(new User() { Name = "roll" });

            users1.Add(new User() { Data = 0 });
            users1.Add(new User() { Data = 0 });
         
              users.Add(new User() { Name = "yaw" } );
              users.Add(new User() { Name = "pitch" });


      
            lbUsers.ItemsSource = users;
      
            controllerVM.flightGearPathVM = "C:\\Program Files\\FlightGear 2020.3.6";
            controllerVM.XMLFilePathVM = "C:\\Program Files\\FlightGear 2020.3.6\\data\\Protocol\\playback_small.xml";
           controllerVM.filePathVM= "C:\\Program Files\\FlightGear 2020.3.6\\data\\Protocol\\reg_flight.csv";
            readCSVfile();

            controllerVM.data0Split();
            controllerVM.xml1Split();
            
            ThreadStart thread_Delegate = new ThreadStart(m.connect);
            Thread thread = new Thread(thread_Delegate);
            thread.Start();
       
            PlayButton_Click(this, null);
       
        }

 
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


   
        private void readCSVfile()
        {
            String[] csvLine = File.ReadAllLines(controllerVM.filePathVM);
            controllerVM.CSVcopyVM = csvLine;
        }
        private void LoadCSV_Click(object sender, RoutedEventArgs e)
        {
          
         
            var dialog1 = new OpenFileDialog();
            dialog1.Title = "Choose CSV";
            if (dialog1.ShowDialog() == true)
            {
                controllerVM.filePathVM = dialog1.FileName;
                
            }
            readCSVfile();
            controllerVM.data0Split();
            PlayButton_Click(this, null);
            
        }

        private void LoadXML_Click(object sender, RoutedEventArgs e)
        {
           //// controllerVM.XMLFilePathVM = "C:\\Program Files\\FlightGear 2020.3.6\\data\\Protocol\\playback_small.xml";
            ////  
            var dialog2 = new OpenFileDialog();
            dialog2.Title = "Choose XML";
            if (dialog2.ShowDialog() == true)
            {
                controllerVM.XMLFilePathVM = dialog2.FileName;

            }
            controllerVM.xml1Split();
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            c.toPlay();
           
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            c.toStop();
          
        }

   
        private void Speed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double x = SpeedSlider.Value;
            c.SleepTime = (int)(100 /x);
            



        }

     
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
             /*      String[] allCSVLines = File.ReadAllLines(controllerVM.filePathVM);
                //saving the number of rows
              int  rowsNumber = allCSVLines.Length;
            if (((int)(sliderSeek.Value)) >= rowsNumber)
            {
            sliderSeek.Value=0;
                sliderSeek.
                }
             */
            
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

        private void onScreenJoystick_Loaded(object sender, RoutedEventArgs e)
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
