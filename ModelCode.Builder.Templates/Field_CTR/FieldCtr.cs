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
using ModelCode.ModelInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelCode.Builder.Templates.Util;
using ModelCode.Builder.Templates.Transfer;
using ModelCode.CreateBusiness;
using Hoyi.conf;

namespace ModelCode.Builder.Templates.Field_CTR
{
    /// <summary>
    /// List<AttributeInfo>的分析.
    /// </summary>
    public class FieldCtr
    {
        /// <summary>
        /// 根据 pattern 计算符合条件的 index 集合.
        /// </summary>
        /// <param name="count"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public List<int> CalcPattern(int count, string filter)
        {
            filter = filter.TrimFFSS().TrimEnTa();

            List<int> indexs = new List<int>();
            filter = filter.ToLower();
            if (filter.Equals("x"))
            {
                indexs = PutToList(0,count);
            }
            else if (filter.StartsWith("first"))
            {
                int ind = FieldExRegAna.RegFirst(filter);
                indexs = PutToList(0, ind);
            }
            else if (filter.StartsWith("last"))
            {
                int ind = FieldExRegAna.RegLast(filter);
                indexs = PutToList(count-ind, count);
            }
            else if (filter.StartsWith("equal"))
            {
                List<int> inds = FieldExRegAna.RegAllNum(filter);
                foreach (int i in inds)
                {
                    indexs.Add(i);
                }
            }
            else if (filter.StartsWith(">"))
            {
                int ind = FieldExRegAna.RegOnlyG_Num(filter);
                indexs = PutToList(ind, count);

            }
            else if (filter.StartsWith("<"))
            {
                int ind = FieldExRegAna.RegOnlyG_Num(filter);
                indexs = PutToList(0, ind);
            }
            else if (filter.StartsWith("inner"))
            {

                // [inner, 2, last(1)]
                // [inner, 2, 4] 表示取>2 并且 < 长度 4 的值..
                List<int> inds = FieldExRegAna.RegAllNum(filter);
                if (filter.Contains("last"))
                {
                    if (inds.Count > 1)
                    {
                        indexs = PutToList(inds[0], count - inds[1]);
                    }
                }
                else
                {
                    if (inds.Count > 1)
                    {
                        indexs = PutToList(inds[0], inds[1] + 1);
                    }
                }
            }
            else if (filter.StartsWith("less"))
            {
                //     [greatless, 2, last(1)] 表示取<2 并且大于长度 count - 1的值..
                //[greatless, 2, 3] 表示取<2 并且大于3 的对象.
                List<int> inds = FieldExRegAna.RegAllNum(filter);
                if (filter.Contains("last"))
                {
                    if (inds.Count > 1)
                    {
                        indexs.AddRange(PutToList(0, inds[0]));
                        indexs.AddRange(PutToList(count - inds[1], count));
                    }
                }
                else
                {
                    if (inds.Count > 1)
                    {

                        indexs.AddRange(PutToList(0, inds[0]));
                        indexs.AddRange(PutToList(inds[1], count));
                    }
                }
            }
            return indexs;
        }
        #region Filter Fields
        /// <summary>
        /// 根据  filter 选出满足条件的条数.
        /// </summary>
        /// <param name="modelInfo"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public List<AttributeInfo> GetFieldListByFilter(EntityInfo modelInfo, string filter)
        {
            List<int> indexs = CalcPattern(modelInfo.Attributes.Count, filter);
            return GetFieldListByInd(indexs, modelInfo);
        }
        /// <summary>
        /// 
        /// 根据序号列表，生成字段的列表.
        /// 
        /// </summary>
        /// <param name="colindexs"></param>
        /// <param name="modelInfo"></param>
        /// <returns></returns>
        public List<AttributeInfo> GetFieldListByInd(List<int> colindexs, EntityInfo modelInfo)
        {
            List<AttributeInfo> cols = new List<AttributeInfo>();
            foreach (int i in colindexs)
            {
                if (modelInfo.Attributes.Count > i)
                {
                    cols.Add(modelInfo.Attributes[i]);   
                }
            }
            return cols;
        }
        /// <summary>
        /// 将 从startIndex开始的count个数，添加到List int 中。
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="Count"></param>
        /// <returns></returns>
        public List<int> PutToList(int startIndex, int Count)
        {
            List<int> indexs = new List<int>();
            for (int i = startIndex; i < Count; i++)
            {
                indexs.Add(i);
            }
            return indexs;
        }
        #endregion

        #region Filter Table


        /// <summary>
        /// 根据  filter 选出满足条件的条数.
        /// </summary>
        /// <param name="modelInfo"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public List<EntityInfo> GetTableListByFilter(EntityInfo entityInfo, string filter)
        {
            List<int> indexs = CalcPattern(AppConf.Ins.getByExeEntityInfo(entityInfo).Entitys.Count, filter);
            return GetTableListByInd(indexs, entityInfo);
        }
        /// <summary>
        /// 
        /// 根据序号列表，生成字段的列表.
        /// 
        /// </summary>
        /// <param name="colindexs"></param>
        /// <param name="modelInfo"></param>
        /// <returns></returns>
        public List<EntityInfo> GetTableListByInd(List<int> colindexs, EntityInfo entity)
        {
            List<EntityInfo> cols = new List<EntityInfo>();
            foreach (int i in colindexs)
            {
                if (entity.Attributes.Count > i)
                {
                    //cols.Add(AppConf.Ins.getByEntityInfo(entity).Entitys[i]);// 这里不是从整个系统中拿.
                    cols.Add(AppConf.Ins.getByExeEntityInfo(entity).Entitys[i]);// 这里不是从整个系统中拿.
                }
            }
            return cols;
        }

        #endregion
    }
}
