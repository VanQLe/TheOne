using PrideTek.TheOne.Maintenance.Data;
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

namespace PrideTek.TheOne.Maintenance
{
    /// <summary>
    /// Interaction logic for AppUserViewl.xaml
    /// </summary>
    public partial class AppUserView : UserControl
    {
        public AppUserView()
        {
            InitializeComponent();
            DataContext = new AppUserViewModel();
        }

       
    }
}
