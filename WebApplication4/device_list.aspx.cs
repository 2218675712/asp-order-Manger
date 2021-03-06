﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class device_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
                GetOutDeviceList();
        }

        /// <summary>
        /// 获取设备列表
        /// </summary>
        public void GetOutDeviceList()
        {
            DataSet ds = OperaterBase.GetData("select * from Device_List");
            Repeater1.DataSource = ds;
            Repeater1.DataBind();
        }

        /// <summary>
        /// 下拉框筛选是否删除
        /// </summary>
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs args)
        {
            // 获取下拉框value值
            string isDeleteSelectValue = DropDownList1.SelectedValue;
            if (!string.IsNullOrEmpty(isDeleteSelectValue))
            {
                GetStaffData("select * from Device_List where is_delete=" + isDeleteSelectValue);
            }
            else
            {
                GetStaffData("select  * from Device_List");
            }
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

        /// <summary>
        /// 表格更新或删除功能
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int deviceId = Convert.ToInt32(((HiddenField) e.Item.FindControl("HiddenField1")).Value);
            if (e.CommandName == "Delete")
            {
                string sql = "update Device_List set is_delete=1 where id = " + deviceId;
                int flag = OperaterBase.CommandBySql(sql);
                if (flag > 0)
                {
                    Response.Write("<script type='text/javascript'>alert(成功删除：'" + flag + "'条数据);</script>");
                    DropDownList1_SelectedIndexChanged(null,null);
                }
            }
            else if (e.CommandName == "Edit")
            {
                Response.Redirect("add_device.aspx?deviceId="+deviceId);
            }
        }

        /// <summary>
        /// 添加设备数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("add_device.aspx");
        }
    }
}