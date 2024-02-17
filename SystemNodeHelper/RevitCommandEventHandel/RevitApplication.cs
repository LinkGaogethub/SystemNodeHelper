using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DynamicData;
using Newtonsoft.Json;
using NodeNetwork;
using Revit.Async;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using SystemNodeHelper.Utility;
using SystemNodeHelper.View;

namespace SystemNodeHelper.RevitCommandEventHandel
{
    public class RevitApplication : IExternalApplication
    {

        static RevitApplication()
        {
            NNViewRegistrar.RegisterSplat();
        }
        public static ExternalEvent SelectionElements;
        public static SelectionElementstExternalEvent SelectionElementstExternalEvent;
        //static RevitApplication Instance = this;
        //static RevitApplication Instance {

        //   re
        //}
        //public static ExternalEvent ShowElement;
        //public static ShowElementExternalEvent ShowElementEvent;

        //public static ExternalEvent SelectionElements;
        //public static SelectionElementstExternalEvent SelectionElementstExternalEvent;


        public static Guid DockablePaneGuid = new Guid("8A5B9B65-213F-4F61-A023-B3A505C9997F");

        public static MainDockablePane MainDockablePane;
        private static UIControlledApplication UIControlledApplication;
        public static string AssemblyPath = Assembly.GetExecutingAssembly().Location;
        public static string DetailComponentsDirPath = new FileInfo(RevitApplication.AssemblyPath).Directory.FullName + "\\DetailComponents";
      
        Result IExternalApplication.OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        Result IExternalApplication.OnStartup(UIControlledApplication app)
        {
            RevitTask.Initialize(app);
            app.ViewActivated += App_ViewActivated;
          //  app.ControlledApplication.DocumentOpened += ControlledApplication_DocumentOpened;

            SelectionElementstExternalEvent = new SelectionElementstExternalEvent();
            SelectionElements = ExternalEvent.Create(SelectionElementstExternalEvent);

            var title = "系统助手";
            //app.CreateRibbonTab(title);
            var commandName = typeof(ShowPaneCommand).FullName;

            RibbonPanel rvtRibbonPanel = app.CreateRibbonPanel(title);

            PushButtonData data = new PushButtonData(title, title, AssemblyPath, commandName);
            RibbonItem item = rvtRibbonPanel.AddItem(data);
            PushButton showViewBtn = item as PushButton;

            showViewBtn.LargeImage = new BitmapImage(new Uri("pack://application:,,,/SystemNodeHelper;component/Resources/img/Topology.png", UriKind.Absolute));


            DockablePaneId dockablePaneId = new DockablePaneId(DockablePaneGuid);
            MainDockablePane = new MainDockablePane();
            app.RegisterDockablePane(dockablePaneId, "", MainDockablePane);
            UIControlledApplication = app;
            return Result.Succeeded;
        }

        private void App_ViewActivated(object sender, Autodesk.Revit.UI.Events.ViewActivatedEventArgs e)
        {
            var doc = e.Document;
            var networkListString = ExtendedDataUtil.ReadExtendedData(doc);
            var mainViewModel = MainDockablePane.MainDockablePaneControl.ViewModel;
            if (!mainViewModel.IsUpdataCurrentNodeSystemChange) return;
                mainViewModel.Network.Nodes.Clear();
                mainViewModel.NodeSystems.Clear();
            if (networkListString != null)
            {
                var networkNames = JsonConvert.DeserializeObject<List<Network>>(networkListString).Select(x => x.Name);
                mainViewModel.NodeSystems.AddRange(networkNames);
            }
            // throw new NotImplementedException();
        }

        // todo 处理成切换active view//  切换doc
        private void ControlledApplication_DocumentOpened(object sender, Autodesk.Revit.DB.Events.DocumentOpenedEventArgs e)
        {
            var doc = e.Document;
            var networkListString = ExtendedDataUtil.ReadExtendedData(doc);
            if (networkListString != null) {
                var networkNames = JsonConvert.DeserializeObject<List<Network>>(networkListString).Select(x =>x.Name);
                MainDockablePane.MainDockablePaneControl.ViewModel.NodeSystems.AddRange(networkNames);
            }

        }

        public static void SetWindowAvibilable()
        {
            var dockablePane = UIControlledApplication.GetDockablePane(new DockablePaneId(DockablePaneGuid));

            dockablePane.Show();

        }

    }
}
