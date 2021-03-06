﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class add_staff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var ID = Convert.ToInt32(Request["staffId"]);
                GetAllProvince();
                if (ID == 0) return;
                Button2.CommandName = "Update";
                UpdateStaff();
                int Info = Convert.ToInt32(Request["info"]);
                if (Info == 1)
                {
                    ShowUserInfo();
                }
            }
        }

        /// <summary>
        /// 图片上传
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            string filename = AvatarUpload();
            int ID = Convert.ToInt32(Request["staffId"]);
            if (Button1.CommandName == "Update")
            {
                OperaterBase.CommandBySql("update Staff_Table set worker_avatar='" + filename + "' where Id=" +
                                          ID + "");
            }
        }

        /// <summary>
        /// 添加修改用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Request["staffId"]);
            string worker_num = TextBox1.Text.Trim();
            string worker_name = TextBox2.Text.Trim();
            string worker_avatar = Image1.ImageUrl;
            string worker_sex = Sex_Tb.SelectedValue.Trim();
            string worker_age = TextBox4.Text.Trim();
            string worker_mobile = TextBox5.Text.Trim();
            string worker_password = TextBox6.Text.Trim();
            string DropDownList1Text = DropDownList1.SelectedItem.Text;
            string DropDownList2Text = DropDownList2.SelectedItem.Text;
            string DropDownList3Text = DropDownList3.SelectedItem.Text;
            string sql = String.Empty;

            try
            {
                if (Button2.CommandName == "Insert")
                {
                    sql =
                        "insert into Staff_Table ( worker_num, worker_name, worker_avatar, worker_sex, worker_age, worker_mobile, worker_password, is_delete,s_province,s_city,s_district) values ('" +
                        worker_num + "','" + worker_name + "','" + worker_avatar + "','" + worker_sex + "','" +
                        worker_age +
                        "','" + worker_mobile + "','" + worker_password + "',0,'" + DropDownList1Text + "','" +
                        DropDownList2Text + "','" + DropDownList3Text + "')";
                }
                else if (Button2.CommandName == "Update")
                {
                    sql = "UPDATE Staff_Table SET worker_num = '" + worker_num + "', worker_name = '" + worker_name +
                          "'," + " worker_sex = '" + worker_sex + "' , worker_age = '" + worker_age + "'," +
                          "worker_mobile = '" + worker_mobile + "' , worker_password = '" + worker_password +
                          "' , s_province = '" + DropDownList1Text + "' , s_city = '" + DropDownList2Text +
                          "' , s_district = '" + DropDownList3Text +
                          "'where Id = " + ID;
                }

                int flag = OperaterBase.CommandBySql(sql);
                if (flag > 0)
                {
                    // 跳转页面
                    Response.Redirect("manage_staff.aspx");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        /// <summary>
        /// 图片上传
        /// </summary>
        /// <returns>图片上传成功或者失败</returns>
        private string AvatarUpload()
        {
            // 获取文件名
            string strName = FileUpload1.PostedFile.FileName;
            try
            {
                // 创建上传模型类，用来接收上传的参数
                uploadModel newUploadModel = new uploadModel();
                newUploadModel = uploadHelper.imgUpload(strName, FileUpload1.HasFile);
                if (newUploadModel.result)
                {
                    FileUpload1.PostedFile.SaveAs(newUploadModel.newFileName);
                    Label1.Text = newUploadModel.message;
                    Image1.ImageUrl = newUploadModel.fileName;
                    // 插入到数据库
                    return newUploadModel.fileName;
                }
                else
                {
                    Label1.Text = newUploadModel.message;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return null;
        }

        /// <summary>
        /// 修改员工信息
        /// </summary>
        private void UpdateStaff()
        {
            var ID = Convert.ToInt32(Request["staffID"]);
            string sql = "select * from Staff_Table where Id=" + ID + "";
            DataSet ds = OperaterBase.GetData(sql);
            TextBox1.Text = ds.Tables[0].Rows[0]["worker_num"].ToString();
            TextBox2.Text = ds.Tables[0].Rows[0]["worker_name"].ToString();
            Image1.ImageUrl = ds.Tables[0].Rows[0]["worker_avatar"].ToString();
            Sex_Tb.SelectedValue = ds.Tables[0].Rows[0]["worker_sex"].ToString();
            TextBox4.Text = ds.Tables[0].Rows[0]["worker_age"].ToString();
            TextBox5.Text = ds.Tables[0].Rows[0]["worker_mobile"].ToString();
            TextBox6.Text = ds.Tables[0].Rows[0]["worker_password"].ToString();
            DropDownList1.SelectedValue=ds.Tables[0].Rows[0]["s_province"].ToString();
            DropDownList2.SelectedValue=ds.Tables[0].Rows[0]["s_city"].ToString();
            DropDownList3.SelectedValue=ds.Tables[0].Rows[0]["s_district"].ToString();
        }

        /// <summary>
        /// 信息展示,禁用输入框
        /// </summary>
        private void ShowUserInfo()
        {
            TextBox1.Enabled = false;
            TextBox2.Enabled = false;
            Button1.Enabled = false;
            Sex_Tb.Enabled = false;
            TextBox4.Enabled = false;
            TextBox5.Enabled = false;
            TextBox6.Enabled = false;
            Button2.Visible = false;
            Button3.Visible = true;
        }

        /// <summary>
        /// 按钮显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button3_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("manage_staff_login.aspx");
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSelectedCity();
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSelectedDistrict();
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 获取所有省份
        /// </summary>
        private void GetAllProvince()
        {
            string sql = "select * from S_Province";
            DataSet ds = OperaterBase.GetData(sql);
            // 给下拉框绑定
            DropDownList1.DataSource = ds;
            // 绑定下拉框文字
            DropDownList1.DataTextField = "ProvinceName";
            //绑定下拉框value值
            DropDownList1.DataValueField = "ProvinceID";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("请选择省份", "0"));
        }

        /// <summary>
        /// 获取选定省份的城市
        /// </summary>
        private void GetSelectedCity()
        {
            string ProvinceID = DropDownList1.SelectedValue;
            string sql = "select * from S_City where ProvinceID=" + ProvinceID + "";
            DataSet ds = OperaterBase.GetData(sql);
            // 给下拉框绑定
            DropDownList2.DataSource = ds;
            // 绑定下拉框文字
            DropDownList2.DataTextField = "CityName";
            //绑定下拉框value值
            DropDownList2.DataValueField = "CityID";
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, new ListItem("请选择城市", "0"));
            // 改变省份清除区县
            DropDownList3.Items.Clear();
            DropDownList3.Items.Insert(0, new ListItem("请选择地区", "0"));
        }

        /// <summary>
        /// 获取选定城市的区县
        /// </summary>
        private void GetSelectedDistrict()
        {
            string CityID = DropDownList2.SelectedValue;
            string sql = "select * from S_District where CityID=" + CityID + "";
            DataSet ds = OperaterBase.GetData(sql);
            // 给下拉框绑定
            DropDownList3.DataSource = ds;
            // 绑定下拉框文字
            DropDownList3.DataTextField = "DistrictName";
            //绑定下拉框value值
            DropDownList3.DataValueField = "DistrictID";
            DropDownList3.DataBind();
            DropDownList3.Items.Insert(0, new ListItem("请选择地区", "0"));
        }
    }
}