/*
 *          Author:Ellen
 *          Email:ellen@miloong.com   专业的App外包提供商，广州巨鲸信息技术有限公司   www.miloong.com
 *          CreateDate:2015-01-20
 *          ModifyDate:2015-01-20
 *          hoyi entities @ hoyi.org
 *          使用请在项目关于内标注hoyi版权，
 *          hoyi版权归hoyi.org所有
 */
using Hoyi.ctrl;
using ModelCode.CreateBusiness;
using ModelCode.ModelInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoyi.model
{
    /// <summary>
    /// 模块需要的操作列表.
    /// </summary>
    public class OperateCollection
    {
        public List<SingleOperate> Operaters { get; set; }
        /// <summary>
        /// 添加默认操作.
        /// </summary>
        /// <param name="table"></param>
        public void AddDefaultValueForSingle(EntityInfo table)
        {
            if (Operaters != null)
            {
                SingleOperate so = Operaters.Single(SK => SK.Tables == table) as SingleOperate;
                DEFAULT_OPERATE_READER.Instance.INIT_DEFAULT_OPERA();
                so.Operaters = DEFAULT_OPERATE_READER.Instance.DEFAULT_OPERATE;
                //so.Operaters = new List<IOperater>();
                // 加载默认的操作.
            }
        }
        /// <summary>
        /// 添加默认操作.
        /// </summary>
        /// <param name="table"></param>
        public void RemoveAllOperate(EntityInfo table)
        {
            if (Operaters != null)
            {
                SingleOperate so = Operaters.Single(SK => SK.Tables == table) as SingleOperate;
                so.Operaters = new List<IOperater>();
            }
        }
        /// <summary>
        /// 获取Table的操作集合.
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public List<IOperater> GetOperatesByTable(EntityInfo table)
        {
            return this.Operaters == null ? null : ((SingleOperate)(Operaters.Single(op => op.Tables == table))).Operaters;
        }
    }
}
