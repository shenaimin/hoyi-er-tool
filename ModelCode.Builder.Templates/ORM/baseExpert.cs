/*
 *          Author:Ellen
 *          Email:ellen@miloong.com   专业的App外包提供商，广州巨鲸信息技术有限公司   www.miloong.com
 *          CreateDate:2015-01-20
 *          ModifyDate:2015-01-20
 *          hoyi entities @ hoyi.org
 *          使用请在项目关于内标注hoyi版权，
 *          hoyi版权归hoyi.org所有
 */
using ModelCode.Model;
using ModelCode.ModelInfo;
using ModelCode.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelCode.Builder.Templates.ORM
{
    public class baseExpert
    {
        /// <summary>
        /// 选择的字段列表.
        /// </summary>
        public List<AttributeInfo> Fieldlist { get; set; }
        /// <summary>
        /// 表名.
        /// </summary>
        public string ClassName { get; set; }

        public string EntityName
        {
            get
            {
                return this.ClassName;
            }
        }

        public string DbHelperName = "DatabaseHelper";

    }
}