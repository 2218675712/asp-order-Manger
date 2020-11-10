using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class order_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string login_user = Session["login_user"].ToString();
                if (string.IsNullOrEmpty(login_user))
                {
                    Response.Write("登录异常");
                    return;
                }
                else
                {
                    string time = System.DateTime.Now.ToString();
                    Response.Write("欢迎" + login_user + "，您在" + time + "登录");
                }

                // 页面第一次加载
                GetOrderList();
            }
        }

        /// <summary>
        /// 获取订单列表
        /// </summary>
        public void GetOrderList()
        {
            string staffId = Request["staffId"];
            // 判断是否为空
            if (!string.IsNullOrEmpty(staffId))
            {
                DataSet ds = OperaterBase.GetData("select * from V_Order_Sta_Dev where order_staff= " + staffId);
                Repeater1.DataSource = ds;
                Repeater1.DataBind();
            }
        }

        /// <summary>
        /// 跳转到订单详情页/订单添加页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string staffId = Request["staffId"];
            if (!string.IsNullOrEmpty(staffId))
            {
                // 跳转到订单详情页 当前登录人的id传过去
                Response.Redirect("order_detail.aspx?staffId=" + staffId);
            }
            else
            {
                // 登录信息失效,需要重新登陆
                Response.Redirect("manage_staff_login.aspx");
            }
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("manage_staff_login.aspx");
        }
    }
}