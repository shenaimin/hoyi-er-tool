/*
 *          Author:Ellen
 *          Email:ellen@miloong.com   专业的App外包提供商，广州巨鲸信息技术有限公司   www.miloong.com
 *          CreateDate:2015-01-20
 *          ModifyDate:2015-01-20
 *          hoyi entities @ hoyi.org
 *          使用请在项目关于内标注hoyi版权，
 *          hoyi版权归hoyi.org所有
 */
using ModelCode.Builder.Templates.Field_CTR;
using ModelCode.Builder.Templates.Util;
using ModelCode.ModelInfo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace ModelCode.Builder.Templates.Transfer.exec
{
    /// <summary>
    /// 
    /// 用于做判断的分析.
    /// 判断的结构为:
    /// if( expressionA condition expressionB){
    ///     echo expressionC;
    /// }else {
    ///     echo expressionD;
    /// }
    /// 
    /// 第一步把A、B、C、D四个条件和Condition 拿出来，
    /// 
    /// </summary>
    public class JudgeExecute :IObjExecute
    {
        public object Execute(object obj, EntityInfo modelinfo, string pattern)
        {
            try
            {
                string exAcondexB = pattern.RegBaseStr(@"(?is)if(.*?){");
                string exC = pattern.RegBaseStr(@"(?is)\)\{.*?\}else\{");
                string exD = pattern.RegBaseStr(@"(?is)\}else\{.*?\}");

                exC = exC.TrimStart("){".ToArray()).Replace("}else{", "");
                exD = exD.Replace("}else{", "").TrimEnd("}".ToArray());

                string exA, exB;
                BaseExecute exec = new BaseExecute();

                String Result = "";
                if (exAcondexB.Contains("=="))
                {
                    string[] exABS = exAcondexB.Split("==".ToCharArray());
                    exA = exABS[0].TrimEnTa();
                    exA = exA.Replace("if(", "");
                    exB = exABS[2].TrimEnTa().Replace("){", "");

                    string reA = exec.Execute(obj, modelinfo, exA) as string;
                    string reB = exec.Execute(modelinfo, modelinfo, exB) as string;
                    if (reA == reB)
                    {
                        Result = exec.Execute(obj, modelinfo, exC) as string;
                    }
                    else
                    {
                        Result = exec.Execute(obj, modelinfo, exD) as string;
                    }

                }else if (exAcondexB.Contains("!="))
                {
                    string[] exABS = exAcondexB.Split("!=".ToCharArray());
                    exA = exABS[0].TrimEnTa();
                    exA = exA.Replace("if(", "");
                    exB = exABS[2].TrimEnTa().Replace("){", "");

                    string reA = exec.Execute(obj, modelinfo, exA) as string;
                    string reB = exec.Execute(modelinfo, modelinfo, exB) as string;
                    if (reA == reB)
                    {
                        Result = exec.Execute(obj, modelinfo, exC) as string;
                    }
                    else
                    {
                        Result = exec.Execute(obj, modelinfo, exD) as string;
                    }
                }
                else
                {
                    exAcondexB = exAcondexB.Replace("if(", "");
                    exAcondexB = exAcondexB.Replace("){", "");
                    bool filter = Boolean.Parse(exec.Execute(obj, modelinfo, exAcondexB).ToString());
                    string[] exABS = exAcondexB.Split("!=".ToCharArray());
                    if (filter)
                    {
                        // 执行A.
                        Result = exec.Execute(obj, modelinfo, exC) as string;
                    }
                    else
                    {
                        // 执行B.
                        Result = exec.Execute(obj, modelinfo, exD) as string;
                    }

                }
                //else if (exAcondexB.Contains("containtable(")) {
                //    string tableName = exAcondexB.Replace("containtable(", "");
                //    tableName = tableName.TrimEnd(')');

                //    //exA = exABS[0].TrimEnTa();
                //    //exA = exA.Replace("if(", "");
                //    //string reA = exec.Execute(obj, modelinfo, exA);
                //    //Result = exec.Execute(obj, modelinfo, exC);
                //}

                return Result;
            }
            catch (Exception ex)
            {
                //如果打开检查，则返回 检查的结果，否则返回空。
                return ExCtr.Return_EX(ex, pattern);
            }

        }
    }
}
