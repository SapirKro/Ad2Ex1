using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ad2ex1;

using System.ComponentModel;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Windows;
using System.Xml;

namespace ad2ex1.Model
{
    public class Mclient : MInterfaceClient

    {
        private String IP="localhost";
        private int port = 5400;
        private List<string> propertiesNames;
        private int rowsNumber, sleepTime;
        private List<string> altimeterList, elevatorList;
        private List<string>  rudderList = new List<string>();
        private List<string> throttleList = new List<string>();
        private List<string> airspeedList = new List<string>();
        private List<string> aileronList = new List<string>();
        private List<string>  rollList = new List<string>()
            , pitchList = new List<string>(),
          yawList = new List<string>(), headingDegList = new List<string>();
        public event PropertyChangedEventHandler PropertyChanged;
        private float airspeed,yaw,roll,pitch, flight_direction, attitude;
        private float rudder, throttle, altimeter;
        private int currentLineNumber;
        private  string  xmlpath;
        List<List<string>> allMyPropertiesLists= new List<List<string>>();
        private int rudderIndex, throttleIndex, airspeedIndex, altimeterIndex,
            rollIndex, pitchIndex, yawIndex, headingDegIndex, aileronIndex, elevatorIndex;
        private String[] csvCopy;
        private float aileron, elevator, headingDeg;
      public bool isStop = false;
        public Mclient(String IP, int port)
        {
            this.port = port;
            this.IP = IP;
        }
        public void toStop()
        {
            isStop =true;
        }
        public void toPlay()
        {
            isStop = false;
           /// return true;
        }

        public float Roll
        {
            get
            {
                return roll;
            }
            set
            {
                if (Roll != value)
                {
                    roll = value;
                    NotifyPropertyChanged("roll");
                }
            }
        }
        public int CurrentLineNumber

        {
            get
            {
                return currentLineNumber;
            }
            set
            {
                if (CurrentLineNumber != value)
                {
                    currentLineNumber = value;
                    NotifyPropertyChanged("currentLineNumber");
                }
            }
        }
        public float Rudder
        {
            get
            {
                return rudder;
            }
            set
            {
                if (Rudder != value)
                {
                    rudder = value;
                    NotifyPropertyChanged("rudder");
                }
            }
        }

        public float HeadingDeg
        {
            get
            {
                return headingDeg;
            }
            set
            {
                if (HeadingDeg != value)
                {
                    headingDeg = value;
                    NotifyPropertyChanged("headingDeg");
                }
            }
        }

        public float Aileron
        {
            get
            {
                return aileron;
            }
            set
            {
                if (Aileron != value)
                {
                    aileron = value;
                    NotifyPropertyChanged("aileron");
                }
            }
        }
        public float Elevator
        {
            get
            {
                return elevator;
            }
            set
            {
                if (Elevator != value)
                {
                    elevator = value;
                    NotifyPropertyChanged("elevator");
                }
            }
        }

        public float Throttle
        {
            get
            {
                return throttle;
            }
            set
            {
                if (Throttle != value)
                {
                    throttle = value;
                    NotifyPropertyChanged("Throttle");
                }
            }
        }
        public List<string> PropertiesNames
        {
            get
            {
                return propertiesNames;
            }
            set
            {
                if (PropertiesNames != value)
                {
                    propertiesNames = value;
                    NotifyPropertyChanged("propertisNames");
                }

            }
        }

        public void indexsForProperties()
        {
            rudderIndex = PropertiesNames.FindIndex(a => a.Contains("rudder"));
            throttleIndex = PropertiesNames.FindIndex(a => a.Contains("throttle"));
            airspeedIndex = PropertiesNames.FindIndex(a => a.Contains("airspeed-kt"));
            altimeterIndex = PropertiesNames.FindIndex(a => a.Contains("altimeter_indicated-altitude-ft"));
            rollIndex = PropertiesNames.FindIndex(a => a.Contains("roll-deg"));
            pitchIndex = PropertiesNames.FindIndex(a => a.Contains("pitch-deg"));
            yawIndex = PropertiesNames.FindIndex(a => a.Contains("side-slip-deg"));
            headingDegIndex = PropertiesNames.FindIndex(a => a.Contains("heading-deg"));
            aileronIndex = PropertiesNames.FindIndex(a => a.Contains("aileron"));
            elevatorIndex = PropertiesNames.FindIndex(a => a.Contains("elevator"));
        }

       


