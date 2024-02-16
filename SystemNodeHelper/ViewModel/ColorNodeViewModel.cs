using NodeNetwork.ViewModels;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using SystemNodeHelper.View;

namespace SystemNodeHelper.ViewModel
{
    public class ColorNodeViewModel : NodeViewModel
    {
        static ColorNodeViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new ColorNodeView(), typeof(IViewFor<ColorNodeViewModel>));
        }
        private static readonly SolidColorBrush _orginalColor = new SolidColorBrush(Colors.CornflowerBlue);
        private SolidColorBrush _background = _orginalColor;
        public SolidColorBrush Background
        {
            get => _background;
            set => this.RaiseAndSetIfChanged(ref _background, value);
        }
        public ColorNodeViewModel()
        {
            PropertyChanged += TreeNodePropertyChanged;
        }

        private void TreeNodePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsSelected")
            {
                if (IsSelected)
                {
                    Background = new SolidColorBrush(Colors.OrangeRed);
                }
                else
                {
                    Background = _orginalColor;
                }
            }
        }
    }
}
