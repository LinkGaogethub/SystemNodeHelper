using DynamicData;
using DynamicData.Binding;
using NodeNetwork.ViewModels;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
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
    /// MainDockablePaneControl.xaml 的交互逻辑
    /// </summary>
    public partial class MainDockablePaneControl : UserControl, IViewFor<MainDockableViewModel>
    {
        #region ViewModel
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
            typeof(MainDockableViewModel), typeof(MainDockablePaneControl), new PropertyMetadata(null));

        public MainDockableViewModel ViewModel
        {
            get => (MainDockableViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (MainDockableViewModel)value;
        }


        #endregion
        public MainDockablePaneControl()
        {
            InitializeComponent();

            var network = new NetworkViewModel();
            networkView.ViewModel = network;

            this.ViewModel = new MainDockableViewModel();
            this.ViewModel.Network= network;

            this.ViewModel.NetworkViewportRegion = networkView.NetworkViewportRegion;

            nodesSystemListComboBox.ItemsSource = this.ViewModel.NodeSystems = new ObservableCollectionExtended<string>();

            this.WhenActivated(d =>
            {
                this.BindCommand(ViewModel, vm => vm.FitModel, v => v.fitModelBtn).DisposeWith(d);
                this.BindCommand(ViewModel, vm => vm.FitNode, v => v.fitNodeBtn).DisposeWith(d);
                //this.BindCommand(ViewModel, vm => vm.ClearNode, v => v.clrarNodeBtn).DisposeWith(d);



                this.BindCommand(ViewModel, vm => vm.CreateNodesBySystem, v => v.createNodesBySystemBtn).DisposeWith(d);
                this.BindCommand(ViewModel, vm => vm.CreateNodesByFatherChild, v => v.createNodesByFatherChildBtn).DisposeWith(d);
                this.BindCommand(ViewModel, vm => vm.CreateNetwork, v => v.createNetworkBtn).DisposeWith(d);
                this.BindCommand(ViewModel, vm => vm.SaveCurrentNetwork, v => v.saveCurrentNetworkBtn).DisposeWith(d);
                this.BindCommand(ViewModel, vm => vm.DeleteNetwork, v => v.deleteNetworkBtn).DisposeWith(d);
                this.BindCommand(ViewModel, vm => vm.CreateDrafting, v => v.createDraftingBtn).DisposeWith(d);

                this.BindCommand(ViewModel, vm => vm.LayoutArrange, v => v.layoutArrangeBtn).DisposeWith(d);
                this.BindCommand(ViewModel, vm => vm.LayoutGrid, v => v.layoutGridBtn).DisposeWith(d);
                this.Bind(ViewModel, vm => vm.CurrentNodeSystem, v => v.nodesSystemListComboBox.SelectedItem).DisposeWith(d);
            });


        }
    }
}
