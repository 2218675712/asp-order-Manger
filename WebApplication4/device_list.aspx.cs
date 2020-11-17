using System;
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
            Repeater1.DataSource = this.getPage(ds);
            Repeater1.DataBind();
            /*
             List<DeviceListModel> deviceListModels = new List<DeviceListModel>();
            foreach (DataRow dataRow in ds.Tables[0].Rows)
            {
                DeviceListModel deviceListModel = new DeviceListModel();
                foreach (DataColumn dataColumn in ds.Tables[0].Columns)
                {
                    switch (dataColumn.ColumnName)
                    {
                        case "id":
                            deviceListModel.id = dataRow["id"].ToString();
                            break;
                        case "device_number":
                            deviceListModel.device_number = dataRow["device_number"].ToString();
                            break;
                        case "device_count":
                            deviceListModel.device_count = dataRow["device_count"].ToString();
                            break;
                        case "is_delete":
                            deviceListModel.is_delete = dataRow["is_delete"].ToString();
                            break;
                    }
                }

                deviceListModels.Add(deviceListModel);
            }

            Repeater1.DataSource = deviceListModels;
            Repeater1.DataBind();
            */
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
                    DropDownList1_SelectedIndexChanged(null, null);
                }
            }
            else if (e.CommandName == "Edit")
            {
                Response.Redirect("add_device.aspx?deviceId=" + deviceId);
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

        public PagedDataSource getPage(DataSet ds)
        {
            // 总条数
            this.AspNetPager1.RecordCount = ds.Tables[0].Rows.Count;
            PagedDataSource pagedDataSource = new PagedDataSource();

            pagedDataSource.DataSource = ds.Tables[0].DefaultView;
            // 是否启动分页
            pagedDataSource.AllowPaging = true;
            // 当前是第几页
            pagedDataSource.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            // 显示多少条数据
            pagedDataSource.PageSize = AspNetPager1.PageSize;
            return pagedDataSource;
        }

        protected void AspNetPager1_OnPageChanged(object sender, EventArgs e)
        {
            GetOutDeviceList();
        }
    }
}