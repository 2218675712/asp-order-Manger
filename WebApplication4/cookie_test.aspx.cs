using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class cookie_test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            // 判断是否选择了记住密码
            var remember_password = CookieHelper.GetCookieValue("remember_password");
            if (!string.IsNullOrEmpty(remember_password))
            {
                // 记住了密码
                if (remember_password=="True")
                {
                    CheckBox1.Checked = true;
                    var worker_mobile1 = CookieHelper.GetCookieValue("worker_mobile");
                    if (!string.IsNullOrEmpty(worker_mobile1))
                    {
                        TextBox1.Text = worker_mobile1;
                    }

                    var worker_password1 = CookieHelper.GetCookieValue("worker_password");
                    if (!string.IsNullOrEmpty(worker_password1))
                    {
                        // 为了显示密码
                        TextBox2.Attributes.Add("value",worker_password1);
                        // 在点击登录的时候,可以取值
                        TextBox2.Text = worker_password1;
                    }
                }
                // 判断是否选择了记住登录
                var auto_login = CookieHelper.GetCookieValue("auto_login");
                if (!string.IsNullOrEmpty(auto_login))
                {
                    // 如果选择了自动登录
                    if (auto_login=="True")
                    {
                        var worker_mobile1 = CookieHelper.GetCookieValue("worker_mobile");
                        if (!string.IsNullOrEmpty(worker_mobile1))
                        {
                            if (worker_mobile1=="12345678901")
                            {
                                Response.Redirect("manage_staff.aspx");
                            }
                            else
                            {
                                Response.Redirect("order_list.aspx");
                            }
                        }
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string worker_mobile = TextBox1.Text;
            // string worker_password = TextBox2.Text;
            string worker_password = TextBox2.Text;
            DataSet ds =
                OperaterBase.GetData("select * from Staff_Table where worker_mobile='" + worker_mobile +
                                     "' and worker_password='" + worker_password + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                bool CheckBoxResult = CheckBox1.Checked;
                if (CheckBoxResult)
                {
                    CookieHelper.SetCookie("worker_mobile", ds.Tables[0].Rows[0]["worker_mobile"].ToString(),
                        DateTime.Now.AddMinutes(10));
                    CookieHelper.SetCookie("worker_password", ds.Tables[0].Rows[0]["worker_password"].ToString(),
                        DateTime.Now.AddMinutes(10));
                    CookieHelper.SetCookie("remember_password", CheckBox2.Checked.ToString(),
                        DateTime.Now.AddMinutes(10));   
                    CookieHelper.SetCookie("auto_login", CheckBox2.Checked.ToString(),
                        DateTime.Now.AddMinutes(10));
                    CookieHelper.SetCookie("Id", ds.Tables[0].Rows[0]["Id"].ToString(),
                        DateTime.Now.AddMinutes(10));
                }
                else
                {
                    Session["worker_mobile"] = ds.Tables[0].Rows[0]["worker_mobile"];
                    Session["worker_password"] = ds.Tables[0].Rows[0]["worker_password"];
                }

                Response.Redirect("manage_staff.aspx");
            }
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (!CheckBox1.Checked)
            {
                CheckBox2.Checked = false;
            }
        }

        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {

            if (CheckBox2.Checked)
            {
                CheckBox1.Checked = true;
            }
        }

        protected void TextBox2_OnTextChanged(object sender, EventArgs e)
        {
            var Pwd_Text = TextBox2.Text.Trim();
            TextBox2.Attributes.Add("value", Pwd_Text);
            TextBox2.Text = Pwd_Text;
        }
    }
}