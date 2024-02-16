using Autodesk.Revit.DB;
using DynamicData;
using DynamicData.Aggregation;
using DynamicData.Binding;
using Newtonsoft.Json;
using ReactiveUI;
using Revit.Async;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using System.Web.Util;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SystemNodeHelper.Properties;
using SystemNodeHelper.RevitCommandEventHandel;
using SystemNodeHelper.Utility;
using SystemNodeHelper.View;
using static System.Windows.Forms.AxHost;
using Line = Autodesk.Revit.DB.Line;
using Transform = Autodesk.Revit.DB.Transform;
using TreeNode = SystemNodeHelper.Utility.TreeNode;

namespace SystemNodeHelper.ViewModel
{
    
    public class DrafitingBindInfo 
    {
        public string Cotegoty { get; set; }
        public BuiltInCategory BuildingType { get; set; }

        public List<FamilyBindInfo> FamilyBindInfos { get; set; }
    }

    public class FamilyBindInfo
    {
        public FamilyBindInfo(FamilySymbol modelFamily) {

            ModelFamilySymbol = modelFamily;
        }
        public string ModelFamilySymbolName
        { 
            get {
               return ModelFamilySymbol.Name;
            }
           
        }


        public string ModelFamilyName
        {
            get
            {
                return ModelFamilySymbol.Family.Name;
            }
        }

        [JsonIgnore]
        public FamilySymbol ModelFamilySymbol { get; set; }

        public int _modelFamilySymbolId = -1;
        public int ModelFamilySymbolId
        {
            get
            {
                if (_modelFamilySymbolId != -1) return _modelFamilySymbolId;
                return ModelFamilySymbol.Id.IntegerValue;
            }
            set
            {
                _modelFamilySymbolId = value;
            }
        }

        [JsonIgnore]
        public Family DrafitingFamily { get; set; }


        public int _drafitingFamilylId = -1;
        public int DrafitingFamilylId
        {
            get
            {
                if (_drafitingFamilylId != -1) return _drafitingFamilylId;
                if (DrafitingFamily == null) return -1;
                return DrafitingFamily.Id.IntegerValue;
            }

            set {

                _drafitingFamilylId = value;
            }
        }

        public string DrafitingFamilyPath { get; set; }
    }


    public class SettingDraftingViewModel : ReactiveObject
    {
        public ReactiveCommand<Unit, Unit> Ok { get; }
        public ReactiveCommand<Unit, Unit> Apply { get; }
        public ReactiveCommand<Unit, Unit> OpenPreviewDic { get; }


        public ObservableCollectionExtended<DrafitingBindInfo> SaveDrafitingBindInfos { get; set; }


        private BindingList<FamilyBindInfo> _listFamilyBindInfo;
        public BindingList<FamilyBindInfo> ListFamilyBindInfo
        {
            get => _listFamilyBindInfo;
            set => this.RaiseAndSetIfChanged(ref _listFamilyBindInfo, value);
        }


        public ObservableCollectionExtended<string> AvaBindDraftingFamily
        {
            get => _avaBindDraftingFamily;
            set => this.RaiseAndSetIfChanged(ref _avaBindDraftingFamily, value);
        }
        private ObservableCollectionExtended<string> _avaBindDraftingFamily;

        private FamilyBindInfo _selectedFamilyBindInfo;
        public FamilyBindInfo SelectedFamilyBindInfo
        {
            get => _selectedFamilyBindInfo;
            set
            {
                this.RaiseAndSetIfChanged(ref _selectedFamilyBindInfo, value);
                if (value == null) {

                    IsEnabledDraftingFamilyComboBox = false;
                    PreviewFamilyImage = null;
                    return;
                }
                IsEnabledDraftingFamilyComboBox = true;
                if (value.DrafitingFamily == null)
                {
                    CurrentBindDraftingFamily =null;
                }
                else {
                    CurrentBindDraftingFamily = value.DrafitingFamily.Name;
                }
               var symbolImg = value.ModelFamilySymbol.GetPreviewImage(new System.Drawing.Size(200, 200));
                if(symbolImg !=null)PreviewFamilyImage = BitmapToBitmapImage(symbolImg);
                BitmapImage BitmapToBitmapImage(Bitmap bitmap)
                {
                    using (MemoryStream stream = new MemoryStream())
                    {
                        bitmap.Save(stream, ImageFormat.Png); // 坑点：格式选Bmp时，不带透明度

                        stream.Position = 0;
                        BitmapImage result = new BitmapImage();
                        result.BeginInit();
                        // According to MSDN, "The default OnDemand cache option retains access to the stream until the image is needed."
                        // Force the bitmap to load right now so we can dispose the stream.
                        result.CacheOption = BitmapCacheOption.OnLoad;
                        result.StreamSource = stream;
                        result.EndInit();
                        result.Freeze();
                        return result;
                    }
                }
            }
        }
        // public List<string> Cotegoties { get; set; }

