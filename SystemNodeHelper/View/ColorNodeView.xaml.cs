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
    /// ColorNodeView.xaml 的交互逻辑
    /// </summary>
    public partial class ColorNodeView : IViewFor<ColorNodeViewModel>
    {
        public ColorNodeView()
        {
            InitializeComponent();

            this.WhenActivated(d =>
            {
                NodeView.ViewModel = this.ViewModel;
                //Disposable.Create(() => NodeView.ViewModel = null).DisposeWith(d);

                this.OneWayBind(ViewModel, vm => vm.Background, v => v.NodeView.Background).DisposeWith(d);
            });

           
        }
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
         typeof(ColorNodeViewModel), typeof(ColorNodeView), new PropertyMetadata(null));

        public ColorNodeViewModel ViewModel
        {
            get => (ColorNodeViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }
        // public ColorNodeModel ViewModel { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (ColorNodeViewModel)value;
        }
    }
}
