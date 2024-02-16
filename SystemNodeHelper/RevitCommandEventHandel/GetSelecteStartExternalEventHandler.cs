using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Revit.Async;
using Revit.Async.ExternalEvents;
using Revit.Async.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemNodeHelper.RevitCommandEventHandel
{
    public class GetSelecteStartExternalEventHandler : SyncGenericExternalEventHandler<string, Element>
    {
        public override object Clone()
        {
            //throw new NotImplementedException();
            return null;
        }

        public override string GetName()
        {
            return "GetSelecteStartExternalEventHandler";
        }

        protected override Element Handle(UIApplication app, string parameter)
        {

            var sele = app.ActiveUIDocument.Selection.GetElementIds();

            if (sele.Count() == 1)
            {
                return app.ActiveUIDocument.Document.GetElement(sele.Single());
            }
            return null;
        }
    }


}
