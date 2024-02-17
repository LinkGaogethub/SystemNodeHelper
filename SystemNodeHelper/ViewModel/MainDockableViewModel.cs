using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using DynamicData;
using DynamicData.Binding;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NodeNetwork.Toolkit.Layout.ForceDirected;
using NodeNetwork.ViewModels;
using ReactiveUI;
using Revit.Async;
using Revit.Async.ExternalEvents;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Web.UI.WebControls;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Markup;
using System.Windows.Media.Imaging;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using SystemNodeHelper.RevitCommandEventHandel;
using SystemNodeHelper.Utility;
using SystemNodeHelper.View;
using static System.Resources.ResXFileRef;
using TreeNode = SystemNodeHelper.Utility.TreeNode;
using Unit = System.Reactive.Unit;

namespace SystemNodeHelper.ViewModel
{
   


    public class MainDockableViewModel : ReactiveObject
    {
        private readonly int _XOffset = 400;
        private readonly int _YOffset = 300;
       // private long _curentNodeLevel = 0;
        #region Network
        private NetworkViewModel _network;
        public System.Windows.Rect NetworkViewportRegion;
        public NetworkViewModel Network
        {
            get => _network;
            set => this.RaiseAndSetIfChanged(ref _network, value);
        }
        #endregion

        public bool IsUpdataCurrentNodeSystemChange =true;


        public string CurrentNodeSystem
        {
            get => _currentNodeSystem;
            set {
               
                this.RaiseAndSetIfChanged(ref _currentNodeSystem, value);
                if (IsUpdataCurrentNodeSystemChange) CurrentNodeSystemChange(value);

            }
        }
        private string _currentNodeSystem;

        public ObservableCollectionExtended<string> NodeSystems
        {
            get => _nodeSystems;
            set => this.RaiseAndSetIfChanged(ref _nodeSystems, value);
        }
        private ObservableCollectionExtended<string> _nodeSystems;
        // public List<string> NodeSystems = new List<string>() { "qwerwer", "1569" };
        //new List<string>() { "qwerwer","1569"};

        public ReactiveCommand<Unit, Unit> FitModel { get; }
        public ReactiveCommand<Unit, Unit> FitNode { get; }
        public ReactiveCommand<Unit, Unit> ClearNode { get; }
        public ReactiveCommand<Unit, Unit> CreateNodesBySystem { get; }
        public ReactiveCommand<Unit, Unit> CreateNodesByFatherChild { get; }
        public ReactiveCommand<Unit, Unit> CreateNetwork { get; }
        public ReactiveCommand<Unit, Unit> SaveCurrentNetwork { get; }
        public ReactiveCommand<Unit, Unit> DeleteNetwork { get; }
        public ReactiveCommand<Unit, Unit> CreateDrafting { get; }

        public ReactiveCommand<Unit, Unit> LayoutArrange { get; }
        public ReactiveCommand<Unit, Unit> LayoutGrid { get; }

        public MainDockableViewModel()
        {

            // ClearNode = ReactiveCommand.Create(ClearNodeCommand);
            CreateNetwork = ReactiveCommand.Create(CreateNodeNodeCommand);
            SaveCurrentNetwork = ReactiveCommand.Create(SaveCurrentNodeCommandRunAsync);
            DeleteNetwork = ReactiveCommand.Create(DeleteNodeCommand);
            CreateDrafting = ReactiveCommand.Create(CreateDraftingCommand);

            CreateNodesBySystem = ReactiveCommand.Create(CreateNodesBySystemCommand);
            CreateNodesByFatherChild = ReactiveCommand.Create(CreateNodesByFatherChildCommand);
          

            LayoutArrange = ReactiveCommand.Create(LayoutArrangeCommand);
            LayoutGrid = ReactiveCommand.Create(LayoutGridCommand);

            FitModel = ReactiveCommand.Create(FitModelCommand);
            FitNode = ReactiveCommand.Create(FitNodeCommand);

        }

        // 设置按钮，页面 catgra 绑定平面视图
        // 生成按钮，根据当前当前节点生成绘图
        /// <summary>
        /// 
        /// </summary>

