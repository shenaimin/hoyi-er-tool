/*
 *          Author:Ellen
 *          Email:ellen@kuaifish.com   专业的App外包提供商，广州快鱼信息技术有限公司   www.kuaifish.com
 *          CreateDate:2015-01-20
 *          ModifyDate:2015-01-20
 *          hoyi entities @ hoyi.org
 *          使用请在项目关于内标注hoyi版权，
 *          hoyi版权归hoyi.org所有
 */
using ModelCode.CreateBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Hoyi.ctrl
{
    /// <summary>
    /// 读取默认操作列表.
    /// 将默认操作列表配置在:DefaultOPERA.xml 中，如果要修改则直接修改这个配置文件就可以了。
    /// </summary>
    public class DEFAULT_OPERATE_READER
    {
        private static DEFAULT_OPERATE_READER instance;

        public static DEFAULT_OPERATE_READER Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DEFAULT_OPERATE_READER();
                }
                return instance;
            }
        }
        /// <summary>
        /// 默认操作.
        /// </summary>
        public List<IOperater> DEFAULT_OPERATE { get; set; }
        /// <summary>
        /// 所有操作类型.
        /// </summary>
        public List<string> ALL_OPERATES { get; set; }

        string DEFAULT_OPERA_URL = Application.StartupPath + "/DefaultOPERA.xml";
        bool inited = false;

        public void INIT_DEFAULT_OPERA()
        {
            if (!inited)
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(DEFAULT_OPERA_URL);

                XmlNodeList tbfnodes = xmlDoc.SelectNodes("/OPERATES/DEFAULT_OPERATES");
                DEFAULT_OPERATE = LoadOPFROMNODES(tbfnodes);


                XmlNodeList allnodes = xmlDoc.SelectNodes("/OPERATES/ALL_OPERATES");
                ALL_OPERATES = LoadAllNodeType(allnodes);
                inited = true;
            }
        }
        /// <summary>
        /// 将node导入ops.
        /// </summary>
        /// <param name="ops"></param>
        /// <param name="nodelist"></param>
        List<string> LoadAllNodeType(XmlNodeList nodelist)
        {
            List<string> optps = new List<string>();
            string type;
            foreach (XmlNode xn in nodelist[0].ChildNodes)
            {
                type = xn.Attributes["Type"].Value;
                optps.Add(type);
            }

            return optps;
        }
        /// <summary>
        /// 将node导入ops.
        /// </summary>
        /// <param name="ops"></param>
        /// <param name="nodelist"></param>
        List<IOperater> LoadOPFROMNODES(XmlNodeList nodelist)
        {
            List<IOperater> ops = new List<IOperater>();
            IOperater tmpOP;
            string type;
            List<string> FieldStr;
            List<int> FieldIndex;
            foreach (XmlNode xn in nodelist[0].ChildNodes)
            {
                type = xn.Attributes["Type"].Value;
                FieldStr = xn.Attributes["FieldIndex"].Value.Split(',').ToList();
                FieldIndex = (from s in FieldStr
                              select (Int32.Parse(s))).ToList();

                tmpOP = new IOperater(type, FieldIndex);

                ops.Add(tmpOP);
            }
            return ops;
        }
    }
}
