using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Linq;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Microsoft.Win32;
using System.Threading.Tasks;

namespace StuExam.Model
{
    /// <summary>
    /// Basic_Academy:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Basic_Academy
    {
        public Basic_Academy()
        { }
        #region Model
        private long _id;
        private string _academyno;
        private string _academyname;
        private string _president;
        private string _obligate1;
        private string _obligate2;
        private string _obligate3;
        private string _obligate4;
        private string _obligate5;
        /// <summary>
        /// 
        /// </summary>
        public long Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AcademyNo
        {
            set { _academyno = value; }
            get { return _academyno; }
        }
        /// <summary>
        /// 学院
        /// </summary>
        public string AcademyName
        {
            set { _academyname = value; }
            get { return _academyname; }
        }
        /// <summary>
        /// 院长
        /// </summary>
        public string President
        {
            set { _president = value; }
            get { return _president; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Obligate1
        {
            set { _obligate1 = value; }
            get { return _obligate1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Obligate2
        {
            set { _obligate2 = value; }
            get { return _obligate2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Obligate3
        {
            set { _obligate3 = value; }
            get { return _obligate3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Obligate4
        {
            set { _obligate4 = value; }
            get { return _obligate4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Obligate5
        {
            set { _obligate5 = value; }
            get { return _obligate5; }
        }
        #endregion Model

    }
    /// <summary>
    /// Teacher_Coure:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Teacher_Coure
    {
        public Teacher_Coure()
        { }
        #region Model
        private string _teacherid;
        private string _academic_year;
        private string _school_term;
        private string _college;
        private string _profession;
        private string _class;
        private string _course;
        /// <summary>
        /// 
        /// </summary>
        public string teacherID
        {
            set { _teacherid = value; }
            get { return _teacherid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string academic_year
        {
            set { _academic_year = value; }
            get { return _academic_year; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string school_term
        {
            set { _school_term = value; }
            get { return _school_term; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string college
        {
            set { _college = value; }
            get { return _college; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string profession
        {
            set { _profession = value; }
            get { return _profession; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Class
        {
            set { _class = value; }
            get { return _class; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Course
        {
            set { _course = value; }
            get { return _course; }
        }
        #endregion Model

    }
    /// <summary>
    /// Basic_Major:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Basic_Major
    {
        public Basic_Major()
        { }
        #region Model
        private long _id;
        private string _majorno;
        private string _majorname;
        private string _academyno;
        private string _academyname;
        private string _fastenno;
        private string _fastenname;
        private string _year;
        private int? _lensch = 4;
        private string _degree;
        private string _obligate1;
        private string _obligate2;
        private string _obligate3;
        private string _obligate4;
        private string _obligate5;
        /// <summary>
        /// 
        /// </summary>
        public long Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 专业编号
        /// </summary>
        public string MajorNo
        {
            set { _majorno = value; }
            get { return _majorno; }
        }
        /// <summary>
        /// 专业
        /// </summary>
        public string MajorName
        {
            set { _majorname = value; }
            get { return _majorname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AcademyNo
        {
            set { _academyno = value; }
            get { return _academyno; }
        }
        /// <summary>
        /// 学院
        /// </summary>
        public string AcademyName
        {
            set { _academyname = value; }
            get { return _academyname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FastenNo
        {
            set { _fastenno = value; }
            get { return _fastenno; }
        }
        /// <summary>
        /// 系
        /// </summary>
        public string FastenName
        {
            set { _fastenname = value; }
            get { return _fastenname; }
        }
        /// <summary>
        /// 开设时间
        /// </summary>
        public string Year
        {
            set { _year = value; }
            get { return _year; }
        }
        /// <summary>
        /// 学制
        /// </summary>
        public int? LenSch
        {
            set { _lensch = value; }
            get { return _lensch; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Degree
        {
            set { _degree = value; }
            get { return _degree; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Obligate1
        {
            set { _obligate1 = value; }
            get { return _obligate1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Obligate2
        {
            set { _obligate2 = value; }
            get { return _obligate2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Obligate3
        {
            set { _obligate3 = value; }
            get { return _obligate3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Obligate4
        {
            set { _obligate4 = value; }
            get { return _obligate4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Obligate5
        {
            set { _obligate5 = value; }
            get { return _obligate5; }
        }
        #endregion Model

    }
    /// <summary>
    /// Basic_Student:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Basic_Student
    {
        public Basic_Student()
        { }
        #region Model
        private long _id;
        private string _studentid;
        private string _secretcode;
        private string _passsalt;
        private string _studentname;
        private string _sex;
        private string _majorno;
        private string _profession;
        private string _classno;
        private string _classes;
        private string _post;
        private string _tel;
        /// <summary>
        /// 
        /// </summary>
        public long Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 学号
        /// </summary>
        public string StudentId
        {
            set { _studentid = value; }
            get { return _studentid; }
        }
        /// <summary>
        /// 密码
        /// </summary>
        public string SecretCode
        {
            set { _secretcode = value; }
            get { return _secretcode; }
        }
        /// <summary>
        /// 密码（加密后）
        /// </summary>
        public string PassSalt
        {
            set { _passsalt = value; }
            get { return _passsalt; }
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public string StudentName
        {
            set { _studentname = value; }
            get { return _studentname; }
        }
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 专业编号
        /// </summary>
        public string MajorNo
        {
            set { _majorno = value; }
            get { return _majorno; }
        }
        /// <summary>
        /// 专业
        /// </summary>
        public string Profession
        {
            set { _profession = value; }
            get { return _profession; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ClassNo
        {
            set { _classno = value; }
            get { return _classno; }
        }
        /// <summary>
        /// 班级
        /// </summary>
        public string Classes
        {
            set { _classes = value; }
            get { return _classes; }
        }
        /// <summary>
        /// 职务
        /// </summary>
        public string Post
        {
            set { _post = value; }
            get { return _post; }
        }
        /// <summary>
        /// 电话
        /// </summary>
        public string Tel
        {
            set { _tel = value; }
            get { return _tel; }
        }
        #endregion Model

    }
    /// <summary>
    /// Public_Table:实体类(首页的新闻、文章类)
    /// </summary>
    [Serializable]
    public partial class Public_Table
    {
        public Public_Table()
        { }
        #region Model
        private long _id;
        private string _kindno;
        private string _kind;
        private string _title;
        private string _bulletin;
        private string _responsible;
        private string _school;
        private bool _isannex = false;
        private bool _isvideo;
        private bool _issc;
        private DateTime? _insertdate = DateTime.Now;
        private string _insertname;
        private DateTime? _updatedate;
        private string _updatename;
        private int _types;
        /// <summary>
        /// 
        /// </summary>
        public long Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KindNo
        {
            set { _kindno = value; }
            get { return _kindno; }
        }
        /// <summary>
        /// 所属类型
        /// </summary>
        public string Kind
        {
            set { _kind = value; }
            get { return _kind; }
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 公告内容
        /// </summary>
        public string Bulletin
        {
            set { _bulletin = value; }
            get { return _bulletin; }
        }
        /// <summary>
        /// 负责人
        /// </summary>
        public string Responsible
        {
            set { _responsible = value; }
            get { return _responsible; }
        }
        /// <summary>
        /// 学校
        /// </summary>
        public string School
        {
            set { _school = value; }
            get { return _school; }
        }
        /// <summary>
        /// 是否有附件
        /// </summary>
        public bool IsAnnex
        {
            set { _isannex = value; }
            get { return _isannex; }
        }
        /// <summary>
        /// 是否有视频
        /// </summary>
        public bool IsVideo
        {
            set { _isvideo = value; }
            get { return _isvideo; }
        }
        /// <summary>
        /// 是否已生成
        /// </summary>
        public bool IsSc
        {
            set { _issc = value; }
            get { return _issc; }
        }
        /// <summary>
        /// 录入时间
        /// </summary>
        public DateTime? InsertDate
        {
            set { _insertdate = value; }
            get { return _insertdate; }
        }
        /// <summary>
        /// 录入人帐号
        /// </summary>
        public string InsertName
        {
            set { _insertname = value; }
            get { return _insertname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? UpdateDate
        {
            set { _updatedate = value; }
            get { return _updatedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UpdateName
        {
            set { _updatename = value; }
            get { return _updatename; }
        }
        /// <summary>
        /// 0通知公知  1课程介绍  2教学资源
        /// </summary>
        public int Types
        {
            set { _types = value; }
            get { return _types; }
        }
        #endregion Model

    }
    /// <summary>
    /// Teacher:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Teacher
    {
        public Teacher()
        { }
        #region Model
        private string _jobnumber;
        private string _password;
        private string _name;
        private byte[] _iamage;
        /// <summary>
        /// 
        /// </summary>
        public string JobNumber
        {
            set { _jobnumber = value; }
            get { return _jobnumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Password
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public byte[] Iamage
        {
            set { _iamage = value; }
            get { return _iamage; }
        }
        #endregion Model

    }
}
