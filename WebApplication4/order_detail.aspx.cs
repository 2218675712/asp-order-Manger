using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class order_detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetDeviceList();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 获取设备型号
        /// </summary>
        private void GetDeviceList()
        {
            DataSet ds = OperaterBase.GetData("select * from Device_List where is_delete=0");
            DropDownList1.DataSource = ds;
            DropDownList1.DataTextField = "device_number";
            DropDownList1.DataValueField = "id";
            DropDownList1.DataBind();
        }

        /// <summary>
        /// 点击下拉列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}