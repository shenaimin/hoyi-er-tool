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

namespace ModelCode.Util
{
    public static partial class KK扩展方法
    {
        /// <summary>
        /// KK上移s the specified data list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataList">The 数据列表 list.</param>
        /// <param name="id">The 需要移动的id.</param>
        /// <param name="位数">The 移动的 位数. 默认为1</param>
        /// <returns></returns>
        public static bool kk上移<T>(this IList<T> dataList, int id, int 位数 = 1)
        {
            return dataList.kk移动(id, id - 位数);
        }

        public static bool kk下移<T>(this IList<T> dataList, int id, int 位数 = 1)
        {
            return dataList.kk移动(id, id + 位数);
        }

        public static bool kk顶部<T>(this IList<T> dataList, int id)
        {
            return dataList.kk移动(id, 0);
        }

        public static bool kk底部<T>(this IList<T> dataList, int id)
        {
            return dataList.kk移动(id, dataList.Count - 1);
        }

        public static bool kk移动<T>(this IList<T> dataList, int 原ID, int 新ID)
        {
            if (原ID >= dataList.Count || 新ID >= dataList.Count || 原ID < 0 || 新ID < 0 || 原ID == 新ID) { return false; }

            try
            {
                var sel = dataList[原ID];
                dataList.RemoveAt(原ID);
                dataList.Insert(新ID, sel);
                return true;
            }
            catch (Exception)
            {
                return false; ;
            }
        }


        public static bool kk交换<T>(this IList<T> list, int 原ID, int 新ID)
        {
            if (原ID >= list.Count || 新ID >= list.Count || 原ID < 0 || 新ID < 0 || 原ID == 新ID) { return false; }

            try
            {
                var sel = list[原ID];
                list[原ID] = list[新ID];
                list[新ID] = sel;
                return true;
            }
            catch (Exception)
            {
                return false; ;
            }


        }
    }
}