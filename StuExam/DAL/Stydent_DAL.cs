using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using StuExam;
using System.Web;

namespace StuExam.DAL
{
    /// <summary>
    /// 数据访问类:Student
    /// </summary>
    public partial class Student
    {
        //数据库执行对象
        private static SqlHelper m_sqlHelper = new SqlHelper();
        public Student()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static int Exists(string StudentId, string Password)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Student");
            strSql.Append(" where StudentId=@StudentId and Password=@Password ");
            SqlParameter[] parameters = {
                    new SqlParameter("@StudentId", SqlDbType.NVarChar,20),
                    new SqlParameter("@Password", SqlDbType.NVarChar,20),       };
            parameters[0].Value = StudentId;
            parameters[1].Value = Password;
            return (int)m_sqlHelper.ExecuteScalar(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static StuExam.Model.Student GetModel(string StudentId, string Password)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 StudentId,Name,Profession,Class,Note from Student ");
            strSql.Append(" where StudentId=@StudentId and Password=@Password");
            SqlParameter[] parameters = {
                    new SqlParameter("@StudentId", SqlDbType.NVarChar,20),
                    new SqlParameter("@Password", SqlDbType.NVarChar,20)
                    };
            parameters[0].Value = StudentId;
            parameters[1].Value = Password;
            StuExam.Model.Student model = new StuExam.Model.Student();
            DataSet ds = m_sqlHelper.ExecuteDataSet(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static StuExam.Model.Student DataRowToModel(DataRow row)
        {
            StuExam.Model.Student model = new StuExam.Model.Student();
            if (row != null)
            {
                if (row["StudentId"] != null)
                {
                    model.StudentId = row["StudentId"].ToString();
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["Profession"] != null)
                {
                    model.Profession = row["Profession"].ToString();
                }
                if (row["Class"] != null)
                {
                    model.Class = row["Class"].ToString();
                }
                if (row["Note"] != null)
                {
                    model.Note = row["Note"].ToString();
                }
            }
            return model;
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod

    }


    /// <summary>
    /// 数据访问类:Teacher
    /// </summary>
    public partial class Teacher
    {
        //数据库执行对象
        private static SqlHelper m_sqlHelper = new SqlHelper();
        public Teacher()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static int Exists(string TeacherId, string Password)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Teacher");
            strSql.Append(" where JobNumber=@JobNumber ");
            SqlParameter[] parameters = {
                    new SqlParameter("@JobNumber", SqlDbType.NVarChar,15),
                    new SqlParameter("@Password", SqlDbType.NVarChar,16),       };
            parameters[0].Value = TeacherId;
            parameters[1].Value = Password;
            return (int)m_sqlHelper.ExecuteScalar(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static StuExam.Model.Teacher DataRowToModel(DataRow row)
        {
            StuExam.Model.Teacher model = new StuExam.Model.Teacher();
            if (row != null)
            {
                if (row["JobNumber"] != null)
                {
                    model.JobNumber = row["JobNumber"].ToString();
                }
                if (row["Password"] != null)
                {
                    model.Password = row["Password"].ToString();
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["Iamage"] != null && row["Iamage"].ToString() != "")
                {
                    model.Iamage = (byte[])row["Iamage"];
                }
            }
            return model;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static StuExam.Model.Teacher GetModel(string TeacherId, string Password)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 JobNumber,Password,Name,Iamage from Teacher ");
            strSql.Append(" where JobNumber=@JobNumber ");
            SqlParameter[] parameters = {
                    new SqlParameter("@JobNumber", SqlDbType.NVarChar,15),
                    new SqlParameter("@Password", SqlDbType.NVarChar,16),};
            parameters[0].Value = TeacherId;
            parameters[1].Value = Password;

            StuExam.Model.Teacher model = new StuExam.Model.Teacher();
            DataSet ds = m_sqlHelper.ExecuteDataSet(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 更新密码
        /// </summary>
        public static bool Update(StuExam.Model.Teacher model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Teacher set ");
            strSql.Append("Password=@Password");
            strSql.Append(" where JobNumber=@JobNumber and Name=@Name");
            SqlParameter[] parameters = {
                    new SqlParameter("@Password", SqlDbType.NVarChar,16),
                    new SqlParameter("@Name", SqlDbType.NVarChar,15),
                    new SqlParameter("@JobNumber", SqlDbType.NVarChar,15)};
            parameters[0].Value = model.Password;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.JobNumber;
            int rows = m_sqlHelper.ExecuteNonQuery(strSql.ToString(), parameters); ;
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion  BasicMethod
    }
}