        public List<List<string>> allPropertiesLists
        {
            get
            {
                return allMyPropertiesLists;
            }
            set
            {
                if (allPropertiesLists != value)
                {
                    allMyPropertiesLists = value;
                    NotifyPropertyChanged("allPropertiesLists");
                }

            }
        }
        public void extractData ()
        {
            rudderList = allPropertiesLists[rudderIndex];

            throttleList = allPropertiesLists[throttleIndex];
            airspeedList = allPropertiesLists[airspeedIndex];
            altimeterList = allPropertiesLists[altimeterIndex];
            rollList = allPropertiesLists[rollIndex];
            pitchList = allPropertiesLists[pitchIndex];
            yawList = allPropertiesLists[yawIndex];
            headingDegList = allPropertiesLists[headingDegIndex];
             aileronList = allPropertiesLists[aileronIndex];
                        elevatorList = allPropertiesLists[elevatorIndex];
                       Airspeed = float.Parse(airspeedList[currentLineNumber]);
                        Altimeter = float.Parse(altimeterList[currentLineNumber]);
                        Roll = float.Parse(rollList[currentLineNumber]);
                        Pitch = float.Parse(pitchList[currentLineNumber]);
                        Yaw = float.Parse(yawList[currentLineNumber]);
                        HeadingDeg = float.Parse(headingDegList[currentLineNumber]);
                        float rudderTemp = float.Parse(rudderList[currentLineNumber]);
                        float throttleTemp = float.Parse(throttleList[currentLineNumber]);
                        //calc new position for Rudder and Throttle
                        Rudder = rudderTemp * 108 + 108;
                        Throttle = throttleTemp * -226 + 226;
           ///////// MessageBox.Show("Throttle %d \n", Throttle,  MessageBoxButton.OK);
            //joystick properties
            float ail = float.Parse(aileronList[currentLineNumber]);
                        float elev = float.Parse(elevatorList[currentLineNumber]);
                        Aileron = ail * 50 + 60;
                        Elevator = elev * 50 + 60;
        }
        public float Attitude
        {
            get
            {
                return attitude;
            }
            set
            {
                if (Attitude != value)
                {
                    attitude = value;
                    NotifyPropertyChanged("attitude");
                }
            }
        }
        private String CSVfilePath;
        public string CSVFilePath
        {
            get
            {
                return CSVfilePath;
            }
            set
            {
                if (CSVFilePath != value)
                    CSVfilePath = value;
            }
        }
        public float Flight_direction
        {
            get
            {
                return flight_direction;
            }
            set
            {
                if (Flight_direction != value)
                {
                    flight_direction = value;
                    NotifyPropertyChanged("flight_direction");
                }
            }
        }


        public float Altimeter
        {
            get
            {
                return altimeter;
            }
            set
            {
                if (Altimeter != value)
                {
                    altimeter = value;
                    NotifyPropertyChanged("altimeter");
                }
            }
        }


        public float Airspeed
        {
            get
            {
                return airspeed;
            }
            set
            {
                if (Airspeed != value)
                {
                    airspeed = value;
                    NotifyPropertyChanged("Airspeed");
                }
            }
        }
        

               public int RowsNumber
        {
            get
            {
                return rowsNumber;
            }
            set
            {
                if (RowsNumber != value)
                {
                    rowsNumber = value;
                    NotifyPropertyChanged("RowsNumber");
                }
            }
        }
        public float Yaw
        {
            get
            {
                return yaw;
            }
            set
            {
                if (Yaw != value)
                {
                    yaw = value;
                    NotifyPropertyChanged("yaw");
                }
            }
        }
        public String[] CSVcopy
        {
            get
            {
                return csvCopy;
            }
            set
            {
                if (CSVcopy != value)
                {
                    csvCopy = value;
                }
            }
        }
        public int SleepTime
        {
            get
            {
                return sleepTime;
            }
            set
            {
                if (SleepTime != value)
                {
                    sleepTime = value;
                    NotifyPropertyChanged(" sleepTime");
                }
            }
        }

