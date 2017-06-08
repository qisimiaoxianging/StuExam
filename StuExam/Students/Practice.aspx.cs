using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections;
using StuExam;
using System.IO;
using StuExam.Model;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Microsoft.Win32;
using System.Web.UI.HtmlControls;

namespace StuExam.Students
{
    public partial class Practice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //判断session是否可用
                if (Session["ExamId"] == null || Session["RemainTime"] == null)
                {
                    this.Page.RegisterStartupScript("ss", "<script>alert('初始化失败请重新开始!')</script>");
                    Timer1.Enabled = false;
                    return;
                }
                //插入答题开始时间
                StuExam.Model.Exam_Student student = new Exam_Student();
                student.Id = Convert.ToString(Session["ExamId"]);
                student.Studentid = Convert.ToString(Session["student_Number"]);
                Session["StartTime"] = DateTime.Now;
                student.StartTime = Convert.ToDateTime(Session["StartTime"]); ;
                student.State = "掉线";
                student.Score = 0;
                student.RemainTime = 120;
                if (!StuExam.DAL.Exam_Student.Update(student))
                {
                    this.Page.RegisterStartupScript("ss", "<script>alert('初始化失败请重新开始!')</script>");
                    return;
                }

                paper.Style["display"] = "none";//将未答完卷提示框隐藏
                overdue.Style["display"] = "none";//将session过期提示框隐藏
                //出题
                Init();
                if (Convert.ToInt32(Session["RemainTime"]) > 0)
                    Timer1.Enabled = true;
            }
        }

        //遍历所有的子结点,将图片切换
        private void GetAllNodeText(TreeNodeCollection tv)
        {
            //遍历所有子结点
            foreach (TreeNode node in tv)
            {
                node.ImageUrl = "~/images/item1.png";
                GetAllNodeText(node.ChildNodes);
            }
        }
        //设置全部的小题div隐藏
        public void NoneDivAll()
        {
            xiaoti1.Style["display"] = "none";
            xiaoti2.Style["display"] = "none";
            xiaoti3.Style["display"] = "none";
            xiaoti4.Style["display"] = "none";
            xiaoti5.Style["display"] = "none";
            xiaoti6.Style["display"] = "none";
            xiaoti7.Style["display"] = "none";
            xiaoti8.Style["display"] = "none";
            xiaoti9.Style["display"] = "none";
            xiaoti10.Style["display"] = "none";
            xiaoti11.Style["display"] = "none";
            xiaoti12.Style["display"] = "none";
            xiaoti13.Style["display"] = "none";
            xiaoti14.Style["display"] = "none";
            xiaoti15.Style["display"] = "none";
            xiaoti16.Style["display"] = "none";
            xiaoti17.Style["display"] = "none";
            xiaoti18.Style["display"] = "none";
            xiaoti19.Style["display"] = "none";
            xiaoti20.Style["display"] = "none";
            xiaoti21.Style["display"] = "none";
            xiaoti22.Style["display"] = "none";
            xiaoti23.Style["display"] = "none";
            xiaoti24.Style["display"] = "none";
            xiaoti25.Style["display"] = "none";
            xiaoti26.Style["display"] = "none";
            xiaoti27.Style["display"] = "none";
            xiaoti28.Style["display"] = "none";
            xiaoti29.Style["display"] = "none";
            xiaoti30.Style["display"] = "none";
            xiaoti101.Style["display"] = "none";
            xiaoti102.Style["display"] = "none";
            xiaoti103.Style["display"] = "none";
            xiaoti104.Style["display"] = "none";
            xiaoti105.Style["display"] = "none";
            xiaoti106.Style["display"] = "none";
            xiaoti107.Style["display"] = "none";
            xiaoti108.Style["display"] = "none";
            xiaoti109.Style["display"] = "none";
            xiaoti110.Style["display"] = "none";
        }
        //控制对应大题的div显示
        public void DisDivChoice()
        {
            xiaoti1.Style["display"] = "block";
            xiaoti2.Style["display"] = "block";
            xiaoti3.Style["display"] = "block";
            xiaoti4.Style["display"] = "block";
            xiaoti5.Style["display"] = "block";
            xiaoti6.Style["display"] = "block";
            xiaoti7.Style["display"] = "block";
            xiaoti8.Style["display"] = "block";
            xiaoti9.Style["display"] = "block";
            xiaoti10.Style["display"] = "block";
            xiaoti11.Style["display"] = "block";
            xiaoti12.Style["display"] = "block";
            xiaoti13.Style["display"] = "block";
            xiaoti14.Style["display"] = "block";
            xiaoti15.Style["display"] = "block";
            xiaoti16.Style["display"] = "block";
            xiaoti17.Style["display"] = "block";
            xiaoti18.Style["display"] = "block";
            xiaoti19.Style["display"] = "block";
            xiaoti20.Style["display"] = "block";
            xiaoti21.Style["display"] = "block";
            xiaoti22.Style["display"] = "block";
            xiaoti23.Style["display"] = "block";
            xiaoti24.Style["display"] = "block";
            xiaoti25.Style["display"] = "block";
            xiaoti26.Style["display"] = "block";
            xiaoti27.Style["display"] = "block";
            xiaoti28.Style["display"] = "block";
            xiaoti29.Style["display"] = "block";
            xiaoti30.Style["display"] = "block";
            for (int i = Convert.ToInt32(Session["save_choice_num"]) + 1; i <= 30; i++)
                According_title(i);
        }
        public void DisDivFilling()
        {
            xiaoti101.Style["display"] = "block";
            xiaoti102.Style["display"] = "block";
            xiaoti103.Style["display"] = "block";
            xiaoti104.Style["display"] = "block";
            xiaoti105.Style["display"] = "block";
            xiaoti106.Style["display"] = "block";
            xiaoti107.Style["display"] = "block";
            xiaoti108.Style["display"] = "block";
            xiaoti109.Style["display"] = "block";
            xiaoti110.Style["display"] = "block";
            for (int i = Convert.ToInt32(Session["save_filling_num"]) + 101; i <= 110; i++)
                According_title(i);
        }

        //使所有的div背景恢复原色
        public void renewBackColor()
        {
            for (int i = 1; i <= (int)Session["save_choice_num"]; i++)
                ((HtmlGenericControl)(xiao.FindControl("xiaoti" + i.ToString()))).Style["background-color"] = "rgb(211,211,211)";
            for (int i = 101; i <= 100 + (int)Session["save_filling_num"]; i++)
                ((HtmlGenericControl)(xiao.FindControl("xiaoti" + i.ToString()))).Style["background-color"] = "rgb(211,211,211)";
            //xiaoti1.Style["background-color"] = "rgb(211,211,211)";
            //xiaoti2.Style["background-color"] = "rgb(211,211,211)";
            //xiaoti3.Style["background-color"] = "rgb(211,211,211)";
            //xiaoti4.Style["background-color"] = "rgb(211,211,211)";
            //xiaoti5.Style["background-color"] = "rgb(211,211,211)";
            //xiaoti6.Style["background-color"] = "rgb(211,211,211)";
            //xiaoti7.Style["background-color"] = "rgb(211,211,211)";
            //xiaoti8.Style["background-color"] = "rgb(211,211,211)";
            //xiaoti9.Style["background-color"] = "rgb(211,211,211)";
            //xiaoti10.Style["background-color"] = "rgb(211,211,211)";
            //xiaoti11.Style["background-color"] = "rgb(211,211,211)";
            //xiaoti12.Style["background-color"] = "rgb(211,211,211)";
            //xiaoti13.Style["background-color"] = "rgb(211,211,211)";
            //xiaoti14.Style["background-color"] = "rgb(211,211,211)";
            //xiaoti15.Style["background-color"] = "rgb(211,211,211)";
            //xiaoti16.Style["background-color"] = "rgb(211,211,211)";
            //xiaoti17.Style["background-color"] = "rgb(211,211,211)";
            //xiaoti18.Style["background-color"] = "rgb(211,211,211)";
            //xiaoti19.Style["background-color"] = "rgb(211,211,211)";
            //xiaoti20.Style["background-color"] = "rgb(211,211,211)";
            //xiaoti21.Style["background-color"] = "rgb(211,211,211)";
            //xiaoti22.Style["background-color"] = "rgb(211,211,211)";
            //xiaoti23.Style["background-color"] = "rgb(211,211,211)";
            //xiaoti24.Style["background-color"] = "rgb(211,211,211)";
            //xiaoti25.Style["background-color"] = "rgb(211,211,211)";
            //xiaoti26.Style["background-color"] = "rgb(211,211,211)";
            //xiaoti27.Style["background-color"] = "rgb(211,211,211)";
            //xiaoti28.Style["background-color"] = "rgb(211,211,211)";
            //xiaoti29.Style["background-color"] = "rgb(211,211,211)";
            //xiaoti30.Style["background-color"] = "rgb(211,211,211)";
            //xiaoti31.Style["background-color"] = "rgb(211,211,211)";
            //xiaoti32.Style["background-color"] = "rgb(211,211,211)";
            //xiaoti33.Style["background-color"] = "rgb(211,211,211)";
            //xiaoti34.Style["background-color"] = "rgb(211,211,211)";
            //xiaoti35.Style["background-color"] = "rgb(211,211,211)";
        }
        //判断选中的是那个结点并改变其背景颜色为红色
        public void setNodeBackColor(int i)
        {
            ((HtmlGenericControl)(xiao.FindControl("xiaoti" + i.ToString()))).Style["background-color"] = "rgb(255,128,128)";
        }


        //设置当前小题的答题情况
        public void SetOne(int type, int index)
        {
            Exam paper = ((Exam)Session["Title"]);
            if (type == 1)
            {
                if (paper.Paper_Choice[index - 1, 3].ToString() == "")
                {
                    one1A.Checked = false;
                    one1B.Checked = false;
                    one1C.Checked = false;
                    one1D.Checked = false;
                }
                else if (paper.Paper_Choice[index - 1, 3].ToString() == "A")
                {
                    one1A.Checked = true;
                    one1B.Checked = false;
                    one1C.Checked = false;
                    one1D.Checked = false;
                }
                else if (paper.Paper_Choice[index - 1, 3].ToString() == "B")
                {
                    one1A.Checked = false;
                    one1B.Checked = true;
                    one1C.Checked = false;
                    one1D.Checked = false;
                }
                else if (paper.Paper_Choice[index - 1, 3].ToString() == "C")
                {
                    one1A.Checked = false;
                    one1B.Checked = false;
                    one1C.Checked = true;
                    one1D.Checked = false;
                }
                else if (paper.Paper_Choice[index - 1, 3].ToString() == "D")
                {
                    one1A.Checked = false;
                    one1B.Checked = false;
                    one1C.Checked = false;
                    one1D.Checked = true;
                }
            }
            else if (type == 2)
            {
                two11.Text = paper.Paper_Filling[index - 1, 5].ToString();
                two12.Text = paper.Paper_Filling[index - 1, 6].ToString();
                two13.Text = paper.Paper_Filling[index - 1, 7].ToString();
            }
        }

        //题目的选择（结点）发生变化时触发
        protected void TreeView1_SelectedNodeChanged1(object sender, EventArgs e)
        {
            if (Session["NowType"] != null && Session["NowIndex"] != null)
            {
                //表示试卷显示成功
                if ((int)Session["NowType"] != 0 && (int)Session["NowIndex"] != 0)
                {
                    //一进来的时候遍历结点，设置图片都是第一张
                    GetAllNodeText(TreeView1.Nodes);
                    renewBackColor();//恢复之前的背景颜色
                    RemoveLogo();
                    SaveOne((int)Session["NowType"], (int)Session["NowIndex"]);//保存上一题的答案并把做了的题的背景标记成绿色

                    TreeNode selectNode = this.TreeView1.SelectedNode;   //获得被选中的根节点     

                    if (TreeView1.SelectedNode.Depth == 0) //表示选中的是根结点(根结点的深度为0)
                    {
                        if (TreeView1.SelectedNode.Text == "单项选择题")
                        {
                            xiaoti1.Style["background-color"] = "rgb(255,128,128)";//根结点默认第一题选中
                            //setAnswerChoice(1);//答题框的设置
                            NoneDivAll();
                            DisDivChoice();
                            TreeView1.Nodes[0].ChildNodes[0].ImageUrl = "~/images/item2.png";
                            Session["NowType"] = 1;//设置题目索引
                            Session["NowIndex"] = 1;
                            SetOne(1, 1);
                            dati.Text = "单项选择题：每题" + ((Exam)Session["Title"]).Paper_Choice[0, 5].ToString() + "分。";
                            Subject_title.Text = "";//先清空之前的题目
                            Subject_title.Text = ((Exam)Session["Title"]).Paper_Choice[(int)Session["NowIndex"] - 1, 1].ToString();
                            AffirmText(1);//标记该题做的情况
                            choice1.Style["display"] = "block";
                            filling1.Style["display"] = "none";
                        }
                        if (TreeView1.SelectedNode.Text == "程序填空题")
                        {
                            xiaoti24.Style["background-color"] = "rgb(255,128,128)";//根结点默认第一题选中
                            //setAnswerFilling(24);//答题框的设置
                            NoneDivAll();
                            DisDivFilling();//隐藏多余小题
                            if (Convert.ToInt32(Session["save_choice_num"]) != 0)
                                TreeView1.Nodes[1].ChildNodes[0].ImageUrl = "~/images/item2.png";
                            else
                                TreeView1.Nodes[0].ChildNodes[0].ImageUrl = "~/images/item2.png";
                            Session["NowType"] = 2;
                            Session["NowIndex"] = 1;
                            SetOne(2, 1);
                            dati.Text = "程序填空题：每题3小题，每小题" + ((Exam)Session["Title"]).Paper_Filling[(int)Session["NowIndex"] - 1, 11].ToString() + "分。";
                            Subject_title.Text = "";//先清空之前的题目
                            Subject_title.Text = ((Exam)Session["Title"]).Paper_Filling[(int)Session["NowIndex"] - 1, 1].ToString();

                            AffirmText(101);//标记该题做的情况
                            choice1.Style["display"] = "none";
                            filling1.Style["display"] = "block";
                        }
                    }
                    else//表示选中的是子结点
                    {
                        //根据选中的子结点获取父节点 用于设置大题的题型
                        if (selectNode.Parent.Text.Trim() == "单项选择题")
                        {
                            NoneDivAll();
                            DisDivChoice();
                            //判断选中的是那个子结点
                            int i = int.Parse(selectNode.Value);//获得结点的Value值，及对应的是第几小题
                            //setAnswerChoice(i);//确定显示哪个答题框
                            setNodeBackColor(i);
                            Session["NowType"] = 1;//设置当前所处的题型
                            Session["NowIndex"] = i;//设置当前小题的索引
                            SetOne(1, i);
                            dati.Text = "单项选择题：每题" + ((Exam)Session["Title"]).Paper_Choice[(int)Session["NowIndex"] - 1, 5].ToString() + "分。";
                            selectNode.ImageUrl = "~/images/item2.png";
                            Subject_title.Text = "";//先清空之前的题目
                            Subject_title.Text = ((Exam)Session["Title"]).Paper_Choice[(int)Session["NowIndex"] - 1, 1].ToString();
                            AffirmText(i);//标记该题做的情况
                            choice1.Style["display"] = "block";
                            filling1.Style["display"] = "none";
                        }
                        if (selectNode.Parent.Text.Trim() == "程序填空题")
                        {
                            NoneDivAll();
                            DisDivFilling();//隐藏多余小题
                            int i = int.Parse(selectNode.Value);//获得结点的Value值，及对应的是第几小题
                            //setAnswerFilling(i);//确定显示哪个答题框 
                            setNodeBackColor(i);
                            Session["NowType"] = 2;//设置当前所处的题型                   
                            i = i - 100;
                            Session["NowIndex"] = i;//设置当前小题的索引
                            SetOne(2, i);
                            dati.Text = "程序填空题：每题3小题，每小题" + ((Exam)Session["Title"]).Paper_Filling[(int)Session["NowIndex"] - 1, 11].ToString() + "分。";
                            selectNode.ImageUrl = "~/images/item2.png";
                            Subject_title.Text = "";//先清空之前的题目
                            Subject_title.Text = ((Exam)Session["Title"]).Paper_Filling[(int)Session["NowIndex"] - 1, 1].ToString();
                            AffirmText(i + 100);//标记该题做的情况
                            choice1.Style["display"] = "none";
                            filling1.Style["display"] = "block";
                        }
                    }
                    //控制答题框的高度
                    if (Convert.ToInt32(Session["NowType"]) == 4)
                    {
                        Title.Style["height"] = "250px";
                        Subject_title.Style["height"] = "235px";
                        answer.Style["height"] = "290px";
                        show_image.Style["top"] = "-200px";
                    }
                    else
                    {
                        Title.Style["height"] = "450px";
                        Subject_title.Style["height"] = "435px";
                        answer.Style["height"] = "95px";
                        show_image.Style["top"] = "-228px";
                    }
                }
                //没有点击抽题事件
                else
                {
                    p.InnerHtml = "程序非法操作";
                    overdue.Style["display"] = "block";
                }
            }
            else
            {
                //session变量失效，此次练习结束，再次练习需要重新登录
                overdue.Style["display"] = "block";
            }
        }

        //上一题按钮
        protected void PreTitle_Click(object sender, EventArgs e)
        {
            if (Session["NowType"] != null && Session["NowIndex"] != null)
            {
                if ((int)Session["NowType"] != Convert.ToInt32(Session["first"]) || (int)Session["NowIndex"] != 1)  //不是全卷的第一题，即不是一.1
                {
                    GetAllNodeText(TreeView1.Nodes);//先将所有的结点图片恢复原样
                    renewBackColor();//设置所有小题背景恢复原色
                    RemoveLogo();//去掉已答标记
                    SaveOne((int)Session["NowType"], (int)Session["NowIndex"]);//保存上一题的答案并把做了的题的背景标记成绿色
                    if ((int)Session["NowIndex"] == 1)//在每一个类型题的第一题位置
                    {
                        if ((int)Session["NowType"] == 2 && Convert.ToInt32(Session["save_choice_num"]) != 0)//位于第二大题的第一小题（保证前一题不为空才能进行切换，至少有两个节点）
                        {
                            TreeView1.Nodes[(int)Session["NowType"] - 2].ChildNodes[Convert.ToInt32(Session["save_choice_num"]) - 1].ImageUrl = "~/images/item2.png";//修改第一大题的最后一题的图片
                            NoneDivAll();
                            DisDivChoice();//显示选择题的小题个数                                                    
                            int i = int.Parse(TreeView1.Nodes[(int)Session["NowType"] - 2].ChildNodes[Convert.ToInt32(Session["save_choice_num"]) - 1].Value);//获得结点的Value值，即对应的是第几小题
                            setNodeBackColor(Convert.ToInt32(Session["save_choice_num"]));//设置当前小题的背景颜色为红色
                            //setAnswerChoice(Convert.ToInt32(Session["save_choice_num"]));//设置答题框
                            //修改当前题目的索引
                            Session["NowType"] = 1;
                            Session["NowIndex"] = Convert.ToInt32(Session["save_choice_num"]);
                            dati.Text = "单项选择题：每题" + ((Exam)Session["Title"]).Paper_Choice[(int)Session["NowIndex"] - 1, 5].ToString() + "分。";
                            SetOne(1, Convert.ToInt32(Session["save_choice_num"]));
                            Subject_title.Text = "";//先清空之前的题目
                            Subject_title.Text = ((Exam)Session["Title"]).Paper_Choice[(int)Session["NowIndex"] - 1, 1].ToString();
                            AffirmText(i);
                            choice1.Style["display"] = "block";
                            filling1.Style["display"] = "none";
                        }
                    }
                    else//说明在同一个大题上，在本大题上向上切换即可
                    {
                        if ((int)Session["NowType"] == 1)
                        {
                            TreeView1.Nodes[(int)Session["NowType"] - 1].ChildNodes[(int)Session["NowIndex"] - 2].ImageUrl = "~/images/item2.png";//修改本大题的上一题的图片    
                            NoneDivAll();
                            DisDivChoice();//显示选择题的小题个数
                            //获得结点的Value值，即对应的是第几小题
                            int i = int.Parse(TreeView1.Nodes[(int)Session["NowType"] - 1].ChildNodes[(int)Session["NowIndex"] - 2].Value);
                            setNodeBackColor(i);//设置当前小题的背景颜色为红色
                            //setAnswerChoice(i);//设置答题框
                            //修改当前题目的索引
                            Session["NowType"] = 1;
                            Session["NowIndex"] = (int)Session["NowIndex"] - 1;
                            dati.Text = "单项选择题：每题" + ((Exam)Session["Title"]).Paper_Choice[(int)Session["NowIndex"] - 1, 5].ToString() + "分。";
                            SetOne(1, (int)Session["NowIndex"]);
                            Subject_title.Text = "";//先清空之前的题目
                            Subject_title.Text = ((Exam)Session["Title"]).Paper_Choice[(int)Session["NowIndex"] - 1, 1].ToString();
                            AffirmText(i);
                        }
                        else if ((int)Session["NowType"] == 2)
                        {
                            int i = 0;
                            if ((Convert.ToInt32(Session["save_choice_num"]) != 0))
                            {
                                TreeView1.Nodes[(int)Session["NowType"] - 1].ChildNodes[(int)Session["NowIndex"] - 2].ImageUrl = "~/images/item2.png";//修改本大题的上一题的图片    
                                i = int.Parse(TreeView1.Nodes[(int)Session["NowType"] - 1].ChildNodes[(int)Session["NowIndex"] - 2].Value);
                            }
                            else if ((Convert.ToInt32(Session["save_choice_num"]) == 0))
                            {
                                TreeView1.Nodes[(int)Session["NowType"] - 2].ChildNodes[(int)Session["NowIndex"] - 2].ImageUrl = "~/images/item2.png";//修改本大题的上一题的图片 
                                i = int.Parse(TreeView1.Nodes[(int)Session["NowType"] - 2].ChildNodes[(int)Session["NowIndex"] - 2].Value);
                            }
                            NoneDivAll();
                            DisDivFilling();//显示填空题的小题个数
                                            //获得结点的Value值，即对应的是第几小题

                            setNodeBackColor(i);//设置当前小题的背景颜色为红色
                            //setAnswerFilling(i);//设置答题框
                            //修改当前题目的索引
                            Session["NowType"] = 2;
                            Session["NowIndex"] = (int)Session["NowIndex"] - 1;
                            dati.Text = "程序填空题：每题3小题，每小题" + ((Exam)Session["Title"]).Paper_Filling[(int)Session["NowIndex"] - 1, 11].ToString() + "分。";
                            SetOne(2, (int)Session["NowIndex"]);
                            Subject_title.Text = "";//先清空之前的题目
                            Subject_title.Text = ((Exam)Session["Title"]).Paper_Filling[(int)Session["NowIndex"] - 1, 1].ToString();
                            AffirmText(i);
                        }
                    }
                }
                //控制答题框的高度
                if (Convert.ToInt32(Session["NowType"]) == 4)
                {
                    Title.Style["height"] = "250px";
                    Subject_title.Style["height"] = "235px";
                    answer.Style["height"] = "290px";
                    show_image.Style["top"] = "-200px";
                }
                else
                {
                    Title.Style["height"] = "450px";
                    Subject_title.Style["height"] = "435px";
                    answer.Style["height"] = "95px";
                    show_image.Style["top"] = "-228px";
                }
            }
            else
            {
                //session变量失效，此次考试结束
                overdue.Style["display"] = "block";
            }

        }
        //下一题按钮
        protected void NextTitle_Click(object sender, EventArgs e)
        {
            if (Session["NowType"] != null && Session["NowIndex"] != null)
            {
                //隐藏显示图片的div
                a_image.ImageUrl = "";
                a_image.Style["display"] = "none";
                int end;
                if (Convert.ToInt32(Session["end"]) == 1)
                    end = Convert.ToInt32(Session["save_choice_num"]);
                else
                    end = Convert.ToInt32(Session["save_filling_num"]);
                if ((int)Session["NowType"] != Convert.ToInt32(Session["end"]) || (int)Session["NowIndex"] != end)//大前提是不在全卷的最后一题
                {
                    GetAllNodeText(TreeView1.Nodes);//先将所有的结点图片恢复原样
                    renewBackColor();//设置所有小题背景恢复原色
                    RemoveLogo();
                    SaveOne((int)Session["NowType"], (int)Session["NowIndex"]);//保存上一题的答案并把做了的题的背景标记成绿色
                    //接下来判断位于那个大题上
                    if ((int)Session["NowType"] == 1)//位于第一大题
                    {
                        if ((int)Session["NowIndex"] == Convert.ToInt32(Session["save_choice_num"]))//位于单选题的最后一小题(至少有两个节点，下一题的节点是1，所以此处不用考虑节点数量问题)
                        {
                            if (Convert.ToInt32(Session["save_filling_num"]) != 0)
                            {
                                Session["NowIndex"] = 1;//下一题肯定是第一小题了
                                //修改第二大题的第一题的图片
                                TreeView1.Nodes[(int)Session["NowType"]].ChildNodes[(int)Session["NowIndex"] - 1].ImageUrl = "~/images/item2.png";
                                NoneDivAll();
                                DisDivFilling();//显示填空题的小题个数
                                //获得结点的Value值，即对应的是第几小题
                                setNodeBackColor(24);//设置当前小题的背景颜色为红色
                                //setAnswerFilling(24);//设置答题框
                                //修改当前题目的索引
                                Session["NowType"] = 2;
                                SetOne(2, 1);
                                dati.Text = "程序填空题：每题3小题，每小题" + ((Exam)Session["Title"]).Paper_Filling[(int)Session["NowIndex"] - 1, 11].ToString() + "分。";
                                Subject_title.Text = "";//先清空之前的题目
                                Subject_title.Text = ((Exam)Session["Title"]).Paper_Filling[(int)Session["NowIndex"] - 1, 1].ToString();
                                AffirmText(101);
                                choice1.Style["display"] = "none";
                                filling1.Style["display"] = "block";
                            }
                        }
                        else //位于第一大题的非最后一题
                        {
                            //修改本大题的下一题的图片
                            TreeView1.Nodes[(int)Session["NowType"] - 1].ChildNodes[(int)Session["NowIndex"]].ImageUrl = "~/images/item2.png";
                            NoneDivAll();
                            DisDivChoice();//显示选择题的小题个数
                            //获得结点的Value值，即对应的是第几小题
                            int i = int.Parse(TreeView1.Nodes[(int)Session["NowType"] - 1].ChildNodes[(int)Session["NowIndex"]].Value);
                            setNodeBackColor(i);//设置当前小题的背景颜色为红色
                            //setAnswerChoice(i);//设置答题框
                            //修改当前题目的索引
                            Session["NowType"] = 1;
                            Session["NowIndex"] = (int)Session["NowIndex"] + 1;
                            dati.Text = "单项选择题：每题" + ((Exam)Session["Title"]).Paper_Choice[(int)Session["NowIndex"] - 1, 5].ToString() + "分。";
                            SetOne(1, (int)Session["NowIndex"]);
                            Subject_title.Text = "";//先清空之前的题目
                            Subject_title.Text = ((Exam)Session["Title"]).Paper_Choice[(int)Session["NowIndex"] - 1, 1].ToString();
                            AffirmText(i);
                        }
                    }
                    else if ((int)Session["NowType"] == 2)//位于第二大题
                    {
                        if ((int)Session["NowIndex"] != Convert.ToInt32(Session["save_filling_num"]))//位于第二大题的非最后一小题
                        {
                            //修改本大题的下一题的图片
                            if (Convert.ToInt32(Session["save_choice_num"]) != 0)//表示有选择题
                                TreeView1.Nodes[(int)Session["NowType"] - 1].ChildNodes[(int)Session["NowIndex"]].ImageUrl = "~/images/item2.png";
                            else
                                TreeView1.Nodes[(int)Session["NowType"] - 2].ChildNodes[(int)Session["NowIndex"]].ImageUrl = "~/images/item2.png";
                            NoneDivAll();
                            DisDivFilling();//显示填空题的小题个数
                            //获得结点的Value值，即对应的是第几小题
                            int i;
                            if (Convert.ToInt32(Session["save_choice_num"]) != 0)//表示有选择题
                                i = int.Parse(TreeView1.Nodes[(int)Session["NowType"] - 1].ChildNodes[(int)Session["NowIndex"]].Value);
                            else
                                i = int.Parse(TreeView1.Nodes[(int)Session["NowType"] - 2].ChildNodes[(int)Session["NowIndex"]].Value);
                            setNodeBackColor(i);//设置当前小题的背景颜色为红色
                            //setAnswerFilling(i);//设置答题框
                            //修改当前题目的索引
                            Session["NowType"] = 2;
                            Session["NowIndex"] = (int)Session["NowIndex"] + 1;
                            dati.Text = "程序填空题：每题3小题，每小题" + ((Exam)Session["Title"]).Paper_Filling[(int)Session["NowIndex"] - 1, 11].ToString() + "分。";
                            SetOne(2, (int)Session["NowIndex"]);
                            Subject_title.Text = "";//先清空之前的题目
                            Subject_title.Text = ((Exam)Session["Title"]).Paper_Filling[(int)Session["NowIndex"] - 1, 1].ToString();
                            AffirmText(i);
                        }
                    }
                }
                //控制答题框的高度
                if (Convert.ToInt32(Session["NowType"]) == 4)
                {
                    Title.Style["height"] = "250px";
                    Subject_title.Style["height"] = "235px";
                    answer.Style["height"] = "290px";
                    show_image.Style["top"] = "-200px";
                }
                else
                {
                    Title.Style["height"] = "450px";
                    Subject_title.Style["height"] = "435px";
                    answer.Style["height"] = "95px";
                    show_image.Style["top"] = "-228px";
                }
            }
            else
            {
                //session变量失效，此次练习结束，再次练习需要重新登录
                overdue.Style["display"] = "block";
            }
        }
        //改卷按钮
        protected void Change_Click(object sender, EventArgs e)
        {
            SaveOne(Convert.ToInt32(Session["NowType"]), Convert.ToInt32(Session["NowIndex"]));
            if (Session["Title"] != null)
            {
                int logo = 1;//记录有没有作答的题目
                //先遍历判断有没有没有作答的题目
                for (int i = 0; i < Convert.ToInt32(Session["save_choice_num"]); i++)
                {
                    if (((Exam)Session["Title"]).Paper_Choice[i, 3].ToString() == null)
                    {
                        logo = 0;
                        break;
                    }
                }
                for (int i = 0; i < Convert.ToInt32(Session["save_filling_num"]); i++)
                {
                    if (((Exam)Session["Title"]).Paper_Filling[i, 5].ToString() == "" || ((Exam)Session["Title"]).Paper_Filling[i, 6].ToString() == "" || ((Exam)Session["Title"]).Paper_Filling[i, 7].ToString() == "")
                    {
                        logo = 0;
                        break;
                    }
                }
                for (int i = 0; i < Convert.ToInt32(Session["save_reading_num"]); i++)
                {
                    if (((Exam)Session["Title"]).Paper_Reading[i, 3].ToString() == "")
                    {
                        logo = 0;
                        break;
                    }
                }
                for (int i = 0; i < Convert.ToInt32(Session["save_design_num"]); i++)
                {
                    if (((Exam)Session["Title"]).Paper_Design[i, 3].ToString() == "")
                    {
                        logo = 0;
                        break;
                    }
                }
                if (logo == 1)//题目全部作答调用判分函数            
                    CountScore();
                else
                {
                    paper.Style["display"] = "block";
                }
            }
            else
            {
                overdue.Style["display"] = "block";
            }
        }

        //判分函数
        public void CountScore()
        {
            //停止计时
            Timer1.Enabled = false;
            if (Session["Title"] != null)
            {
                //选择题
                for (int i = 0; i < Convert.ToInt32(Session["save_choice_num"]); i++)
                {
                    if (((Exam)Session["Title"]).Paper_Choice[i, 2].ToString() == ((Exam)Session["Title"]).Paper_Choice[i, 3].ToString())
                        ((Exam)Session["Title"]).Paper_Choice[i, 4] = ((Exam)Session["Title"]).Paper_Choice[i, 5];
                    else
                        ((Exam)Session["Title"]).Paper_Choice[i, 4] = 0;
                }
                //填空题
                for (int i = 0; i < Convert.ToInt32(Session["save_filling_num"]); i++)
                {
                    int index;
                    int n;
                    ArrayList arr1 = new ArrayList();
                    ArrayList arr2 = new ArrayList();
                    ArrayList arr3 = new ArrayList();
                    //将标准答案的多个答案分开
                    while (((Exam)Session["Title"]).Paper_Filling[i, 2].ToString().Length != 0)
                    {
                        index = ((Exam)Session["Title"]).Paper_Filling[i, 2].ToString().IndexOf("$$");
                        if (index == -1)
                        {
                            arr1.Add(((Exam)Session["Title"]).Paper_Filling[i, 2].ToString());
                            ((Exam)Session["Title"]).Paper_Filling[i, 2] = "";
                        }
                        else
                        {
                            arr1.Add(((Exam)Session["Title"]).Paper_Filling[i, 2].ToString().Substring(0, index));
                            ((Exam)Session["Title"]).Paper_Filling[i, 2] = ((Exam)Session["Title"]).Paper_Filling[i, 2].ToString().Substring(index + 2);
                        }
                    }
                    while (((Exam)Session["Title"]).Paper_Filling[i, 3].ToString().Length != 0)
                    {
                        index = ((Exam)Session["Title"]).Paper_Filling[i, 3].ToString().IndexOf("$$");
                        if (index == -1)
                        {
                            arr2.Add(((Exam)Session["Title"]).Paper_Filling[i, 3].ToString());
                            ((Exam)Session["Title"]).Paper_Filling[i, 3] = "";
                        }
                        else
                        {
                            arr2.Add(((Exam)Session["Title"]).Paper_Filling[i, 3].ToString().Substring(0, index));
                            ((Exam)Session["Title"]).Paper_Filling[i, 3] = ((Exam)Session["Title"]).Paper_Filling[i, 3].ToString().Substring(index + 2);
                        }
                    }
                    while (((Exam)Session["Title"]).Paper_Filling[i, 4].ToString().Length != 0)
                    {
                        index = ((Exam)Session["Title"]).Paper_Filling[i, 4].ToString().IndexOf("$$");
                        if (index == -1)
                        {
                            arr3.Add(((Exam)Session["Title"]).Paper_Filling[i, 4].ToString());
                            ((Exam)Session["Title"]).Paper_Filling[i, 4] = "";
                        }
                        else
                        {
                            arr3.Add(((Exam)Session["Title"]).Paper_Filling[i, 4].ToString().Substring(0, index));
                            ((Exam)Session["Title"]).Paper_Filling[i, 4] = ((Exam)Session["Title"]).Paper_Filling[i, 4].ToString().Substring(index + 2);
                        }
                    }
                    //去掉学生答案多余空格
                    while (((string)((Exam)Session["Title"]).Paper_Filling[i, 5]).IndexOf("  ") != -1)
                        ((Exam)Session["Title"]).Paper_Filling[i, 5] = ((string)((Exam)Session["Title"]).Paper_Filling[i, 5]).Replace("  ", " ");
                    while (((string)((Exam)Session["Title"]).Paper_Filling[i, 5]).IndexOf("( )") != -1)
                        ((Exam)Session["Title"]).Paper_Filling[i, 5] = ((string)((Exam)Session["Title"]).Paper_Filling[i, 5]).Replace("( )", "()");
                    while (((string)((Exam)Session["Title"]).Paper_Filling[i, 5]).IndexOf("[ ]") != -1)
                        ((Exam)Session["Title"]).Paper_Filling[i, 5] = ((string)((Exam)Session["Title"]).Paper_Filling[i, 5]).Replace("[ ]", "[]");
                    //去掉多余空格
                    while (((string)((Exam)Session["Title"]).Paper_Filling[i, 6]).IndexOf("  ") != -1)
                        ((Exam)Session["Title"]).Paper_Filling[i, 6] = ((string)((Exam)Session["Title"]).Paper_Filling[i, 6]).Replace("  ", " ");
                    while (((string)((Exam)Session["Title"]).Paper_Filling[i, 6]).IndexOf("( )") != -1)
                        ((Exam)Session["Title"]).Paper_Filling[i, 6] = ((string)((Exam)Session["Title"]).Paper_Filling[i, 6]).Replace("( )", "()");
                    while (((string)((Exam)Session["Title"]).Paper_Filling[i, 6]).IndexOf("[ ]") != -1)
                        ((Exam)Session["Title"]).Paper_Filling[i, 6] = ((string)((Exam)Session["Title"]).Paper_Filling[i, 6]).Replace("[ ]", "[]");
                    //去掉多余空格
                    while (((string)((Exam)Session["Title"]).Paper_Filling[i, 7]).IndexOf("  ") != -1)
                        ((Exam)Session["Title"]).Paper_Filling[i, 7] = ((string)((Exam)Session["Title"]).Paper_Filling[i, 7]).Replace("  ", " ");
                    while (((string)((Exam)Session["Title"]).Paper_Filling[i, 7]).IndexOf("( )") != -1)
                        ((Exam)Session["Title"]).Paper_Filling[i, 7] = ((string)((Exam)Session["Title"]).Paper_Filling[i, 7]).Replace("( )", "()");
                    while (((string)((Exam)Session["Title"]).Paper_Filling[i, 7]).IndexOf("[ ]") != -1)
                        ((Exam)Session["Title"]).Paper_Filling[i, 7] = ((string)((Exam)Session["Title"]).Paper_Filling[i, 7]).Replace("[ ]", "[]");
                    //获取得分
                    for (n = 0; n < arr1.Count; n++)
                    {
                        if (arr1[n].ToString().Trim() == ((Exam)Session["Title"]).Paper_Filling[i, 5].ToString().Trim())
                        {
                            ((Exam)Session["Title"]).Paper_Filling[i, 8] = ((Exam)Session["Title"]).Paper_Filling[i, 11];
                            break;
                        }
                    }
                    for (n = 0; n < arr2.Count; n++)
                    {
                        if (arr2[n].ToString().Trim() == ((Exam)Session["Title"]).Paper_Filling[i, 6].ToString().Trim())
                        {
                            ((Exam)Session["Title"]).Paper_Filling[i, 9] = ((Exam)Session["Title"]).Paper_Filling[i, 11];
                            break;
                        }
                    }
                    for (n = 0; n < arr3.Count; n++)
                    {
                        if (arr3[n].ToString().Trim() == ((Exam)Session["Title"]).Paper_Filling[i, 7].ToString().Trim())
                        {
                            ((Exam)Session["Title"]).Paper_Filling[i, 10] = ((Exam)Session["Title"]).Paper_Filling[i, 11];
                            break;
                        }
                    }
                }
            }
            else
            {
                overdue.Style["display"] = "block";
            }
            //计算总分
            Session["AllScore"] = 0;
            for (int i = 0; i < Convert.ToInt32(Session["save_choice_num"]); i++)
                Session["AllScore"] = (int)Session["AllScore"] + (int)((Exam)Session["Title"]).Paper_Choice[i, 4];
            for (int i = 0; i < Convert.ToInt32(Session["save_filling_num"]); i++)
                Session["AllScore"] = (int)Session["AllScore"] + (int)((Exam)Session["Title"]).Paper_Filling[i, 8] + (int)((Exam)Session["Title"]).Paper_Filling[i, 9] + (int)((Exam)Session["Title"]).Paper_Filling[i, 10];


            if (Session["AllScore"] != null)
            {
                ShowScore();
                showscore.Style["display"] = "block";
            }
            else
                overdue.Style["display"] = "block";
        }
        //去掉所有题目前面的已答标记
        public void RemoveLogo()
        {
            for (int j = 0; j < Convert.ToInt32(Session["root"]); j++)
            {
                if (Convert.ToInt32(Session["save_choice_num"]) != 0 && Convert.ToInt32(Session["root_choice"]) == 1)
                {
                    for (int i = 0; i < Convert.ToInt32(Session["save_choice_num"]); i++)
                        TreeView1.Nodes[j].ChildNodes[i].Text = "第" + (i + 1).ToString() + "题";
                    Session["root_choice"] = 0;
                }
                else if (Convert.ToInt32(Session["save_filling_num"]) != 0 && Convert.ToInt32(Session["root_filling"]) == 1)
                {
                    for (int i = 0; i < Convert.ToInt32(Session["save_filling_num"]); i++)
                        TreeView1.Nodes[j].ChildNodes[i].Text = "第" + (i + 1).ToString() + "题";
                    Session["root_filling"] = 0;
                }
                else if (Convert.ToInt32(Session["save_reading_num"]) != 0 && Convert.ToInt32(Session["root_reading"]) == 1)
                {
                    for (int i = 0; i < Convert.ToInt32(Session["save_reading_num"]); i++)
                        TreeView1.Nodes[j].ChildNodes[i].Text = "第" + (i + 1).ToString() + "题";
                    Session["root_reading"] = 0;
                }
                else if (Convert.ToInt32(Session["save_design_num"]) != 0 && Convert.ToInt32(Session["root_design"]) == 1)
                {
                    for (int i = 0; i < Convert.ToInt32(Session["save_design_num"]); i++)
                        TreeView1.Nodes[j].ChildNodes[i].Text = "第" + (i + 1).ToString() + "题";
                    Session["root_design"] = 0;
                }
            }
        }
        //存储学生答案到Student.变量中,并将做过的题显示成绿色,对应题目做已答标记
        public void SaveStuAnswer1()
        {
            if (Session["Title"] != null)
            {
                //SaveOne((int)Session["NowType"], (int)Session["NowIndex"]);
                Exam paper = ((Exam)Session["Title"]);
                for (int i = 0; i < ((int)Session["save_choice_num"]); i++)
                {
                    if (paper.Paper_Choice[i, 3].ToString() != "")
                    {
                        ((HtmlGenericControl)(xiao.FindControl("xiaoti" + (i + 1).ToString()))).Style["background-color"] = "rgb(0,192,0)";
                        TreeView1.Nodes[0].ChildNodes[i].Text = "第" + (i + 1).ToString() + "题(已答)";
                    }
                }
                for (int i = 0; i < ((int)Session["save_filling_num"]); i++)
                {
                    if (paper.Paper_Filling[i, 5].ToString().Trim() != "" && paper.Paper_Filling[i, 6].ToString().Trim() != "" && paper.Paper_Filling[i, 7].ToString().Trim() != "")
                    {
                        ((HtmlGenericControl)(xiao.FindControl("xiaoti" + (100 + i + 1).ToString()))).Style["background-color"] = "rgb(0,192,0)";
                        TreeView1.Nodes[1].ChildNodes[i].Text = "第" + (i + 1).ToString() + "题(已答)";
                    }
                }
            }
            else
                overdue.Style["display"] = "block";
        }
        //判断当前位于哪一题，并确定是否做过该题
        public void AffirmText(int i)
        {
            if (i < 100)
            {
                if (((Exam)Session["Title"]).Paper_Choice[i - 1, 3].ToString() == "")
                {
                    xiaoti.Text = "【第" + i.ToString() + "题 未做】";
                    xiaoti.Style["color"] = "red";
                }
                else
                {
                    xiaoti.Text = "【第" + i.ToString() + "题 已做】";
                    xiaoti.Style["color"] = "green";
                }
            }
            else
            {
                i = i - 100;
                if (((Exam)Session["Title"]).Paper_Filling[i - 1, 5].ToString() != "" && ((Exam)Session["Title"]).Paper_Filling[i - 1, 6].ToString() != "" && ((Exam)Session["Title"]).Paper_Filling[i - 1, 7].ToString() != "")
                {
                    xiaoti.Text = "【第" + i.ToString() + "题 已做】";
                    xiaoti.Style["color"] = "green";
                }
                else
                {
                    xiaoti.Text = "【第" + i.ToString() + "题 未做】";
                    xiaoti.Style["color"] = "red";
                }
            }
        }
        public void SaveOne(int type, int index)
        {
            //选择题保存
            if (type == 1)
            {
                if (!one1A.Checked)
                {
                    if (!one1B.Checked)
                    {
                        if (!one1C.Checked)
                        {
                            if (!one1D.Checked)
                            {
                                //((Exam)Session["Title"]).Paper_Choice[index - 1, 3] = "N";
                            }
                            else
                            {
                                ((Exam)Session["Title"]).Paper_Choice[index - 1, 3] = "D";
                                ((HtmlGenericControl)(xiao.FindControl("xiaoti" + index.ToString()))).Style["background-color"] = "rgb(0,192,0)";
                                TreeView1.Nodes[0].ChildNodes[index - 1].Text = "第" + index.ToString() + "题(已答)";
                            }
                        }
                        else
                        {
                            ((Exam)Session["Title"]).Paper_Choice[index - 1, 3] = "C";
                            ((HtmlGenericControl)(xiao.FindControl("xiaoti" + index.ToString()))).Style["background-color"] = "rgb(0,192,0)";
                            TreeView1.Nodes[0].ChildNodes[index - 1].Text = "第" + index.ToString() + "题(已答)";
                        }
                    }
                    else
                    {
                        ((Exam)Session["Title"]).Paper_Choice[index - 1, 3] = "B";
                        ((HtmlGenericControl)(xiao.FindControl("xiaoti" + index.ToString()))).Style["background-color"] = "rgb(0,192,0)";
                        TreeView1.Nodes[0].ChildNodes[index - 1].Text = "第" + index.ToString() + "题(已答)";
                    }
                }
                else
                {
                    ((Exam)Session["Title"]).Paper_Choice[index - 1, 3] = "A";
                    ((HtmlGenericControl)(xiao.FindControl("xiaoti" + index.ToString()))).Style["background-color"] = "rgb(0,192,0)";
                    TreeView1.Nodes[0].ChildNodes[index - 1].Text = "第" + index.ToString() + "题(已答)";
                }
            }
            else if (type == 2)//填空题保存
            {
                if (two11.Text.Trim() != string.Empty && two12.Text.Trim() != string.Empty && two13.Text.Trim() != string.Empty)
                {

                    ((HtmlGenericControl)(xiao.FindControl("xiaoti" + index.ToString()))).Style["background-color"] = "rgb(0,192,0)";
                    TreeView1.Nodes[1].ChildNodes[index - 1].Text = "第" + index.ToString() + "题(已答)";

                    ((Exam)Session["Title"]).Paper_Filling[index - 1, 5] = two11.Text.Trim();
                    ((Exam)Session["Title"]).Paper_Filling[index - 1, 6] = two12.Text.Trim();
                    ((Exam)Session["Title"]).Paper_Filling[index - 1, 7] = two13.Text.Trim();
                }
                else
                {
                    if (two11.Text.Trim() != "")
                        ((Exam)Session["Title"]).Paper_Filling[index - 1, 5] = two11.Text.Trim();
                    if (two12.Text.Trim() != "")
                        ((Exam)Session["Title"]).Paper_Filling[index - 1, 6] = two12.Text.Trim();
                    if (two13.Text.Trim() != "")
                        ((Exam)Session["Title"]).Paper_Filling[index - 1, 7] = two13.Text.Trim();
                }
            }
            SaveStuAnswer1();

        }
        //确认交卷按钮
        protected void Button1_Click(object sender, EventArgs e)
        {
            paper.Style["display"] = "none";
            //调用判分函数
            CountScore();
        }
        //取消继续答题按钮
        protected void Button2_Click(object sender, EventArgs e)
        {
            paper.Style["display"] = "none";
            return;
        }
        //session过期  退出登录
        protected void Button3_Click(object sender, EventArgs e)
        {
            overdue.Style["display"] = "none";
        }

        //初始化`
        protected void Init()
        {
            DataTable dt = new DataTable();
            Exam Student = new Exam();
            //根据剩余时间判断是否是重连
            int remaintime = Convert.ToInt32(Session["RemainTime"]);
            if (remaintime != 120)
                Time.InnerHtml = "剩余" + remaintime.ToString() + "分钟";
            //-------------------抽取题目-------------------------// 
            int root = 2;//记录根结点的数量，方便后边对根结点的移除
            //选择题
            if (remaintime == 120)
                dt = StuExam.DAL.Choice.PaperGetList("Id = " + Convert.ToString(Session["ExamId"]));
            else
                dt = StuExam.DAL.Choice.ExamGetList("ExamId = " + Convert.ToString(Session["ExamId"]) + " and StudentId = " + Convert.ToString(Session["student_Number"]));

            DataTable choice = dt;
            Session["root_choice"] = 1;
            if (dt.Rows.Count != 23)
            {
                int depth = 23;
                if (dt.Rows.Count != 0)
                {
                    while (depth > dt.Rows.Count)//移除多余树控件的子结点 注意:在Nodes移除一项后，所有的马上会提前
                    {
                        TreeView1.Nodes[0].ChildNodes.RemoveAt(dt.Rows.Count);
                        depth--;
                    }
                    while (depth < dt.Rows.Count)
                    {
                        TreeNode ChileNode = new TreeNode();
                        ChileNode.Text = "第" + (depth + 1).ToString() + "题";
                        ChileNode.Value = (depth + 1).ToString();
                        ChileNode.ImageUrl = "~/images/item1.png";
                        TreeView1.Nodes[0].ChildNodes.Add(ChileNode);
                        depth++;
                    }
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Student.Paper_Choice[i, 0] = dt.Rows[i]["Number"].ToString().Trim(); //题目编号
                        //存储的是随机抽取到的题目
                        Student.Paper_Choice[i, 1] = dt.Rows[i]["Subject"]; //Teaching.Model.Base.Decrypt(dt.Rows[i]["Subject"].ToString().Trim());   
                        Student.Paper_Choice[i, 2] = dt.Rows[i]["Answer"].ToString().Trim();//存储题目的标准答案  
                        Student.Paper_Choice[i, 5] = Convert.ToInt32(choice.Rows[i]["Value"]);//                  
                    }
                }
                else
                {
                    //移除根结点
                    TreeView1.Nodes.Remove(TreeView1.Nodes[0]);
                    root--;
                    Session["root_choice"] = 0;
                }
            }
            else
                for (int i = 0; i < 23; i++)
                {
                    Student.Paper_Choice[i, 0] = dt.Rows[i]["Number"].ToString().Trim(); //题目编号
                    //存储的是随机抽取到的题目
                    Student.Paper_Choice[i, 1] = dt.Rows[i]["Subject"];
                    Student.Paper_Choice[i, 2] = dt.Rows[i]["Answer"].ToString().Trim();//存储题目的标准答案   
                    Student.Paper_Choice[i, 5] = Convert.ToInt32(choice.Rows[i]["Value"]);//
                }
            Session["save_choice_num"] = dt.Rows.Count;//记录抽取到的选择题的个数
            //填空题
            if (remaintime == 120)
                dt = StuExam.DAL.Filling.PaperGetList("Id = " + Convert.ToString(Session["ExamId"]));
            else
                dt = StuExam.DAL.Filling.ExamGetList("ExamId = " + Convert.ToString(Session["ExamId"]) + " and StudentId = " + Convert.ToString(Session["student_Number"]));
            DataTable filling = dt;
            Session["root_filling"] = 1;
            if (dt.Rows.Count != 10)
            {
                int depth = 4;
                if (dt.Rows.Count != 0)
                {
                    while (depth > dt.Rows.Count)//移除多余树控件的子结点
                    {
                        if (root == 2)
                            TreeView1.Nodes[1].ChildNodes.RemoveAt(dt.Rows.Count);
                        else
                            TreeView1.Nodes[0].ChildNodes.RemoveAt(dt.Rows.Count);
                        depth--;
                    }
                    while (depth < dt.Rows.Count)
                    {
                        TreeNode ChileNode = new TreeNode();
                        ChileNode.Text = "第" + (depth + 1).ToString() + "题";
                        ChileNode.Value = (depth + 1 + 100).ToString();
                        ChileNode.ImageUrl = "~/images/item1.png";
                        TreeView1.Nodes[1].ChildNodes.Add(ChileNode);
                        depth++;
                    }
                }
                else
                {
                    //移除根结点
                    if (root == 1)
                        TreeView1.Nodes.Remove(TreeView1.Nodes[0]);
                    else
                        TreeView1.Nodes.Remove(TreeView1.Nodes[1]);
                    root--;
                    Session["root_filling"] = 0;
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Student.Paper_Filling[i, 0] = dt.Rows[i]["Number"].ToString().Trim();
                    Student.Paper_Filling[i, 1] = dt.Rows[i]["Subject"];
                    Student.Paper_Filling[i, 2] = dt.Rows[i]["Answer1"].ToString().Trim();
                    Student.Paper_Filling[i, 3] = dt.Rows[i]["Answer2"].ToString().Trim();
                    Student.Paper_Filling[i, 4] = dt.Rows[i]["Answer3"].ToString().Trim();
                    Student.Paper_Filling[i, 11] = Convert.ToInt32(filling.Rows[i]["Value"]);
                }
            }
            else
                for (int i = 0; i < 4; i++)
                {
                    Student.Paper_Filling[i, 0] = dt.Rows[i]["Number"].ToString().Trim();
                    Student.Paper_Filling[i, 1] = dt.Rows[i]["Subject"];
                    Student.Paper_Filling[i, 2] = dt.Rows[i]["Answer1"].ToString().Trim();
                    Student.Paper_Filling[i, 3] = dt.Rows[i]["Answer2"].ToString().Trim();
                    Student.Paper_Filling[i, 4] = dt.Rows[i]["Answer3"].ToString().Trim();
                    Student.Paper_Filling[i, 11] = Convert.ToInt32(filling.Rows[i]["Value"]);
                }
            Session["save_filling_num"] = dt.Rows.Count;//记录抽取到的填空题的个数
                                                        //以下数据库操作需要事务处理，一次性完成

            //-------------------抽取题目结束-------------------//

            //设置答题的初始题型
            if (Convert.ToInt32(Session["save_choice_num"]) != 0)
            {
                Session["NowType"] = 1; //表示当前的题型。1、选择题；2、程序填空题
                Session["first"] = 1;
            }
            else if (Convert.ToInt32(Session["save_filling_num"]) != 0)
            {
                Session["NowType"] = 2; //表示当前的题型。1、选择题；2、程序填空题
                Session["first"] = 2;
            }
            else
            {
                this.Page.RegisterStartupScript("ss", "<script>alert('该范围内没有题目，请重新选择!')</script>");
                return;
            }
            if (Convert.ToInt32(Session["save_filling_num"]) != 0)
                Session["end"] = 2;
            else
                Session["end"] = 1;
            Session["NowIndex"] = 1; //表示现在选中题目的索引（目前是第几题），从1开始。           

            //默认程序运行选择题的第一题被选中
            NoneDivAll();//隐藏全部的盒子
            if (Convert.ToInt32(Session["save_choice_num"]) != 0)
            {
                xiaoti1.Style["background-color"] = "rgb(255,128,128)";
                choice1.Style["display"] = "block";//显示选择题的答题框
                DisDivChoice();//显示选择题的小题样式
                //隐藏选择小题显示多出来的部分
                for (int i = Convert.ToInt32(Session["save_choice_num"]) + 1; i <= 30; i++)
                    According_title(i);
                SaveStuAnswer1();
                dati.Text = "单项选择题：每题" + Student.Paper_Choice[(int)Session["NowIndex"] - 1, 5].ToString() + "分。";
            }
            else if (Convert.ToInt32(Session["save_filling_num"]) != 0)
            {
                xiaoti101.Style["background-color"] = "rgb(255,128,128)";
                filling1.Style["display"] = "block";//显示填空题的答题框
                DisDivFilling();//显示填空题的题型
                //隐藏填空题小题显示多出来的部分
                for (int i = Convert.ToInt32(Session["save_filling_num"]) + 101; i <= 110; i++)
                    According_title(i);
                SaveStuAnswer1();
                dati.Text = "程序填空题：每题3小题，每小题" + Student.Paper_Filling[(int)Session["NowIndex"] - 1, 11].ToString() + "分。";
            }

            TreeView1.Nodes[0].ChildNodes[0].ImageUrl = "~/images/item2.png";//第一个结点的第一个子结点默认选中



            //首先初始化学生答案和得分，定义：当答案为空时，此题未做。
            for (int i = 0; i < Convert.ToInt32(Session["save_choice_num"]); i++)
            {
                if (remaintime == 120)
                    Student.Paper_Choice[i, 3] = "";
                else
                    Student.Paper_Choice[i, 3] = Convert.ToString(choice.Rows[i]["StudentAnswer"]);
                Student.Paper_Choice[i, 4] = 0;
            }
            for (int i = 0; i < Convert.ToInt32(Session["save_filling_num"]); i++)
            {
                if (remaintime == 120)
                {
                    Student.Paper_Filling[i, 5] = "";
                    Student.Paper_Filling[i, 6] = "";
                    Student.Paper_Filling[i, 7] = "";
                }
                else
                {
                    Student.Paper_Filling[i, 5] = Convert.ToString(filling.Rows[i]["StudentAnswer1"]);
                    Student.Paper_Filling[i, 6] = Convert.ToString(filling.Rows[i]["StudentAnswer2"]);
                    Student.Paper_Filling[i, 7] = Convert.ToString(filling.Rows[i]["StudentAnswer3"]);
                }
                Student.Paper_Filling[i, 8] = 0;
                Student.Paper_Filling[i, 9] = 0;
                Student.Paper_Filling[i, 10] = 0;
            }
            //将存储到的题目以及答案存储到session变量中
            Session["Title"] = Student;
            Subject_title.Text = "";//先清空之前的题目
            string s = "";
            if (Convert.ToInt32(Session["save_choice_num"]) != 0)
                Subject_title.Text = ((Exam)Session["Title"]).Paper_Choice[(int)Session["NowIndex"] - 1, 1].ToString();
            else if (Convert.ToInt32(Session["save_filling_num"]) != 0)
                Subject_title.Text = ((Exam)Session["Title"]).Paper_Filling[(int)Session["NowIndex"] - 1, 1].ToString();

            PreTitle.Enabled = true;//启用上一题按钮
            NextTitle.Enabled = true;//启用下一题按钮
            change.Enabled = true;//启用改卷按钮            
            xiaoti.Text = "【第1题 未做】";

        }
        //根据传入的参数确定小题logo哪个隐藏
        public void According_title(int i)
        {
            ((HtmlGenericControl)(xiao.FindControl("xiaoti" + i.ToString()))).Style["display"] = "none";
        }
        //清空重新创建结点
        public void AddNodes()
        {
            while (Convert.ToInt32(Session["root"]) != 0)//先清除所有的结点
            {
                TreeView1.Nodes.Remove(TreeView1.Nodes[0]);
                Session["root"] = Convert.ToInt32(Session["root"]) - 1;
            }
            //恢复之前的所有结点
            TreeNode RootNode1 = new TreeNode();
            RootNode1.Text = "单项选择题";
            RootNode1.ImageUrl = "~/images/item1.png";
            RootNode1.Expand();
            TreeView1.Nodes.Add(RootNode1);
            for (int i = 0; i < 23; i++)
            {
                TreeNode ChileNode = new TreeNode();
                ChileNode.Text = "第" + (i + 1).ToString() + "题";
                ChileNode.Value = (i + 1).ToString();
                ChileNode.ImageUrl = "~/images/item1.png";
                TreeView1.Nodes[0].ChildNodes.Add(ChileNode);
            }
            TreeNode RootNode2 = new TreeNode();
            RootNode2.Text = "程序填空题";
            RootNode2.ImageUrl = "~/images/item1.png";
            RootNode2.Expand();
            TreeView1.Nodes.Add(RootNode2);
            for (int i = 0; i < 4; i++)
            {
                TreeNode ChileNode = new TreeNode();
                ChileNode.Text = "第" + (i + 1).ToString() + "题";
                ChileNode.Value = (i + 24).ToString();
                ChileNode.ImageUrl = "~/images/item1.png";
                TreeView1.Nodes[1].ChildNodes.Add(ChileNode);
            }
            TreeNode RootNode3 = new TreeNode();
            RootNode3.Text = "程序阅读题";
            RootNode3.ImageUrl = "~/images/item1.png";
            RootNode3.Expand();
            TreeView1.Nodes.Add(RootNode3);
            for (int i = 0; i < 5; i++)
            {
                TreeNode ChileNode = new TreeNode();
                ChileNode.Text = "第" + (i + 1).ToString() + "题";
                ChileNode.Value = (i + 28).ToString();
                ChileNode.ImageUrl = "~/images/item1.png";
                TreeView1.Nodes[2].ChildNodes.Add(ChileNode);
            }
            TreeNode RootNode4 = new TreeNode();
            RootNode4.Text = "程序设计题";
            RootNode4.ImageUrl = "~/images/item1.png";
            RootNode4.Expand();
            TreeView1.Nodes.Add(RootNode4);
            for (int i = 0; i < 3; i++)
            {
                TreeNode ChileNode = new TreeNode();
                ChileNode.Text = "第" + (i + 1).ToString() + "题";
                ChileNode.Value = (i + 33).ToString();
                ChileNode.ImageUrl = "~/images/item1.png";
                TreeView1.Nodes[3].ChildNodes.Add(ChileNode);
            }
        }
        //关闭得分层
        protected void Button6_Click(object sender, EventArgs e)
        {
            showscore.Style["display"] = "none";
        }
        //显示得分
        public void ShowScore()
        {
            int reallyAllScore = 0;
            if (Convert.ToInt32(Session["save_choice_num"]) != 0)
            {
                TableRow tr = new TableRow();
                TableCell tc1 = new TableCell();
                tc1.Text = "<strong>单项选择题</strong>";
                tc1.RowSpan = Convert.ToInt32(Session["save_choice_num"]);
                TableCell tc2 = new TableCell();
                tc2.Text = "<strong>第1题:" + ((Exam)Session["Title"]).Paper_Choice[0, 5].ToString() + "分</strong>";
                TableCell tc3 = new TableCell();
                tc3.Text = ((Exam)Session["Title"]).Paper_Choice[0, 4].ToString();
                tr.Controls.Add(tc1);
                tr.Controls.Add(tc2);
                tr.Controls.Add(tc3);
                countscore.Controls.Add(tr);
                for (int i = 2; i <= Convert.ToInt32(Session["save_choice_num"]); i++)
                {
                    TableRow trs = new TableRow();
                    TableCell tcs1 = new TableCell();
                    tcs1.Text = "<strong>第" + i.ToString() + "题:" + ((Exam)Session["Title"]).Paper_Choice[i - 1, 5].ToString() + "分</strong>";
                    TableCell tcs2 = new TableCell();
                    tcs2.Text = ((Exam)Session["Title"]).Paper_Choice[i - 1, 4].ToString();
                    trs.Controls.Add(tcs1);
                    trs.Controls.Add(tcs2);
                    countscore.Controls.Add(trs);
                }
                for (int i = 0; i < Convert.ToInt32(Session["save_choice_num"]); i++)
                    reallyAllScore += Convert.ToInt32(((Exam)Session["Title"]).Paper_Choice[i, 5]);
            }
            if (Convert.ToInt32(Session["save_filling_num"]) != 0)
            {
                TableRow tr = new TableRow();
                TableCell tc1 = new TableCell();
                tc1.Text = "<strong>程序填空题</strong>";
                tc1.RowSpan = Convert.ToInt32(Session["save_filling_num"]);
                TableCell tc2 = new TableCell();
                tc2.Text = "<strong>第1题:" + ((Exam)Session["Title"]).Paper_Filling[0, 11].ToString() + "分</strong>";
                TableCell tc3 = new TableCell();
                tc3.Text = ((int)((Exam)Session["Title"]).Paper_Filling[0, 8] + (int)((Exam)Session["Title"]).Paper_Filling[0, 9] + (int)((Exam)Session["Title"]).Paper_Filling[0, 10]).ToString();
                tr.Controls.Add(tc1);
                tr.Controls.Add(tc2);
                tr.Controls.Add(tc3);
                countscore.Controls.Add(tr);
                for (int i = 2; i <= Convert.ToInt32(Session["save_filling_num"]); i++)
                {
                    TableRow trs = new TableRow();
                    TableCell tcs1 = new TableCell();
                    tcs1.Text = "<strong>第" + i.ToString() + "题:" + ((Exam)Session["Title"]).Paper_Filling[i - 1, 11].ToString() + "分</strong>";
                    TableCell tcs2 = new TableCell();
                    tcs2.Text = ((int)((Exam)Session["Title"]).Paper_Filling[i - 1, 8] + (int)((Exam)Session["Title"]).Paper_Filling[i - 1, 9] + (int)((Exam)Session["Title"]).Paper_Filling[i - 1, 10]).ToString();
                    trs.Controls.Add(tcs1);
                    trs.Controls.Add(tcs2);
                    countscore.Controls.Add(trs);
                }
                for (int i = 0; i < Convert.ToInt32(Session["save_filling_num"]); i++)
                    reallyAllScore += Convert.ToInt32(((Exam)Session["Title"]).Paper_Filling[i, 11]);
            }
            TableRow trq = new TableRow();
            TableCell tc1q = new TableCell();
            tc1q.Style["font-size"] = "17px";
            tc1q.Style["height"] = "30px";
            tc1q.Style["background-color"] = "rgb(255,204,204)";
            Label lb = new Label();
            lb.Text = "得分:" + Session["AllScore"].ToString();
            lb.Style["margin-left"] = "387px";
            lb.Style["color"] = "#777777";
            lb.Style["font-weight"] = "bold";
            Label lb1 = new Label();
            lb1.Text = "满分:" + reallyAllScore.ToString();
            lb1.Style["color"] = "#777777";
            lb1.Style["font-weight"] = "bold";
            tc1q.Controls.Add(lb1);
            tc1q.Controls.Add(lb);
            tc1q.ColumnSpan = 3;
            trq.Controls.Add(tc1q);
            countscore.Controls.Add(trq);

            //保存成绩
            StuExam.Model.Exam_Student student = new Exam_Student();
            student.Id = Convert.ToString(Session["ExamId"]);
            student.Studentid = Convert.ToString(Session["student_Number"]);
            student.StartTime = Convert.ToDateTime(Session["StartTime"]); ;
            student.State = "已完成";
            student.Score = Convert.ToInt32(Session["AllScore"]);
            student.RemainTime = Convert.ToInt32(Session["RemainTime"]);
            if (!StuExam.DAL.Exam_Student.Update(student))
            {
                this.Page.RegisterStartupScript("ss", "<script>alert('连接失败请重新登录!')</script>");
                return;
            }
        }

        //定时器每隔一分钟连接服务器，失败代表掉线
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            //剩余时间显示
            int time = Convert.ToInt32(Session["RemainTime"]);
            //时间到，考试结束
            if (time == 1)
            {
                CountScore();
            }
            Time.InnerText = "剩余" + --time + "分钟";
            Session["RemainTime"] = time;

            if (time != 120)
            {
                //状态操作
                StuExam.Model.Exam_Student student = new Exam_Student();
                student.Id = Convert.ToString(Session["ExamId"]);
                student.Studentid = Convert.ToString(Session["student_Number"]);
                student.StartTime = Convert.ToDateTime(Session["StartTime"]);
                student.State = "掉线";
                student.Score = 0;
                student.RemainTime = time;
                if (!StuExam.DAL.Exam_Student.Update(student))
                {
                    this.Page.RegisterStartupScript("ss", "<script>alert('初始化失败请重新开始!')</script>");
                    return;
                }


                Exam paper = ((Exam)Session["Title"]);
                //选择题保存
                if (!StuExam.DAL.Choice.UpdateList(paper.Paper_Choice, Convert.ToString(Session["ExamId"]), Convert.ToString(Session["student_Number"]), Convert.ToInt32(Session["save_choice_num"])))
                {
                    this.Page.RegisterStartupScript("ss", "<script>alert('更新失败请重新连接!')</script>");
                    return;
                }

                //填空题保存
                if (!StuExam.DAL.Filling.UpdateList(paper.Paper_Filling, Convert.ToString(Session["ExamId"]), Convert.ToString(Session["student_Number"]), Convert.ToInt32(Session["save_filling_num"])))
                {
                    this.Page.RegisterStartupScript("ss", "<script>alert('更新失败请重新连接!')</script>");
                    return;
                }
                //this.Page.RegisterStartupScript("ss", "<script>alert('更新成功!')</script>");
            }

        }
    }
}