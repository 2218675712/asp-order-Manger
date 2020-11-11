using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    // 继承页面
    public partial class manage_staff : BasePage
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string login_user = CookieHelper.GetCookieValue("worker_mobile");
                if (string.IsNullOrEmpty(login_user))
                {
                    login_user = Session["worker_mobile"].ToString();
                    if (string.IsNullOrEmpty(login_user))
                    {
                        Response.Write("登录异常");
                        return;
                    }

                }

                string time = System.DateTime.Now.ToString();
                Response.Write("欢迎" + login_user + "，您在" + time + "登录");


                GetStaffData("select  * from Staff_Table where is_delete=0");
            }
        }

        /// <summary>
        /// 根据指定条件获取员工数据
        /// </summary>
        private void GetStaffData(string sql)
        {
            DataSet ds =
                OperaterBase.GetData(sql);
            List<DeviceModel> deviceList = new List<DeviceModel>();
            foreach (DataRow dataRow in ds.Tables[0].Rows)
            {
                DeviceModel deviceModel = new DeviceModel();
                foreach (DataColumn dataColumn in ds.Tables[0].Columns)
                {
                    switch (dataColumn.ColumnName)
                    {
                        case "worker_num":
                            deviceModel.worker_num = dataRow["worker_name"].ToString();
                            break;
                        case "worker_name":
                            deviceModel.worker_name = dataRow["worker_name"].ToString();
                            break;
                        case "worker_avatar":
                            deviceModel.worker_avatar = dataRow["worker_avatar"].ToString();
                            break;
                        case "worker_sex":
                            deviceModel.worker_sex = dataRow["worker_sex"].ToString();
                            break;
                        case "worker_age":
                            deviceModel.worker_age = dataRow["worker_age"].ToString();
                            break;
                        case "worker_mobile":
                            deviceModel.worker_mobile = dataRow["worker_mobile"].ToString();
                            break;
                        case "worker_password":
                            deviceModel.worker_password = dataRow["worker_password"].ToString();
                            break;
                        case "s_province":
                            deviceModel.s_province = dataRow["s_province"].ToString();
                            break;
                        case "s_city":
                            deviceModel.s_city = dataRow["s_city"].ToString();
                            break;
                        case "s_district":
                            deviceModel.s_district = dataRow["s_district"].ToString();
                            break;
                        case "Id":
                            deviceModel.Id = dataRow["Id"].ToString();
                            break;
                    }
                }

                deviceList.Add(deviceModel);
            }

            Repeater1.DataSource = deviceList;
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

        /// <summary>
        /// 退出登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("manage_staff_login.aspx");
        }
    }
}