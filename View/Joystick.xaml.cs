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
using ad2ex1.ViewModel;
using ad2ex1.Model;
namespace ad2ex1.View
{
    /// <summary>
    /// interaction logic for UserControl1.xaml
    /// </summary>
    public partial class Joystick : UserControl
    {
        public viewModelJoystick joystickVM;
        public Joystick(MInterfaceClient c)
        {
            InitializeComponent();
            joystickVM = new viewModelJoystick(c);
            DataContext = joystickVM;
           //// Loaded += JoystickView_Loaded;
        }
    }
}
