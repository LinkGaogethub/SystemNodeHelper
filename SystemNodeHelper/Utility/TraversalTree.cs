using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Plumbing;
using DynamicData;
using Newtonsoft.Json;
using ReactiveUI;
using Revit.Async;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using SystemNodeHelper.RevitCommandEventHandel;
using SystemNodeHelper.View;
using SystemNodeHelper.ViewModel;

namespace SystemNodeHelper.Utility
{
    /// <summary>
    /// A TreeNode object represents an element in the system
    /// </summary>
    public class TreeNode : ColorNodeViewModel
    {
        //static TreeNode()
        //{
        //    Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<TreeNode>));
        //}
        static TreeNode()
        {
            Splat.Locator.CurrentMutable.Register(() => new ColorNodeView(), typeof(IViewFor<TreeNode>));
        }

        #region Member variables
        /// <summary>
        /// Id of the element
        /// </summary>
        private Autodesk.Revit.DB.ElementId m_Id;
        /// <summary>
        /// Flow direction of the node
        /// For the starting element of the traversal, the direction will be the same as the connector
        /// connected to its following element; Otherwise it will be the direction of the connector connected to
        /// its previous element
        /// </summary>
        private FlowDirectionType m_direction;
        /// <summary>
        /// The parent node of the current node.
        /// </summary>
        private TreeNode m_parent;
        /// <summary>
        /// The connector of the previous element to which current element is connected
        /// </summary>
        private Connector m_inputConnector;
        /// <summary>
        /// The first-level child nodes of the current node
        /// </summary>
        private List<TreeNode> m_childNodes;
        /// <summary>
        /// Active document of Revit
        /// </summary>
        private Document m_document;
        private Element _element;
        #endregion


     

        #region Properties
        /// <summary>
        /// Id of the element
        /// </summary>
        public Autodesk.Revit.DB.ElementId ElementId
        {
            get
            {
                return m_Id;
            }
        }
        public string ElementUniqueId;
        public Autodesk.Revit.DB.Element Element
        {
            get
            {
                return _element;
            }
        }

        /// <summary>
        /// Flow direction of the node
        /// </summary>
        public FlowDirectionType Direction
        {
            get
            {
                return m_direction;
            }
            set
            {
                m_direction = value;
            }
        }

        /// <summary>
        /// Gets and sets the parent node of the current node.
        /// </summary>
        public TreeNode TreeNodeParent
        {
            get
            {
                return m_parent;
            }
            set
            {
                m_parent = value;
            }
        }

        /// <summary>
        /// Gets and sets the first-level child nodes of the current node
        /// </summary>
        public List<TreeNode> ChildNodes
        {
            get
            {
                return m_childNodes;
            }
            set
            {
                m_childNodes = value;
            }
        }

       
        //public NodeInputViewModel NodeInputViewModel
        //{
        //    get {
        //        var node1Input  = new NodeInputViewModel();
        //        node1Input.Name = "input";
        //        return node1Input;
        //    }
        //}

        // public List<NodeOutputViewModel> NodeOutputViewModelLisy = new List<NodeOutputViewModel>();

        //public NodeViewModel NodeViewModel { set; get; }

        /// <summary>
        /// The connector of the previous element to which current element is connected
        /// </summary>
        public Connector InputConnector
        {
            get
            {
                return m_inputConnector;
            }
            set
            {
                m_inputConnector = value;
            }
        }
        #endregion



