/*
 *          Author:Sam
 *          Email:ellen@hoyi.org
 *          CreateDate:2015-01-20
 *          ModifyDate:2015-01-20
 *          hoyi entities @ hoyi.org
 *          使用请在项目关于内标注hoyi版权，
 *          hoyi版权归hoyi.org所有
 */
using ModelCode.ModelInfo;
using ModelCode.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hoyi.model
{
    public class AttrTemplateCtrl
    {
        public static AttrTemplateCtrl Cr() {
            return new AttrTemplateCtrl();
        }

        public List<AttributeInfo> GetTemplate(EntityInfo entity, string templateName)
        {
            string path = Application.StartupPath + "\\att_temps\\" + templateName;
            List<AttributeInfo> attrs = new List<AttributeInfo>();
            attrs = XmlSerializer.LoadFromXml(path, attrs.GetType()) as List<AttributeInfo>;
            foreach (AttributeInfo att in attrs)
            {
                att.Comment = att.Comment.Replace("%EntityName%", entity.EntityName);
                att.Comment = att.Comment.Replace("%ClassName%", entity.ClassName);


                att.ColumnName = att.ColumnName.Replace("%ClassName%", entity.ClassName);
                att.ColumnName = att.ColumnName.Replace("%EntityName%", entity.EntityName);
            }
            return attrs;
        }
    }
}
