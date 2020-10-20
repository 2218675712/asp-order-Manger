using System;
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
                var ID = Convert.ToInt32(Request["staffID"]);
                if (ID == 0) return;
                Button1.CommandName = "Update";
                UpdateStaff();
            }
        }

        /// <summary>
        /// 图片上传
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            string filename = avatatUpload();
            int ID = Convert.ToInt32(Request["staffID"]);
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
            int ID = Convert.ToInt32(Request["studentID"]);
            string worker_num = TextBox1.Text.Trim();
            string worker_name = TextBox2.Text.Trim();
            string worker_avatar = Image1.ImageUrl;
            string worker_sex = TextBox3.Text.Trim();
            string worker_age = TextBox4.Text.Trim();
            string worker_mobile = TextBox5.Text.Trim();
            string worker_password = TextBox6.Text.Trim();
            if (Button2.CommandName == "Insert")
            {
                int flag = OperaterBase.CommandBySql(
                    "insert into Staff_Table ( worker_num, worker_name, worker_avatar, worker_sex, worker_age, worker_mobile, worker_password, is_delete) values ('" +
                    worker_num + "','" + worker_name + "','" + worker_avatar + "','" + worker_sex + "','" + worker_age +
                    "','" + worker_mobile + "','" + worker_password + "',0)");
                if (flag > 0)
                {
                    // 跳转页面
                    Response.Redirect("manage_staff.aspx");
                }
            }
            else if(Button2.CommandName == "Update")
            {
                int flag = OperaterBase.CommandBySql(
                    "UPDATE Staff_Table SET worker_num = '" + worker_num + "', worker_name = '" + worker_name + "'," +
                    " worker_sex = '" + worker_sex +
                    "' , worker_age = '" + worker_age + "'," +
                    "worker_mobile = '" + worker_mobile + "' , worker_password = '" + worker_password + "' Id = " + ID);
                if (flag > 0)
                {
                    // 跳转页面
                    Response.Redirect("manage_staff.aspx");
                }
            }
        }

        /// <summary>
        /// 图片上传
        /// </summary>
        /// <returns>图片上传成功或者失败</returns>
        private string avatatUpload()
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
            TextBox3.Text = ds.Tables[0].Rows[0]["worker_sex"].ToString();
            TextBox4.Text = ds.Tables[0].Rows[0]["worker_age"].ToString();
            TextBox5.Text = ds.Tables[0].Rows[0]["worker_mobile"].ToString();
            TextBox6.Text = ds.Tables[0].Rows[0]["worker_password"].ToString();
        }
    }
}