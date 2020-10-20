using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class manage_staff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetStaffData("select  * from Staff_Table where is_delete=0");
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

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int staffId = Convert.ToInt32(((HiddenField) e.Item.FindControl("staffId")).Value);
            // 删除员工
            if (e.CommandName == "Delete")
            {
                string sql = "update Staff_Table set is_delete=1 where Id=" + staffId + "";
                int flag = OperaterBase.CommandBySql(sql);
                if (flag > 0)
                {
                    Response.Write("<script type='text/javascript'>alert(成功删除：'" + flag + "'条数据);</script>");
                    GetStaffData("select  * from Staff_Table where is_delete=0");
                }
            }
            else if (e.CommandName == "Edit")
            {
                Response.Redirect("add_staff.aspx?staffId=" + staffId);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("add_staff.aspx");
        }

        /// <summary>
        /// 下拉框筛选性别
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string isDeleteSelectValue = DropDownList1.SelectedValue;
            if (!string.IsNullOrEmpty(isDeleteSelectValue))
            {
                GetStaffData("select * from Staff_Table where worker_sex=" + isDeleteSelectValue);
            }
            else
            {
                GetStaffData("select  * from Staff_Table where is_delete=0");
            }
        }
    }
}