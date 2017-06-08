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
