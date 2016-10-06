//using Prism.Commands;
//using Prism.Mvvm;
//using Prism.Regions;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


//namespace PrideTek.TheOne.Maintenance.ViewModels
//{
//    public class MainWindowViewModel : BindableBase
//    {
//        private readonly IRegionManager _regionManger;

//        public DelegateCommand<string> NaviagteCommand { get; set; }

//        public MainWindowViewModel()
//        {
//            _regionManger = new RegionManager();
//        }
//        public MainWindowViewModel(IRegionManager regionManger)
//        {
//            _regionManger = regionManger;
//            NaviagteCommand = new DelegateCommand<string>(Navigate);
//        }

//        private void Navigate(string uri)
//        {
//            _regionManger.RequestNavigate("ContentRegion", uri);
//        }
//    }
//}
