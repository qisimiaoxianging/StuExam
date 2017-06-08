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
        /// 获得数据列表
        /// </summary>
        public static DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select StudentId,Name,Profession,Class,Note ");
            strSql.Append(" FROM Student ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by StudentId asc");
            return m_sqlHelper.ExecuteDataTable(strSql.ToString());
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
    /// 数据访问类:Teacher_Coure
    /// </summary>
    public partial class Teacher_Coure
    {
        //数据库执行对象
        private static SqlHelper m_sqlHelper = new SqlHelper();
        public Teacher_Coure()
        { }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(StuExam.Model.Teacher_Coure model)
        {
            //添加课程时判断有没有添加重复的课程
            int n = StuExam.DAL.Teacher_Coure.Exists(model.teacherID, model.academic_year, model.school_term, model.college, model.profession, model.Class, model.Course);
            if (n == 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Teacher_Coure(");
                strSql.Append("teacherID,academic_year,school_term,college,profession,Class,Course)");
                strSql.Append(" values (");
                strSql.Append("@teacherID,@academic_year,@school_term,@college,@profession,@Class,@Course)");
                SqlParameter[] parameters = {
                    new SqlParameter("@teacherID", SqlDbType.NVarChar,15),
                    new SqlParameter("@academic_year", SqlDbType.NVarChar,10),
                    new SqlParameter("@school_term", SqlDbType.NVarChar,20),
                    new SqlParameter("@college", SqlDbType.NVarChar,15),
                    new SqlParameter("@profession", SqlDbType.NVarChar,10),
                    new SqlParameter("@Class", SqlDbType.NVarChar,10),
                    new SqlParameter("@Course", SqlDbType.NVarChar,20)};
                parameters[0].Value = model.teacherID;
                parameters[1].Value = model.academic_year;
                parameters[2].Value = model.school_term;
                parameters[3].Value = model.college;
                parameters[4].Value = model.profession;
                parameters[5].Value = model.Class;
                parameters[6].Value = model.Course;

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
            else
            {
                return -1;
            }

        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(string teacherID, string academic_year, string school_term, string college, string profession, string Class, string Course)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Teacher_Coure ");
            strSql.Append(" where teacherID=@teacherID and academic_year=@academic_year and school_term=@school_term and college=@college and profession=@profession and Class=@Class and Course=@Course ");
            SqlParameter[] parameters = {
                    new SqlParameter("@teacherID", SqlDbType.NVarChar,15),
                    new SqlParameter("@academic_year", SqlDbType.NVarChar,10),
                    new SqlParameter("@school_term", SqlDbType.NVarChar,20),
                    new SqlParameter("@college", SqlDbType.NVarChar,15),
                    new SqlParameter("@profession", SqlDbType.NVarChar,10),
                    new SqlParameter("@Class", SqlDbType.NVarChar,10),
                    new SqlParameter("@Course", SqlDbType.NVarChar,20)          };
            parameters[0].Value = teacherID;
            parameters[1].Value = academic_year;
            parameters[2].Value = school_term;
            parameters[3].Value = college;
            parameters[4].Value = profession;
            parameters[5].Value = Class;
            parameters[6].Value = Course;


            int rows = m_sqlHelper.ExecuteNonQuery(strSql.ToString(), parameters);
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
        /// 是否存在该记录
        /// </summary>
        public static int Exists(string teacherID, string academic_year, string school_term, string college, string profession, string Class, string Course)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Teacher_Coure");
            strSql.Append(" where teacherID=@teacherID and academic_year=@academic_year and school_term=@school_term and college=@college and profession=@profession and Class=@Class and Course=@Course ");
            SqlParameter[] parameters = {
                    new SqlParameter("@teacherID", SqlDbType.NVarChar,15),
                    new SqlParameter("@academic_year", SqlDbType.NVarChar,10),
                    new SqlParameter("@school_term", SqlDbType.NVarChar,20),
                    new SqlParameter("@college", SqlDbType.NVarChar,15),
                    new SqlParameter("@profession", SqlDbType.NVarChar,10),
                    new SqlParameter("@Class", SqlDbType.NVarChar,10),
                    new SqlParameter("@Course", SqlDbType.NVarChar,20)          };
            parameters[0].Value = teacherID;
            parameters[1].Value = academic_year;
            parameters[2].Value = school_term;
            parameters[3].Value = college;
            parameters[4].Value = profession;
            parameters[5].Value = Class;
            parameters[6].Value = Course;

            return (int)m_sqlHelper.ExecuteScalar(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 获得表中指定条件的所有数据
        /// </summary>
        public static DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(" academic_year,school_term,college,profession,Class,Course ");
            strSql.Append(" FROM Teacher_Coure ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return m_sqlHelper.ExecuteDataTable(strSql.ToString());
        }
        /// <summary>
        /// 获得表中学年
        /// </summary>
        public static DataTable GetList_year(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct");
            strSql.Append(" academic_year ");
            strSql.Append(" FROM Teacher_Coure ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return m_sqlHelper.ExecuteDataTable(strSql.ToString());
        }
        /// <summary>
        /// 获得表中指定条件的专业班级
        /// </summary>
        public static DataTable GetList_Class(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct ");
            strSql.Append(" Class ");
            strSql.Append(" FROM Teacher_Coure ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return m_sqlHelper.ExecuteDataTable(strSql.ToString());
        }
        /// <summary>
        /// 获得表中指定条件的专业课程
        /// </summary>
        public static DataTable GetList_Course(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct ");
            strSql.Append(" Course ");
            strSql.Append(" FROM Teacher_Coure ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return m_sqlHelper.ExecuteDataTable(strSql.ToString());
        }
    }


    /// <summary>
    /// 数据访问类:Stuhomework
    /// </summary>
    public partial class Stuhomework
    {
        //数据库执行对象
        private static SqlHelper m_sqlHelper = new SqlHelper();

        /// <summary>
        /// 更新10列数据
        /// </summary>
        public static bool Update(StuExam.Model.Stuhomework model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Stuhomework set ");
            strSql.Append("StudentId=@StudentId,");
            strSql.Append("actiontime=@actiontime,");
            strSql.Append("maketime=@maketime,");
            strSql.Append("hwSituation=@hwSituation,");
            strSql.Append("hwScore=@hwScore,");
            strSql.Append("count_answer=@count_answer,");
            strSql.Append("stuHour=@stuHour,");
            strSql.Append("stuMinute=@stuMinute,");
            strSql.Append("stuSecond=@stuSecond,");
            strSql.Append("logo=@logo");
            strSql.Append(" where StudentId=@StudentId and actiontime=@actiontime");
            SqlParameter[] parameters = {
                    new SqlParameter("@StudentId", SqlDbType.NVarChar,20),
                    new SqlParameter("@actiontime", SqlDbType.DateTime),
                    new SqlParameter("@maketime", SqlDbType.NVarChar,10),
                    new SqlParameter("@hwSituation", SqlDbType.NVarChar,20),
                    new SqlParameter("@hwScore", SqlDbType.Int,4),
                    new SqlParameter("@count_answer", SqlDbType.Int,4),
                    new SqlParameter("@stuHour", SqlDbType.Char,4),
                    new SqlParameter("@stuMinute", SqlDbType.Char,4),
                    new SqlParameter("@stuSecond", SqlDbType.Char,4),
                    new SqlParameter("@logo", SqlDbType.Int,4)};
            parameters[0].Value = model.StudentId;
            parameters[1].Value = model.actiontime;
            parameters[2].Value = model.maketime;
            parameters[3].Value = model.hwSituation;
            parameters[4].Value = model.hwScore;
            parameters[5].Value = model.count_answer;
            parameters[6].Value = model.stuHour;
            parameters[7].Value = model.stuMinute;
            parameters[8].Value = model.stuSecond;
            parameters[9].Value = model.logo;
            int rows = m_sqlHelper.ExecuteNonQuery(strSql.ToString(), parameters);
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
        /// 更新做题标记
        /// </summary>
        public static bool Update_logo(StuExam.Model.Stuhomework model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Stuhomework set ");
            strSql.Append("hwSituation=@hwSituation,");
            strSql.Append("logo=@logo,");
            strSql.Append("hwScore=@hwScore ");
            strSql.Append(" where StudentId=@StudentId and actiontime=@actiontime");
            SqlParameter[] parameters = {
                    new SqlParameter("@StudentId", SqlDbType.NVarChar,20),
                    new SqlParameter("@actiontime", SqlDbType.DateTime),
                    new SqlParameter("@hwSituation", SqlDbType.NVarChar,20),
                    new SqlParameter("@logo", SqlDbType.Int,4),
                    new SqlParameter("@hwScore", SqlDbType.Int,4)};
            parameters[0].Value = model.StudentId;
            parameters[1].Value = model.actiontime;
            parameters[2].Value = model.hwSituation;
            parameters[3].Value = model.logo;
            parameters[4].Value = model.hwScore;
            int rows = m_sqlHelper.ExecuteNonQuery(strSql.ToString(), parameters);
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
        /// 更新做题时间
        /// </summary>
        public static bool Update_time(StuExam.Model.Stuhomework model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Stuhomework set ");
            strSql.Append("actiontime=@actiontime,");
            strSql.Append("stuHour=@stuHour,");
            strSql.Append("stuMinute=@stuMinute,");
            strSql.Append("stuSecond=@stuSecond ");
            strSql.Append(" where StudentId=@StudentId and actiontime=@actiontime");
            SqlParameter[] parameters = {
                    new SqlParameter("@StudentId", SqlDbType.NVarChar,20),
                    new SqlParameter("@actiontime", SqlDbType.DateTime),
                    new SqlParameter("@stuHour", SqlDbType.Char,4),
                    new SqlParameter("@stuMinute", SqlDbType.Char,4),
                    new SqlParameter("@stuSecond", SqlDbType.Char,4),};
            parameters[0].Value = model.StudentId;
            parameters[1].Value = model.actiontime;
            parameters[2].Value = model.stuHour;
            parameters[3].Value = model.stuMinute;
            parameters[4].Value = model.stuSecond;
            int rows = m_sqlHelper.ExecuteNonQuery(strSql.ToString(), parameters);
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
        /// 获得前几行数据
        /// </summary>
        public static DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append("maketime,hwSituation,hwScore,count_answer,actiontime,stuHour,stuMinute,stuSecond,logo ");
            strSql.Append("FROM Stuhomework ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append("order by actiontime asc");
            return m_sqlHelper.ExecuteDataTable(strSql.ToString());
        }
        /// <summary>
        /// 获得前几行数据,按分数高低排序
        /// </summary>
        public static DataTable GetList_byscore(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append("maketime,hwSituation,hwScore,count_answer,actiontime,stuHour,stuMinute,stuSecond,logo ");
            strSql.Append("FROM Stuhomework ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append("order by hwScore asc");
            return m_sqlHelper.ExecuteDataTable(strSql.ToString());
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(StuExam.Model.Stuhomework model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Stuhomework(");
            strSql.Append("StudentId,actiontime,maketime,hwSituation,hwScore,count_answer,stuHour,stuMinute,stuSecond,logo)");
            strSql.Append(" values (");
            strSql.Append("@StudentId,@actiontime,@maketime,@hwSituation,@hwScore,@count_answer,@stuHour,@stuMinute,@stuSecond,@logo)");
            SqlParameter[] parameters = {
                    new SqlParameter("@StudentId", SqlDbType.NVarChar,20),
                    new SqlParameter("@actiontime", SqlDbType.DateTime),
                    new SqlParameter("@maketime", SqlDbType.NVarChar,10),
                    new SqlParameter("@hwSituation", SqlDbType.NVarChar,20),
                    new SqlParameter("@hwScore", SqlDbType.Int,4),
                    new SqlParameter("@count_answer", SqlDbType.Int,4),
                    new SqlParameter("@stuHour", SqlDbType.Char,4),
                    new SqlParameter("@stuMinute", SqlDbType.Char,4),
                    new SqlParameter("@stuSecond", SqlDbType.Char,4),
                    new SqlParameter("@logo", SqlDbType.Int,4)};
            parameters[0].Value = model.StudentId;
            parameters[1].Value = model.actiontime;
            parameters[2].Value = model.maketime;
            parameters[3].Value = model.hwSituation;
            parameters[4].Value = model.hwScore;
            parameters[5].Value = model.count_answer;
            parameters[6].Value = model.stuHour;
            parameters[7].Value = model.stuMinute;
            parameters[8].Value = model.stuSecond;
            parameters[9].Value = model.logo;

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
    }

    /// <summary>
    /// 数据访问类:Exam
    /// </summary>
    public partial class Exam
    {
        //数据库执行对象
        private static SqlHelper m_sqlHelper = new SqlHelper();
        public Exam()
        { }
        #region  BasicMethod
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(string Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Exam ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.NVarChar,15)
            };
            parameters[0].Value = Id;

            int rows = m_sqlHelper.ExecuteNonQuery(strSql.ToString(), parameters);
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
        /// 增加一条数据
        /// </summary>
        public static int Add(StuExam.Model.Exam model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Exam(");
            strSql.Append("Id,Describe,Professional_class,chapter_strat,chapter_stop,actiontime,stoptime,info)");
            strSql.Append(" values (");
            strSql.Append("@Id,@Describe,@Professional_class,@chapter_strat,@chapter_stop,@actiontime,@stoptime,@info)");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.NVarChar,15),
                    new SqlParameter("@Describe", SqlDbType.NVarChar,50),
                    new SqlParameter("@Professional_class", SqlDbType.NVarChar,20),
                    new SqlParameter("@chapter_strat", SqlDbType.Int,4),
                    new SqlParameter("@chapter_stop", SqlDbType.Int,4),
                    new SqlParameter("@actiontime", SqlDbType.DateTime),
                    new SqlParameter("@stoptime", SqlDbType.DateTime),
                    new SqlParameter("@info", SqlDbType.NVarChar, 1000)};
            parameters[0].Value = model.Id;
            parameters[1].Value = model.Describe;
            parameters[2].Value = model.Professional_class;
            parameters[3].Value = model.chapter_strat;
            parameters[4].Value = model.chapter_stop;
            parameters[5].Value = model.actiontime;
            parameters[6].Value = model.stoptime;
            parameters[7].Value = model.info;

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
        /// 得到一个对象实体
        /// </summary>
        public StuExam.Model.Exam GetModel(string Class)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Class,chapter,section,ranks,stoptime,actiontime,maketime,Choice,Filling,Reading,Design from Exam ");
            strSql.Append(" where Class=@Class ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Class", SqlDbType.NVarChar,20),};
            parameters[0].Value = Class;


            StuExam.Model.Exam model = new StuExam.Model.Exam();
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
        public StuExam.Model.Exam DataRowToModel(DataRow row)
        {
            StuExam.Model.Exam model = new StuExam.Model.Exam();
            if (row != null)
            {
                if (row["Professional_class"] != null)
                {
                    model.Professional_class = row["Professional_class"].ToString();
                }
                if (row["chapter_strat"] != null && row["chapter_strat"].ToString() != "")
                {
                    model.chapter_strat = int.Parse(row["chapter_strat"].ToString());
                }
                if (row["section_start"] != null && row["section_start"].ToString() != "")
                {
                    model.section_start = int.Parse(row["section_start"].ToString());
                }
                if (row["chapter_stop"] != null && row["chapter_stop"].ToString() != "")
                {
                    model.chapter_stop = int.Parse(row["chapter_stop"].ToString());
                }
                if (row["section_stop"] != null && row["section_stop"].ToString() != "")
                {
                    model.section_stop = int.Parse(row["section_stop"].ToString());
                }
                if (row["ranks"] != null)
                {
                    model.ranks = row["ranks"].ToString();
                }
                if (row["actiontime"] != null && row["actiontime"].ToString() != "")
                {
                    model.actiontime = DateTime.Parse(row["actiontime"].ToString());
                }
                if (row["stoptime"] != null && row["stoptime"].ToString() != "")
                {
                    model.stoptime = DateTime.Parse(row["stoptime"].ToString());
                }
            }
            return model;
        }


        /// <summary>
        /// 获得指定字段的数据
        /// </summary>
        public static DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append("Id,Describe,chapter_strat,chapter_stop,ranks,actiontime,stoptime,info");
            strSql.Append(" FROM Exam");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append("order by actiontime asc");
            return m_sqlHelper.ExecuteDataTable(strSql.ToString());
        }
        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }

    /// <summary>
    /// 数据访问类:Filling
    /// </summary>
    public partial class Filling
    {
        //数据库执行对象
        private static SqlHelper m_sqlHelper = new SqlHelper();
        public Filling()
        { }
        #region  BasicMethod
        /// <summary>
        /// 更新学生答题(填空题)
        /// </summary>
        public static bool UpdateList(object[,] Paper_Filling, string ExamId, string StudentId, int Num)
        {
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            strSql1.Append("delete from Exam_Filling where ");
            strSql1.Append("ExamId =" + ExamId);
            strSql1.Append(" and StudentId =" + StudentId);

            strSql2.Append("insert into Exam_Filling (ExamId,StudentId,Number,Subject,Answer1,Answer2,Answer3,StudentAnswer1,StudentAnswer2,StudentAnswer3,Score1,Score2,Score3,Value) values ");
            for (int i = 0; i < Num; i++)
            {
                strSql2.Append("(");
                strSql2.Append("'" + ExamId + "',");
                strSql2.Append("'" + StudentId + "',");
                strSql2.Append("'" + Paper_Filling[i, 0].ToString() + "',");
                strSql2.Append("'" + Paper_Filling[i, 1].ToString().Replace("'", "''") + "',");
                strSql2.Append("'" + Paper_Filling[i, 2].ToString().Replace("'", "''") + "',");
                strSql2.Append("'" + Paper_Filling[i, 3].ToString().Replace("'", "''") + "',");
                strSql2.Append("'" + Paper_Filling[i, 4].ToString().Replace("'", "''") + "',");
                strSql2.Append("'" + Paper_Filling[i, 5].ToString().Replace("'", "''") + "',");
                strSql2.Append("'" + Paper_Filling[i, 6].ToString().Replace("'", "''") + "',");
                strSql2.Append("'" + Paper_Filling[i, 7].ToString().Replace("'", "''") + "',");
                strSql2.Append("'" + Paper_Filling[i, 8].ToString() + "',");
                strSql2.Append("'" + Paper_Filling[i, 9].ToString() + "',");
                strSql2.Append("'" + Paper_Filling[i, 10].ToString() + "',");
                strSql2.Append("'" + Paper_Filling[i, 11].ToString() + "'");
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
        /// 增加考卷（填空题）
        /// </summary>
        public static bool AddList(DataTable dt)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Filling_Paper (Id,Number,Subject,Answer1,Answer2,Answer3,Value) values ");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strSql.Append("(");
                strSql.Append("'" + dt.Rows[i][0] + "',");
                strSql.Append("'" + dt.Rows[i][1] + "',");
                strSql.Append("'" + dt.Rows[i][2].ToString().Replace("'", "''") + "',");
                strSql.Append("'" + dt.Rows[i][3].ToString().Replace("'", "''") + "',");
                strSql.Append("'" + dt.Rows[i][4].ToString().Replace("'", "''") + "',");
                strSql.Append("'" + dt.Rows[i][5].ToString().Replace("'", "''") + "',");
                strSql.Append("'" + dt.Rows[i][6] + "'");
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
        /// 是否存在该记录
        /// </summary>
        public static int Exists(int Number)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Filling");
            strSql.Append(" where Number=@Number");
            SqlParameter[] parameters = {
                    new SqlParameter("@Number", SqlDbType.Int,4)
            };
            parameters[0].Value = Number;

            return (int)m_sqlHelper.ExecuteScalar(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(StuExam.Model.Filling model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Filling(");
            strSql.Append("Subject,Answer1,Answer2,Answer3,Chapter)");
            strSql.Append(" values (");
            strSql.Append("@Subject,@Answer1,@Answer2,@Answer3,@Chapter)");
            SqlParameter[] parameters = {
                    new SqlParameter("@Subject", SqlDbType.NVarChar),
                    new SqlParameter("@Answer1", SqlDbType.NVarChar,150),
                    new SqlParameter("@Answer2", SqlDbType.NVarChar,150),
                    new SqlParameter("@Answer3", SqlDbType.NVarChar,150),
                    new SqlParameter("@Chapter", SqlDbType.Int,4)};
            parameters[0].Value = model.Subject;
            parameters[1].Value = model.Answer1;
            parameters[2].Value = model.Answer2;
            parameters[3].Value = model.Answer3;
            parameters[4].Value = model.Chapter;

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
        /// 更新一条数据
        /// </summary>
        public static bool Update(StuExam.Model.Filling model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Filling set ");
            strSql.Append("Subject='" + model.Subject + "',");
            strSql.Append("Answer1='" + model.Answer1 + "',");
            strSql.Append("Answer2='" + model.Answer2 + "',");
            strSql.Append("Answer3='" + model.Answer3 + "',");
            strSql.Append("Chapter='" + model.Chapter + "'");
            strSql.Append(" where Number='" + model.Number + "'");

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
        /// 删除一条数据
        /// </summary>
        public static bool Delete(int Number)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Filling ");
            strSql.Append(" where Number=@Number");
            SqlParameter[] parameters = {
                    new SqlParameter("@Number", SqlDbType.Int,4)
            };
            parameters[0].Value = Number;

            int rows = m_sqlHelper.ExecuteNonQuery(strSql.ToString(), parameters);
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
        /// 批量删除数据
        /// </summary>
        public static bool DeleteList(string Numberlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Filling ");
            strSql.Append(" where Number in (" + Numberlist + ")  ");
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
        /// 得到一个对象实体
        /// </summary>
        public static StuExam.Model.Filling GetModel(int Number)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Number,Subject,Answer1,Answer2,Answer3,Chapter,Section from Filling ");
            strSql.Append(" where Number=@Number");
            SqlParameter[] parameters = {
                    new SqlParameter("@Number", SqlDbType.Int,4)
            };
            parameters[0].Value = Number;

            StuExam.Model.Filling model = new StuExam.Model.Filling();
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
        public static StuExam.Model.Filling DataRowToModel(DataRow row)
        {
            StuExam.Model.Filling model = new StuExam.Model.Filling();
            if (row != null)
            {
                if (row["Number"] != null && row["Number"].ToString() != "")
                {
                    model.Number = int.Parse(row["Number"].ToString());
                }
                if (row["Subject"] != null)
                {
                    model.Subject = (string)row["Subject"];
                }
                if (row["Answer1"] != null)
                {
                    model.Answer1 = row["Answer1"].ToString();
                }
                if (row["Answer2"] != null)
                {
                    model.Answer2 = row["Answer2"].ToString();
                }
                if (row["Answer3"] != null)
                {
                    model.Answer3 = row["Answer3"].ToString();
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
        ///  获得学生考试选择题答案存取信息
        /// </summary>
        public static DataTable ExamGetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select NewID() as rdId,Number,Subject,Answer1,Answer2,Answer3,StudentAnswer1,StudentAnswer2,StudentAnswer3,Value ");
            strSql.Append(" FROM Exam_Filling ");
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
            strSql.Append("select NewID() as rdId,Number,Subject,Answer1,Answer2,Answer3,Value ");
            strSql.Append(" FROM Filling_Paper ");
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
            strSql.Append("select Number,Subject,Answer1,Answer2,Answer3,Chapter,Section ");
            strSql.Append(" FROM Filling ");
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
            strSql.Append(" NewID() as rdId,Subject,Answer1,Answer2,Answer3,Number");
            strSql.Append(" FROM Filling ");
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
            strSql.Append("select Subject,Answer1,Answer2,Answer3,Chapter,Section ");
            strSql.Append(" FROM Filling ");
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
            strSql.Append("select count(Number) FROM Filling ");
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
            strSql.Append(")AS Row, T.*  from Filling T ");
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


    /// <summary>
    /// 数据访问类:chapter_Scope
    /// </summary>
    public partial class chapter_Scope
    {
        //数据库执行对象
        private static SqlHelper m_sqlHelper = new SqlHelper();
        public chapter_Scope() { }
        /// <summary>
        /// 获得指定大章的小节数量
        /// </summary>
        public static DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(" sections_num ");
            strSql.Append(" FROM chapter_Scope ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return m_sqlHelper.ExecuteDataTable(strSql.ToString());
        }
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public static int GetRecordCount()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) FROM chapter_Scope ");
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

    }


    public partial class Exam_Student
    {
        //数据库执行对象
        private static SqlHelper m_sqlHelper = new SqlHelper();

        /// <summary>
        /// 更新10列数据
        /// </summary>
        public static bool Update(StuExam.Model.Exam_Student model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Exam_Student set ");
            strSql.Append("StartTime=@StartTime,");
            strSql.Append("RemainTime=@RemainTime,");
            strSql.Append("State=@State,");
            strSql.Append("Score=@Score");
            strSql.Append(" where StudentId=@StudentId and Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@StartTime", SqlDbType.DateTime),
                    new SqlParameter("@RemainTime", SqlDbType.Int,4),
                    new SqlParameter("@State", SqlDbType.NVarChar,20),
                    new SqlParameter("@Score", SqlDbType.Int,4),
                    new SqlParameter("@StudentId", SqlDbType.NVarChar,15),
                    new SqlParameter("@Id", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.StartTime;
            parameters[1].Value = model.RemainTime;
            parameters[2].Value = model.State;
            parameters[3].Value = model.Score;
            parameters[4].Value = model.Studentid;
            parameters[5].Value = model.Id;
            int rows = m_sqlHelper.ExecuteNonQuery(strSql.ToString(), parameters);
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
        /// 获得数据
        /// </summary>
        public static DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append("Id,StudentId,ExamTime,StartTime,RemainTime,State,Score ");
            strSql.Append("FROM Exam_Student ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append("order by Id asc");
            return m_sqlHelper.ExecuteDataTable(strSql.ToString());
        }
        /// <summary>
        /// 获得前几行数据,按分数高低排序
        /// </summary>
        public static DataTable GetList_byscore(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append("Id,StudentId,ExamTime,StartTime,RemainTime,State,Score ");
            strSql.Append("FROM Exam_Student ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append("order by Score asc");
            return m_sqlHelper.ExecuteDataTable(strSql.ToString());
        }
        /// <summary>
        /// 增加多条数据
        /// </summary>
        public static bool AddList(DataTable dt)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Exam_Student (ID,StudentId,ExamTime,StartTime,RemainTime,State,Score) values ");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strSql.Append("(");
                strSql.Append("'" + dt.Rows[i][0] + "',");
                strSql.Append("'" + dt.Rows[i][1] + "',");
                strSql.Append("'" + dt.Rows[i][2] + "',");
                strSql.Append("'" + dt.Rows[i][3] + "',");
                strSql.Append("'" + dt.Rows[i][4] + "',");
                strSql.Append("'" + dt.Rows[i][5] + "',");
                strSql.Append("'" + dt.Rows[i][6] + "'");
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
        /// 增加一条数据
        /// </summary>
        public static int Add(StuExam.Model.Exam_Student model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Exam_Student(");
            strSql.Append("ExamTime,StartTime,RemainTime,State,Score,StudentId,Id)");
            strSql.Append(" values (");
            strSql.Append("@ExamTime,@StartTime,@RemainTime,@State,@Score,@StudentId,@Id)");
            SqlParameter[] parameters = {
                    new SqlParameter("@ExamTime", SqlDbType.Int,4),
                    new SqlParameter("@StartTime", SqlDbType.DateTime),
                    new SqlParameter("@RemainTime", SqlDbType.Int,4),
                    new SqlParameter("@State", SqlDbType.NVarChar,20),
                    new SqlParameter("@Score", SqlDbType.Int,4),
                    new SqlParameter("@StudentId", SqlDbType.NVarChar,15),
                    new SqlParameter("@Id", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.ExamTime;
            parameters[1].Value = model.StartTime;
            parameters[2].Value = model.RemainTime;
            parameters[3].Value = model.State;
            parameters[4].Value = model.Score;
            parameters[5].Value = model.Studentid;
            parameters[6].Value = model.Id;

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
    }
}

