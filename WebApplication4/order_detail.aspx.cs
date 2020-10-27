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
                // 锁定员工姓名
                GetStaffDetail();
                // 获取设备下拉列表
                GetDeviceList();
            }
        }

        /// <summary>
        /// 锁定员工姓名
        /// </summary>
        private void GetStaffDetail()
        {
            // 获取传递过来的员工id
            string staffId = Request["staffId"];
            if (!string.IsNullOrEmpty(staffId))
            {
                DataSet ds = OperaterBase.GetData("select * from Staff_Table where is_delete=0 and Id=" + staffId);
                // 如果查询到数据,给员工姓名textBox赋值,并向隐藏控件赋值id
                if (ds.Tables[0].Rows.Count > 0)
                {
                    TextBox4.Text = ds.Tables[0].Rows[0]["worker_name"].ToString();
                    HiddenField1.Value = ds.Tables[0].Rows[0]["Id"].ToString();
                }
                // 查不到跳转到登录页面
                else
                {
                    Response.Redirect("manage_staff_login.aspx");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // 获取传递过来的员工id
            string staffId = Request["staffId"];
            string order_number = TextBox1.Text;
            string device_number = DropDownList1.SelectedItem.Text;
            string device_count = TextBox3.Text;
            // 库存设置
            int count = GetIinventoryCount(device_number, device_count);
            if (count == -1)
            {
                return;
            }

            string sql =
                "insert into Order_List ( order_number,order_staff, device_id, device_count,is_delete)values ('" +
                order_number
                + "','" + staffId + "','" + device_number + "','" + device_count + "',0)";
            int num = OperaterBase.CommandBySql(sql);
            if (num > 0)
            {
                Response.Redirect("manage_staff_login.aspx");
            }
        }

        /// <summary>
        /// 获取设备型号
        /// </summary>
        private void GetDeviceList()
        {
            DataSet ds = OperaterBase.GetData("select * from Device_List where is_delete=0 order by device_number");
            DropDownList1.DataSource = ds;
            DropDownList1.DataTextField = "device_number";
            DropDownList1.DataValueField = "id";
            DropDownList1.DataBind();
            // 插入到第一个位置,内容和value值
            DropDownList1.Items.Insert(0, new ListItem("请选择设备编号", "0"));
        }

        /// <summary>
        /// 库存数量比对,重新设置库存数量
        /// </summary>
        /// <param name="device_number">设备型号</param>
        /// <param name="device_count">下单数量</param>
        /// <returns></returns>
        public int GetIinventoryCount(string device_number, string device_count)
        {
            // 应该重新设置的库存数量
            int count = -1;
            DataSet ds =
                OperaterBase.GetData("select * from Device_List where device_number = '" + device_number + "'");
            // 说明查出来数据了
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToInt32(device_count) > Convert.ToInt32(ds.Tables[0].Rows[0]["device_count"]))
                {
                    Label1.Text = "下单数量大于库存数量，库存数量为" + Convert.ToInt32(ds.Tables[0].Rows[0]["device_count"]);
                }
                else
                {
                    // 数量正常，可以正常减去
                    count = Convert.ToInt32(ds.Tables[0].Rows[0]["device_count"]) - Convert.ToInt32(device_count);
                    OperaterBase.CommandBySql("update Device_List set device_count=" + count +
                                              " where device_number='" + device_number + "'");
                }
            }
            else
            {
                Label1.Text = "设备号有异常，请检查";
            }

            return count;
        }
    }
}