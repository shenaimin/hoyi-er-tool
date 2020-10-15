using <%%# a.NameSpace #%%>.<%%# m.Caption #%%>.Expert;
using <%%# a.NameSpace #%%>.<%%# m.Caption #%%>.Model;
using <%%# a.NameSpace #%%>.<%%# m.Caption #%%>.Extend;
using <%%# a.NameSpace #%%>.<%%# m.Caption #%%>.IExpert;
using Infrastructure.Database.Cluster;
using Infrastructure.Baser;
using Infrastructure.Database;
using Infrastructure.Database.Pager;
using Infrastructure.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CTERP.page.mds.<%%# m.Caption #%%>.<%%# e.ClassName #%%>
{
    public partial class rt_lg_pg_<%%# e.ClassName  #%%> : ValidatedPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 这里是标识当前页 分页用多少行.
            ViewState["XPG_SIZE"] = "10";
            // Filter 的分页条数.
            ViewState["FLT_SIZE"] = "10";
            if (!this.IsPostBack)
            {
                BindFilter();
                Reload();
            }
            AddEventFilter();
            BindPagingCtrl();
        }

		public bool isRelationed(string <%%# e.rela_uni_in_field() #%%>)
		{
            if (ViewState["FIL_ID"] != null)
            {
                string <%%# e.rela_uni_out_tb_infield() #%%> = ViewState["FIL_ID"].ToString();
                return <%%# e.rela_uni_tb().ClassName #%%>Factory.Create().ExistsBy<%%# e.rela_uni_out_tb_infield().ToParscal() #%%>A<%%# e.rela_uni_in_field().ToParscal() #%%>(<%%# e.rela_uni_out_tb_infield() #%%>, <%%# e.rela_uni_in_field() #%%>);
            }
			return false;
		}		
		
        /// <summary>
        /// 初始化brandinfo数据.
        /// </summary>
        public void BindFilter()
        {
            int recordCount = <%%# e.rela_uni_out_tb_name()  #%%>Factory.Create().GetAllCount();
            this.ctPaging.InitParams(<%%# e.rela_uni_out_tb_name()  #%%>Info.F_<%%# e.rela_uni_out_tb().getfirfieldname()  #%%>, "1", ViewState["FLT_SIZE"].ToString(), recordCount);
            AddEventFilter();
            this.ctPaging.Binds();

            IPagingDataInfo pgd = new IPagingDataInfo(<%%# e.rela_uni_out_tb_name()  #%%>Info.F_<%%# e.rela_uni_out_tb().getfirfieldname()  #%%>, "1", "1");
            DataTable dt = <%%# e.rela_uni_out_tb_name()  #%%>Factory.Create().GetAll(pgd);
            if (dt.Rows.Count > 0)
            {
				// 这里要修改
                ViewState["FIL_ID"] = dt.Rows[0]["<%%# e.rela_uni_out_tb_infield()  #%%>"].ToString();
                setFilterByID();
            }
        }
        /// <summary>
        /// brandinfo 事件
        /// </summary>
        public void AddEventFilter()
        {
            this.ctPaging.BindsEvent += ctPaging_BindsEvent;
        }
        /// <summary>
        /// brandinfo 加载数据
        /// </summary>
        /// <param name="pgd"></param>
        void ctPaging_BindsEvent(IPagingDataInfo pgd)
        {
            DataTable dt = <%%# e.rela_uni_out_tb_name()  #%%>Factory.Create().GetAll(pgd);
            this.rep<%%# e.rela_uni_out_tb_name()  #%%>.DataSource = dt;
            this.rep<%%# e.rela_uni_out_tb_name()  #%%>.DataBind();
        }
   
        public void BindPagingCtrl() {
            if (ViewState["PG_CTRL"] == null || (pagectrlType)ViewState["PG_CTRL"] == pagectrlType.Default)
            {
                this.ctPaging2.BindsEvent += ctPaging2_all_BindsEvent;
            }
            else if ((pagectrlType)ViewState["PG_CTRL"] == pagectrlType.Current)
            {
                this.ctPaging2.BindsEvent += ctPaging2_current_BindsEvent;
            }
        }
		
        public void Reload()
        {
            //ViewState["PG_CTRL"] = pagectrlType.Default;
            this.IntPageParam();
            this.ctPaging2.Binds();
        }
		
	    public void IntPageParam() {
            int recordCount = <%%# e.ClassName #%%>Factory.Create().GetAllCount();
            this.ctPaging2.InitParams(<%%# e.ClassName #%%>Info.F_<%%# e.getfirfieldName() #%%>, "1", ViewState["XPG_SIZE"].ToString(), recordCount);
            this.ctPaging2.BindsEvent += ctPaging2_all_BindsEvent;
        }
		
		protected void btnSearchCurrent_Click(object sender, EventArgs e)
		{
            ViewState["PG_CTRL"] = pagectrlType.Current;
            //int recordCount = <%%# e.ClassName #%%>Factory.Create().LikeBy<%%# e.getsecfieldname().ToParscal() #%%>Count(tx_<%%# e.getsecfieldname() #%%>.Text);
			
			int recordCount = 0;
			if (ViewState["FIL_ID"] == null)
			{
				recordCount = <%%# e.ClassName #%%>Factory.Create().GetAllCount();
			}
			else
			{
                string <%%# e.rela_uni_out_tb_infield() #%%> = ViewState["FIL_ID"].ToString();
				recordCount = <%%# e.ClassName #%%>Extend.Create().Get<%%# e.ClassName #%%>By<%%# e.rela_uni_out_tb_infield().ToParscal() #%%>Count(<%%# e.rela_uni_out_tb_infield() #%%>);
				//recordCount = <%%# e.ClassName #%%>Factory.Create().GetBy<%%# e.unikey_in_fieldname().ToParscal() #%%>Count(<%%# e.unikey_out_fieldname() #%%>);
			}
            this.ctPaging2.InitParams(<%%# e.ClassName #%%>Info.F_<%%# e.getfirfieldName() #%%>, "1", ViewState["XPG_SIZE"].ToString(), recordCount);
            this.ctPaging2.BindsEvent += ctPaging2_current_BindsEvent;
            this.ctPaging2.Binds();
		}
		
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ViewState["PG_CTRL"] = pagectrlType.Search;
            int recordCount = <%%# e.ClassName #%%>Factory.Create().LikeBy<%%# e.getsecfieldname().ToParscal() #%%>Count(tx_<%%# e.getsecfieldname() #%%>.Text);
            this.ctPaging2.InitParams(<%%# e.ClassName #%%>Info.F_<%%# e.getfirfieldName() #%%>, "1", ViewState["XPG_SIZE"].ToString(), recordCount);
            this.ctPaging2.BindsEvent += ctPaging2_all_BindsEvent;
            this.ctPaging2.Binds();
        }

        protected void btnReload_Click(object sender, EventArgs e)
        {
            ViewState["PG_CTRL"] = pagectrlType.Search;
            ViewState["FIL_ID"] = null;
            Reload();
        }

        void ctPaging2_all_BindsEvent(IPagingDataInfo pgd)
        {
            this.rep1.DataSource = <%%# e.ClassName #%%>Factory.Create().GetAll(pgd);
            this.rep1.DataBind();
        }
		
        void ctPaging2_current_BindsEvent(IPagingDataInfo pgd)
        {
			if (ViewState["FIL_ID"] == null)
			{
				this.rep1.DataSource = <%%# e.ClassName #%%>Factory.Create().GetAll(pgd);
			}
			else
			{
                string <%%# e.rela_uni_out_tb_infield() #%%> = ViewState["FIL_ID"].ToString();
				this.rep1.DataSource = <%%# e.ClassName #%%>Extend.Create().Get<%%# e.ClassName #%%>By<%%# e.rela_uni_out_tb_infield().ToParscal() #%%>(pgd, <%%# e.rela_uni_out_tb_infield() #%%>);
				//recordCount = <%%# e.ClassName #%%>Factory.Create().GetBy<%%# e.unikey_in_fieldname().ToParscal() #%%>Count(<%%# e.unikey_out_fieldname() #%%>);
			}
            this.rep1.DataBind();
        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            OrderCTRUtils.Create().btnOrder_Click(sender, e, ctPaging2, <%%# e.ClassName #%%>Info.F_<%%# e.getfirfieldName() #%%>);
        }
        /// <summary>
        /// 设置OrderTag，设置排序的标识.↑↓ 
        /// </summary>
        /// <param name="showtext">显示的文本，区别与表的字段.</param>
        /// <param name="field"></param>
        /// <returns></returns>
        public string OrderTag(string showtext, string field)
        {
            return OrderCTRUtils.Create().OrderTag(showtext, field, ctPaging2);
        }
		
        protected void rep<%%# e.rela_uni_out_tb_name()  #%%>_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "checkfilter")
            {
				ViewState["PG_CTRL"] = pagectrlType.Default;
                ViewState["FIL_ID"] = e.CommandArgument.ToString();
                setFilterByID();
            }
        }

        public void setFilterByID()
        {
            if (ViewState["FIL_ID"] == null)
            {
                lb_checked<%%# e.rela_uni_out_tb_name()  #%%>Name.Text = "未选择<%%# e.rela_uni_out_tb().EntityName #%%>，这里显示所有<%%# e.rela_uni_out_tb().EntityName #%%>";
                lb_checked<%%# e.rela_uni_out_tb_name()  #%%>.Text = "";
            }
            else
            {
                string <%%# e.rela_uni_out_tb().getfirfieldname() #%%> = ViewState["FIL_ID"].ToString();
                //tx_<%%# e.rela_uni_const().Column_Name #%%>.Text = <%%# e.rela_uni_out_tb().getfirfieldname() #%%>;
                <%%# e.rela_uni_out_tb_name() #%%>Info <%%# e.rela_uni_out_tb_name() #%%> = <%%# e.rela_uni_out_tb_name() #%%>Factory.Create().GetSimpleBy<%%# e.rela_uni_out_tb().getfirfieldname().ToParscal() #%%>(<%%# e.rela_uni_out_tb().getfirfieldname() #%%>);
                lb_checked<%%# e.rela_uni_out_tb_name()  #%%>Name.Text = <%%# e.rela_uni_out_tb_name() #%%>.<%%# e.rela_uni_out_tb().getsecfieldname() #%%>;
                lb_checked<%%# e.rela_uni_out_tb_name()  #%%>.Text = <%%# e.rela_uni_out_tb_name() #%%>.ToJson();
            }

            Reload();
        }

        protected void chk_RELATION_CheckedChanged(object sender, EventArgs e)
        {
            if (ViewState["FIL_ID"] != null)
            {
                CheckBox chk = sender as CheckBox;
                string <%%# e.rela_uni_in_field() #%%> = chk.Attributes["CommandArgument"];
                string <%%# e.rela_uni_out_tb_infield() #%%> = ViewState["FIL_ID"].ToString();
                // 插入关联表.

                <%%# e.rela_uni_tb().ClassName #%%>Info relation = new <%%# e.rela_uni_tb().ClassName #%%>Info();
                relation.<%%# e.rela_uni_in_field() #%%> = <%%# e.rela_uni_in_field() #%%>;
                relation.<%%# e.rela_uni_out_tb_infield() #%%> = <%%# e.rela_uni_out_tb_infield() #%%>;
                
                bool res;
                if (chk.Checked)
                {
                    res = <%%# e.rela_uni_tb().ClassName #%%>Factory.Create().Add(relation);
                }
                else
                {
                    res = <%%# e.rela_uni_tb().ClassName #%%>Factory.Create().DeleteBy<%%# e.rela_uni_out_tb_infield().ToParscal() #%%>A<%%# e.rela_uni_in_field().ToParscal() #%%>(<%%# e.rela_uni_out_tb_infield() #%%>, <%%# e.rela_uni_in_field() #%%>);
                }
                JSController.Alert(res ? "操作关联成功!" : "操作关联失败!");
            }
            else
            {
                JSController.Alert("请选择 <%%# e.rela_uni_out_tb().EntityName #%%>，再添加关联.");
            }
        }

        protected void btnAddRelation_Click(object sender, EventArgs e)
        {
            ViewState["PG_CTRL"] = pagectrlType.RELATION;
            BindPagingCtrl();
            this.ctPaging2.Binds();
        }
    }
}