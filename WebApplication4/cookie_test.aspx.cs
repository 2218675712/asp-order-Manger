using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class cookie_test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string worker_mobile = TextBox1.Text;
            string worker_password = TextBox2.Text;
            DataSet ds =
                OperaterBase.GetData("select * from Staff_Table where worker_mobile='" + worker_mobile +
                                     "' and worker_password='" + worker_password + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                bool CheckBoxResult = CheckBox1.Checked;
                if (CheckBoxResult)
                {
                    // 设置cookie
                    // Response.Cookies["worker_mobile"].Value = ds.Tables[0].Rows[0]["worker_mobile"].ToString();
                    // 设置过期时间
                    // Response.Cookies["worker_mobile"].Expires=DateTime.Now.AddDays(3);
                    HttpCookie cookie = new HttpCookie("worker_mobile")
                    {
                        Value = HttpUtility.UrlEncode(ds.Tables[0].Rows[0]["worker_mobile"].ToString()),
                        Expires = DateTime.Now.AddDays(3)
                    };
                    HttpContext.Current.Response.Cookies.Add(cookie);
                    // 设置直接过期
                    // Response.Cookies["worker_mobile"].Expires=DateTime.Now.AddDays(-3);
                    // 获取cookie
                    HttpCookie httpCookie = HttpContext.Current.Request.Cookies["worker_mobile"];
                    if (httpCookie != null)
                    {
                        Response.Write("登录成功");
                    }
                }
            }
        }
    }
}