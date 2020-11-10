using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class add_device : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 获取设备id
                int deviceId = Convert.ToInt32(Request["deviceId"]);
                // 如果是0代表没有传值,不是更新
                if (deviceId == 0)
                {
                    return;
                }

                Button1.CommandName = "Update";
                UpdateUser();
            }
        }

        /// <summary>
        /// 更新用户
        /// 给文本框获取数据库原值
        /// </summary>
        private void UpdateUser()
        {
            int deviceId = Convert.ToInt32(Request["deviceId"]);
            string sql = "select * from Device_List where id=" + deviceId;
            DataSet ds = OperaterBase.GetData(sql);
            TextBox1.Text = ds.Tables[0].Rows[0]["device_number"].ToString();
            TextBox2.Text = ds.Tables[0].Rows[0]["device_count"].ToString();
        }

        /// <summary>
        /// 确认按钮点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            AddUser();
        }

        /// <summary>
        /// 添加或更新用户
        /// </summary>
        public void AddUser()
        {
            // 传参设备id
            int deviceId = Convert.ToInt32(Request["deviceId"]);
            string device_number = TextBox1.Text.Trim();
            int device_count = Convert.ToInt32(TextBox2.Text.Trim());
            // 判断是否是插入还是更新
            if (Button1.CommandName == "Insert")
            {
                int num = OperaterBase.CommandBySql(
                    "insert into  Device_List ( device_number, device_count, is_delete) values ('" + device_number +
                    "'," + device_count + ",0)");
                if (num > 0)
                {
                    Label1.Text = "插入成功";
                    // 跳转页面
                    Response.Redirect("device_list.aspx");
                }
            }
            else if (Button1.CommandName == "Update")
            {
                int num = OperaterBase.CommandBySql("update Device_List set device_number='" + device_number +
                                                    "',device_count=" + device_count + " where id=" + deviceId);
                if (num > 0)
                {
                    Label1.Text = "更新成功";
                    // 跳转页面
                    Response.Redirect("device_list.aspx");
                }
            }
        }
    }
}