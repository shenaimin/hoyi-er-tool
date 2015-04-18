/*
 *          Author:Ellen
 *          Email:ellen@kuaifish.com   专业的App外包提供商，广州快鱼信息技术有限公司   www.kuaifish.com
 *          CreateDate:2015-01-20
 *          ModifyDate:2015-01-20
 *          hoyi entities @ hoyi.org
 *          使用请在项目关于内标注hoyi版权，
 *          hoyi版权归hoyi.org所有
 */
using Hoyi.model;
using ModelCode.CreateBusiness;
using ModelCode.ModelInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hoyi.ctrl
{
    public class OperatorCtrl
    {
        private static OperatorCtrl _instance;

        public static OperatorCtrl Ins
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new OperatorCtrl();
                }
                return _instance;
            }
        }
        #region 表方法

        /// <summary>
        /// 需要操作的表.
        /// </summary>
        public OperateCollection Opers { get; set; }

        /// <summary>
        /// 数据库内表.
        /// </summary>
        private List<EntityInfo> needTable = new List<EntityInfo>();
        /// <summary>
        /// 单表内的字段.
        /// </summary>
        private List<AttributeInfo> needColumn = new List<AttributeInfo>();

        public ListBox lsOperate;
        public ListBox lsEntity;
        /// <summary>
        /// 初始化操作集合.
        /// </summary>
        public void InitOpers()
        {
            if (Opers == null)
                Opers = new OperateCollection();
            if (Opers.Operaters == null)
                Opers.Operaters = new List<SingleOperate>();
            Opers.Operaters.Clear();

            this.lsOperate.Items.Clear();

            DEFAULT_OPERATE_READER.Instance.INIT_DEFAULT_OPERA();
            List<IOperater> default_OPS = DEFAULT_OPERATE_READER.Instance.DEFAULT_OPERATE;


            foreach (var item in lsEntity.Items)
            {
                if ((item as EntityInfo).operaters.Count <= 0)
                {
                    Opers.Operaters.Add(new SingleOperate(item as EntityInfo, default_OPS));
                    //// 添加操作个数.
                    this.lsOperate.Items.Add(default_OPS.Count);
                }
                else
                {
                    Opers.Operaters.Add(new SingleOperate(item as EntityInfo, (item as EntityInfo).operaters));
                    //// 添加操作个数.
                    this.lsOperate.Items.Add((item as EntityInfo).operaters.Count);
                }

            }
        }
        #endregion

    }
}
