/*
 *          Author:Ellen
 *          Email:ellen@miloong.com   专业的App外包提供商，广州巨鲸信息技术有限公司   www.miloong.com
 *          CreateDate:2015-01-20
 *          ModifyDate:2015-01-20
 *          hoyi entities @ hoyi.org
 *          使用请在项目关于内标注hoyi版权，
 *          hoyi版权归hoyi.org所有
 */
using ModelCode.ModelInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelCode.CreateBusiness
{
    /// <summary>
    /// 操作.
    /// </summary>
    public class IOperater
    {
        public IOperater() { }
        /// <summary>
        /// 初始化.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="fieldIndex"></param>
        public IOperater(string type, List<int> fieldIndex)
        {
            this.Type = type;
            this.FieldIndex = fieldIndex;
        }
        /// <summary>
        /// 操作类型.
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 按字段序号操作.
        /// </summary>
        public List<int> FieldIndex { get; set; }
    }
}
