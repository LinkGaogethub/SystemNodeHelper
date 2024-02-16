using Autodesk.Revit.DB;
using DynamicData;
using NodeNetwork.ViewModels;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using SystemNodeHelper.View;
using SystemNodeHelper.ViewModel;

namespace SystemNodeHelper.Utility
{
    public class NetworkConverter
    {
        private readonly NetworkViewModel _vm;

        public NetworkConverter(NetworkViewModel vm)
        {
            _vm = vm;
        }

        public Network BuildModel(string name)
        {
           // string str = Interaction.InputBox("提示信息", "标题", "文本内容", -1, -1);
        
         

            List<TreeNode> nodeViewModels = _vm.Nodes.Items.Cast<TreeNode>().ToList();
            List<SerializedNode> serializedNodes = new List<SerializedNode>();
            List<SerializedConnection> serializedConnections = new List<SerializedConnection>();
            foreach (TreeNode modelBase in nodeViewModels)
            {
                SerializedNode node = new SerializedNode
                {
                    ElementIdIntegerValue = modelBase.ElementId.IntegerValue,
                    ElementUniqueId = modelBase.Element.UniqueId,
                    Name = modelBase.Name,
                    //ModelData = modelBase.Data,
                    Type = modelBase.GetType().FullName,
                    Postion = modelBase.Position,
                    State = modelBase.IsCollapsed
                };
                serializedNodes.Add(node);
            }

            foreach (var connection in _vm.Connections.Items)
                serializedConnections.Add(new SerializedConnection
                {
                    From = (connection.Output.Parent as TreeNode).Element.UniqueId,
                    To = (connection.Input.Parent as TreeNode).Element.UniqueId,
                    InputName = connection.Input.Name,
                    OutputName = connection.Output.Name
                });

            return new Network(name,serializedNodes, serializedConnections);
        }


        public NetworkViewModel LoadModel(Document doc,Network net)
        {
            List<TreeNode> nodes = new List<TreeNode>();
            foreach (var nodeVm in net.SerializedNodes)
            {
                var type = Type.GetType(nodeVm.Type);
                if (type == null)
                    throw new Exception("Type not found");
               // var node = (NodeViewModelBase)Activator.CreateInstance(type);
                var input = net.SerializedConnections.FirstOrDefault(x => x.To == nodeVm.ElementUniqueId);
                var node = new TreeNode(doc, new ElementId(nodeVm.ElementIdIntegerValue), input == null);
                node.ElementUniqueId = nodeVm.ElementUniqueId;
                node.Name = nodeVm.Name;
                node.Position = nodeVm.Postion;
                //node.Data = nodeVm.ModelData;
                //node.IsCollapsed = nodeVm.State;
                var outputs = net.SerializedConnections.Where(x => x.From == nodeVm.ElementUniqueId);

                for (int i = 0; i < outputs.Count(); i++)
                {
                    var node1Input = new NodeOuputUnchange();
                    //node1Input.IsEditorVisible = true;
                    node1Input.Name = "Connector" + (i + 1);
                    node.Outputs.Add(node1Input);
                }
                nodes.Add(node);
                _vm.Nodes.Add(node);

            }


          // _vm.Nodes.AddRange(nodes);
            foreach (var connection in net.SerializedConnections)
            {
                var from = nodes.FirstOrDefault(x => x.ElementUniqueId == connection.From);
                var to = nodes.FirstOrDefault(x => x.ElementUniqueId == connection.To);
                to.TreeNodeParent = from;
                from.ChildNodes.Add(to);
                if (from == null || to == null) continue;
                //    throw new Exception("Node not found");
                var fromOutput = from.Outputs.Items.FirstOrDefault(x => x.Name == connection.OutputName);
                var toInput = to.Inputs.Items.FirstOrDefault(x => x.Name == connection.InputName);
                if (fromOutput == null || toInput == null) continue;
                //  throw new Exception("Input or Output not found");
                //var con = _vm.ConnectionFactory(toInput, fromOutput);
                //_vm.Connections.Edit(x => x.Add(con));

                _vm.Connections.Add(new ConnectionViewModel(_vm, toInput, fromOutput));

            }

            return _vm;
        }
    }


    public class Network
    {
        public string Name { get; set; }
        public List<SerializedNode> SerializedNodes { get; set; }
        public List<SerializedConnection> SerializedConnections { get; set; }

        public Network(string name,List<SerializedNode> serializedNode, List<SerializedConnection> serializedConnection) {

            SerializedNodes = serializedNode;
            SerializedConnections = serializedConnection;
            Name = name;
        }


    }

    public class SerializedConnection
    {
        public string From { get; set; }
        public string To { get; set; }
        public string InputName { get; set; }
        public string OutputName { get; set; }
    }

    public class SerializedNode
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string ElementUniqueId { get; set; }
        public int ElementIdIntegerValue { get; set; }
        public System.Windows.Point Postion { get; set; }
        public bool State { get; set; }
      //  public NodeModelBase ModelData { get; set; }
    }

    //public class NodeViewModelBase : ColorNodeViewModel
    //{
    //    static NodeViewModelBase()
    //    {
    //        Splat.Locator.CurrentMutable.Register(() => new ColorNodeView(), typeof(IViewFor<NodeViewModelBase>));
    //    }
    //    public Guid Id { get; set; }
    //    public NodeViewModelBase()
    //    {
    //        Id = Guid.NewGuid();

    //    }
    //}
}
