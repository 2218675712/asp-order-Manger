using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Label1.Text = string.Compare("abc", "ABC", true).ToString();
            //  DateTime de = DateTime.Now;
            //   Label2.Text = String.Format("{0:D}", de);

            int[] arr = new int[10];
            for (var i = 0; i < arr.Length; i++)
            {
                arr[i] = i;
                Response.Write("conles.log(第" + i + "个是i)");
            }
        }
    }
}