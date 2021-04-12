using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Windows;
using System.Xml;

namespace ad2ex1.Model
{
   public interface MInterfaceClient : INotifyPropertyChanged

    {

        string CSVFilePath
        {
            get;
            set;
        }
        float Yaw
        {
            get;
            set;
        }

        float Roll
        {
            get;
            set;
        }
        List<List<string>> allPropertiesLists
        {
            get;
        }
        List<string> PropertiesNames
        {
            get;
            set;
        }
        int CurrentLineNumber
        {
            get;
            set;
        }
        float Pitch
        {
            get;
            set;
        }
        float Altimeter
        {
            get;
            set;
        }

        float Airspeed
        {
            get;
            set;
        }

        float Flight_direction
        {
            get;
            set;
        }

        float Attitude
        {
            get;
            set;
        }

        float Rudder
        {
            get;
            set;
        }
        float Throttle
        {
            get;
            set;
        }
        float Aileron
        {
            get;
            set;
        }
        float Elevator
        {
            get;
            set;
        }
        float HeadingDeg
        {
            get;
            set;
        }
    }
}