        private void CreateDraftingCommand()
        {

            if (_currentNodeSystem == null)
            {
                MessageBox.Show("要新建一个或者浏览已经存在的画板", "错误!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            ///
            /// 生成设置窗口
            /// 用 设备和风道末端 显示 族和族类别名称
            /// ///

            ///
            /// 根据实例 确定 类别 cat ，确定用哪个族
            /// 确定类别 和 详图的位置，生成
            /// 根据位置连接 这些详图
            ///
            //var settingDraftingView = new SettingDraftingView();
            // settingDraftingView.ShowDialog();

            RevitTask.RunAsync(app => {

                var doc = app.ActiveUIDocument.Document;
               // var app = commandData.Application;
                var avaDetailComponentsFamilySymbol = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_DetailComponents).OfClass(typeof(FamilySymbol)).Cast<FamilySymbol>();

                //var jsonConents = JsonConvert.SerializeObject(SaveDrafitingBindInfos);
                // RevitApplication.AssemblyPath

                var directory = new FileInfo(RevitApplication.AssemblyPath).Directory;
                var filepath = System.IO.Path.Combine(directory.FullName, "setting.json");
                string json = string.Empty;
                using (FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
                    {
                        json = sr.ReadToEnd().ToString();
                    }
                }

                var setting = JsonConvert.DeserializeObject<List<DrafitingBindInfo>>(json);

                var settingFamilyBindInfos = new List<FamilyBindInfo>();
                if (setting != null) {
                    foreach (var item in setting)
                    {
                        settingFamilyBindInfos.AddRange(item.FamilyBindInfos);
                    }
                    settingFamilyBindInfos = settingFamilyBindInfos.Where(x => x.DrafitingFamilylId != -1).ToList();
                }
               



                //var avaDetailComponentsFamilys = avaDetailComponentsFamilySymbol.Select(x => x.Family).ToList();
                var avaDetailComponentsFamilys = new List<Family>();
                foreach (var item in avaDetailComponentsFamilySymbol)
                {
                    if (!avaDetailComponentsFamilys.Select(x => x.Id.IntegerValue).Contains(item.Family.Id.IntegerValue))
                    {
                        avaDetailComponentsFamilys.Add(item.Family);
                    }
                }


                var drafitingBindInfo = new List<DrafitingBindInfo>();

                var ductTerminalSymbols = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_DuctTerminal).OfClass(typeof(FamilySymbol)).Cast<FamilySymbol>().ToList();

                //var ductTerminalFamilyBindInfos = ductTerminalSymbols.Select(x => new FamilyBindInfo(x)).ToList();
                //foreach (var item in ductTerminalFamilyBindInfos)
                //{
                //    var settingFamilyBindInfo = settingFamilyBindInfos.Where(x => x.ModelFamilySymbolId == item.ModelFamilySymbolId).SingleOrDefault();
                //    if (settingFamilyBindInfo == null) continue;
                //   var drafitingFamily = doc.GetElement(new ElementId(settingFamilyBindInfo.DrafitingFamilylId)) as Family;

                //    if (drafitingFamily == null) continue;
                //    item.DrafitingFamily = drafitingFamily;
                //}

              

                drafitingBindInfo.Add(new DrafitingBindInfo()
                {
                    Cotegoty = "风道末端", //todo get from revit
                    BuildingType = BuiltInCategory.OST_DuctTerminal,
                    FamilyBindInfos = GetPreSetFamilyBindInfos(ductTerminalSymbols),
                });

                var mechanicalEquipmentSymbols = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_MechanicalEquipment).OfClass(typeof(FamilySymbol)).Cast<FamilySymbol>().ToList();
                drafitingBindInfo.Add(new DrafitingBindInfo()
                {
                    Cotegoty = "机械设备", //todo get from revit
                    BuildingType = BuiltInCategory.OST_MechanicalEquipment,
                    FamilyBindInfos = GetPreSetFamilyBindInfos(mechanicalEquipmentSymbols),
                });


                var otherSymbols = new FilteredElementCollector(doc).OfClass(typeof(FamilySymbol)).Cast<FamilySymbol>().ToList();
                otherSymbols = otherSymbols.SkipWhile(x => x.Category.Id.IntegerValue == (int)BuiltInCategory.OST_DuctTerminal || x.Category.Id.IntegerValue == (int)BuiltInCategory.OST_MechanicalEquipment).ToList();


                drafitingBindInfo.Add(new DrafitingBindInfo()
                {
                    Cotegoty = "其他", //todo get from revit
                 //   BuildingType = BuiltInCategory.OST_MechanicalEquipment,
                    FamilyBindInfos = GetPreSetFamilyBindInfos(otherSymbols),
                });

                var dic = new Dictionary<Family, BitmapImage>();

                //var dicPath = @"C:\ProgramData\Autodesk\ApplicationPlugins\Bimlogiq.SchematicTools.bundle\Contents\2020\DetailComponents";


                var directoryInfo = new DirectoryInfo(RevitApplication.DetailComponentsDirPath);
                var files = directoryInfo.GetFiles();
                //string[] fyles = Directory.GetFiles(dicPath);
                foreach (var item in avaDetailComponentsFamilys)
                {
                    var imgPngPath = RevitApplication.DetailComponentsDirPath + "\\" + item.Name + ".png";
                    var png = new FileInfo(imgPngPath);
                    //if (!png.Exists)
                    // {

                    var file = files.Where(x => x.Extension == ".rfa" && x.Name.Replace(x.Extension, "").ToLower() == item.Name.ToLower()).SingleOrDefault();
                    //  fileName.Contains(item.Family.Name)
                    if (file == null)
                    {
                        dic.Add(item, null);
                        continue;
                    }
                    File.Delete(imgPngPath);
                    ImgHelper.CreatImg(file.FullName, imgPngPath);

              
                    BitmapImage bitmap = new BitmapImage();
                    if (File.Exists(imgPngPath))
                    {
                        bitmap.BeginInit();
                        bitmap.CacheOption = BitmapCacheOption.OnLoad;

                        using (Stream ms = new MemoryStream(File.ReadAllBytes(imgPngPath)))
                        {
                            bitmap.StreamSource = ms;
                            bitmap.EndInit();
                            bitmap.Freeze();
                        }
                    }
                    dic.Add(item, bitmap);

                }
                var settingDraftingView = new SettingDraftingView(drafitingBindInfo, dic);


                //ImgHelper.GetImage(@"C:\ProgramData\Autodesk\ApplicationPlugins\Bimlogiq.SchematicTools.bundle\Contents\2020\DetailComponents\2WayValve.rfa");

                settingDraftingView.ShowDialog();

                List<FamilyBindInfo> GetPreSetFamilyBindInfos(List<FamilySymbol> familySymbols)
                {
                    var familyBindInfos = familySymbols.Select(x => new FamilyBindInfo(x)).ToList();
                    // var drafitingBindInfo = new List<FamilyBindInfo>();
                    foreach (var item in familyBindInfos)
                    {
                        var settingFamilyBindInfo = settingFamilyBindInfos.Where(x => x.ModelFamilySymbolId == item.ModelFamilySymbolId).FirstOrDefault();
                        if (settingFamilyBindInfo == null) continue;
                        var drafitingFamily = doc.GetElement(new ElementId(settingFamilyBindInfo.DrafitingFamilylId)) as Family;

                        if (drafitingFamily == null) continue;
                        item.DrafitingFamily = drafitingFamily;
                    }
                    return familyBindInfos;
                }


            });


           

