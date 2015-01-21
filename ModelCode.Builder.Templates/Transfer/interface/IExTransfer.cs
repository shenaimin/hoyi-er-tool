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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelCode.Builder.Templates.Transfer
{
    /// <summary>
    /// 转换的接口类
    /// </summary>
    public interface IExTransfer
    {
        /// <summary>
        /// 转换代码内容.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="modelInfo"></param>
        /// <returns></returns>
        string Transfer(string content, EntityInfo entity, Object modelInfo);
    }
}
