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

        public class ViewModelController : IViewModel
        {
            /***Data Members***/
            private MInterfaceClient clientModel;
            public bool isConnected;
            private double playSpeed;
            private string FGPath;
            private Thread connectThread;
            private TimeSpan Time;
            public event PropertyChangedEventHandler PropertyChanged;
            /***Properties***/
            public String[] VM_CSVcopy
            {
                get
                {
                    return clientModel.CSVcopy;
                }
                set
                {
                    if (VM_CSVcopy != value)
                        clientModel.CSVcopy = value;
                }
            }
            public List<List<string>> VM_currentAtt
            {
                get
                {
                    return clientModel.allPropertiesLists;
                }

            }
            public double VM_playSpeed
            {
                get
                {
                    return playSpeed;
                }
                set
                {
                    if (playSpeed != value)
                    {
                        playSpeed = value;
                        onPropertyChanged("VM_playSpeed");
                    }
                }
            }
            public int VM_TransSpeed
            {
                get
                {
                    return clientModel.SleepTime;
                }
                set
                {
                    if (VM_playSpeed != value)
                        clientModel.SleepTime = value;
                }
            }
            public int VM_simLen
            {
                get
                {
                    return clientModel.RowsNumber;
                }

            }
            public TimeSpan VM_Time
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
            }
            public int VM_lineNumber
            {
                get
                {
                    return clientModel.CurrentLineNumber;
                }
                set
                {
                    if (VM_lineNumber != value)
                    {
                        clientModel.CurrentLineNumber = value;
                        onPropertyChanged("VM_lineNumber");
                    }
                }
            }
            public string VM_fpath
            {
                get
                {
                    return clientModel.CSVFilePath;
                }
                set
                {
                    if (VM_fpath != value)
                    {
                        clientModel.CSVFilePath= value;
                        onPropertyChanged("VM_path");
                    }


                }
            }
            public string VM_XMLPath
            {
                get
                {
                    return clientModel.XMLPath;
                }
                set
                {
                    if (VM_XMLPath != value)
                        clientModel.XMLPath = value;
                }
            }
            public string VM_FGPath
            {
                get
                {
                    return FGPath;
                }
                set
                {
                    if (VM_FGPath != value)
                        FGPath = value;
                }
            }
            public List<string> VM_headerNames
            {
                get
                {
                return clientModel.PropertiesNames;
                }
            }
            /***Methods***/
            public void onPropertyChanged(string propName)
            {
                if (PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
                }
            }
            public ViewModelController(MInterfaceClient m)
            {
                this.clientModel = m;
                playSpeed = 0;
                Time = new TimeSpan(0, 0, 0);
                isConnected = false;
                clientModel.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
                {
                    onPropertyChanged("VM_" + e.PropertyName);
                };
            }
            public void connect()
            {
                //checking if there is path for FG
                if (VM_fpath != null)
                {
                    //checking if thread is already exist and alive - if not creating new thread for connection
                    if (connectThread == null || !connectThread.IsAlive)
                    {
                        connectThread = new Thread(delegate ()
                        {
                            clientModel.connect();
                            isConnected = false;
                        });
                    }
                    //if thread is suspend - resume thread
                    if ((connectThread.ThreadState & ThreadState.Suspended) == ThreadState.Suspended)
                    {
                        resumeConnection();
                    }
                    else //start connection
                    {
                        isConnected = true;
                        connectThread.Start();
                    }
                }
                else
                {
                    //if user didn't load any csv file
                    MessageBox.Show("Please load a CSV and XML file before running the simulation", "File Missing", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            /*setting up time - every second passed*/
            public void settingUpTime()
            {
                int min, sec, hours;
                //regular streaming is 10 line in second (sleep of 100 milsec) - calculating time accordingly
                sec = VM_lineNumber / 10;
                min = VM_lineNumber / 600;
                hours = VM_lineNumber / 6000;
                VM_Time = new TimeSpan(hours, min, sec);
            }
            public void resumeConnection()
            {
                connectThread.Resume();
            }
            public void pauseConnection()
            {
                if (connectThread != null && connectThread.IsAlive)
                    connectThread.Suspend();
            }
            /*copy XML if doesn't in protocol folder. User should select XML file*/
            public void copyXML()
            {
                //destfolder should be in protocol folder of FG folder
                string fileName = "\\data\\Protocol\\playback_small.xml";
                string destFile = VM_FGPath + fileName;
                //trying copy file
                try
                {
                    File.Copy(VM_XMLPath, destFile, true);
                }
                catch (UnauthorizedAccessException)
                {
                    //if user doesn't have any authorized to copy file
                    MessageBox.Show("UnAuthorizedAccessException: Unable to access file.\nPleae Allow access and than try again.", "Access Denied", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            public void splitAtt()
            {
                clientModel.attSplit(this.VM_CSVcopy);
            }
            public void xmlPraser()
            {
                clientModel.xmlParser();
            }
        }
    
}
