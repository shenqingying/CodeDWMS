using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DWMS.Web.Data
{
    /// <summary>
    /// ADO.NET 数据库查询帮助类
    /// </summary>
    public class SQLHelper
    {
        private SqlConnection conn = null;
        private SqlCommand cmd = null;
        private SqlDataReader sdr = null;

        /// <summary>
        /// 默认唯一连接数据库
        /// </summary>
        public SQLHelper()
        {
            string con = "";
            conn = new SqlConnection(con);
        }


        /// <summary>
        /// 提供多个连接字符串
        /// </summary>
        /// <param name="con">外部传入连接字符串</param>
        public SQLHelper(string con)
        {
            conn = new SqlConnection(con);
        }

        /// <summary>
        /// 打开数据库连接
        /// </summary>
        /// <returns></returns>
        private  SqlConnection GetConn()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.OpenAsync();
            }
            return conn;
        }
        /// <summary>
        /// 不带参数，返回受影响行数
        /// </summary>
        /// <param name="ComText">T-SQL语句或者存储过程</param>
        /// <param name="type">T-SQL文本内容或存储过程名称或用户自定义表名称</param>
        /// <returns></returns>
        public int ExecuteNoQuery(string ComText, CommandType type)
        {
            int result;
            try
            {
                cmd = new SqlCommand(ComText, GetConn());
                cmd.CommandType = type;
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return result;
        }
        /// <summary>
        /// 执行带参数的，返回受影响行数
        /// </summary>
        /// <param name="ComText"></param>
        /// <param name="type"></param>
        /// <param name="sqlParameters"></param>
        /// <returns></returns>
        public int ExecuteNoQuery(string ComText, CommandType type, SqlParameter[] sqlParameters)
        {
            int result;
            try
            {
                using (cmd = new SqlCommand(ComText, GetConn()))
                {
                    cmd.CommandType = type;
                    cmd.Parameters.AddRange(sqlParameters);
                    result = cmd.ExecuteNonQuery();
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return result;
        }
        /// <summary>
        /// 执行不带参数，返回DataTable
        /// </summary>
        /// <param name="ComText">如上</param>
        /// <param name="type">如上</param>
        /// <returns></returns>
        public DataTable ExecuteReader(string ComText,CommandType type)
        {
            DataTable dt = new DataTable();
            cmd = new SqlCommand(ComText, GetConn());
            cmd.CommandType = type;
            using (sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                dt.Load(sdr);
            }
            return dt;
        }/// <summary>
        /// 执行带参数，返回DataTable
        /// </summary>
        /// <param name="ComText"></param>
        /// <param name="type"></param>
        /// <param name="sqlParameters"></param>
        /// <returns></returns>
        public  DataTable ExecuteReader(string ComText,CommandType type,SqlParameter[] sqlParameters)
        {
            DataTable dt = new DataTable();
            cmd = new SqlCommand(ComText, GetConn());
            cmd.CommandType = type;
            cmd.Parameters.AddRange(sqlParameters);
            using (sdr =  cmd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                dt.Load(sdr);
            }
            return dt;
        }
    }
}
