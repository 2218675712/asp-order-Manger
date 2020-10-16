using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication4
{
    public class OperaterBase
    {
        /// <summary>
        /// 查询数据库
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>返回dataset数据</returns>
        public static DataSet GetData(string sql)
        {
            string conn = ConfigurationManager.ConnectionStrings["orderManager"].ConnectionString;
            SqlConnection sct = new SqlConnection(conn);
            SqlDataAdapter sda = new SqlDataAdapter(sql, sct);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;
        }

        /// <summary>
        /// 增删改
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>返回修改行数</returns>
        public static int CommandBySql(string sql)
        {
            string conn = ConfigurationManager.ConnectionStrings["orderManager"].ConnectionString;
            SqlConnection sct = new SqlConnection(conn);
            SqlCommand smd = new SqlCommand(sql, sct);
            sct.Open(); //打开数据库链接
            int flag = smd.ExecuteNonQuery();
            sct.Close(); //关闭数据库链接
            return flag;
        }
    }
}