        private string _currentCotegoty;
        public string CurrentCotegoty
        {
            get => _currentCotegoty;
            set
            {
                this.RaiseAndSetIfChanged(ref _currentCotegoty, value);
                if (value == null) return;
                // todo set AvaBindDraftingFamily
                // ListFamilyBindInfo.Clear();

                var  temp = new BindingList<FamilyBindInfo>();
                temp.AddRange(SaveDrafitingBindInfos.Single(x => x.Cotegoty == value).FamilyBindInfos);
                ListFamilyBindInfo = temp;
                CurrentBindDraftingFamily = null;
                //SelectedFamilyBindInfo = null;
            }
        }
        private string _currentBindDraftingFamily;
        public string CurrentBindDraftingFamily
        {
            get => _currentBindDraftingFamily;
            set
            {
                
                this.RaiseAndSetIfChanged(ref _currentBindDraftingFamily, value);
                if (value == null) {
                    PreviewDraftingImage =null;
                    return;
                }
                
                // todo set AvaBindDraftingFamily
                if (SelectedFamilyBindInfo != null) {
                    SelectedFamilyBindInfo.DrafitingFamily = _avaDetailComponentsFamilys.Where(x => x.Name == value).Single();
                    BitmapImage img;
                    _familysImg.TryGetValue(SelectedFamilyBindInfo.DrafitingFamily, out img);
                    PreviewDraftingImage = img;
                }
               
            }
        }

        //  IsEnabledDraftingFamilyComboBox


        private bool _isEnabledDraftingFamilyComboBox;
        public bool IsEnabledDraftingFamilyComboBox
        {
            get => _isEnabledDraftingFamilyComboBox;
            set
            {
                this.RaiseAndSetIfChanged(ref _isEnabledDraftingFamilyComboBox, value);
            }
        }

        private BitmapImage _previewDraftingImage;
        public BitmapImage PreviewDraftingImage
        {
            get => _previewDraftingImage;
            set => this.RaiseAndSetIfChanged(ref _previewDraftingImage, value);
        }

        private BitmapImage _previewFamilyImage;
        public BitmapImage PreviewFamilyImage
        {
            get => _previewFamilyImage;
            set => this.RaiseAndSetIfChanged(ref _previewFamilyImage, value);
        }


        private List<Family> _avaDetailComponentsFamilys;
        private Dictionary<Family, BitmapImage> _familysImg;

