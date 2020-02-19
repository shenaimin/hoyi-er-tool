/*
 *          Author:Ellen
 *          Email:ellen@miloong.com   专业的App外包提供商，广州巨鲸信息技术有限公司   www.miloong.com
 *          CreateDate:2015-01-20
 *          ModifyDate:2015-01-20
 *          hoyi entities @ hoyi.org
 *          使用请在项目关于内标注hoyi版权，
 *          hoyi版权归hoyi.org所有
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ModelCode.Util
{
    public static class XmlSerializer
    {
        public static void SaveToXml(string filePath, object sourceObj, Type type, string xmlRootName)
        {
            if (!string.IsNullOrWhiteSpace(filePath) && sourceObj != null)
            {
                type = type != null ? type : sourceObj.GetType();

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    System.Xml.Serialization.XmlSerializer xmlSerializer = string.IsNullOrWhiteSpace(xmlRootName) ?
                        new System.Xml.Serialization.XmlSerializer(type) :
                        new System.Xml.Serialization.XmlSerializer(type, new XmlRootAttribute(xmlRootName));
                    xmlSerializer.Serialize(writer, sourceObj);
                }
            }
        }

        public static object LoadFromXml(string filePath, Type type)
        {
            object result = null;

            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(type);
                    result = xmlSerializer.Deserialize(reader);
                }
            }

            return result;
        }
    }
}