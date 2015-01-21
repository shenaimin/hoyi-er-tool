/*
 *          Author:Sam
 *          Email:ellen@hoyi.org
 *          CreateDate:2015-01-20
 *          ModifyDate:2015-01-20
 *          hoyi entities @ hoyi.org
 *          使用请在项目关于内标注hoyi版权，
 *          hoyi版权归hoyi.org所有
 */
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
    /// 单张表操作列表.
    /// </summary>
    public class SingleOperate
    {
        public SingleOperate() { }

        public SingleOperate(EntityInfo table, List<IOperater> ops)
        {
            this.Tables = table;
            this.Operaters = ops;
        }
        /// <summary>
        /// 表信息.
        /// </summary>
        public EntityInfo Tables { get; set; }
        /// <summary>
        /// 操作列表.
        /// </summary>
        public List<IOperater> Operaters { get; set; }
    }
}