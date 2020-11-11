using System;
using System.Web.UI;

namespace WebApplication4
{
    public partial class BasePage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OnInit(null);
        }

        public string CurrentUser
        {
            get { return CookieHelper.GetCookieValue("worker_mobile"); }
            set { }
        }

        protected override void OnInit(EventArgs e)
        {
            if (string.IsNullOrEmpty(CurrentUser))
            {
                if (string.IsNullOrEmpty(Session["worker_mobile"].ToString()))
                {
                    Response.Redirect("manage_staff_login.aspx");
                }
            }

            // 回到调用他的页面
            base.OnInit(e);
        }
    }
}