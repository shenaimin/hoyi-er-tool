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
using System.Linq;
using System.Reflection;
using System.Text;
using ModelCode.Builder.Templates.Util;
using ModelCode.Util;
using ModelCode.Builder.Templates.Transfer.methodEx;
using ModelCode.ModelInfo;
using System.Configuration;
using ModelCode.Builder.Templates.Field_CTR;
using Hoyi.conf;

namespace ModelCode.Builder.Templates.Transfer.exec
{
    /// <summary>
    /// 单个Column的执行，IObjExecute可以延伸出各个对象的具体Execute实现.
    /// 
    /// 这里很多方法可以用插件形式插进来，然后再给其他对象调用.
    /// </summary>
    public class BaseExecute : IObjExecute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="modelinfo"></param>
        /// <param name="pattern"></param>
        /// <param name="split">分割符号，默认为：'.'</param>
        /// <returns></returns>
        public object Execute(Object obj, EntityInfo entity, string pattern)
        {
            try
            {
                string tmpp = pattern.TrimEnTa();
                if (tmpp.StartsWith("\"") && tmpp.EndsWith("\""))
                {
                    return pattern.TrimStart('\"').TrimEnd('\"');
                }
                List<string> prormethods = pattern.Split('.').ToList();

                string method = "";
                EntityInfo mod = null;

                string param = "";

                switch (prormethods[0].TrimEnTa().ToLower())
                {
                    case "a":
                        obj = AppConf.Ins.Application;
                        break;
                    case "e":
                        obj = entity;
                        break;
                    case "m":
                        obj = AppConf.Ins.getByEntityInfo(entity);
                        break;
                    case "tb":
                        obj = entity;
                        break;
                    case "tbs":
                        obj = AppConf.Ins.getByEntityInfo(entity).Entitys;
                        break;
                    case "t":
                        //obj = obj;
                        break;
                    case "modelinfo":
                        obj = entity;
                        break;
                    default:
                        break;
                }

                for (int i = 1; i < prormethods.Count; i++)
                {
                    method = prormethods[i];
                    Type tp = obj.GetType();

                    if (method.Contains('('))
                    {
                        method = method.Replace("()", "").TrimEnTa();
                        List<MethodInfo> methods = tp.GetMethods().Where(s => s.Name.ToLower().Equals(method.ToLower())).ToList();
                        if (methods.Count > 0)
                        {
                            obj = tp.InvokeMember(method, BindingFlags.InvokeMethod, null, obj, null);
                        }
                        else
                        {
                            obj = MethodExCtr.Create().Execute(method, obj);
                        }
                    }
                    else if (method.Contains('['))
                    {
                        param = method.RegBaseStr(@"(?is)\[.*?\]").TrimStart('[').TrimEnd(']');
                        method = method.TrimEnTa();
                        method = method.Substring(0, method.IndexOf('['));


                        obj = tp.InvokeMember(method, BindingFlags.GetProperty, null, obj, new object[] { param });
                    }
                    else
                    {
                        method = method.TrimEnTa();
                        obj = tp.InvokeMember(method, BindingFlags.GetProperty, null, obj, null);
                    }
                }
                return obj;
            }
            catch (Exception ex)
            {
                //如果打开检查，则返回 检查的结果，否则返回空。
                return ExCtr.Return_EX(ex, pattern);
            }
        }

    }
}
