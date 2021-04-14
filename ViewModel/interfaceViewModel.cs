using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ad2ex1.View;

using System.ComponentModel;

namespace ad2ex1.ViewModel
{
    public interface interfaceViewModel : INotifyPropertyChanged
    {
        string flightGearPathVM
        {
            get;
            set;
        }
        string XMLFilePathVM
        {
            get;
            set;
        }
        float RollVM
        {
            get;
        }
        int CurrentLineNumberVM

        {
            get;
            set;
        }
        float RudderVM
        {
            get;
        }

        float HeadingDegVM
        {
            get;

        }

        float AileronVM
        {
            get;

        }
        float ElevatorVM
        {
            get;

        }

        float ThrottleVM
        {
            get;
        }
        List<string> PropertiesNamesVM
        {
            get;

        }

     /*   TimeSpan VM_Time
        {
            get;
            set;
        }*/
        int LineNumberVM
        {
            get;
            set;
        }
        string filePathVM
        {
            get;
            set;
        }
        List<string> dataNamesVM
        {
            get;
        }
        float AttitudeVM
        {
            get;
        }

        float Flight_DirectionVM
        {
            get;
        }
        float AltimeterVM
        {
            get;
        }


        float AirspeedVM
        {
            get;
        }


        int RowsNumberVM
        {
            get;
        }
        float YawVM
        {
            get;
        }

        int SleepTimeVM
        {
            get;
            set;
        }

        float PitchVM
        {
            get;
        }
        
        String[] CSVcopyVM
        {
            get;
            set;
        }


       
        
        string CSVFilePathVM
        {
            get;
            set;
        }
       
        void xml1Split();
        
       List<List<string>> allPropertiesListsVM
        {
            get;
        }
         void data0Split();
        void data1Split(string[] csvFile);

        void connect();
    }
}