        public SettingDraftingViewModel(List<DrafitingBindInfo> saveDrafitingBindInfos, Dictionary<Family, BitmapImage> familysImg)
        {

            _familysImg = familysImg;
            AvaBindDraftingFamily = new ObservableCollectionExtended<string>();
            SaveDrafitingBindInfos = new ObservableCollectionExtended<DrafitingBindInfo>();
            ListFamilyBindInfo = new BindingList<FamilyBindInfo>();

            SaveDrafitingBindInfos.AddRange(saveDrafitingBindInfos);

            _avaDetailComponentsFamilys = familysImg.Keys.ToList();
            // Cotegoties = SaveDrafitingBindInfos.Select(x => x.Cotegoty).ToList();
            CurrentCotegoty = SaveDrafitingBindInfos[0].Cotegoty;
           // ListFamilyBindInfo = SaveDrafitingBindInfos[0].FamilyBindInfos;
            AvaBindDraftingFamily.AddRange(_avaDetailComponentsFamilys.Select(x => x.Name).ToList());


            Ok = ReactiveCommand.Create(OkCommand);
            Apply = ReactiveCommand.Create(ApplyCommand);
            OpenPreviewDic = ReactiveCommand.Create(OpenPreviewDicCommand);

            //this.FamilySymbols = new List<Family>();
            //this.Cotegoties = new List<string>();
            //this.Countries.Add(new Country { Name = "Andora" });
            //this.Countries.Add(new Country { Name = "Aruba" });
            //this.Countries.Add(new Country { Name = "Afganistan" });
            //this.Countries.Add(new Country { Name = "Algeria" });
            //this.Countries.Add(new Country { Name = "Argentina" });
            //this.Countries.Add(new Country { Name = "Armenia" });
            //this.Countries.Add(new Country { Name = "Antigua" });
            //CountryNames.AddRange(this.Countries.Select(x => x.Name));
        }

        private void OpenPreviewDicCommand()
        {
            System.Diagnostics.Process.Start(RevitApplication.DetailComponentsDirPath);
        }

        private void ApplyCommand()
        {
            //throw new NotImplementedException();
            SaveToJson();
        }