        public TreeNode() : base() { 
        
        }
        #region Methods
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="doc">Revit document</param>
        /// <param name="id">Element's Id</param>
        public TreeNode(Document doc, Autodesk.Revit.DB.ElementId id, bool isStartNode =  false):base()
        {
           
            m_document = doc;
            m_Id = id;
            m_childNodes = new List<TreeNode>();


            //this.Name = "Constant";

            //Output = new ValueNodeOutputViewModel<int?>
            //{
            //    Name = "Value",
            //    Editor = ValueEditor,
            //    Value = this.WhenAnyValue(vm => vm.ValueEditor.Value)
            //};
            //this.Outputs.Add(Output);
            try {

                Element element = _element = m_document.GetElement(m_Id);
                FamilyInstance fi = element as FamilyInstance;
                //var node1 = new NodeViewModel();
                // node1.PropertyChanged += Node1_PropertyChanged;
                var title = new StringBuilder();
                if (fi == null)
                {
                    if (element is Duct)
                    {
                        var duct = element as Duct;
                        title.AppendLine(duct.DuctType.get_Parameter(BuiltInParameter.ALL_MODEL_FAMILY_NAME).AsString());
                        title.AppendLine(duct.DuctType.Name);
                    }
                    else {
                        title.AppendLine(element.Name);
                    }
                }
                else
                {

                    if (fi.Symbol != null)
                    {
                        title.AppendLine(fi.Symbol.FamilyName);
                        title.AppendLine(fi.Symbol.Name);
                    }
                    // todo  染色 根据filter

                    //MEPModel mepModel = fi.MEPModel;
                    //if (mepModel is MechanicalEquipment)
                    //{
                    //    title = "MechanicalEquipment";
                    //}
                    //else if (mepModel is MechanicalFitting)
                    //{
                    //    MechanicalFitting mf = mepModel as MechanicalFitting;
                    //    title = "MechanicalFitting";
                    //}
                    //else
                    //{
                    //    title = "FamilyInstance";
                    //}
                }
                Name = title.ToString();
                // if (isAddInput)
                //{

                if (!isStartNode) {
                    var node1Input = new NodeInputUnchange();

                    node1Input.Name = "Connector";
                    Inputs.Add(node1Input);
                }
                
                // }

                //for (int i = 0; i < ChildNodes.Count(); i++)
                //{
                //    // var childNode = ChildNodes[i];
                //    var output = new NodeOuputUnchange();
                //    //output.SetConnectionPreview(false);

                //    output.Name = "Connector" + (i + 1);
                //    Outputs.Add(output);
                //}
                PropertyChanged += TreeNodePropertyChanged;

            }
            catch(Exception ex)
            {



            }
           
        }

        private void TreeNodePropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
           

            if (e.PropertyName == "IsSelected")
            {
                // 判断是不是在框选 状态
                var treeNode = sender as TreeNode;
                if (IsSelected)
                {
                    RevitApplication.SelectionElementstExternalEvent.ElementIds.Add(treeNode.ElementId);
                }
                else
                {
                    RevitApplication.SelectionElementstExternalEvent.ElementIds = RevitApplication.SelectionElementstExternalEvent.ElementIds.SkipWhile(x => x == treeNode.ElementId).ToList();
                }

                RevitApplication.SelectionElements.Raise();
            }

        }

        /// <summary>
        /// Get Element by its Id
        /// </summary>
        /// <param name="eid">Element's Id</param>
        /// <returns>Element</returns>
        private Element GetElementById(Autodesk.Revit.DB.ElementId eid)
        {
            return m_document.GetElement(eid);
        }

