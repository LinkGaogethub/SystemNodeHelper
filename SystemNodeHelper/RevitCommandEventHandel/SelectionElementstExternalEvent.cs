using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemNodeHelper.RevitCommandEventHandel
{
    public class SelectionElementstExternalEvent : IExternalEventHandler
    {
        public List<ElementId> ElementIds = new List<ElementId>();
        public void Execute(UIApplication app)
        {
            var sel = app.ActiveUIDocument.Selection;
            sel.SetElementIds(ElementIds);
        }

        public string GetName()
        {
            return this.GetType().Name;
        }
    }
}
