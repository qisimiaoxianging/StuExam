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
    /// Student:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Student
    {
        public Student()
        { }
        #region Model
        private string _studentid;
        private string _name;
        private string _profession;
        private string _class;
        private string _note;
        private string _password;
        /// <summary>
        /// 
        /// </summary>
        public string StudentId
        {
            set { _studentid = value; }
            get { return _studentid; }
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
        public string Profession
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
        public string Note
        {
            set { _note = value; }
            get { return _note; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Password
        {
            set { _password = value; }
            get { return _password; }
        }
        #endregion Model

    }


    /// <summary>
    /// Filling:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Filling
    {
        public Filling()
        { }
        #region Model
        private long _number;
        private string _subject;
        private string _answer1;
        private string _answer2;
        private string _answer3;
        private int _chapter;
        private int _section;
        private string _subject1;
        /// <summary>
        /// 编号
        /// </summary>
        public long Number
        {
            set { _number = value; }
            get { return _number; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Subject
        {
            set { _subject = value; }
            get { return _subject; }
        }
        /// <summary>
        /// 答案1,每道程序填空题有且只有三个填空
        /// </summary>
        public string Answer1
        {
            set { _answer1 = value; }
            get { return _answer1; }
        }
        /// <summary>
        /// 答案
        /// </summary>
        public string Answer2
        {
            set { _answer2 = value; }
            get { return _answer2; }
        }
        /// <summary>
        /// 答案
        /// </summary>
        public string Answer3
        {
            set { _answer3 = value; }
            get { return _answer3; }
        }
        /// <summary>
        /// 章
        /// </summary>
        public int Chapter
        {
            set { _chapter = value; }
            get { return _chapter; }
        }
        /// <summary>
        /// 节
        /// </summary>
        public int Section
        {
            set { _section = value; }
            get { return _section; }
        }
        /// <summary>
        /// 内容
        /// </summary>
        public string Subject1
        {
            set { _subject1 = value; }
            get { return _subject1; }
        }
        #endregion Model

    }
    /// <summary>
    /// Reading:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>

    /// <summary>
    /// Choice:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Choice
    {
        public Choice()
        { }
        #region Model
        private long _number;
        private string _subject;
        private string _answer;
        private int _chapter;
        private int _section;
        private string _subject1;
        /// <summary>
        /// 编号
        /// </summary>
        public long Number
        {
            set { _number = value; }
            get { return _number; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Subject
        {
            set { _subject = value; }
            get { return _subject; }
        }
        /// <summary>
        /// 答案
        /// </summary>
        public string Answer
        {
            set { _answer = value; }
            get { return _answer; }
        }
        /// <summary>
        /// 章
        /// </summary>
        public int Chapter
        {
            set { _chapter = value; }
            get { return _chapter; }
        }
        /// <summary>
        /// 节
        /// </summary>
        public int Section
        {
            set { _section = value; }
            get { return _section; }
        }
        /// <summary>
        /// 内容
        /// </summary>
        public string Subject1
        {
            set { _subject1 = value; }
            get { return _subject1; }
        }
        #endregion Model

    }
}

