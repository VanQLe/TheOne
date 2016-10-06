using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Unity;
using PrideTek.TheOne.Maintenance;
using PrideTek.TheOne.ClientServices;

namespace PrideTek.TheOne.MainApp
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            //registers
            Container.RegisterType(typeof(object), typeof(AppUserView), "AppUserView");
            Container.RegisterType(typeof(object), typeof(CustomerView), "CustomerView");
            Container.RegisterType<IAppUserClientService,AppUserClientService>();
            Container.RegisterType<ICustomerClientService, CustomerClientService>();
        }
    }
}
