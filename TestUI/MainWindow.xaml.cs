using DynamicData;
using Newtonsoft.Json;
using NodeNetwork.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Serialization;
using SystemNodeHelper.Utility;
using SystemNodeHelper.ViewModel;

namespace TestUI
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var mainWin = new SystemNodeHelper.MainWindow();
            var network = mainWin.MainDockablePaneControl.ViewModel.Network;

            var node1 = new NodeViewModel();
            node1.Name = "Node 1";
            node1.Position = new Point(500, 500);
            network.Nodes.Add(node1);
    

            //var serializer = new XmlSerializer(typeof(NodeViewModel));
            //var writer = new StringWriter();
            //serializer.Serialize(writer, node1);


            var node1Input = new NodeInputViewModel();
            //node1Input.IsEditorVisible = true;
            node1.Position = new Point(200, 500);
            node1Input.Name = "Node 1 input";
            node1.Inputs.Add(node1Input);

            var node2 = new NodeViewModel();
            node2.Name = "Node 2";
            network.Nodes.Add(node2);
            var node2Output = new NodeOutputViewModel();
            node2Output.Name = "Node 2 output";
            node2.Outputs.Add(node2Output);



            var connection = new ConnectionViewModel(network, node1Input, node2Output);
            connection.CanBeRemovedByUser = true;
            network.Connections.Add(connection);


            
      
          //  File.Write(JsonSerializer.Serialize(serializedNetwork);

            mainWin.MainDockablePaneControl.ViewModel.NodeSystems.Add("aaa");
            mainWin.ShowDialog();
            Close();
        }
    }
}
