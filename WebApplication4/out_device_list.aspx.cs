using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class out_device_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
                GetOutDeviceList();
        }

        /// <summary>
        /// 获取出库列表
        /// </summary>
        public void GetOutDeviceList()
        {
            DataSet ds = OperaterBase.GetData("select * from V_Out_Stock");
            Repeater1.DataSource = ds;
            Repeater1.DataBind();
        }

        /// <summary>
        /// 下拉框筛选是否删除
        /// </summary>
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs args)
        {
            // 获取下拉框value值
            string isDeleteSelectValue = DropDownList1.SelectedValue;
            if (!string.IsNullOrEmpty(isDeleteSelectValue))
            {
                GetStaffData("select * from V_Out_Stock where is_delete=" + isDeleteSelectValue);
            }
            else
            {
                GetStaffData("select  * from V_Out_Stock");
            }
        }

        /// <summary>
        /// 根据指定条件获取员工数据
        /// </summary>
        private void GetStaffData(string sql)
        {
            DataSet ds =
                OperaterBase.GetData(sql);

            Repeater1.DataSource = ds;
            Repeater1.DataBind();
        }

        /// <summary>
        /// 表格更新或删除功能
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
        }
    }
}