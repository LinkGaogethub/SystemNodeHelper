using Autodesk.Revit.DB;
using DynamicData.Aggregation;
using DynamicData.Binding;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
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
    /// SettingDraftingView.xaml 的交互逻辑
    /// </summary>
    public partial class SettingDraftingView : Window, IViewFor<SettingDraftingViewModel>
    {
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
            typeof(SettingDraftingViewModel), typeof(SettingDraftingView), new PropertyMetadata(null));

        public SettingDraftingViewModel ViewModel
        {
            get => (SettingDraftingViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (SettingDraftingViewModel)value;
        }
        public SettingDraftingView(List<DrafitingBindInfo> saveDrafitingBindInfos,   Dictionary<Family, BitmapImage> avaDetailComponentsFamilys)
        {
            InitializeComponent();
            this.ViewModel = new SettingDraftingViewModel( saveDrafitingBindInfos, avaDetailComponentsFamilys);
        

            avaBindDraftingFamilyComboBox.ItemsSource = this.ViewModel.AvaBindDraftingFamily ;
            cotegotyComboBox.ItemsSource =  this.ViewModel.SaveDrafitingBindInfos.Select(x => x.Cotegoty).ToList();


            //this.WhenAnyValue(x => x.listView.ItemsSource)
            //.Select(list => list.Cast<FamilyBindInfo>())
            //.BindTo(this, x => x.ViewModel.ListFamilyBindInfo);
            // listView.ItemsSource = this.ViewModel.ListFamilyBindInfo;
           // previewImage.Source = this.ViewModel.PreviewImage;


            this.WhenActivated(d =>
            {
                this.OneWayBind(ViewModel, vm => vm.PreviewDraftingImage, v => v.previewDraftingImage.Source).DisposeWith(d);
                this.OneWayBind(ViewModel, vm => vm.PreviewFamilyImage, v => v.previewFamilyImage.Source).DisposeWith(d);

                this.OneWayBind(ViewModel, x => x.ListFamilyBindInfo, x => x.listView.ItemsSource).DisposeWith(d); 
              // this.OneWayBind(ViewModel, x => x.AvaBindDraftingFamily, x => x.avaBindDraftingFamilyComboBox.ItemsSource).DisposeWith(d);
                this.Bind(ViewModel, x => x.SelectedFamilyBindInfo, x => x.listView.SelectedItem).DisposeWith(d);
                //this.Bind(ViewModel, x => x.Cotegoties, x => x.cotegotyComboBox.ItemsSource);
                this.Bind(ViewModel, vm => vm.CurrentCotegoty, v => v.cotegotyComboBox.SelectedItem).DisposeWith(d);
                this.Bind(ViewModel, vm => vm.CurrentBindDraftingFamily, v => v.avaBindDraftingFamilyComboBox.SelectedItem).DisposeWith(d);
                this.OneWayBind(ViewModel, vm => vm.IsEnabledDraftingFamilyComboBox, v => v.avaBindDraftingFamilyComboBox.IsEnabled).DisposeWith(d);



                this.BindCommand(ViewModel, vm => vm.Ok, v => v.okBtn).DisposeWith(d);
                this.BindCommand(ViewModel, vm => vm.Apply, v => v.applyBtn).DisposeWith(d);

                this.BindCommand(ViewModel, vm => vm.OpenPreviewDic, v => v.openPreviewDicBtn).DisposeWith(d);


            });
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void okBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