            //if (_currentNodeSystem == null)
            //{
            //    MessageBox.Show("要新建一个或者浏览已经存在的画板", "错误!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}
            //RevitTask.RunAsync(app => {


            //        Autodesk.Revit.DB.Document doc = app.ActiveUIDocument.Document;
            //        Transaction transaction = new Transaction(doc, "CreateDraftingView");
            //        transaction.Start();

            //        ViewFamilyType viewFamilyType = null;
            //        FilteredElementCollector collector = new FilteredElementCollector(doc);
            //        var viewFamilyTypes = collector.OfClass(typeof(ViewFamilyType)).ToElements();
            //        foreach (Element e in viewFamilyTypes)
            //        {
            //            ViewFamilyType v = e as ViewFamilyType;
            //            if (v.ViewFamily == ViewFamily.Drafting)
            //            {
            //                viewFamilyType = v;
            //                break;
            //            }
            //        }
            //        ViewDrafting drafting = ViewDrafting.Create(doc, viewFamilyType.Id);
            //        if (null == drafting)
            //        {
            //          // message = "Can't create the ViewDrafting.";
            //          //  return Autodesk.Revit.UI.Result.Failed;
            //        }
            //        transaction.Commit();

            //        app.ActiveUIDocument.ActiveView= drafting;
            //       // TaskDialog.Show("Revit", "Create view drafting succeeded.");
            //       //return Autodesk.Revit.UI.Result.Succeeded;


            //});
            void CreateSubCategoryAndDetailLine(Document doc)
            {
                var categories = doc.Settings.Categories;
                var subCategoryName = "MySubCategory";
                Category category = doc.Settings.Categories.
                    get_Item(BuiltInCategory.OST_GenericAnnotation);
                Category subCategory = null;
                if (!category.SubCategories.Contains(subCategoryName))
                {
                    subCategory = categories.NewSubcategory(category,
                        subCategoryName);
                    var newcolor = new Autodesk.Revit.DB.Color(250, 10, 0);
                    subCategory.LineColor = newcolor;
                    subCategory.SetLineWeight(10, GraphicsStyleType.Projection);
                }
                else
                    subCategory = category.SubCategories.get_Item(subCategoryName);

                Line newLine = Line.CreateBound(
                    new XYZ(0, 1, 0), new XYZ(-1, 0, 0));
                var detailLine = doc.FamilyCreate.NewDetailCurve(
                    doc.ActiveView, newLine);
                detailLine.LineStyle = subCategory.GetGraphicsStyle(
                    GraphicsStyleType.Projection);
            }
        }

