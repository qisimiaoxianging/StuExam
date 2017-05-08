using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace StuExam.DAL
{
    public class SqlHelper
    {
        private string connectionString;

        private SqlConnection m_conn = null;
        private SqlTransaction m_trans = null;
        private bool m_isTransUsed = false; 

        /// <summary>
        /// 设定数据库访问字符串
        /// </summary>
        public string ConnectionString
        {

            set { connectionString = value; }
        }

        public void BeginTrans()
        {
            if (m_conn == null)
            {
                m_conn = new SqlConnection(connectionString);
            }

            if (m_conn.State == ConnectionState.Closed)
            {
                m_conn.Open();
            }

            m_isTransUsed = true;

            m_trans = m_conn.BeginTransaction();
        }

        public void CommitTrans()
        {
            if (m_trans != null)
            {
                m_trans.Commit();
            }

            if (m_conn != null)
            {
                m_conn.Close();
            }

            m_isTransUsed = false;
        }

        public void RollbackTrans()
        {
            if (m_trans != null)
            {
                m_trans.Rollback();
            }

            if (m_conn != null)
            {
                m_conn.Close();
            }

            m_isTransUsed = false;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionString">数据库访问字符串</param>
        public SqlHelper(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public SqlHelper()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["con"].ToString();
        }


        /// <summary>
        /// 执行一个查询，并返回结果集
        /// </summary>
        /// <param name="sql">要执行的sql文本命令</param>
        /// <returns>返回查询的结果集</returns>
        public DataTable ExecuteDataTable(string sql)
        {
            return ExecuteDataTable(sql, CommandType.Text, null);
        }

        /// <summary>
        /// 执行一个查询，并返回结果集
        /// </summary>
        /// <param name="sql">要执行的sql文本命令</param>
        /// <returns>返回查询的结果集</returns>
        public DataTable ExecuteDataTable(string sql, SqlParameter[] parameters)
        {
            return ExecuteDataTable(sql, CommandType.Text, parameters);
        }

        /// <summary>
        /// 执行一个查询，并返回查询结果
        /// </summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <param name="commandtype">要执行查询语句的类型，如存储过程或者sql文本命令</param>
        /// <param name="parameters">Transact-SQL语句或者存储过程参数数组</param>
        /// <returns></returns>
        public DataTable ExecuteDataTable(string sql, CommandType commandtype, SqlParameter[] parameters)
        {
            DataTable data = new DataTable(); //实例化datatable，用于装载查询结果集
            if (m_isTransUsed)
            {
                using (SqlCommand cmd = new SqlCommand(sql, m_conn, m_trans))
                {
                    cmd.CommandType = commandtype;//设置command的commandType为指定的Commandtype
                    //如果同时传入了参数，则添加这些参数
                    if (parameters != null)
                    {
                        foreach (SqlParameter parameter in parameters)
                        {
                            cmd.Parameters.Add(parameter);
                        }
                    }

                    //通过包含查询sql的sqlcommand实例来实例化sqldataadapter
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(data);//填充datatable

                }
            }
            else
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.CommandType = commandtype;//设置command的commandType为指定的Commandtype
                        //如果同时传入了参数，则添加这些参数
                        if (parameters != null)
                        {
                            foreach (SqlParameter parameter in parameters)
                            {
                                cmd.Parameters.Add(parameter);
                            }
                        }

                        //通过包含查询sql的sqlcommand实例来实例化sqldataadapter
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(data);//填充datatable

                    }
                }
            }

            return data;
        }

        /// <summary>
        /// 执行一个查询，并返回结果集
        /// </summary>
        /// <param name="sql">要执行的sql文本命令</param>
        /// <returns>返回查询的结果集</returns>
        public DataSet ExecuteDataSet(string sql)
        {
            return ExecuteDataSet(sql, CommandType.Text, null);
        }

        /// <summary>
        /// 执行一个查询，并返回结果集
        /// </summary>
        /// <param name="sql">要执行的sql文本命令</param>
        /// <returns>返回查询的结果集</returns>
        public DataSet ExecuteDataSet(string sql, SqlParameter[] parameters)
        {
            return ExecuteDataSet(sql, CommandType.Text, parameters);
        }


        /// <summary>
        /// 执行一个查询，并返回查询结果
        /// </summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <param name="commandtype">要执行查询语句的类型，如存储过程或者sql文本命令</param>
        /// <param name="parameters">Transact-SQL语句或者存储过程参数数组</param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(string sql, CommandType commandtype, SqlParameter[] parameters)
        {
            DataSet data = new DataSet(); //实例化datatable，用于装载查询结果集
            if (m_isTransUsed)
            {
                using (SqlCommand cmd = new SqlCommand(sql, m_conn, m_trans))
                {
                    cmd.CommandType = commandtype;//设置command的commandType为指定的Commandtype
                    //如果同时传入了参数，则添加这些参数
                    if (parameters != null)
                    {
                        foreach (SqlParameter parameter in parameters)
                        {
                            cmd.Parameters.Add(parameter);
                        }
                    }

                    //通过包含查询sql的sqlcommand实例来实例化sqldataadapter
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(data);//填充datatable

                }
            }
            else
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.CommandType = commandtype;//设置command的commandType为指定的Commandtype
                        //如果同时传入了参数，则添加这些参数
                        if (parameters != null)
                        {
                            foreach (SqlParameter parameter in parameters)
                            {
                                cmd.Parameters.Add(parameter);
                            }
                        }

                        //通过包含查询sql的sqlcommand实例来实例化sqldataadapter
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(data);//填充datatable

                    }
                }
            }

            return data;
        }

     

        /// <summary>
        /// 执行一个查询，返回结果集的首行首列。忽略其他行，其他列
        /// </summary>
        /// <param name="sql">要执行的SQl命令</param>
        /// <returns></returns>
        public Object ExecuteScalar(string sql)
        {
            return ExecuteScalar(sql, CommandType.Text, null);
        }

        /// <summary>
        /// 执行一个查询，返回结果集的首行首列。忽略其他行，其他列
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public Object ExecuteScalar(string sql, SqlParameter[] parameters)
        {
            return ExecuteScalar(sql, CommandType.Text, parameters);
        }




        /// <summary>
        /// 执行一个查询，返回结果集的首行首列。忽略其他行，其他列
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="commandType">参数类型</param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Object ExecuteScalar(string sql, CommandType commandType, SqlParameter[] parameters)
        {
            Object result = null;
            if (m_isTransUsed)
            {
                SqlCommand cmd = new SqlCommand(sql, m_conn, m_trans);
                cmd.CommandType = commandType;
                if (parameters != null)
                {
                    foreach (SqlParameter parapmeter in parameters)
                    {
                        cmd.Parameters.Add(parapmeter);
                    }
                }

                result = cmd.ExecuteScalar();
            }
            else
            {
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = commandType;
                if (parameters != null)
                {
                    foreach (SqlParameter parapmeter in parameters)
                    {
                        cmd.Parameters.Add(parapmeter);
                    }
                }

                con.Open();
                result = cmd.ExecuteScalar();
                con.Close();
            }

            return result;
        }

        /// <summary>
        /// 对数据库进行增删改的操作
        /// </summary>
        /// <param name="sql">要执行的sql命令</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sql)
        {
            return ExecuteNonQuery(sql, CommandType.Text, null);
        }

        /// <summary>
        /// 对数据库进行增删改的操作
        /// </summary>
        /// <param name="sql">要执行的sql命令</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sql, SqlParameter[] parameters)
        {
            return ExecuteNonQuery(sql, CommandType.Text, parameters);
        }



        /// <summary>
        /// 对数据库进行增删改的操作
        /// </summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <param name="commandType">要执行的查询语句类型，如存储过程或者sql文本命令</param>
        /// <param name="parameters">Transact-SQL语句或者存储过程的参数数组</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sql, CommandType commandType, SqlParameter[] parameters)
        {
            int count = 0;

            if (m_isTransUsed)
            {
                SqlCommand cmd = new SqlCommand(sql, m_conn, m_trans);
                //cmd.CommandType = commandType;
                if (parameters != null)
                {
                    foreach (SqlParameter parameter in parameters)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                }
                try
                {
                    count = cmd.ExecuteNonQuery();
                }
                catch { }
            }
            else
            {
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandTimeout = 180;//timeout jgy
                cmd.CommandType = commandType;
                if (parameters != null)
                {
                    foreach (SqlParameter parameter in parameters)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                }

                con.Open();
                try
                {
                    count = cmd.ExecuteNonQuery();
                }
                catch { }
                con.Close();
            }
            return count;
        }

        
    }
}
