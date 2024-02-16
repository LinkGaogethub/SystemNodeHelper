using Autodesk.Revit.DB;
using Autodesk.Revit.DB.ExtensibleStorage;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SystemNodeHelper.Utility
{
    internal class ExtendedDataUtil
    {
        
        private static readonly string _field = "NetworkList";
        private static readonly Guid _guid = new Guid("52be9ad5-f4f4-48bc-8cad-14ade63e4440");

        // todo 输入名字
        public static void WriteExtendedData(Document doc,string json,string optionTip = "Creat Network") {
    
            Transaction transaction = new Transaction(doc, optionTip);
            transaction.Start();

            Schema schema;

            Entity entity;
            Element myElement;
            schema = Schema.Lookup(_guid);

            if (schema == null)
            {
                //全局存储单元
                //  var guid = Guid.NewGuid();
                 myElement = DataStorage.Create(doc);
                //【1】建立存储框架（可以理解为类似于定义了一个类）
                SchemaBuilder builder = new SchemaBuilder(_guid);
                //【1-1】权限设置
                builder.SetReadAccessLevel(AccessLevel.Public);
                builder.SetWriteAccessLevel(AccessLevel.Public);
                //【1-2】基本信息
                builder.SetSchemaName(_field + "ExtendedData");
                builder.SetDocumentation("Storge Information in file");
                //【1-3】创建字段
                FieldBuilder fieldBuilder = builder.AddSimpleField(_field, typeof(string));
                //【1-4】得到创建的框架
                schema = builder.Finish();
                //【2】创建实体（可以理解为实例化这个类）
                 entity = new Entity(schema);
            }
            else {
                myElement = new FilteredElementCollector(doc).OfClass(typeof(DataStorage)).FirstElement();
                 entity = myElement.GetEntity(schema);
            }

            Field stringValue = schema.GetField(_field);
            entity.Set<string>(stringValue, json);
            myElement.SetEntity(entity);
            transaction.Commit();
        }
        public static string ReadExtendedData(Document doc)
        {

            Schema currentScheme = Schema.Lookup(_guid);
            if (currentScheme == null) return null;
            //过滤找到这个单元
            Element CurrentElement = new FilteredElementCollector(doc).OfClass(typeof(DataStorage)).FirstElement();
            if (CurrentElement == null) return null;
            Entity currentEntity = CurrentElement.GetEntity(currentScheme);
            return  currentEntity.Get<String>(currentScheme.GetField(_field));
        }



    }
}