        public float Pitch
        {
            get
            {
                return pitch;
            }
            set
            {
                if (Pitch != value)
                {
                    pitch = value;
                    NotifyPropertyChanged("pitch");
                }
            }
        }

        public void xmlParser()
        {
            propertiesNames = new List<string>();
            XmlDocument doc = new XmlDocument();
            doc.Load(XMLPath);
            //finding the output node 
            XmlNode node = doc.DocumentElement.SelectSingleNode("/PropertyList/generic/output");
            //iterating all childer nodes in output node
            foreach (XmlNode n in node)
            {
                //checking if node names equals to chunck - if it is - taking name attribute from chunck
                if (n.LocalName.Equals("chunk"))
                {
                    string name = n.SelectSingleNode("name").InnerText;
                    propertiesNames.Add(name);
                }
            }

        }

        public void attSplit(string[] csvFile)
        {
            int counter = 0;
            //iterating array - splitting every cell (line) in array
            foreach (string line in csvFile)
            {
                
                string[] curr = line.Split(',');
                //adding attributes to the right header list
                for (int i = 0; i < curr.Length; i++)
                {
                    if (counter <= curr.Length - 1)
                    {
                        allMyPropertiesLists.Add(new List<string>());
                        counter++;
                    }
                    allMyPropertiesLists[i].Add(curr[i]);
                }
            }
        }
        public String XMLPath
        {
            get
            {
                return xmlpath;
            }
            set
            {
                if (XMLPath != value)
                {
                    xmlpath = value;
                    NotifyPropertyChanged("XMLpath");
                }
            }
        }

        

        public void joyStickPos()
        {
            aileronList = allPropertiesLists[aileronIndex];
            elevatorList = allPropertiesLists[elevatorIndex];
            //convert string to float
            float ail = float.Parse(aileronList[currentLineNumber]);
            float elev = float.Parse(elevatorList[currentLineNumber]);
            //"normalized" value for joystick postion
            Aileron = ail * 30 + 48;
            Elevator = elev * 30 + 48;
        }

        /*
                float MInterfaceClient.Yaw { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
                float MInterfaceClient.Roll { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
                float MInterfaceClient.Pitch { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
                float MInterfaceClient.Altimeter { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
                float MInterfaceClient.Airspeed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
                float MInterfaceClient.Flight_direction { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
                float MInterfaceClient.Attitude { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        */

        /*--generic=socket,in,10,127.0.0.1,5400,tcp,playback_small\n--fdm = null"*/
        public void connect()
        {
           

            try
            {
               TcpClient client = new TcpClient(IP, port);
               var clientNetworkStream = client.GetStream();
                //put all CSV into allCSVLines 
                String[] allCSVLines = File.ReadAllLines(CSVfilePath);
                //saving the number of rows
                rowsNumber = allCSVLines.Length;
                    sleepTime = 100;
                // while loope - as long there is data to send - send one line at a time to server
                // sending one line at a time to server
                                while (rowsNumber > currentLineNumber)
                {
                         allCSVLines[currentLineNumber] += "\n";
                    //encode current line to byte to write to server
                    Byte[] currentLineBytes = System.Text.Encoding.ASCII.GetBytes(allCSVLines[currentLineNumber]);
                    // send the line encoding to server
                    clientNetworkStream.Write(currentLineBytes, 0, currentLineBytes.Length);
                    /*  //calculating joystick position*/
                      joyStickPos();
                    // get flight variables new position
                    extractData();
                    //inc index to next line
                    if (isStop == false)
                    {
                        currentLineNumber++;
                    }
                    //sleep until need to check again 
                    Thread.Sleep(sleepTime);
                }
           
                clientNetworkStream.Close();
                client.Close();
            }
            
            catch (Exception e1)
            {
                MessageBox.Show("Error\nDid you start flight gear?\n", "Error", MessageBoxButton.OK);
                
            }

        }


                public void NotifyPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
      
      
    }


}
