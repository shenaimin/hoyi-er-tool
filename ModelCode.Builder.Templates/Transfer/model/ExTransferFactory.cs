/*
 *          Author:Sam
 *          Email:ellen@hoyi.org
 *          CreateDate:2015-01-20
 *          ModifyDate:2015-01-20
 *          hoyi entities @ hoyi.org
 *          使用请在项目关于内标注hoyi版权，
 *          hoyi版权归hoyi.org所有
 */
using ModelCode.Builder.Templates.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelCode.Builder.Templates.Util;
using ModelCode.Builder.Templates.Transfer.model;

namespace ModelCode.Builder.Templates.Transfer
{
    /// <summary>
    /// 单条函数处理的TransferFactory.
    /// </summary>
    public class ExTransferFactory : IExTransferFactory
    {
        public IExTransfer CreateTransfer(string content)
        {
            if (content.Contains(AnaConfig.FIELD_EXP_FILTER_HEAD))
            {
                return new FieldExTransfer();
            }
            else if (content.Contains(AnaConfig.TABLE_EXP_FILTER_HEAD))
            {
                return new TableExTransfer();
            }
            else if (content.Contains(AnaConfig.OPERATE_EXP_FILETER_HEAD))
            {
                return new OperateTransfer();
            }
            else if (content.TrimEnTa().StartsWith("<%%#!"))
            {
                return new NoteTransfer();
            }
            else if (content.TrimPSS().TrimEnTa().StartsWith("if("))
            {
                return new ColumnExTransfer();
            }
            else
            {
                return new KeyExTransfer();
            }
        }
    }
}
