using PrideTek.TheOne.ClientServices;
using PrideTek.TheOne.Maintenance.ViewModels;
using PrideTek.TheOne.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for CustomerView.xaml
    /// </summary>
    public partial class CustomerView : UserControl
    {
        public CustomerView()
        {
            InitializeComponent();

            if (DesignerProperties.GetIsInDesignMode(this))
            {
                DataContext = new CustomerViewVM();
            }
            else
            {
                DataContext = new CustomerViewVM(new ClientServices<Customer>());
            }
        }
    }
}
