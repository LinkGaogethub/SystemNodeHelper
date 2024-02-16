using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.ExtensibleStorage;
using Autodesk.Revit.UI;
using Revit.Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemNodeHelper.Utility;

namespace SystemNodeHelper.RevitCommandEventHandel
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    [Journaling(JournalingMode.UsingCommandData)]
    public class ShowPaneCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {

            RevitApplication.SetWindowAvibilable();
            return Result.Succeeded;
            //UIDocument uidoc = commandData.Application.ActiveUIDocument;
            //Document doc = uidoc.Document;
        }
    }
}
