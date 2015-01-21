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
using System.Configuration;
using System.Linq;
using System.Text;

namespace ModelCode.Builder.Templates.Field_CTR
{
    public class ExCtr
    {
        /// <summary>
        /// 返回错误信息.
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static string Return_EX(Exception ex, string pattern)
        {
            //如果打开检查，则返回 检查的结果，否则返回空。
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["openNullvalueReturn"]))
            {
                return "\" <%% " + pattern + " -> execute error. " + ex.Message + " #%%> \" ";
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 返回不能转换的错误.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static string Retuen_CANOT_TRANS(string entity)
        {
            string msg = "\" <%% " + entity + " -> can not transfer.  #%%> \" ";
            return Return_EX(msg);
        }

        /// <summary>
        /// 返回错误消息.
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static string Return_EX(string msg)
        {
            //如果打开检查，则返回 检查的结果，否则返回空。
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["openNullvalueReturn"]))
            {
                return msg;
            }
            else
            {
                return "";
            }
        }
    }
}
