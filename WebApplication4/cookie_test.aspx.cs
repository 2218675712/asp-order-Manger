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
            // 判断自动登录是否选中
            if (CheckBox2.Checked == false)
            {
                string worker_mobile1 = CookieHelper.GetCookieValue("worker_mobile");
                if (!string.IsNullOrEmpty(worker_mobile1))
                {
                    TextBox1.Text = worker_mobile1;
                }

                string worker_password1 = CookieHelper.GetCookieValue("worker_password");
                if (!string.IsNullOrEmpty(worker_password1))
                {
                    // 设置属性值
                    TextBox2.Attributes.Add("value",worker_password1);
                    
                }

                // 勾选自动登录
                if (!string.IsNullOrEmpty(worker_mobile1) && !string.IsNullOrEmpty(worker_password1))
                {
                    CheckBox2.Checked = true;
                }
            }
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
                    /*HttpCookie cookie = new HttpCookie("worker_mobile")
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
                    }*/
                    CookieHelper.SetCookie("worker_mobile", ds.Tables[0].Rows[0]["worker_mobile"].ToString(),
                        DateTime.Now.AddMinutes(10));
                    CookieHelper.SetCookie("worker_password", ds.Tables[0].Rows[0]["worker_password"].ToString(),
                        DateTime.Now.AddMinutes(10));
                    CookieHelper.SetCookie("auto_login", CheckBox2.Checked.ToString(),
                        DateTime.Now.AddMinutes(10));
                    CookieHelper.SetCookie("Id", ds.Tables[0].Rows[0]["Id"].ToString(),
                        DateTime.Now.AddMinutes(10));
                }
            }
        }
    }
}