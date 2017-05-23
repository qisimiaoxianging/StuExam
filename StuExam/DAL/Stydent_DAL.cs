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
    /// 数据访问类:Choice
    /// </summary>
    public partial class Choice
    {
        //数据库执行对象
        private static SqlHelper m_sqlHelper = new SqlHelper();
        public Choice()
        { }
        #region  BasicMethod
        /// <summary>
        /// 更新学生答题(选择题)
        /// </summary>
        public static bool UpdateList(object[,] Paper_Choice, string ExamId, string StudentId, int Num)
        {
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            strSql1.Append("delete from Exam_Choice where ");
            strSql1.Append("ExamId =" + ExamId);
            strSql1.Append(" and StudentId =" + StudentId);

            strSql2.Append("insert into Exam_Choice (ExamId,StudentId,Number,Subject,Answer,StudentAnswer,Score,Value) values ");
            for (int i = 0; i < Num; i++)
            {
                strSql2.Append("(");
                strSql2.Append("'" + ExamId + "',");
                strSql2.Append("'" + StudentId + "',");
                strSql2.Append("'" + Paper_Choice[i, 0].ToString() + "',");
                strSql2.Append("'" + Paper_Choice[i, 1].ToString().Replace("'", "''") + "',");
                strSql2.Append("'" + Paper_Choice[i, 2].ToString() + "',");
                strSql2.Append("'" + Paper_Choice[i, 3].ToString() + "',");
                strSql2.Append("'" + Paper_Choice[i, 4].ToString() + "',");
                strSql2.Append("'" + Paper_Choice[i, 5].ToString() + "'");
                if (i < Num - 1)
                    strSql2.Append("),");
                else
                    strSql2.Append(")");
            }

            //由于删除和插入必须同时完成所以使用事务
            m_sqlHelper.BeginTrans();
            try
            {
                int rows1 = m_sqlHelper.ExecuteNonQuery(strSql1.ToString());
                int rows2 = m_sqlHelper.ExecuteNonQuery(strSql2.ToString());
            }
            catch (Exception ex)
            {
                m_sqlHelper.RollbackTrans();
                return false;
            }
            finally
            {
                m_sqlHelper.CommitTrans();
            }

            return true;
        }
        /// <summary>
        /// 增加考卷（选择题）
        /// </summary>
        public static bool AddList(DataTable dt)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Choice_Paper (Id,Number,Subject,Answer,Value) values ");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strSql.Append("(");
                strSql.Append("'" + dt.Rows[i][0] + "',");
                strSql.Append("'" + dt.Rows[i][1] + "',");
                strSql.Append("'" + dt.Rows[i][2].ToString().Replace("'", "''") + "',");
                strSql.Append("'" + dt.Rows[i][3] + "',");
                strSql.Append("'" + dt.Rows[i][4] + "'");
                if (i < dt.Rows.Count - 1)
                    strSql.Append("),");
                else
                    strSql.Append(")");
            }
            int rows = m_sqlHelper.ExecuteNonQuery(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 增加题目
        /// </summary>
        public static int Add(StuExam.Model.Choice model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Choice(");
            strSql.Append("Subject,Answer,Chapter)");
            strSql.Append(" values (");
            strSql.Append("@Subject,@Answer,@Chapter)");
            SqlParameter[] parameters = {
                    new SqlParameter("@Subject", SqlDbType.NVarChar,3000),
                    new SqlParameter("@Answer", SqlDbType.NVarChar,10),
                    new SqlParameter("@Chapter", SqlDbType.Int)};
            parameters[0].Value = model.Subject;
            parameters[1].Value = model.Answer;
            parameters[2].Value = model.Chapter;

            object obj = m_sqlHelper.ExecuteNonQuery(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static int Exists(int Number)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Choice");
            strSql.Append(" where Number=@Number");
            SqlParameter[] parameters = {
                    new SqlParameter("@Number", SqlDbType.Int,4)
            };
            parameters[0].Value = Number;

            return (int)m_sqlHelper.ExecuteScalar(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static StuExam.Model.Choice GetModel(int Number)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Number,Subject,Answer,Chapter,Section from Choice ");
            strSql.Append(" where Number=@Number");
            SqlParameter[] parameters = {
                    new SqlParameter("@Number", SqlDbType.Int,4)
            };
            parameters[0].Value = Number;

            StuExam.Model.Choice model = new StuExam.Model.Choice();
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
        public static StuExam.Model.Choice DataRowToModel(DataRow row)
        {
            StuExam.Model.Choice model = new StuExam.Model.Choice();
            if (row != null)
            {
                if (row["Number"] != null && row["Number"].ToString() != "")
                {
                    model.Number = int.Parse(row["Number"].ToString());
                }
                if (row["Subject"] != null)
                {
                    model.Subject = row["Subject"].ToString();
                }
                if (row["Answer"] != null)
                {
                    model.Answer = row["Answer"].ToString();
                }
                if (row["Chapter"] != null && row["Chapter"].ToString() != "")
                {
                    model.Chapter = int.Parse(row["Chapter"].ToString());
                }
                if (row["Section"] != null && row["Section"].ToString() != "")
                {
                    model.Section = int.Parse(row["Section"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得学生考试选择题答案存取信息
        /// </summary>
        public static DataTable ExamGetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(" NewID() as rdId,Subject,Answer,StudentAnswer,Number,Value");
            strSql.Append(" FROM Exam_Choice ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by Value");
            return m_sqlHelper.ExecuteDataTable(strSql.ToString());
        }

        /// <summary>
        /// 获得试卷数据列表
        /// </summary>
        public static DataTable PaperGetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(" NewID() as rdId,Subject,Answer,Number,Value");
            strSql.Append(" FROM Choice_Paper ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by Value");
            return m_sqlHelper.ExecuteDataTable(strSql.ToString());
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(" NewID() as rdId,Subject,Answer,Number");
            strSql.Append(" FROM Choice ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return m_sqlHelper.ExecuteDataTable(strSql.ToString());
        }

        /// <summary>
        /// 随机获得若干条数据
        /// </summary>
        public static DataTable GetList(int Top, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" NewID() as rdId,Subject,Answer,Number ");
            strSql.Append(" FROM Choice ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by rdId");
            return m_sqlHelper.ExecuteDataTable(strSql.ToString());
        }
        /// <summary>
        /// 获得指定编号的题目信息
        /// </summary>
        public static DataTable GetListByNum(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(" Subject,Answer,Chapter,Section ");
            strSql.Append(" FROM Choice ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return m_sqlHelper.ExecuteDataTable(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public static int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) FROM Choice ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = m_sqlHelper.ExecuteNonQuery(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        public static bool updateing(string Number, string Subject, string Answer, string Chapter)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Choice SET ");
            strSql.Append("Subject = '" + Subject + "', ");
            strSql.Append("Answer = '" + Answer + "', ");
            strSql.Append("Chapter = '" + Chapter + "' ");
            strSql.Append("WHERE Number = '" + Number + "' ");
            int rows = m_sqlHelper.ExecuteNonQuery(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.Number desc");
            }
            strSql.Append(")AS Row, T.*  from Choice T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return m_sqlHelper.ExecuteDataSet(strSql.ToString());
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
            strSql.Append(" where JobNumber=@JobNumber and Password=@Password");
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