        private void OkCommand()
        {
            //throw new NotImplementedException();
            SaveToJson();

            // 
            RevitTask.RunAsync(app =>
            {
                var mainViewModel = RevitApplication.MainDockablePane.MainDockablePaneControl.ViewModel;
                mainViewModel.IsUpdataCurrentNodeSystemChange= false;

                var doc = app.ActiveUIDocument.Document;
                var vm = RevitApplication.MainDockablePane.MainDockablePaneControl.ViewModel.Network;
                List<TreeNode> nodeViewModels = vm.Nodes.Items.Cast<TreeNode>().ToList();

                //SaveDrafitingBindInfos
                var settingFamilyBindInfos = new List<FamilyBindInfo>();
                if (SaveDrafitingBindInfos != null)
                {
                    foreach (var item in SaveDrafitingBindInfos)
                    {
                        settingFamilyBindInfos.AddRange(item.FamilyBindInfos);
                    }
                    settingFamilyBindInfos = settingFamilyBindInfos.Where(x => x.DrafitingFamilylId != -1).ToList();
                }



                Transaction transaction = new Transaction(doc, "CreateDraftingView");
                transaction.Start();

                ViewFamilyType viewFamilyType = null;
                FilteredElementCollector collector = new FilteredElementCollector(doc);
                var viewFamilyTypes = collector.OfClass(typeof(ViewFamilyType)).ToElements();
                foreach (Element e in viewFamilyTypes)
                {
                    ViewFamilyType v = e as ViewFamilyType;
                    if (v.ViewFamily == ViewFamily.Drafting)
                    {
                        viewFamilyType = v;
                        break;
                    }
                }
                ViewDrafting drafting = ViewDrafting.Create(doc, viewFamilyType.Id);

                if (null == drafting)
                {
                    //todo 失败提示
                    return;
                }

                drafting.Scale = 50;
                transaction.Commit();
                app.ActiveUIDocument.ActiveView = drafting;

                using (Transaction drawDrafting = new Transaction(doc, "Draw Drafting")) {
                    drawDrafting.Start();

                    var rootNodes = nodeViewModels.Where(x => x.TreeNodeParent == null).ToList();

                   // FamilyInstance prDrafitingCom = null;
                   // XYZ prDrafitingComXYZ = null;
                    foreach (var rootNode in rootNodes)
                    {
                        CreateDrafitingComByRootNode(rootNode, null);
                    }

                    void CreateDrafitingComByRootNode(TreeNode node, XYZ fatherDrafitingComXYZ) {

                       // FamilyInstance newDrafitingCom;
                        XYZ newDrafitingComXYZ;
                        if (fatherDrafitingComXYZ == null)
                        {
                            newDrafitingComXYZ  = CreateDrafitingComByNode(node, null);
                        }
                        else {
                             newDrafitingComXYZ = CreateDrafitingComByNode(node, fatherDrafitingComXYZ);
                        }

                        if (newDrafitingComXYZ == null)
                        {
                            newDrafitingComXYZ = fatherDrafitingComXYZ;
                        }
                        else {
                            if (newDrafitingComXYZ != null && fatherDrafitingComXYZ != null)
                            {
                                var prePoint = fatherDrafitingComXYZ;
                                var newPoint = newDrafitingComXYZ;
                                
                                if (prePoint.Y == newPoint.Y)
                                {
                                   CreateDetailLine(prePoint, newPoint);
                                }
                                else
                                {
                                    var center1 = new XYZ(prePoint.X / 2 + newPoint.X / 2, prePoint.Y, 0);
                                    var center2 = new XYZ(prePoint.X / 2 + newPoint.X / 2, newPoint.Y, 0);
                                    CreateDetailLine(prePoint, center1);
                                    CreateDetailLine(center1, center2);
                                    CreateDetailLine(center2, newPoint);
                                }         
                            }   

                            fatherDrafitingComXYZ = newDrafitingComXYZ;
                        } 
                        
                        

                        foreach (var item in node.ChildNodes)
                        {
                            CreateDrafitingComByRootNode(item, fatherDrafitingComXYZ);
                        }
                    }
                  
                    void CreateDetailLine( XYZ endpoint, XYZ startpoint)
                    {
                        var graphicsStyle = new FilteredElementCollector(doc).OfClass(typeof(GraphicsStyle)).ToElements().Where(x => x.UniqueId == "d3516a40-06bf-11d4-91b5-0000863f27ad-00004633").SingleOrDefault() as GraphicsStyle;
                        try {
                        
                            Line line = Line.CreateBound(startpoint.Multiply(1 / 304.8), endpoint.Multiply(1 / 304.8));
                            //var ccc =  line.CreateTransformed(Transform.CreateTranslation(new XYZ(0.9, 0.9,0)));
                            //  line = ccc as Line;
                            var modeline = doc.Create.NewDetailCurve(doc.ActiveView, line) as DetailLine;
                            modeline.LineStyle = graphicsStyle;
                        }
                        catch(Exception ex) {
                            return;
                        }
                        //DetailLine line = locationCurve.Curve as DetailLine;
                       
           
                    }

                   XYZ   CreateDrafitingComByNode(TreeNode node, XYZ prePostion = null) {
                        var fIn = node.Element as FamilyInstance;
                        if (null == fIn) return null;
                        var symbol = fIn.Symbol;
                        var familyBindInfo = settingFamilyBindInfos.Where(x => x.ModelFamilySymbol.Id.IntegerValue == symbol.Id.IntegerValue).FirstOrDefault();
                        if (familyBindInfo != null)
                        {
                            var drafitingFamilySymbol = familyBindInfo.DrafitingFamily.GetFamilySymbolIds().Select(x => doc.GetElement(x)).Cast<FamilySymbol>().ToArray()[0];

                            // var startP = new XYZ(node.Position.X / 200, node.Position.Y / 200, 0);
                             var location = new XYZ(0, -node.Position.Y*1.5 , 0);
                            if (prePostion != null) {
                                location = new XYZ(prePostion.X + 1500, -node.Position.Y *1.5, 0);
                            }
                           // location = location.Multiply(1 / 304.8);
                           var result = doc.Create.NewFamilyInstance(location.Multiply(1 / 304.8), drafitingFamilySymbol, drafting);
                         // (result.Location as LocationPoint).Point = location;
                            return  location ;
                        }
                        return null;
                    }
                    drawDrafting.Commit();
                }

                mainViewModel.IsUpdataCurrentNodeSystemChange = true;
            });
           
        }

        private void SaveToJson() {
            
            var jsonConents = JsonConvert.SerializeObject(SaveDrafitingBindInfos);
            // RevitApplication.AssemblyPath

           var directory = new FileInfo(RevitApplication.AssemblyPath).Directory;
            var path = System.IO.Path.Combine(directory.FullName,"setting.json");

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    sw.WriteLine(jsonConents);
                }
            }

        }
    }
}
