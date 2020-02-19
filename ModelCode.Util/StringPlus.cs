/*
 *          Author:Ellen
 *          Email:ellen@miloong.com   专业的App外包提供商，广州巨鲸信息技术有限公司   www.miloong.com
 *          CreateDate:2015-01-20
 *          ModifyDate:2015-01-20
 *          hoyi entities @ hoyi.org
 *          使用请在项目关于内标注hoyi版权，
 *          hoyi版权归hoyi.org所有
 */
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace ModelCode.Util
//{
//    public class StringPlus
//    {
//        public string Value { get {
//            return this.Result;
//        } }
//        public string Result { get; set; }

//        public StringPlus() { }

//        public string DelLastComma()
//        {
//            Result = Result.TrimEnd(',');
//            return Result;
//        }

//        public string Append(string Text)
//        {
//            Result = Result += Text;
//            return Result;
//        }

//        public string AppendLine()
//        {
//            Result = Result += "\n";
//            return Result;
//        }
//        public string AppendLine(string Text)
//        {
//            Result = Result + Text;
//            return Result;
//        }
//        public string AppendSpace(int SpaceNum, string Text) {
//            for (int i = 0; i < SpaceNum; i++)
//            {
//                Result += "\t";
//            }
//            Result = Result + Text;
//            return Result;
//        }
//        public string AppendSpaceLine(int SpaceNum, string Text)
//        {
//            for (int i = 0; i < SpaceNum; i++)
//            {
//                Result += "\t";
//            }
//            Result = Result + Text + "\n";
//            return Result;
//        }
//        public string ToString() {
//            return Result;
//        }
//    }
//}
