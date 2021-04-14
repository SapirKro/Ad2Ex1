using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using ad2ex1.Model;

namespace ad2ex1.ViewModel
{
   


    public class JoystickVM : INotifyPropertyChanged
    {
  
        private MInterfaceClient myClient;
        public event PropertyChangedEventHandler PropertyChanged;

        public float aileronVM
        {
            get
            {
                return myClient.Aileron; ;
            }
            set
            {
                if (aileronVM != value)
                {
                    myClient.Aileron = value;
                    onPropertyChanged("aileronVM");
                }
            }
        }
        public float elevatorVM
        {
            get
            {
                return myClient.Elevator;
            }
            set
            {
                if (elevatorVM != value)
                {
                    myClient.Elevator = value;
                    onPropertyChanged("elevatorVM");
                }
            }
        }
        public float rudderVM
        {
            get
            {
                return myClient.Rudder;
            }
            set
            {
                if (rudderVM != value)
                {
                    myClient.Rudder = value;
                    onPropertyChanged("rudderVM");
                }
            }
        }
        public int currentLineNumberVM

        {
            get
            {
                return myClient.CurrentLineNumber;
            }
        }

        public float throttleVM
        {
            get
            {
                return myClient.Throttle;
            }
            set
            {
                if (throttleVM != value)
                {
                    myClient.Throttle = value;
                    onPropertyChanged("throttleVM");
                }
            }
        }
        public float airspeedVM
        {
            get
            {
                return myClient.Airspeed;
            }
            set
            {
                if (airspeedVM != value)
                {
                    myClient.Airspeed = value;
                    onPropertyChanged("airspeedVM");
                }
            }
        }
        public float altimeterVM
        {
            get
            {
                return myClient.Altimeter;
            }
            set
            {
                if (altimeterVM != value)
                {
                    myClient.Altimeter = value;
                    onPropertyChanged("altimeterVM");
                }
            }
        }
        public float rollVM
        {
            get
            {
                return myClient.Roll;
            }
            set
            {
                if (rollVM != value)
                {
                    myClient.Roll = value;
                    onPropertyChanged("rollVM");
                }
            }
        }
        public float yawVM
        {
            get
            {
                return myClient.Yaw;
            }
            set
            {
                if (yawVM != value)
                {
                    myClient.Yaw = value;
                    onPropertyChanged("yawVM");
                }
            }
        }
        public float pitchVM
        {
            get
            {
                return myClient.Pitch;
            }
            set
            {
                if (pitchVM != value)
                {
                    myClient.Pitch = value;
                    onPropertyChanged("pitchVM");
                }
            }
        }
        public float HeadingDegVM
        {
            get
            {
                return myClient.HeadingDeg;
            }
            set
            {
                if (HeadingDegVM != value)
                {
                    myClient.HeadingDeg = value;
                    onPropertyChanged("HeadingDegVM");
                }
            }
        }
     
        public JoystickVM(MInterfaceClient c)
        {
            myClient = c;
            myClient.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                onPropertyChanged(e.PropertyName+"VM");
            };
      
          resetData();
        }
       public void resetData()
        {
   
            myClient.Airspeed = 0;
            myClient.Altimeter = 0;
            myClient.Roll = 0;
            myClient.Pitch = 0;
            myClient.Yaw = 0;
            myClient.HeadingDeg = 0;
          
        }
        public void onPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        public void connect()
        {
            myClient.connect();
        }
    }
}
