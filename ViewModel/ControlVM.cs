using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ad2ex1.Model;

using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Windows;

namespace ad2ex1.ViewModel
{

        public class ControlVM : interfaceViewModel
    {
       
            private MInterfaceClient myClient;
          
            private string flightGearEXEPath;
       
                  public event PropertyChangedEventHandler PropertyChanged;
       
           
         /*   public List<List<string>> VM_currentAtt
            {
                get
                {
                    return myClient.allPropertiesLists;
                }

            }*/
        public string CSVFilePathVM
        {
            get
            {
                return myClient.CSVFilePath;
            }
            set
            {
                myClient.CSVFilePath = value;
            }
        }
   
        public float RollVM
        {
            get
            {
                return myClient.Roll;
            }
        }
        public int CurrentLineNumberVM

        {
            get
            {
                return myClient.CurrentLineNumber;
            }
            set
            {
                if(CurrentLineNumberVM != value)
                {
                    CurrentLineNumberVM = value;
                    myClient.CurrentLineNumber = value;
                }
            }
        }
        public float RudderVM
        {
            get
            {
                return myClient.Rudder;
            }
        }

        public float HeadingDegVM
        {
            get
            {
                return myClient.HeadingDeg;
            }
            
        }
        public String[] CSVcopyVM
        {
            get
            {
                return myClient.CSVFilecopy;
            }
            set
            {
                if (CSVcopyVM != value)
                    myClient.CSVFilecopy = value;
            }
        }
        public float AileronVM
        {
            get
            {
                return myClient.Aileron;
            }
            
        }
        public float ElevatorVM
        {
            get
            {
                return myClient.Elevator;
            }
            
        }

        public float ThrottleVM
        {
            get
            {
                return myClient.Throttle;
            }
            
        }
        public List<string> PropertiesNamesVM
        {
            get
            {
                return myClient.PropertiesNames;
            }
            
        }

       /* public TimeSpan VM_Time
            {
                get
                {
                    return Time;
                }
                set
                {
                    if (VM_Time != value)
                    {
                        Time = value;
                        onPropertyChanged("VM_Time");
                    }
                }
            }*/
            public int LineNumberVM
            {
                get
                {
                    return myClient.CurrentLineNumber;
                }
                set
                {
                    if (LineNumberVM != value)
                    {
                        myClient.CurrentLineNumber = value;
                        onPropertyChanged("LineNumberVM");
                    }
                }
            }
            public string filePathVM
            {
                get
                {
                    return myClient.CSVFilePath;
                }
                set
                {
                    if (filePathVM != value)
                    {
                        myClient.CSVFilePath= value;
                        onPropertyChanged("filePathVM");
                    }


                }
            }
            public string XMLFilePathVM
            {
                get
                {
                    return myClient.XMLFilePath;
                }
                set
                {
                    if (XMLFilePathVM != value)
                        myClient.XMLFilePath = value;
                }
            }
            public string flightGearPathVM
            {
                get
                {
                    return flightGearEXEPath;
                }
                set
                {
                    if (flightGearPathVM != value)
                        flightGearEXEPath = value;
                }
            }
            public List<string> dataNamesVM
            {
                get
                {
                return myClient.PropertiesNames;
                }
            }
        public float AttitudeVM
        {
            get
            {
                return myClient.Attitude;
            }
        }

        public float Flight_DirectionVM
        {
            get
            {
                return myClient.Flight_Direction;
            }
        }
        public float AltimeterVM
        {
            get
            {
                return myClient.Altimeter;
            }
        }


        public float AirspeedVM
        {
            get
            {
                return myClient.Airspeed;
            }
        }


        public int RowsNumberVM
        {
            get
            {
                return myClient.RowsNumber;
            }
        }
        public float YawVM
        {
            get
            {
                return myClient.Yaw;
            }            
        }

        public int SleepTimeVM
        {
            get
            {
                return myClient.SleepTime;
            }
            set
            {
                if(SleepTimeVM != value)
                {
                    SleepTimeVM = value;
                    myClient.SleepTime = value;
                }
            }
        }

        public float PitchVM
        {
            get
            {
                return myClient.Pitch;
            }            
        }

        

        public void onPropertyChanged(string propName)
            {
                if (PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
                }
            }
        /// <summary>
        /// /counstrector
        /// </summary>
        /// <param name="m"></param>
            public ControlVM(MInterfaceClient m)
            {
                this.myClient = m;
             
                myClient.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
                {
                    onPropertyChanged( e.PropertyName+"VM" );
                };
            }
        public void connect()
        {
            myClient.connect();
        }

        public void xmlSplit()
        {
            myClient.xmlSplit();
        }

        public List<List<string>> allPropertiesListsVM
        {
            get
            {
                return myClient.allPropertiesLists;
            }
        }
    
        public void copyXML()
            {
                string srcfileName = "\\data\\Protocol\\playback_small.xml";
                string destetionFile = flightGearPathVM + srcfileName;
                    try
                {
                    File.Copy(XMLFilePathVM, destetionFile, true);
                }
                catch (UnauthorizedAccessException)
                {
           
                    MessageBox.Show("UnAuthorizedAccessException", "Error", MessageBoxButton.OK);
                }
            }
            public void data0Split()
            {
                myClient.dataSplit(this.CSVcopyVM);
            }
            public void xml1Split()
            {
                myClient.xmlSplit();
            }

            public void data1Split(string[] csvFile)
        {
            myClient.dataSplit(csvFile);
        }
    }
    
}
