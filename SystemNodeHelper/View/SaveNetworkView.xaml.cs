using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reactive;
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
using System.Windows.Shapes;
using SystemNodeHelper.ViewModel;

namespace SystemNodeHelper.View
{
    /// <summary>
    /// SaveNetworkView.xaml 的交互逻辑
    /// </summary>
    public partial class SaveNetworkView : Window , IViewFor<SaveNetworkViewModel>
    {

        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
            typeof(SaveNetworkViewModel), typeof(SaveNetworkView), new PropertyMetadata(null));

        public SaveNetworkViewModel ViewModel
        {
            get => (SaveNetworkViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (SaveNetworkViewModel)value;
        }
   
      
        public SaveNetworkView()
        {
            InitializeComponent();

            this.ViewModel = new SaveNetworkViewModel();

            this.WhenActivated(d =>
            {
                this.BindCommand(ViewModel, vm => vm.Ok, v => v.okBtn).DisposeWith(d);
                //this.BindCommand(ViewModel, vm => Ok, v => v.okBtn).DisposeWith(d);
           
                this.Bind(ViewModel, vm => vm.Text, v => v.natworkNameTextBox.Text).DisposeWith(d);
            });

        }



        private void okBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
