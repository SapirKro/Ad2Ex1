using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ad2ex1;
using System.Windows.Forms;
using System.ComponentModel;
using System.IO;
using System.Net.Sockets;
using System.Threading;
///using System.Windows;
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
        private String[] csvfileCopy;
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
                    NotifyPropertyChanged("throttle");
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
            rudderIndex = PropertiesNames.FindIndex(x => x.Contains("rudder"));
         
                       aileronIndex = PropertiesNames.FindIndex(x => x.Contains("aileron"));
            elevatorIndex = PropertiesNames.FindIndex(x => x.Contains("elevator"));
            yawIndex = PropertiesNames.FindIndex(x => x.Contains("side-slip-deg"));
            rollIndex = PropertiesNames.FindIndex(x => x.Contains("roll-deg"));
            headingDegIndex = PropertiesNames.FindIndex(x => x.Contains("heading-deg"));
            throttleIndex = PropertiesNames.FindIndex(x => x.Contains("throttle"));
            airspeedIndex = PropertiesNames.FindIndex(x => x.Contains("airspeed-kt"));
            altimeterIndex = PropertiesNames.FindIndex(x => x.Contains("altimeter_indicated-altitude-ft"));
            pitchIndex = PropertiesNames.FindIndex(x => x.Contains("pitch-deg"));
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
     /*   public void extractData ()
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
        }*/
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
        public float Flight_Direction
        {
            get
            {
                return flight_direction;
            }
            set
            {
                if (Flight_Direction != value)
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
                    NotifyPropertyChanged("airspeed");
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
                    NotifyPropertyChanged("rowsNumber");
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
        public String[] CSVFilecopy
        {
            get
            {
                return csvfileCopy;
            }
            set
            {
                if (CSVFilecopy != value)
                {
                    csvfileCopy = value;
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
                    NotifyPropertyChanged("SleepTime");
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

        public void xmlSplit()
        {
            propertiesNames = new List<string>();
            XmlDocument doc = new XmlDocument();
            doc.Load(XMLFilePath);

            XmlNode node = doc.DocumentElement.SelectSingleNode("/PropertyList/generic/output");
               foreach (XmlNode n in node)
            {
                 if (n.LocalName.Equals("chunk"))
                {
                    string name = n.SelectSingleNode("name").InnerText;
                    propertiesNames.Add(name);
                }
            }

        }

        public void dataSplit(string[] csvFile)
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
        public String XMLFilePath
        {
            get
            {
                return xmlpath;
            }
            set
            {
                if (XMLFilePath != value)
                {
                    xmlpath = value;
                    NotifyPropertyChanged("XMLFilePath");
                }
            }
        }

        

     /*   public void joyStickPos()
        {
            aileronList = allPropertiesLists[aileronIndex];
            elevatorList = allPropertiesLists[elevatorIndex];
            //convert string to float
            float ail = float.Parse(aileronList[currentLineNumber]);
            float elev = float.Parse(elevatorList[currentLineNumber]);
            //"normalized" value for joystick postion
            Aileron = ail * 30 + 48;
            Elevator = elev * 30 + 48;
        }*/

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
             ///  TcpClient client = new TcpClient(IP, port);
                TcpClient client1 = new TcpClient();

                Console.WriteLine("trying to connect....");
                ///client1.Connect(IP, port);
                while (!(client1.Connected))
                {
                    try
                    {
                        client1.Connect(IP, port);
                    }
                    catch
                    {
                        
                        Console.WriteLine("trying again to connect in 1 second....");
                        Thread.Sleep(1000);
                    }
                   
                   
                }
               
                Console.WriteLine("client connect!");
                var clientNetworkStream = client1.GetStream();
                //put all CSV into allCSVLines 
                String[] allCSVLines = File.ReadAllLines(CSVfilePath);
                //saving the number of rows
                rowsNumber = allCSVLines.Length;
                    sleepTime = 100;
                string[] words;
          
                  while (rowsNumber > currentLineNumber)
                {
                    words = allCSVLines[currentLineNumber].Split(',');
                    Throttle = float.Parse(words[6]);
                    Aileron = float.Parse(words[0]);
                    Airspeed = float.Parse(words[21]);
                    Altimeter = float.Parse(words[25]);
                    Elevator = float.Parse(words[1]);
                    HeadingDeg = float.Parse(words[19]);
                    Pitch = float.Parse(words[18]);
                    Roll = float.Parse(words[17]);
                    Rudder = float.Parse(words[2]);
                    Yaw = float.Parse(words[yawIndex]);
                    
                    allCSVLines[currentLineNumber] += "\n";
                    //encode current line to byte to write to server
                    Byte[] currentLineBytes = System.Text.Encoding.ASCII.GetBytes(allCSVLines[currentLineNumber]);
                    // send the line encoding to server
                    clientNetworkStream.Write(currentLineBytes, 0, currentLineBytes.Length);
                    /*  //calculating joystick position*/
                 ////     joyStickPos();
                    // get flight variables new position
                 
                    //inc index to next line
                    if (isStop == false)
                    {
                        CurrentLineNumber++;
                    }
                    //sleep until need to check again 
                    Thread.Sleep(sleepTime);
                }
           
                if(rowsNumber <= currentLineNumber)
                {
                    DialogResult dialogResult = MessageBox.Show("Flight record end.Do you want to restart the flight?", "End Record", MessageBoxButtons.YesNoCancel);
                 if(dialogResult == DialogResult.Yes)
{currentLineNumber=0;
                        
                      

                          clientNetworkStream.Close();
                client1.Close();
    connect();
}
//if no:
                }*/
                clientNetworkStream.Close();
                client1.Close();
            }
            
            catch (Exception e1)
            {
               /// MessageBox.Show("Error\nDid you start flight gear?\ntrying again..", "Error", MessageBoxButton.OK);
               DialogResult dialogResult = MessageBox.Show("Error\nDid you start flight gear?\ntrying again..", "Error", MessageBoxButtons.OK);
           
                connect();


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
