using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace bookDB
{
    public class bookDBClass
    {
        SqlConnection conn; //数据库连接对象

        private void openConnection() //创建数据库连接对象,打开数据库连接
        {
            //数据库连接字符串
            string strConn = "Server=(local);Database=bookData;" +
                            "Integrated Security=SSPI;Persist Security Info=False";
            conn = new SqlConnection(strConn);
            if(conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        private void closeConnection()  //关闭数据库连接
        {
            if(conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        public DataTable getDataBySQL(string strComm)  //根据传入的SQL语句生成相应的数据表,该方法的参数是SQL语句
        {
            SqlDataAdapter adapterSql;
            DataSet ds = new DataSet();
            try
            {
                openConnection();
                adapterSql = new SqlDataAdapter(strComm, conn);
                adapterSql.Fill(ds, "table01");
                closeConnection();
                //返回生成的数据表
                return ds.Tables[0];
            }
            catch(Exception ex)
            {
                //异常报告
                MessageBox.Show("创建数据表发生异常!异常原因:" +
                                    ex.Message, "错误提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            return null;
        }

        public bool updateDataTable(string strComm)  //根据传入的SQL语句更新相应的数据表,更新包括数据表的增加,修改和删除
        {
            try
            {
                SqlCommand comm;
                openConnection();
                comm = new SqlCommand(strComm, conn);
                comm.ExecuteNonQuery();
                closeConnection();
                //更新成功
                return true;

            }
            catch(Exception ex)
            {
                //更新失败,返回失败原因
                MessageBox.Show("更新数据失败!" + ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
    }
}