        /// <summary>
        /// Dump the node into XML file
        /// </summary>
        /// <param name="writer">XmlWriter object</param>
        public void DumpIntoXML(XmlWriter writer)
        {
            // Write node information
            Element element = GetElementById(m_Id);
            FamilyInstance fi = element as FamilyInstance;
            if (fi != null)
            {
                MEPModel mepModel = fi.MEPModel;
                String type = String.Empty;
                if (mepModel is MechanicalEquipment)
                {
                    type = "MechanicalEquipment";
                    writer.WriteStartElement(type);
                }
                else if (mepModel is MechanicalFitting)
                {
                    MechanicalFitting mf = mepModel as MechanicalFitting;
                    type = "MechanicalFitting";
                    writer.WriteStartElement(type);
                    writer.WriteAttributeString("Category", element.Category.Name);
                    writer.WriteAttributeString("PartType", mf.PartType.ToString());
                }
                else
                {
                    type = "FamilyInstance";
                    writer.WriteStartElement(type);
                    writer.WriteAttributeString("Category", element.Category.Name);
                }

                writer.WriteAttributeString("Name", element.Name);
                writer.WriteAttributeString("Id", element.Id.IntegerValue.ToString());
                writer.WriteAttributeString("Direction", m_direction.ToString());
                writer.WriteEndElement();
            }
            else
            {
                String type = element.GetType().Name;

                writer.WriteStartElement(type);
                writer.WriteAttributeString("Name", element.Name);
                writer.WriteAttributeString("Id", element.Id.IntegerValue.ToString());
                writer.WriteAttributeString("Direction", m_direction.ToString());
                writer.WriteEndElement();
            }

            foreach (TreeNode node in m_childNodes)
            {
                if (m_childNodes.Count > 1)
                {
                    writer.WriteStartElement("Path");
                }

                node.DumpIntoXML(writer);

                if (m_childNodes.Count > 1)
                {
                    writer.WriteEndElement();
                }
            }
        }
        #endregion
    }

    /// <summary>
    /// Data structure of the traversal
    /// </summary>
    public class TraversalTree
    {
        #region Member variables
        // Active document of Revit
        private Document m_document;
        // The MEP system of the traversal
        private MEPSystem m_system;
        // The flag whether the MEP system of the traversal is a mechanical system or piping system
        private Boolean m_isMechanicalSystem;
        // The starting element node
        private TreeNode m_startingElementNode;


        public TreeNode StartingElementNode { get { return m_startingElementNode; } }
        #endregion

        #region Methods
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="activeDocument">Revit document</param>
        /// <param name="system">The MEP system to traverse</param>
        public TraversalTree(Document activeDocument, MEPSystem system)
        {
            m_document = activeDocument;
            m_system = system;
            m_isMechanicalSystem = (system is MechanicalSystem);
        }

        /// <summary>
        /// Traverse the system
        /// </summary>
        public void Traverse(Element element)
        {
            // Get the starting element node
            m_startingElementNode = GetStartingElementNode( element);

            // Traverse the system recursively
            Traverse(m_startingElementNode);
        }

        /// <summary>
        /// Get the starting element node.
        /// If the system has base equipment then get it;
        /// Otherwise get the owner of the open connector in the system
        /// </summary>
        /// <returns>The starting element node</returns>
        private  TreeNode GetStartingElementNode(Element element)
        {
            TreeNode startingElementNode = null;

            FamilyInstance equipment = m_system.BaseEquipment;
            //
            // If the system has base equipment then get it;
            // Otherwise get the owner of the open connector in the system
            if (equipment != null)
            {
                startingElementNode = new TreeNode(m_document, equipment.Id,true);
            }
            else
            {
                 //todo 可以提示
                //var ownerOfOpenConnector =  GetOwnerOfOpenConnector();
                //startingElementNode = new TreeNode(m_document, ownerOfOpenConnector.Id, true);
                startingElementNode = new TreeNode(m_document, element.Id, true);
            }

            startingElementNode.TreeNodeParent = null;
            startingElementNode.InputConnector = null;

            return startingElementNode;
        }

        /// <summary>
        /// Get the owner of the open connector as the starting element
        /// </summary>
        /// <returns>The owner</returns>
        private    Element   GetOwnerOfOpenConnector()
        {
        //   Element element = null;

            //
            // Get an element from the system's terminals
            ElementSet elements = m_system.Elements;
            foreach (Element ele in elements)
            {
              //  element = ele;
                Connector openConnector = GetOpenConnector(ele, null);
                if (openConnector != null) return openConnector.Owner;
            }
            return null;
           //var result = await RevitTask.RunAsync(async app =>
           // {
           //     // 在这里执行同步代码，返回一个结果
           //     return RevitTask.RaiseGlobal<GetSelecteStartExternalEventHandler, string, Element>("");
           // });
            // TODO 提示

            // Get the open connector recursively
           // return result.Result;

          //  return openConnector.Owner;
        }

        /// <summary>
        /// Get the open connector of the system if the system has no base equipment
        /// </summary>
        /// <param name="element">An element in the system</param>
        /// <param name="inputConnector">The connector of the previous element 
        /// to which the element is connected </param>
        /// <returns>The found open connector</returns>
        private Connector GetOpenConnector(Element element, Connector inputConnector)
        {
            Connector openConnector = null;
            ConnectorManager cm = null;
            //
            // Get the connector manager of the element
            if (element is FamilyInstance)
            {
                FamilyInstance fi = element as FamilyInstance;
                cm = fi.MEPModel.ConnectorManager;
            }
            else
            {
                MEPCurve mepCurve = element as MEPCurve;
                cm = mepCurve.ConnectorManager;
            }

            foreach (Connector conn in cm.Connectors)
            {
                // Ignore the connector does not belong to any MEP System or belongs to another different MEP system
                if (conn.MEPSystem == null || !conn.MEPSystem.Id.IntegerValue.Equals(m_system.Id.IntegerValue))
                {
                    continue;
                }

                // If the connector is connected to the input connector, they will have opposite flow directions.
                if (inputConnector != null && conn.IsConnectedTo(inputConnector))
                {
                    continue;
                }

                // If the connector is not connected, it is the open connector
                if (!conn.IsConnected)
                {
                    openConnector = conn;
                    break;
                }

                //
                // If open connector not found, then look for it from elements connected to the element
                foreach (Connector refConnector in conn.AllRefs)
                {
                    // Ignore non-EndConn connectors and connectors of the current element
                    if (refConnector.ConnectorType != ConnectorType.End ||
                        refConnector.Owner.Id.IntegerValue.Equals(conn.Owner.Id.IntegerValue))
                    {
                        continue;
                    }

                    // Ignore connectors of the previous element
                    if (inputConnector != null && refConnector.Owner.Id.IntegerValue.Equals(inputConnector.Owner.Id.IntegerValue))
                    {
                        continue;
                    }

                    openConnector = GetOpenConnector(refConnector.Owner, conn);
                    if (openConnector != null)
                    {
                        return openConnector;
                    }
                }
            }

            return openConnector;
        }

        /// <summary>
        /// Traverse the system recursively by analyzing each element
        /// </summary>
        /// <param name="elementNode">The element to be analyzed</param>
        private void Traverse(TreeNode elementNode)
        {
            //
            // Find all child nodes and analyze them recursively
            AppendChildren(elementNode);

            foreach (TreeNode node in elementNode.ChildNodes)
            {
                Traverse(node);
            }
        }

        /// <summary>
        /// Find all child nodes of the specified element node
        /// </summary>
        /// <param name="elementNode">The specified element node to be analyzed</param>
        private void AppendChildren(TreeNode elementNode)
        {
            List<TreeNode> nodes = elementNode.ChildNodes;
            ConnectorSet connectors;
            //
            // Get connector manager
            Element element = GetElementById(elementNode.ElementId);
            FamilyInstance fi = element as FamilyInstance;
            if (fi != null)
            {
                connectors = fi.MEPModel.ConnectorManager.Connectors;
            }
            else
            {
                MEPCurve mepCurve = element as MEPCurve;
                connectors = mepCurve.ConnectorManager.Connectors;
            }
            var i = 0;
            // Find connected connector for each connector
            foreach (Connector connector in connectors)
            {
                MEPSystem mepSystem = connector.MEPSystem;
                // Ignore the connector does not belong to any MEP System or belongs to another different MEP system
                if (mepSystem == null || !mepSystem.Id.IntegerValue.Equals(m_system.Id.IntegerValue))
                {
                    continue;
                }

                //
                // Get the direction of the TreeNode object
                if (elementNode.TreeNodeParent == null)
                {
                    if (connector.IsConnected)
                    {
                        elementNode.Direction = connector.Direction;
                    }
                }
                else
                {
                    // If the connector is connected to the input connector, they will have opposite flow directions.
                    // Then skip it.
                    if (connector.IsConnectedTo(elementNode.InputConnector))
                    {
                        elementNode.Direction = connector.Direction;
                        continue;
                    }
                }

                // Get the connector connected to current connector
                Connector connectedConnector = GetConnectedConnector(connector);
                if (connectedConnector != null)
                {
                    TreeNode node = new TreeNode(m_document, connectedConnector.Owner.Id);
                    node.InputConnector = connector;
                    node.TreeNodeParent = elementNode;
                   // node.ParentNodes = elementNode;
                    nodes.Add(node);


                    var output = new NodeOuputUnchange();
                    output.Name = "Connector" + (i++ + 1);
                    elementNode.Outputs.Add(output);
              
                }
            }

            nodes.Sort(delegate (TreeNode t1, TreeNode t2)
            {
                return t1.ElementId.IntegerValue > t2.ElementId.IntegerValue ? 1 : (t1.ElementId.IntegerValue < t2.ElementId.IntegerValue ? -1 : 0);
            }
            );
        }

        /// <summary>
        /// Get the connected connector of one connector
        /// </summary>
        /// <param name="connector">The connector to be analyzed</param>
        /// <returns>The connected connector</returns>
        static private Connector GetConnectedConnector(Connector connector)
        {
            Connector connectedConnector = null;
            ConnectorSet allRefs = connector.AllRefs;
            foreach (Connector conn in allRefs)
            {
                // Ignore non-EndConn connectors and connectors of the current element
                if (conn.ConnectorType != ConnectorType.End ||
                    conn.Owner.Id.IntegerValue.Equals(connector.Owner.Id.IntegerValue))
                {
                    continue;
                }

                connectedConnector = conn;
                break;
            }

            return connectedConnector;
        }

        /// <summary>
        /// Get element by its id
        /// </summary>
        private Element GetElementById(Autodesk.Revit.DB.ElementId eid)
        {
            return m_document.GetElement(eid);
        }

        /// <summary>
        /// Dump the traversal into an XML file
        /// </summary>
        /// <param name="fileName">Name of the XML file</param>
        public void DumpIntoXML(String fileName)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "    ";
            XmlWriter writer = XmlWriter.Create(fileName, settings);

            // Write the root element
            String mepSystemType = String.Empty;
            mepSystemType = (m_system is MechanicalSystem ? "MechanicalSystem" : "PipingSystem");
            writer.WriteStartElement(mepSystemType);

            // Write basic information of the MEP system
            WriteBasicInfo(writer);
            // Write paths of the traversal
            WritePaths(writer);

            // Close the root element
            writer.WriteEndElement();

            writer.Flush();
            writer.Close();
        }

        /// <summary>
        /// Write basic information of the MEP system into the XML file
        /// </summary>
        /// <param name="writer">XMLWriter object</param>
        private void WriteBasicInfo(XmlWriter writer)
        {
            MechanicalSystem ms = null;
            PipingSystem ps = null;
            if (m_isMechanicalSystem)
            {
                ms = m_system as MechanicalSystem;
            }
            else
            {
                ps = m_system as PipingSystem;
            }

            // Write basic information of the system
            writer.WriteStartElement("BasicInformation");

            // Write Name property
            writer.WriteStartElement("Name");
            writer.WriteString(m_system.Name);
            writer.WriteEndElement();

            // Write Id property
            writer.WriteStartElement("Id");
            writer.WriteValue(m_system.Id.IntegerValue);
            writer.WriteEndElement();

            // Write UniqueId property
            writer.WriteStartElement("UniqueId");
            writer.WriteString(m_system.UniqueId);
            writer.WriteEndElement();

            // Write SystemType property
            writer.WriteStartElement("SystemType");
            if (m_isMechanicalSystem)
            {
                writer.WriteString(ms.SystemType.ToString());
            }
            else
            {
                writer.WriteString(ps.SystemType.ToString());
            }
            writer.WriteEndElement();

            // Write Category property
            writer.WriteStartElement("Category");
            writer.WriteAttributeString("Id", m_system.Category.Id.IntegerValue.ToString());
            writer.WriteAttributeString("Name", m_system.Category.Name);
            writer.WriteEndElement();

            // Write IsWellConnected property
            writer.WriteStartElement("IsWellConnected");
            if (m_isMechanicalSystem)
            {
                writer.WriteValue(ms.IsWellConnected);
            }
            else
            {
                writer.WriteValue(ps.IsWellConnected);
            }
            writer.WriteEndElement();

            // Write HasBaseEquipment property
            writer.WriteStartElement("HasBaseEquipment");
            bool hasBaseEquipment = ((m_system.BaseEquipment == null) ? false : true);
            writer.WriteValue(hasBaseEquipment);
            writer.WriteEndElement();

            // Write TerminalElementsCount property
            writer.WriteStartElement("TerminalElementsCount");
            writer.WriteValue(m_system.Elements.Size);
            writer.WriteEndElement();

            // Write Flow property
            writer.WriteStartElement("Flow");
            if (m_isMechanicalSystem)
            {
                writer.WriteValue(ms.GetFlow());
            }
            else
            {
                writer.WriteValue(ps.GetFlow());
            }
            writer.WriteEndElement();

            // Close basic information
            writer.WriteEndElement();
        }

        /// <summary>
        /// Write paths of the traversal into the XML file
        /// </summary>
        /// <param name="writer">XMLWriter object</param>
        private void WritePaths(XmlWriter writer)
        {
            writer.WriteStartElement("Path");
            m_startingElementNode.DumpIntoXML(writer);
            writer.WriteEndElement();
        }
        #endregion
    }
}
