/*
 *          Author:Sam
 *          Email:ellen@hoyi.org
 *          CreateDate:2015-01-20
 *          ModifyDate:2015-01-20
 *          hoyi entities @ hoyi.org
 *          使用请在项目关于内标注hoyi版权，
 *          hoyi版权归hoyi.org所有
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelCode.ModelInfo.ENTITYS
{
    public class ConnInfo
    {
        /// <summary>
        /// 起始对象ID.
        /// </summary>
        public string SrcElementID { get; set; }
        /// <summary>
        /// 目标对象ID.
        /// </summary>
        public string TargetElementID { get; set; }
        /// <summary>
        /// 线的类型.
        /// </summary>
        public LineType linetype { get; set; }
    }
    public enum LineType { 
        Line,
        Connector,
        ComplexLine,
        Circle
    }
}
