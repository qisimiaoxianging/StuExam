using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StuExam
{
    public class Exam
    {
        //23道单项选择题，第0列为编号，第一列存储题目，第二列标准答案，第三列学生答案，第四列得分，第五列分值
        public object[,] Paper_Choice = new object[100, 6];
        //4道程序填空题，每道三个空格，第0列为编号，第一列题目，第二至第四列标准答案，第五至第七列学生答案，第八至第十列得分，第11列分值
        public object[,] Paper_Filling = new object[20, 12];
        //5道程序阅读题，结构与选择题类似
        public object[,] Paper_Reading = new object[20, 5];
        //3道程序设计题，结构与选择题类似
        public object[,] Paper_Design = new object[20, 5];
        public Exam() { }//无参构造函数


        //程序设计题判分
        struct Node  //向量节点
        {
            public string KeyWord;    //关键字
            public double StdNum;     //标准答案节点的值
            public double Num;        //学生答案节点的值
        }
        //统计一个字符串出现某个子串的次数,此函数会删除原字符串中的子串
        public static int SubStringCount(ref string str, string substr)//第一个参数是标准答案或者学生答案，第二个参数是关键字
        {
            int count = 0;
            if (substr == "stdio.h" || substr == "math.h" || substr == "stdlib.h")//include的部分
            {
                string Tsubstr;
                Tsubstr = "\"" + substr + "\""; //判断带引号的include
                if (str.Contains(Tsubstr))//判断指定关键字是否出现在标准答案或者学生答案中
                {
                    string strReplaced = str.Replace(Tsubstr, "");
                    count = count + (str.Length - strReplaced.Length) / Tsubstr.Length;
                    str = strReplaced;
                }
                Tsubstr = "<" + substr + ">";
                if (str.Contains(Tsubstr))  //判断带尖括号的include
                {
                    string strReplaced = str.Replace(Tsubstr, "");
                    count = count + (str.Length - strReplaced.Length) / Tsubstr.Length;
                    str = strReplaced;
                }
            }
            else//代码主体部分
            {
                if (str.Contains(substr))
                {
                    string strReplaced = str.Replace(substr, "");
                    count = count + (str.Length - strReplaced.Length) / substr.Length;
                    str = strReplaced;
                }
            }
            return count;
        }
        //统计变量的个数
        public static int SubBLCount(string str, string substr)//第一个变量是标准答案或者学生答案，第二个变量是关键字
        {
            int count = 0;
            int start, end;
            string Blstr;
            while (str.Contains(substr))
            {
                start = str.IndexOf(substr);
                end = str.IndexOf(";", start);//从变量第一次出现的位置搜索分号第一次出现的位置
                if (end == -1)//找不到分号
                    end = str.Length - 1;
                Blstr = str.Substring(start, end - start + 1);//截取变量到分号结束部分的内容
                str = str.Replace(Blstr, "");//去掉变量到分号结束部分的内容
                count = count + SubStringCount(ref Blstr, ",") + 1;
            }
            return count;
        }
        //程序设计题，满分5分   ----C语言
        public static int MarkDesign(string StdAnswer, string Answer)
        {
            int fs;//分数
            //32个关键字
            //42个运算符加分号，分号用于测量程序规模
            string[] KeyWord = { "struct", "break",                        //去掉了int,float等关键字，因为后面回去统计相应变量个数
                                 "else", "long", "switch", "case", "enum",
                                 "register", "typedef", "extern", "return",
                                 "union", "const", "unsigned",
                                 "continue", "for", "signed", "void", "default",
                                  "sizeof", " volatile", "if",   //这里去掉了“do”关键字，因为这个关键字随意性太大
                                 "while", "static",   //以上这些为关键字
                                 "stdio.h","math.h",
                                 "<<=",">>=","%d","%f","%c","%s",             //这里去掉了复合运算如“+=”等操作，因为这类操作随意性较大，同时“+”和“=”在后面也还会被检测，因此去掉影响不大
                                "<<",">>",">=","<=","==","!=","->","++","--","&&","||", //以上这些操作符由于不止一个字符，需要一边检测一边删除，否则会影响后面的检测
                                ">","<","-","[","(",".","*","&","!","~","/","\"","'","{",
                                "*","%","+","-","&","^","|","?","=",",",";"};
            List<Node> Vector = new List<Node>();  //答案向量，答案向量由四部分组成：1、关键字；2、运算符；3、程序规模；4、变量规模

            //先统计出标准答案的向量，再利用标准答案向量来统计学生答案向量。即标准答案向量中不存在的分量不做统计

            string tmpStdAnswer = StdAnswer;
            foreach (string str in KeyWord) //节点统计，由于涉及到双字符的操作符，为了不会与单字符混淆，算法采用统计一个删除一个的方法来处理
            {
                int number = SubStringCount(ref tmpStdAnswer, str);
                if (number != 0)//统计标准答案的关键字及其数量，并保存在答案向量中
                {
                    Node NodeNow = new Node();
                    NodeNow.KeyWord = str;
                    NodeNow.StdNum = number;
                    NodeNow.Num = 0;
                    Vector.Add(NodeNow);
                }
            }

            //根据标准答案向量统计出学生答案向量
            tmpStdAnswer = Answer;
            for (int i = 0; i < Vector.Count; i++)
            {
                int number = SubStringCount(ref tmpStdAnswer, Vector[i].KeyWord);
                if (number != 0)//学生答案中存在标准答案的关键字
                {
                    Node NodeNow = new Node();
                    NodeNow = Vector[i];
                    NodeNow.Num = number;
                    Vector[i] = NodeNow;
                }
            }

            //变量规模统计
            if (StdAnswer.Contains("int"))//确定指定的类型是否出现在变量中
            {
                Node NodeNow = new Node();
                NodeNow.KeyWord = "intN";
                NodeNow.StdNum = SubBLCount(StdAnswer, "int");
                NodeNow.Num = SubBLCount(Answer, "int");
                Vector.Add(NodeNow);
            }
            if (StdAnswer.Contains("float") || StdAnswer.Contains("double"))
            {
                Node NodeNow = new Node();
                NodeNow.KeyWord = "floatN";
                NodeNow.StdNum = SubBLCount(StdAnswer, "float") + SubBLCount(StdAnswer, "double");
                NodeNow.Num = SubBLCount(Answer, "float") + SubBLCount(Answer, "double");
                Vector.Add(NodeNow);
            }
            if (StdAnswer.Contains("char"))
            {
                Node NodeNow = new Node();
                NodeNow.KeyWord = "charN";
                NodeNow.StdNum = SubBLCount(StdAnswer, "char");
                NodeNow.Num = SubBLCount(Answer, "char");
                Vector.Add(NodeNow);
            }

            //归一化向量：新数据=原数据/和
            for (int i = 0; i < Vector.Count; i++)
            {
                double sum;
                Node NodeNow = new Node();
                NodeNow = Vector[i];
                sum = NodeNow.StdNum + NodeNow.Num;//标准答案加学生答案
                NodeNow.StdNum = NodeNow.StdNum / sum;//得到的是小数
                NodeNow.Num = NodeNow.Num / sum;
                Vector[i] = NodeNow;
            }

            //开始求向量余弦相似度。。。。。。。。。。。。。。。。。。。。。。。！！！！！！！！！！！！！！！！！！
            double sgmAB = 0, sgmStdNum = 0, sgmNum = 0, cos;
            for (int i = 0; i < Vector.Count; i++)
            {
                sgmAB = sgmAB + Vector[i].StdNum * Vector[i].Num;
                sgmStdNum = sgmStdNum + Vector[i].StdNum * Vector[i].StdNum;
                sgmNum = sgmNum + Vector[i].Num * Vector[i].Num;
            }
            if (sgmAB == 0)
                cos = 0;
            else
                cos = sgmAB / (Math.Sqrt(sgmStdNum) * Math.Sqrt(sgmNum));

            //调整比例
            if (cos < 0.3)
                cos = cos + ((int)(cos * 10) - 1) * 0.01;
            else if (cos < 0.7)
                cos = cos + ((int)(cos * 100) - 10) * 0.001;
            else
                cos = cos + ((int)(cos * 100) - 5) * 0.001;
            if (cos < 0)
                cos = 0;
            if (cos > 1)
                cos = 1;
            fs = (int)(cos * 5 + 0.5);
            return fs;
        }
    }
}