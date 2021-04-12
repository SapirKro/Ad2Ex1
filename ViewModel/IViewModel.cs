using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ad2ex1.View;

using System.ComponentModel;

namespace ad2ex1.ViewModel
{
    public interface IViewModel : INotifyPropertyChanged
    {
        string VM_FGPath
        {
            get;
            set;
        }
        string VM_XMLPath
        {
            get;
            set;
        }

    }
}