        private void CreateNodeNodeCommand()
        {
            RevitTask.RunAsync(app => {

                var doc = app.ActiveUIDocument.Document;
                var networkListString = ExtendedDataUtil.ReadExtendedData(doc);
                //  var name = "testNet";
                var saveNetworkView = new SaveNetworkView();

                saveNetworkView.ShowDialog();
                if (!saveNetworkView.ViewModel.IsOk) return;
                var networkName = saveNetworkView.ViewModel.Text;

                if (NodeSystems.Contains(networkName)) {

                    MessageBox.Show("列表中已经存在这个名称", "错误!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                // _network.Connections.Clear();
                // var networkListString = ExtendedDataUtil.ReadExtendedData(doc);
                // var converter = new NetworkConverter(_network);
                // var serialisedNetwork = converter.BuildModel(networkName);
                IsUpdataCurrentNodeSystemChange = false;
                CurrentNodeSystem = networkName;
                IsUpdataCurrentNodeSystemChange = true;
                SaveCurrentNodeCommand(app);

                var networkJson = string.Empty;
                var curentNetwork = new Network(networkName, new List<SerializedNode>(), new List<SerializedConnection>());
                if (networkListString == null)
                {
                     networkJson = JsonConvert.SerializeObject(new List<Network>() { curentNetwork });
                }
                else {
                    var networks = JsonConvert.DeserializeObject<List<Network>>(networkListString);
                    networks.Add(curentNetwork);
                    networkJson = JsonConvert.SerializeObject(networks);

                }
                ExtendedDataUtil.WriteExtendedData(doc, networkJson, "Create Network " + networkName);
                NodeSystems.Add(networkName);
               
                _network.Nodes.Clear();

                //this.RaiseAndSetIfChanged(ref _currentNodeSystem, networkName);
                doc.Save();
            });
        }

        private void DeleteNodeCommand()
        {
            RevitTask.RunAsync(app => {
                var doc = app.ActiveUIDocument.Document;
                var networkListString = ExtendedDataUtil.ReadExtendedData(doc);
                if (networkListString != null)
                {
                    var networks = JsonConvert.DeserializeObject<List<Network>>(networkListString);
                    var net = networks.SingleOrDefault(x => x.Name == _currentNodeSystem);

                    if (net != null) {

                      var option=  MessageBox.Show("将删除" + _currentNodeSystem, "警告!", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                        if ( option != DialogResult.OK) {
                            return;
                        }
                        networks.Remove(net);
                        ExtendedDataUtil.WriteExtendedData(doc, JsonConvert.SerializeObject(networks),"Delete Network "+ _currentNodeSystem);
                        RevitApplication.MainDockablePane.MainDockablePaneControl.ViewModel.NodeSystems.Remove(_currentNodeSystem);
                        _network.Nodes.Clear();
                        doc.Save();
                    }
                }
            });
        }

        private void ClearNodeCommand()
        {
            _network.Nodes.Clear();
        }

        private void CurrentNodeSystemChange(string name) {

            if (name == null) return;
            RevitTask.RunAsync(app =>
            {
              //  SaveCurrentNodeCommand(app);
                _network.Nodes.Clear();
                _network.ZoomFactor = 1;
                _network.DragOffset = new System.Windows.Point(0,0);
                var doc = app.ActiveUIDocument.Document;
                var networkListString = ExtendedDataUtil.ReadExtendedData(doc);
                if (networkListString != null) {
                    var networks = JsonConvert.DeserializeObject<List<Network>>(networkListString);
                    var net = networks.SingleOrDefault(x => x.Name == name);
                    if (net != null)
                    {
                   
                        var converter = new NetworkConverter(_network);
                        converter.LoadModel(doc, net);
                    }
                  
                }
            });
        }

        // todo todo 记录active view  ，代码跳转激活
        private void FitModelCommand()
        {
            RevitTask.RunAsync(app =>
            {
                var sel = app.ActiveUIDocument.Selection;
                app.ActiveUIDocument.ShowElements(sel.GetElementIds());

            });
        }
        
        private void FitNodeCommand()
        {
            RevitTask.RunAsync(app =>
            {
                if (app.ActiveUIDocument == null) return;
                var elementIds = app.ActiveUIDocument.Selection.GetElementIds();

                // TestSchematicsUI.MainWindow.NetworkView.ClearSelection();

                if (elementIds.Count == 1)
                {
                   // var networkView = _win.ViewModel.Network;
                    var eleIntegerValue = elementIds.ToArray()[0].IntegerValue;

                    SyncShowNode(eleIntegerValue);

                }

            });
        }
        
        private void CreateNodesBySystemCommand() 
        {
         
            RevitTask.RunAsync(uiapp =>
            {
                if (_currentNodeSystem == null)
                {
                    MessageBox.Show("要新建一个或者选选择画板", "错误!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                var activeDoc = uiapp.ActiveUIDocument;
                if (activeDoc == null)
                {
                    // TaskDialog.Show("No Active Document", "There's no active document in Revit.", TaskDialogCommonButtons.Ok);
                    return;
                }

                // Verify the number of selected elements
                ElementSet selElements = new ElementSet();
                foreach (ElementId elementId in activeDoc.Selection.GetElementIds())
                {
                    selElements.Insert(activeDoc.Document.GetElement(elementId));
                }
                if (selElements.Size != 1)
                {
                    MessageBox.Show("先选一个系统", "错误!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //  message = "Please select ONLY one element from current project.";
                    return;
                }

                //// Get the selected element
                Element selectedSystem = null;
                foreach (Element element in selElements)
                {
                    selectedSystem = element;
                    break;
                }


                MessageBox.Show("选择一个元素作为起始节点", "继续", MessageBoxButtons.OK);
                FocusToRevit(uiapp);
             
                var reference = activeDoc.Selection.PickObject(ObjectType.Element, "请选择模型构件");
                var selectedElement = activeDoc.Document.GetElement(reference);
                // Get the expected mechanical or piping system from selected element
                // Some elements in a non-well-connected system may get lost when traversing 
                //the system in the direction of flow; and
                // flow direction of elements in a non-well-connected system may not be right, 
                // therefore the sample will only support well-connected system.
               var system = ExtractMechanicalOrPipingSystem(selectedElement);
                if (selectedSystem as MEPSystem == null) return;
                TraversalTree tree = new TraversalTree(activeDoc.Document, selectedSystem as MEPSystem);
               
                tree.Traverse(selectedElement);
                // var  TreeStartNodetreeNode = ;
                //_network = network;
               
                TraverseAddViewModel(tree.StartingElementNode);
                SaveCurrentNodeCommand(uiapp);
            });


         

             MEPSystem ExtractMechanicalOrPipingSystem(Element selectedElement)
            {
                MEPSystem system = null;

                if (selectedElement is MEPSystem)
                {
                    if (selectedElement is MechanicalSystem || selectedElement is PipingSystem)
                    {
                        system = selectedElement as MEPSystem;
                        return system;
                    }
                }
                else // Selected element is not a system
                {
                    FamilyInstance fi = selectedElement as FamilyInstance;
                    //
                    // If selected element is a family instance, iterate its connectors and get the expected system
                    if (fi != null)
                    {
                        MEPModel mepModel = fi.MEPModel;
                        ConnectorSet connectors = null;
                        try
                        {
                            connectors = mepModel.ConnectorManager.Connectors;
                        }
                        catch (System.Exception)
                        {
                            system = null;
                        }

                        system = ExtractSystemFromConnectors(connectors);
                    }
                    else
                    {
                        //
                        // If selected element is a MEPCurve (e.g. pipe or duct), 
                        // iterate its connectors and get the expected system
                        MEPCurve mepCurve = selectedElement as MEPCurve;
                        if (mepCurve != null)
                        {
                            ConnectorSet connectors = null;
                            connectors = mepCurve.ConnectorManager.Connectors;
                            system = ExtractSystemFromConnectors(connectors);
                        }
                    }
                }

                return system;
            }

             MEPSystem ExtractSystemFromConnectors(ConnectorSet connectors)
            {
                MEPSystem system = null;

                if (connectors == null || connectors.Size == 0)
                {
                    return null;
                }

                // Get well-connected mechanical or piping systems from each connector
                List<MEPSystem> systems = new List<MEPSystem>();
                foreach (Connector connector in connectors)
                {
                    MEPSystem tmpSystem = connector.MEPSystem;
                    if (tmpSystem == null)
                    {
                        continue;
                    }

                    MechanicalSystem ms = tmpSystem as MechanicalSystem;
                    if (ms != null)
                    {
                        if (ms.IsWellConnected)
                        {
                            systems.Add(tmpSystem);
                        }
                    }
                    else
                    {
                        PipingSystem ps = tmpSystem as PipingSystem;
                        if (ps != null && ps.IsWellConnected)
                        {
                            systems.Add(tmpSystem);
                        }
                    }
                }

                // If more than one system is found, get the system contains the most elements
                int countOfSystem = systems.Count;
                if (countOfSystem != 0)
                {
                    int countOfElements = 0;
                    foreach (MEPSystem sys in systems)
                    {
                        if (sys.Elements.Size > countOfElements)
                        {
                            system = sys;
                            countOfElements = sys.Elements.Size;
                        }
                    }
                }

                return system;
            }
             
       
            void TraverseAddViewModel(TreeNode elementNode, bool isRoot = true)
            {
                var _curentNodeLevel = 0;
                if (isRoot)
                {
                    //var nodeViewModel = GetNodeViewModel(elementNode.Id, elementNode.ChildNodes, false);
                    //var elementNode = elementNode;
                    //elementNode.NodeViewModel = nodeViewModel;

                    if (_network.Nodes.Count > 0)
                    {
                       var bottomNode = _network.Nodes.Items.OrderByDescending(x => x.Position.Y).First();
                        elementNode.Position = new System.Windows.Point(200, _YOffset + bottomNode.Position.Y);
                        _network.Nodes.Add(elementNode);

                    }
                    else {
                        elementNode.Position = new System.Windows.Point(200, _YOffset);
                        _network.Nodes.Add(elementNode);
                    }
                   
                }


                //nodeViewModel.Parent.
                if (elementNode.ChildNodes.Count > 1) _curentNodeLevel++;
                for (int i = 0; i < elementNode.ChildNodes.Count; i++)
                {

                    var child = elementNode.ChildNodes[i];
                    child.TreeNodeParent = elementNode;
                    //   var chNode = GetNodeViewModel(child.Id, child.ChildNodes);
                    var chNode = child;
                    _network.Nodes.Add(chNode);
                    //var parentPosition = elementNode.NodeViewModel.Position;
                    var parentPosition = elementNode.Position;
                    var position = new System.Windows.Point(parentPosition.X + _XOffset, parentPosition.Y);
                    if (elementNode.ChildNodes.Count > 1)
                    {
                       var hOffset = elementNode.ChildNodes.Count()* _YOffset;

                        position = new System.Windows.Point(parentPosition.X + _XOffset, parentPosition.Y - hOffset/2 + (i+1) * _YOffset);
                    }

                    chNode.Position = position;

                    var connection = new ConnectionViewModel(
                        _network,
                        chNode.Inputs.Items.ToArray()[0],
                       //elementNode.NodeViewModel.Outputs.Items.ToArray()[i]);
                       elementNode.Outputs.Items.ToArray()[i]);
                    //   connection.CanBeRemovedByUser = false;

                    _network.Connections.Add(connection);

                    TraverseAddViewModel(child, false);
                }
            }

        }

      
        private void CreateNodesByFatherChildCommand()
        {
            if (_currentNodeSystem == null)
            {
                MessageBox.Show("要新建一个", "错误!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            RevitTask.RunAsync(app =>
            {
                FocusToRevit(app);
          
               // var seleEleIds = app.ActiveUIDocument.Selection.GetElementIds();
                var reFather = app.ActiveUIDocument.Selection.PickObject(ObjectType.Element);

                MessageBox.Show("继续指定子项", "继续", MessageBoxButtons.OK);

                var eleFather = app.ActiveUIDocument.Document.GetElement(reFather);

                var reChildsRe = app.ActiveUIDocument.Selection.PickObjects(ObjectType.Element);
                var chs = AddChildNode(reChildsRe.Select(x => app.ActiveUIDocument.Document.GetElement(x)).ToList(), new System.Windows.Point(0, 0));

                TreeNode fatherNode = null;
                foreach (TreeNode item in _network.Nodes.Items)
                {
                    if (item.ElementId.IntegerValue == reFather.ElementId.IntegerValue)
                    {
                        fatherNode = item;
                        break;
                    }
                }
                if (fatherNode == null)
                {
                    fatherNode = new TreeNode(app.ActiveUIDocument.Document, reFather.ElementId, true);
                    var position = new System.Windows.Point(0, 0);
                    var roots = _network.Nodes.Items.ToArray().Where(x => ((TreeNode)x).TreeNodeParent == null);
                    if (roots.Count() > 0)
                    {
                        var bottomNode = roots.OrderByDescending(x => x.Position.Y).First();

                        if (((TreeNode)bottomNode).ChildNodes.Count() > 0)
                        {

                            var bottomNodeCh = ((TreeNode)bottomNode).ChildNodes.OrderByDescending(x => x.Position.Y).First();
                            position = new System.Windows.Point(bottomNodeCh.Position.X - _XOffset, bottomNodeCh.Position.Y + _XOffset);
                        }
                    }
                    fatherNode.Position = position;
                    _network.Nodes.Add(fatherNode);
                }
          

                for (int i = 0; i < chs.Count(); i++)
                {
                    var node = chs[i];
                    node.TreeNodeParent = fatherNode;
                   // fatherNode.ChildNodes.Add(node);// todo test
                    if (fatherNode.ChildNodes.Count > 0)
                    {
                        var endCh = _network.Nodes.Items.OrderByDescending(x => x.Position.Y).First();
                        node.Position = new System.Windows.Point(endCh.Position.X, endCh.Position.Y + (i + 1) * _YOffset);

                    }
                    else
                    {
                        //nude.Position = new System.Windows.Point(fatherNode.Position.X + _XOffset, fatherNode.Position.Y + (i + 1) * _YOffset - chs.Count() * _YOffset / 2);
                        node.Position = new System.Windows.Point(fatherNode.Position.X + _XOffset, fatherNode.Position.Y + i * _YOffset);
                    }
                }
                //networkView.Nodes.Items.Any(x => x.id);
                _network.Nodes.AddRange(chs);
                var orginCount = fatherNode.ChildNodes.Count;
                fatherNode.ChildNodes.AddRange(chs);


             
                for (int i = 0; i < fatherNode.ChildNodes.Count ; i++)
                {
                    if (i < orginCount) continue;
                    var output = new NodeOuputUnchange();
                    output.Name = "Connector" + ( i + 1);
                    fatherNode.Outputs.Add(output);
                }

       
                for (int i = 0; i < fatherNode.ChildNodes.Count; i++)
                {
                    if (i < orginCount) continue;
                    var ch = fatherNode.ChildNodes[i ];
                    var connection = new ConnectionViewModel(this._network, ch.Inputs.Items.ToArray()[0], fatherNode.Outputs.Items.ToArray()[i ]);
                    this._network.Connections.Add(connection);
                }
                //for (int i = 0; i < fatherNode.ChildNodes.Count; i++)
                //{
                //    var j =  i;
                //    if (orginCount > 0)
                //    {
                //        j = i + orginCount - 1;
                //    }
                 
                //    var output = new NodeOuputUnchange();
                //    output.Name = "Connector" + (j);
                //    fatherNode.Outputs.Add(output);
                //    if (orginCount == 0) j++;
                //    var ch = fatherNode.ChildNodes[j];
                //    var connection = new ConnectionViewModel(this._network, ch.Inputs.Items.ToArray()[0], fatherNode.Outputs.Items.ToArray()[j]);
                //    this._network.Connections.Add(connection);
                //}

               // SyncShowNode(eleFather.Id.IntegerValue ,false);

                List<TreeNode> AddChildNode(List<Element> elements, System.Windows.Point fatherPint)
                {

                    var result = new List<TreeNode>();
                    for (int i = 0; i < elements.Count(); i++)
                    {
                        var ele = elements[i];

                        var nodech = _network.Nodes.Items.ToArray().Where(x => ((TreeNode)x).ElementId.IntegerValue == ele.Id.IntegerValue).SingleOrDefault();
                        // var ele = _application.ActiveUIDocument.Document.GetElement(re);
                        //var nodech = new ColorNodeModel();
                        if (nodech == null)
                        {
                            nodech = new TreeNode(app.ActiveUIDocument.Document, ele.Id);
                            nodech.Name = ele.Name;
                            //nodech.Position = new System.Windows.Point(fatherPint.X + 200, fatherPint.Y + i * 200);
                        }


                        result.Add((TreeNode)nodech);
                    }

                    return result;
                }

            });
        }

        private void SaveCurrentNodeCommandRunAsync() {
            RevitTask.RunAsync(app => {
                SaveCurrentNodeCommand(app);
            });




            //todo
            /// 给一个名称，添加导扩展 的network list里 ，检查是否存在


            //var serializer = new XmlSerializer(typeof(NodeNetworkViewModel));
            //var writer = new StringWriter();
            //serializer.Serialize(writer, _network);

            //XmlWriterSettings settings = new XmlWriterSettings();
            //settings.Indent = true;
            //settings.IndentChars = "    ";
            //XmlWriter writerqwe = XmlWriter.Create(@"F:\2.dev\4. revitSysTopu\output.xml", settings);


            //var serializer = new XmlSerializer(typeof(NetworkViewModel));
            //var reader = new StringReader(xmlString);
            //var nodeNetwork = (NodeNetworkViewModel)serializer.Deserialize(reader);

        }


        private void SaveCurrentNodeCommand(UIApplication app)
        {
           

                if (_currentNodeSystem == null)
                {
                    MessageBox.Show("要新建一个或者浏览已经存在的画板", "错误!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                var doc = app.ActiveUIDocument.Document;
                var currentNodeSystem = RevitApplication.MainDockablePane.MainDockablePaneControl.ViewModel.CurrentNodeSystem;



                var networkListString = ExtendedDataUtil.ReadExtendedData(doc);
                ////  var name = "testNet";
                //  var saveNetworkView = new SaveNetworkView();

                //  saveNetworkView.ShowDialog();
                //  if ( !saveNetworkView.ViewModel.IsOk) return;
                //  var currentNodeSystem = saveNetworkView.ViewModel.Text;

                var converter = new NetworkConverter(_network);
                var serialisedNetwork = converter.BuildModel(currentNodeSystem);
                var networkJson = string.Empty;
                if (networkListString == null)
                {
                    networkJson = JsonConvert.SerializeObject(new List<Network>() { serialisedNetwork });
                }
                else
                {
                    var networks = JsonConvert.DeserializeObject<List<Network>>(networkListString);
                    var net = networks.SingleOrDefault(x => x.Name == currentNodeSystem);
                    //if (net == null) return;
                    // net = serialisedNetwork;
                    //var index = networks.IndexOf(net);
                    networks.Remove(net);
                    networks.Add(serialisedNetwork);
                    networkJson = JsonConvert.SerializeObject(networks);
                }

                ExtendedDataUtil.WriteExtendedData(doc, networkJson, "Save Network " + _currentNodeSystem);
                doc.Save();
          




            //todo
            /// 给一个名称，添加导扩展 的network list里 ，检查是否存在


            //var serializer = new XmlSerializer(typeof(NodeNetworkViewModel));
            //var writer = new StringWriter();
            //serializer.Serialize(writer, _network);

            //XmlWriterSettings settings = new XmlWriterSettings();
            //settings.Indent = true;
            //settings.IndentChars = "    ";
            //XmlWriter writerqwe = XmlWriter.Create(@"F:\2.dev\4. revitSysTopu\output.xml", settings);


            //var serializer = new XmlSerializer(typeof(NetworkViewModel));
            //var reader = new StringReader(xmlString);
            //var nodeNetwork = (NodeNetworkViewModel)serializer.Deserialize(reader);

        }

        private void LayoutArrangeCommand() {
            //ForceDirectedLayouter layouter = new ForceDirectedLayouter();
            //var config = new Configuration
            //{
            //    Network = this.Network,
            //};
            //layouter.Layout(config, 10000);
            foreach (var item in _network.SelectedNodes.Items)
            {
                var node = (TreeNode)item;

                OrderNode(node);
            }

            void OrderNode(TreeNode node) {
                if (node.ChildNodes.Count > 1) return;
                foreach (var chn in node.ChildNodes)
                {
                    chn.Position = new System.Windows.Point(node.Position.X + _XOffset, node.Position.Y);
                    OrderNode(chn);
                }
            }
        }


        // todo 根据连线确定子和父
        private void LayoutGridCommand() {
           //var networkView = Network;
            var roots = _network.Nodes.Items.ToArray().Where(x => ((TreeNode)x).TreeNodeParent == null);
             //var roots = networkView.Nodes.Items.ToArray().Where(x => ((TreeNode)x).Inputs.Count ==0);
            foreach (TreeNode root in roots)
            {
                OrderNode(root);
            }

            void OrderNode(TreeNode node)
            {

                if (node.ChildNodes.Count > 0)
                {
                    var parentPosition = node.Position;

                    for (int i = 0; i < node.ChildNodes.Count; i++)
                    {
                        var position = new System.Windows.Point(parentPosition.X + _XOffset, parentPosition.Y);
                        if (node.ChildNodes.Count > 1)
                        {
                            position = new System.Windows.Point(parentPosition.X + _XOffset, parentPosition.Y + i * _YOffset);
                        }
                        var child = node.ChildNodes[i];
                        child.Position = position;
                        OrderNode(child);
                    }
                }
            }
        }

        private void SyncShowNode(int eleIntegerValue,bool isSelected = true)
        {
            foreach (TreeNode treeNode in _network.Nodes.Items)
            {
                if (treeNode.ElementId.IntegerValue == eleIntegerValue)
                {
                    _network.ZoomFactor = 1;

                    _network.DragOffset = new System.Windows.Point(-treeNode.Position.X + NetworkViewportRegion.Width / 2 + 50, -treeNode.Position.Y + NetworkViewportRegion.Height / 2 + 50);
                    treeNode.IsSelected = isSelected;
                    break;
                }
            }
        }

        private void FocusToRevit(UIApplication uiapp)
        {
            IsUpdataCurrentNodeSystemChange = false;
            var initNodeSystem = _currentNodeSystem;
            try
            {
                var openViews = uiapp.ActiveUIDocument.GetOpenUIViews();
                var initView = uiapp.ActiveUIDocument.ActiveView;
                Autodesk.Revit.DB.View dummyView = null;

                var queryUv = openViews.FirstOrDefault(x => x.ViewId != initView?.Id);
                if (queryUv != null)
                    dummyView = uiapp.ActiveUIDocument.Document.GetElement(queryUv.ViewId) as Autodesk.Revit.DB.View;

                bool needClose = false;
                if (dummyView == null)
                {
                    dummyView = new Autodesk.Revit.DB.FilteredElementCollector(uiapp.ActiveUIDocument.Document)
                                .OfCategory(Autodesk.Revit.DB.BuiltInCategory.OST_Views)
                                .WhereElementIsNotElementType()
                                .FirstOrDefault(v => v.Id != initView?.Id) as Autodesk.Revit.DB.View;
                    needClose = true;
                }

                if (dummyView != null && initView != null)
                {
                    uiapp.ActiveUIDocument.ActiveView = dummyView;
                    uiapp.ActiveUIDocument.ActiveView = initView;
                    if (needClose)
                    {
                        try
                        {
                            var uv = uiapp.ActiveUIDocument.GetOpenUIViews().FirstOrDefault(x => x.ViewId == dummyView.Id);
                            if (uv != null)
                            {
                                uv.Close();
                            }
                        }
                        catch { }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            CurrentNodeSystem = initNodeSystem;
            IsUpdataCurrentNodeSystemChange = true;


        }

    }
}
