using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Text;
using System.Collections;

namespace StuExam.Teacher
{
    public partial class Assignment_work : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                dt = StuExam.DAL.Teacher_Coure.GetList_year("teacherID='" + Session["teacher_Number"] + "'");
                for (int i = 0; i < dt.Rows.Count; i++)//添加学年
                {
                    DropDownList3.Items.Add(dt.Rows[i]["academic_year"].ToString());
                }
                dt = StuExam.DAL.Teacher_Coure.GetList_Class("teacherID='" + Session["teacher_Number"] + "'and academic_year='" + DropDownList3.SelectedValue + "'and school_term='" + DropDownList4.SelectedValue + "'");//根据登录时的session传值
                for (int i = 0; i < dt.Rows.Count; i++)//添加专业班级
                {
                    DropDownList1.Items.Add(dt.Rows[i]["Class"].ToString());
                }
                dt = StuExam.DAL.Teacher_Coure.GetList("Class='" + DropDownList1.SelectedValue + "'and teacherID='" + Session["teacher_Number"] + "'and academic_year='" + DropDownList3.SelectedValue + "'and school_term='" + DropDownList4.SelectedValue + "'");
                for (int i = 0; i < dt.Rows.Count; i++)//添加专业课程
                {
                    DropDownList2.Items.Add(dt.Rows[i]["Course"].ToString());
                }
            }
            if (DropDownList1.SelectedValue != "")
            {
                if (DropDownList2.SelectedValue != "")
                {
                    homework.Style["display"] = "block";//显示表格
                    if (DropDownList2.SelectedValue == "高级语言程序设计C")
                    {
                        //根据拼接的查询条件生成作业表单
                        DataTable dt = new DataTable();
                        dt = StuExam.DAL.Exam.GetList("Professional_class='" + DropDownList1.SelectedValue + "'");
                        createtable(dt);
                        Session["dt"] = dt;
                    }
                    //addtablerow();
                    //后续或根据具体情况扩充数据库。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。
                }
                else
                {
                    this.Page.RegisterStartupScript("ss", "<script>alert('请选择专业课程!')</script>");
                    return;
                }
            }
            else
            {
                this.Page.RegisterStartupScript("ss", "<script>alert('请选择专业班级!')</script>");
                return;
            }
            actiontime.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }
        //专业班级改变事件
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = StuExam.DAL.Teacher_Coure.GetList_Course("Class='" + DropDownList1.SelectedValue + "'");
            if (dt.Rows.Count != 0)
            {
                DropDownList2.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)//填充专业课程
                {
                    DropDownList2.Items.Add(dt.Rows[i]["Course"].ToString());
                }
            }
        }
        //创建表格的已有的部分
        public void createtable(DataTable dt)
        {
            //想爱你清空之前的部分
            for (int i = 1; i < this.tabShow.Rows.Count - 1; i++)
            {
                this.tabShow.Rows.RemoveAt(1);
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TableRow row = new TableRow();//行
                TableCell cell1 = new TableCell();//章起
                cell1.Text = dt.Rows[i]["chapter_strat"].ToString();
                TableCell cell3 = new TableCell();//章末
                cell3.Text = dt.Rows[i]["chapter_stop"].ToString();
                TableCell cell4 = new TableCell();//基本信息
                cell4.Text = dt.Rows[i]["Describe"].ToString();
                TableCell cell8 = new TableCell();//发布日期
                DateTime time1 = Convert.ToDateTime(dt.Rows[i]["actiontime"]);
                cell8.Text = time1.ToString("yyyy-MM-dd");
                TableCell cell6 = new TableCell();//截止日期
                DateTime time = Convert.ToDateTime(dt.Rows[i]["stoptime"]);
                cell6.Text = time.ToString("yyyy-MM-dd");


                TableCell cell7 = new TableCell();//操作
                LinkButton bt = new LinkButton();
                bt.Text = "查看";
                bt.CommandArgument = i.ToString();
                bt.Command += new CommandEventHandler(this.lnk_check_Command);//为查看按钮添加单击事件
                cell7.Controls.Add(bt);

                row.Cells.Add(cell1);
                row.Cells.Add(cell3);
                row.Cells.Add(cell4);
                //row.Cells.Add(cell5);
                row.Cells.Add(cell8);
                row.Cells.Add(cell6);
                row.Cells.Add(cell7);
                this.tabShow.Rows.AddAt(1, row); //最后将行添加到tabShow中
            }
        }
        //学年改变事件        
        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = StuExam.DAL.Teacher_Coure.GetList_Class("teacherID='" + 20120101 + "'and academic_year='" + DropDownList3.SelectedValue + "'and school_term='" + DropDownList4.SelectedValue + "'");//根据登录时的session传值
            if (dt.Rows.Count != 0)
            {
                DropDownList1.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)//添加专业班级
                {
                    DropDownList1.Items.Add(dt.Rows[i]["Class"].ToString());
                }
            }
            dt = StuExam.DAL.Teacher_Coure.GetList("Class='" + DropDownList1.SelectedValue + "'and teacherID='" + 20120101 + "'and academic_year='" + DropDownList3.SelectedValue + "'and school_term='" + DropDownList4.SelectedValue + "'");
            if (dt.Rows.Count != 0)
            {
                DropDownList2.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)//添加专业课程
                {
                    DropDownList2.Items.Add(dt.Rows[i]["Course"].ToString());
                }
            }
        }
        //学期改变事件
        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = StuExam.DAL.Teacher_Coure.GetList_Class("teacherID='" + 20120101 + "'and academic_year='" + DropDownList3.SelectedValue + "'and school_term='" + DropDownList4.SelectedValue + "'");//根据登录时的session传值
            if (dt.Rows.Count != 0)
            {
                DropDownList1.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)//添加专业班级
                {
                    DropDownList1.Items.Add(dt.Rows[i]["Class"].ToString());
                }
            }
            dt = StuExam.DAL.Teacher_Coure.GetList("Class='" + DropDownList1.SelectedValue + "'and teacherID='" + 20120101 + "'and academic_year='" + DropDownList3.SelectedValue + "'and school_term='" + DropDownList4.SelectedValue + "'");
            if (dt.Rows.Count != 0)
            {
                DropDownList2.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)//添加专业课程
                {
                    DropDownList2.Items.Add(dt.Rows[i]["Course"].ToString());
                }
            }
        }
        //查看作业完成情况
        protected void lnk_check_Command(object sender, CommandEventArgs e)
        {
            this.Page.RegisterStartupScript("ss", "<script>alert('单击查看作业!')</script>");

            string id = e.CommandArgument.ToString();
            string actiontime, stoptime;
            int m = Convert.ToInt32(id) + 1; //获得当前点击的是哪个作业链接
            for (int i = 0; i < tabShow.Rows.Count; i++)
            {
                if (m == i)//确定是点击哪个链接之后，确定对应的信息
                {
                    Session["actiontime"] = ((DataTable)Session["dt"]).Rows[m - 1]["actiontime"].ToString();
                    stoptime = ((DataTable)Session["dt"]).Rows[m - 1]["stoptime"].ToString();
                    break;
                }
            }
            Check.Style["display"] = "block";
            check_situation.Rows.Clear();
            //select.Style["display"] = "none";
            TableRow head = new TableRow();
            TableCell head1 = new TableCell();
            head1.Text = "学号";
            head1.CssClass = "head";
            TableCell head2 = new TableCell();
            head2.Text = "姓名";
            head2.CssClass = "head";
            TableCell head3 = new TableCell();
            head3.Text = "答题次数";
            head3.CssClass = "head";
            TableCell head4 = new TableCell();
            head4.Text = "答题时间";
            head4.CssClass = "head";
            TableCell head5 = new TableCell();
            head5.Text = "得分";
            head5.CssClass = "head";
            head.Cells.Add(head1);
            head.Cells.Add(head2);
            head.Cells.Add(head3);
            head.Cells.Add(head4);
            head.Cells.Add(head5);
            check_situation.Rows.Add(head);
            DataTable stuID = new DataTable();
            stuID = StuExam.DAL.Student.GetList("Class='" + DropDownList1.SelectedValue.ToString() + "'");//获得学号
            for (int i = 0; i < stuID.Rows.Count; i++)
            {
                TableRow tr = new TableRow();
                TableCell ID = new TableCell();
                ID.Text = stuID.Rows[i]["StudentId"].ToString();
                TableCell name = new TableCell();
                name.Text = stuID.Rows[i]["Name"].ToString();
                DataTable stuhomework = new DataTable();
                stuhomework = StuExam.DAL.Stuhomework.GetList_byscore(" StudentId='" + stuID.Rows[i]["StudentId"].ToString() + "' and  actiontime='" + Session["actiontime"].ToString().Substring(0, 10) + "'");
                TableCell count = new TableCell();
                count.Text = stuhomework.Rows[0]["count_answer"].ToString();
                TableCell score = new TableCell();
                score.Text = stuhomework.Rows[0]["hwScore"].ToString();
                TableCell maketime = new TableCell();
                maketime.Text = stuhomework.Rows[0]["maketime"].ToString();
                tr.Controls.Add(ID);
                tr.Controls.Add(name);
                tr.Controls.Add(count);
                tr.Controls.Add(maketime);
                tr.Controls.Add(score);
                check_situation.Rows.Add(tr);
            }
        }

        //起始章节改变事件
        protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList6.Items.Clear();//清空之前的小节
            DataTable dt = new DataTable();
            if (DropDownList5.SelectedValue == "第10章")
                dt = StuExam.DAL.chapter_Scope.GetList("chapter=" + 10 + "");
            else
                dt = StuExam.DAL.chapter_Scope.GetList("chapter=" + DropDownList5.SelectedValue.Substring(1, 1) + "");
            for (int i = 0; i < Convert.ToInt32(dt.Rows[0]["sections_num"]); i++)
                DropDownList6.Items.Add("第" + (i + 1).ToString() + "节");
        }
        //末尾章节改变事件
        protected void DropDownList7_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList8.Items.Clear();//清空之前的小节
            DataTable dt = new DataTable();
            if (DropDownList7.SelectedValue == "第10章")
                dt = StuExam.DAL.chapter_Scope.GetList("chapter=" + 10 + "");
            else
                dt = StuExam.DAL.chapter_Scope.GetList("chapter=" + DropDownList7.SelectedValue.Substring(1, 1) + "");
            for (int i = 0; i < Convert.ToInt32(dt.Rows[0]["sections_num"]); i++)
                DropDownList8.Items.Add("第" + (i + 1).ToString() + "节");
        }
        //点击选择日历时间
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            calender.Style["display"] = "block";
            Calendar1.Enabled = true;
        }
        //禁用日历之前的日期
        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date < DateTime.Now.Date)
            {
                e.Day.IsSelectable = false;
            }
        }
        //点击生成考试
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            /*先判断章节范围是否正确*/
            int action_chapter;//记录起始章
            if (DropDownList9.SelectedValue != "第10章")
                action_chapter = Convert.ToInt32(DropDownList5.SelectedValue.Substring(1, 1));
            else
                action_chapter = 10;
            int end_chapter;//记录结束章
            if (DropDownList10.SelectedValue != "第10章")
                end_chapter = Convert.ToInt32(DropDownList7.SelectedValue.Substring(1, 1));
            else
                end_chapter = 10;
            int action_section = Convert.ToInt32(DropDownList6.SelectedValue.Substring(1, 1));//记录开始小节
            int end_section = Convert.ToInt32(DropDownList8.SelectedValue.Substring(1, 1));//记录结束小节

            int choice_num1 = Convert.ToInt32(TextBox2.Text.ToString());//选择题1的数目
            double choice_value1 = Convert.ToInt32(TextBox3.Text.ToString());//选择题1的分值
            int choice_num2 = Convert.ToInt32(TextBox4.Text.ToString());//选择题2的数目
            double choice_value2 = Convert.ToInt32(TextBox5.Text.ToString());//选择题2的分值

            int fill_num1 = Convert.ToInt32(TextBox6.Text.ToString());//填空题1的数目
            double fill_value1 = Convert.ToInt32(TextBox7.Text.ToString());//填空题1的分值
            int fill_num2 = Convert.ToInt32(TextBox8.Text.ToString());//填空题2的数目
            double fill_value2 = Convert.ToInt32(TextBox9.Text.ToString());//填空题2的分值

            if (choice_num1 * choice_value1 + choice_num2 * choice_value2 + fill_num1 * fill_value1 * 3 + fill_num2 * fill_value2 * 3 != 100)
            {
                this.Page.RegisterStartupScript("ss", "<script>alert('您选择的分值不为100，请重新选择!')</script>");
            }

            if (action_chapter > end_chapter)
            {
                this.Page.RegisterStartupScript("ss", "<script>alert('起始章应该小于终止章，请重新选择!')</script>");
                return;
            }
            string time = "";
            time = addtime.Value.ToString();
            if (time.Equals("") || time.Equals(null))
            {
                this.Page.RegisterStartupScript("ss", "<script>alert('您未选择时间，请选择!')</script>");
                return;
            }

            //考卷Id
            string ExamId = DateTime.Now.ToString("yyyyMMddhhmmss");
            //题目类型及分值
            StringBuilder sb = new StringBuilder();
            sb.Append("[{");
            sb.Append("\"choice_num1\":\"" + choice_num1.ToString() + "\",");
            sb.Append("\"choice_value1\":\"" + choice_value1.ToString() + "\",");
            sb.Append("\"choice_num2\":\"" + choice_num2.ToString() + "\",");
            sb.Append("\"choice_value2\":\"" + choice_value2.ToString() + "\",");
            sb.Append("\"fill_num1\":\"" + fill_num1.ToString() + "\",");
            sb.Append("\"fill_value1\":\"" + fill_value1.ToString() + "\",");
            sb.Append("\"fill_num2\":\"" + fill_num2.ToString() + "\",");
            sb.Append("\"fill_value2\":\"" + fill_value2.ToString() + "\"");
            sb.Append("}]");




            //选取所有的题目进行选择
            DataTable choice = new DataTable();
            DataTable finlling = new DataTable();
            DataTable choice_paper = new DataTable();
            DataTable finlling_paper = new DataTable();
            DataTable Student = new DataTable();
            DataTable Exam_Student = new DataTable();
            string Range = "Chapter>=" + action_chapter + " and Chapter<=" + end_chapter + "";
            choice = StuExam.DAL.Choice.GetList(Range);
            if (choice.Rows.Count <= choice_num1 + choice_num2)
            {
                this.Page.RegisterStartupScript("ss", "<script>alert('选择题总题数不足，请重新选择!')</script>");
                return;
            }
            finlling = StuExam.DAL.Filling.GetList(Range);
            if (finlling.Rows.Count <= fill_num1 + fill_num2)
            {
                this.Page.RegisterStartupScript("ss", "<script>alert('填空题总题数不足，请重新选择!')</script>");
                return;
            }

            string te = "";
            //产生出题随机数
            long tick = DateTime.Now.Ticks;
            Random ran = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
            int[] mapchoice = new int[choice.Rows.Count];
            int[] mapfilling = new int[finlling.Rows.Count];
            //生成考卷datatable
            choice_paper.Clear();
            choice_paper.Columns.Add("Id");
            choice_paper.Columns.Add("Number");
            choice_paper.Columns.Add("Subject");
            choice_paper.Columns.Add("Answer");
            choice_paper.Columns.Add("Value");
            //循环添加
            for (int i = 0; i < choice_num1 + choice_num2; i++)
            {
                int j = ran.Next(choice.Rows.Count);
                if (mapchoice[j] != 1)
                {
                    DataRow dr = choice_paper.NewRow();
                    dr["Id"] =
                        ExamId.ToString();
                    dr["Number"] = choice.Rows[j]["Number"].ToString();
                    dr["Subject"] = choice.Rows[j]["Subject"].ToString();
                    dr["Answer"] = choice.Rows[j]["Answer"].ToString();
                    if (i < choice_num1)
                        dr["Value"] = choice_value1;
                    else
                        dr["Value"] = choice_value2;
                    choice_paper.Rows.Add(dr);
                    mapchoice[j] = 1;
                }
                else
                    i--;
            }

            //生成考卷datatable
            finlling_paper.Clear();
            finlling_paper.Columns.Add("Id");
            finlling_paper.Columns.Add("Number");
            finlling_paper.Columns.Add("Subject");
            finlling_paper.Columns.Add("Answer1");
            finlling_paper.Columns.Add("Answer2");
            finlling_paper.Columns.Add("Answer3");
            finlling_paper.Columns.Add("Value");
            for (int i = 0; i < fill_num1 + fill_num2; i++)
            {
                int j = ran.Next(finlling.Rows.Count);
                if (mapfilling[j] != 1)
                {
                    DataRow dr = finlling_paper.NewRow();
                    dr["Id"] =
                        ExamId.ToString();
                    dr["Number"] = finlling.Rows[j]["Number"].ToString();
                    dr["Subject"] = finlling.Rows[j]["Subject"].ToString();
                    dr["Answer1"] = finlling.Rows[j]["Answer1"].ToString();
                    dr["Answer2"] = finlling.Rows[j]["Answer2"].ToString();
                    dr["Answer3"] = finlling.Rows[j]["Answer3"].ToString();
                    if (i < fill_num1)
                        dr["Value"] = fill_value1;
                    else
                        dr["Value"] = fill_value2;
                    finlling_paper.Rows.Add(dr);
                    mapfilling[j] = 1;
                }
                else
                    i--;
            }
            //获取该班级人员
            Student = StuExam.DAL.Student.GetList("Class='" + DropDownList1.SelectedValue + "'");
            //生成成绩表
            Exam_Student.Clear();
            Exam_Student.Columns.Add("Id");
            Exam_Student.Columns.Add("StudentId");
            Exam_Student.Columns.Add("ExamTime");
            Exam_Student.Columns.Add("StartTime");
            Exam_Student.Columns.Add("RemainTime");
            Exam_Student.Columns.Add("State");
            Exam_Student.Columns.Add("Score");
            for (int i = 0; i < Student.Rows.Count; i++)
            {
                DataRow dr = Exam_Student.NewRow();
                dr["Id"] = ExamId.ToString();
                dr["StudentId"] = Student.Rows[i]["StudentId"].ToString();
                dr["ExamTime"] = 0;
                dr["StartTime"] = null;
                dr["RemainTime"] = 120;
                dr["State"] = "未答卷";
                dr["Score"] = 0;
                Exam_Student.Rows.Add(dr);
            }

            //表明考试生成成功，接下来插入对应的数据库（根据课程名称）
            StuExam.Model.Exam model = new Model.Exam();
            model.Id = ExamId;
            model.Describe = TextBox10.Text.ToString();
            model.Professional_class = DropDownList1.SelectedValue.ToString();
            model.chapter_strat = action_chapter;
            model.chapter_stop = end_chapter;
            model.actiontime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            model.stoptime = Convert.ToDateTime(time);
            model.info = sb.ToString();

            try
            {
                //将考试添加到homewoek表
                StuExam.DAL.Exam.Add(model);
                //将试卷中的选择题插入
                StuExam.DAL.Choice.AddList(choice_paper);
                //将试卷中的填空题插入
                StuExam.DAL.Filling.AddList(finlling_paper);
                //将相关信息插入成绩表
                StuExam.DAL.Exam_Student.AddList(Exam_Student);
            }
            catch (Exception ex)
            {
                StuExam.DAL.Exam.Delete(ExamId.ToString());
                this.Page.RegisterStartupScript("ss", "<script>alert('试卷生成失败，请重新选择!')</script>");
                return;
            }
            DataTable dt = StuExam.DAL.Exam.GetList("Professional_class='" + DropDownList1.SelectedValue + "'");
            createtable(dt);

        }
        //点击链接选择日历时间事件
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            calenderButton.Text = Calendar1.SelectedDate.Year.ToString() + "-" + Calendar1.SelectedDate.Month.ToString() + "-" + Calendar1.SelectedDate.Day.ToString();
            Session["calenderButton"] = calenderButton.Text;
            calender.Style["display"] = "none";//隐藏日历框
            Calendar1.Enabled = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //string username = Request.Form.Get("addtime").ToString();
            //string username = addtime.Value.ToString();
            //Response.Write("<script>alert('"+ username.Substring(3,5) + "');</script>");
            //Response.Write("<script>alert('" + TextBox2.Text.ToString() + "');</script>");
            //int choice_num1 = Convert.ToInt32(TextBox2.ToString());//选择题1的数目
        }
    }
}