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

namespace ModelCode.Builder.Templates.Analysis
{
    /// <summary>
    /// 标识一个实体模板文件生成的路径规则.
    /// </summary>
    public class TemplateRule
    {
        public string ID;

        /// <summary>
        /// 标识使用哪个 Template 文件进行 实体内容的生成.
        /// </summary>
        public string TemplateURL;

        /// <summary>
        /// 标识 生成路径的规则.
        /// </summary>
        public string TargetURL;
    }
}
