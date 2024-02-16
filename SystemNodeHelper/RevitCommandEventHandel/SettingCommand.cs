using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DynamicData;
using Newtonsoft.Json;
using NodeNetwork.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using SystemNodeHelper.Utility;
using SystemNodeHelper.View;
using SystemNodeHelper.ViewModel;
using static System.Windows.Forms.AxHost;

namespace SystemNodeHelper.RevitCommandEventHandel
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    [Journaling(JournalingMode.UsingCommandData)]
    public class SettingCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var doc = commandData.Application.ActiveUIDocument.Document;
            var app = commandData.Application;
            var avaDetailComponentsFamilySymbol = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_DetailComponents).OfClass(typeof(FamilySymbol)).Cast<FamilySymbol>();

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
                // return;
                return Result.Succeeded;
            }

            drafting.Scale = 50;
            transaction.Commit();
            app.ActiveUIDocument.ActiveView = drafting;
            

                var p1 = new XYZ(0, 0, 0);  
                var p2 = new XYZ(0, 1000 , 0);

                CreateDetailLine(p1, p2);

            Transaction transaction2 = new Transaction(doc, "Create NewFamilyInstance");
            transaction2.Start();
            //XYZ origin = new XYZ(0, 0, 0);
            var familySymbols = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_DetailComponents).OfClass(typeof(FamilySymbol)).ToArray();
            var instance = doc.Create.NewFamilyInstance(p1, familySymbols[1] as FamilySymbol, drafting);
            transaction2.Commit();
            void CreateDetailLine(XYZ endpoint, XYZ startpoint)
                {
                    using (Transaction drawDrafting = new Transaction(doc, "Draw Drafting"))
                {
                    drawDrafting.Start();

                    var graphicsStyleqwe = new FilteredElementCollector(doc).OfClass(typeof(GraphicsStyle)).ToElements();
                    var graphicsStyle = new FilteredElementCollector(doc).OfClass(typeof(GraphicsStyle)).ToElements().Where(x => x.UniqueId == "d3516a40-06bf-11d4-91b5-0000863f27ad-00004633").SingleOrDefault() as GraphicsStyle;
                 

                        Line line = Line.CreateBound(startpoint.Multiply(1/304.8), endpoint.Multiply(1 / 304.8));
                        //var ccc =  line.CreateTransformed(Transform.CreateTranslation(new XYZ(0.9, 0.9,0)));
                        //  line = ccc as Line;
                        var modeline = doc.Create.NewDetailCurve(drafting, line) as DetailLine;
                        modeline.LineStyle = graphicsStyle;

                    //DetailLine line = locationCurve.Curve as DetailLine;

                    drawDrafting.Commit();
                }
                }

            
              


           
            return Result.Succeeded;
        }


        private BitmapImage BitmapToBitmapImage(System.Drawing.Bitmap bitmap)
        {
            BitmapImage bitmapImage = new BitmapImage();
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                bitmap.Save(ms, bitmap.RawFormat);
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = ms;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();
            }
            return bitmapImage;
        }

    }
}
