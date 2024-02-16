using Autodesk.Revit.UI;
using NodeNetwork.ViewModels;
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
using SystemNodeHelper.ViewModel;

namespace SystemNodeHelper.View
{
    /// <summary>
    /// MainDockablePane.xaml 的交互逻辑
    /// </summary>
    public partial class MainDockablePane : Page, Autodesk.Revit.UI.IDockablePaneProvider
    {
        public MainDockablePane()
        {
            InitializeComponent();

            //var mainDockableModel = new MainDockableViewModel();
            //mainDockablePaneControl.DataContext = mainDockableModel;
        }
        public MainDockablePaneControl MainDockablePaneControl
        {

            get
            {

                return mainDockablePaneControl;
            }
        }
        public NetworkViewModel Network { get { return mainDockablePaneControl.ViewModel.Network;} }

        public void SetupDockablePane(DockablePaneProviderData data)
        {
            data.FrameworkElement = this as FrameworkElement;
            data.InitialState = new DockablePaneState
            {
                DockPosition = DockPosition.Right
            };
        }
    }
}
