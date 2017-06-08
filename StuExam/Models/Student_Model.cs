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


    /// <summary>
    /// Exam:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Exam
    {
        public Exam()
        { }
        #region Model
        private string _id;
        private string _describe;
        private string _professional_class;
        private int? _chapter_strat;
        private int? _section_start;
        private int? _chapter_stop;
        private int? _section_stop;
        private string _ranks;
        private DateTime? _actiontime;
        private DateTime? _stoptime;
        private string _info;
        /// <summary>
        /// 
        /// </summary>
        public string Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Describe
        {
            set { _describe = value; }
            get { return _describe; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Professional_class
        {
            set { _professional_class = value; }
            get { return _professional_class; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? chapter_strat
        {
            set { _chapter_strat = value; }
            get { return _chapter_strat; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? section_start
        {
            set { _section_start = value; }
            get { return _section_start; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? chapter_stop
        {
            set { _chapter_stop = value; }
            get { return _chapter_stop; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? section_stop
        {
            set { _section_stop = value; }
            get { return _section_stop; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ranks
        {
            set { _ranks = value; }
            get { return _ranks; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? actiontime
        {
            set { _actiontime = value; }
            get { return _actiontime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? stoptime
        {
            set { _stoptime = value; }
            get { return _stoptime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string info
        {
            set { _info = value; }
            get { return _info; }
        }
        #endregion Model

    }

    /// <summary>
    /// Exam_Student:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public partial class Exam_Student
    {
        public Exam_Student()
        { }
        #region Model
        private string _id;
        private string _studentid;
        private DateTime? _StartTime;
        private string _state;
        private int? _ExamTime;
        private int? _RemainTime;
        private int? _score;

        public string Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Studentid
        {
            get
            {
                return _studentid;
            }

            set
            {
                _studentid = value;
            }
        }

        public DateTime? StartTime
        {
            get
            {
                return _StartTime;
            }

            set
            {
                _StartTime = value;
            }
        }

        public string State
        {
            get
            {
                return _state;
            }

            set
            {
                _state = value;
            }
        }

        public int? ExamTime
        {
            get
            {
                return _ExamTime;
            }

            set
            {
                _ExamTime = value;
            }
        }

        public int? RemainTime
        {
            get
            {
                return _RemainTime;
            }

            set
            {
                _RemainTime = value;
            }
        }

        public int? Score
        {
            get
            {
                return _score;
            }

            set
            {
                _score = value;
            }
        }
        #endregion
    }


    /// <summary>
    /// Stuhomework:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Stuhomework
    {
        public Stuhomework()
        { }
        #region Model
        private string _studentid;
        private DateTime? _actiontime;
        private string _maketime;
        private string _hwsituation;
        private int? _hwscore;
        private int? _count_answer;
        private string _stuhour;
        private string _stuminute;
        private string _stusecond;
        private int? _logo;
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
        public DateTime? actiontime
        {
            set { _actiontime = value; }
            get { return _actiontime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string maketime
        {
            set { _maketime = value; }
            get { return _maketime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string hwSituation
        {
            set { _hwsituation = value; }
            get { return _hwsituation; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? hwScore
        {
            set { _hwscore = value; }
            get { return _hwscore; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? count_answer
        {
            set { _count_answer = value; }
            get { return _count_answer; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string stuHour
        {
            set { _stuhour = value; }
            get { return _stuhour; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string stuMinute
        {
            set { _stuminute = value; }
            get { return _stuminute; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string stuSecond
        {
            set { _stusecond = value; }
            get { return _stusecond; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? logo
        {
            set { _logo = value; }
            get { return _logo; }
        }
        #endregion Model

    }
}

