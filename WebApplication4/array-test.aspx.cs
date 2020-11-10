using System;
using System.Web.UI;

namespace WebApplication4
{
    public partial class array_test : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("string.Compare:" + String.Compare("132", "123", StringComparison.OrdinalIgnoreCase));
            Response.Write("string.Equals:" + string.Equals("132", "132"));
            DateTime dt = DateTime.Now;
            Response.Write(string.Format("{0:D}", dt));
            string str1 = "hello";
            Response.Write(str1.Substring(1, 1));
            string str2 = "h he hel hell hello";
            string[] splitstrings = str2.Split(' ');
            foreach (string splitstring in splitstrings)
            {
                Response.Write(splitstring + "<br/>");
            }

            string str3 = "中午吃啥";
            string str4;
            str4 = str3.Insert(0, "11991");
            Response.Write(str3);
            Response.Write(str4);
            string str5 = "aabbcc";
            // 补零
            str5.PadRight(7, '1');
            Response.Write(str5.PadLeft(10, '1'));
            string str6 = "true";
            Response.Write(str6.Remove(2));
            Response.Write(str6.Remove(1, 2));
            string str7 = "true";
            string str8 = string.Copy(str7);
            Response.Write(str8);
            string str9 = "aaabbb";
            Response.Write(str9.Replace("aa", "cc"));
            // 一维数组
            // type[] arrayName
            int[] arr = new int[5] {0, 1, 2, 3, 4};
            arr[0] = 1;
            arr[0] = 2;
            int[] arrs = {0, 1, 2, 3, 4};
            string[] arrStr = {"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"};
            foreach (string s in arrStr)
            {
                Response.Write("今天是" + s + "<br/>");
            }

            int[,] arr3 = new int[2, 2] {{8, 4}, {3, 4}};
            int[][] arr4 = {
                new int[] {1, 3, 5, 7, 9},
                new int[] {0, 2, 4, 6},
                new int[] {11, 22}
            };
            // int[,] arr4 = {{1, 5}, {3, 2}};
            /*foreach (int i in arr4)
            {
                Response.Write("二维数组"+i);
            }*/
            /*for (var i = 0; i < arr3.GetLength(0); i++)
            {
                for (var j = 0; j < arr3.GetLength(1); j++)
                {
                    Response.Write("二维数组" + arr3[i, j]);
                }
            }*/
            
            for (var i = 0; i < arr4.Length; i++)
            {
                for (var j = 0; j < arr4[i].Length; j++)
                {
                    Response.Write(arr4[i][j]);
                }
            }
            

        }
    }
}