using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class manage_staff_login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = TextBox1.Text;
            string password = TextBox2.Text;
            string adminLoginSql = "select * from Staff_Table where worker_mobile='" + username +
                                   "' and worker_password='" + password + "'";
            DataSet ds = OperaterBase.GetData(adminLoginSql);
            if (ds.Tables[0].Rows.Count == 0)
            {
                Label1.Text = "信息有误，请检查";
                return;
            }
            
            
            // 存入session，判断session是否为空
            Session["login_user"] = ds.Tables[0].Rows[0]["worker_mobile"];
            if (string.IsNullOrEmpty(Session["login_user"].ToString()))
            {
                Label1.Text = "服务器错误，请联系管理员";
                return;
            }


            // 必须是管理员
            if (ds.Tables[0].Rows[0]["worker_num"].ToString() == "admin")
            {
                Response.Redirect("manage_staff.aspx");
            }
            else
            {
                Response.Redirect("order_list.aspx?staffId=" + ds.Tables[0].Rows[0]["Id"]);
            }
        }
    }
}