using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;


namespace StuExam.Students
{
    public partial class Management : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Model"] = 1;//1表示试卷查询，2表示密码修改
                //第一次显示试卷查询界面
                frame.Style["display"] = "block";
                mark_course.Style["display"] = "block";
                Out.Style["display"] = "block";
                iframe1.Style["display"] = "none";//隐藏修改密码
                li1.Style["background"] = "rgb(144,175,199)";
                LinkButton1.Style["color"] = "white";
                li2.Style["background"] = "white";
                LinkButton2.Style["color"] = "rgb(144,175,199)";
            }

            Label2.Text = Session["student_Number"].ToString();
            Label3.Text = Session["student_Name"].ToString();
            Label4.Text = Session["student_Profession"].ToString();
            Label5.Text = Session["student_Class"].ToString();


            BindTable();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Out.Style["display"] = "none";
            iframe1.Style["display"] = "block";
            iframe1.Attributes["src"] = "ModifyPassword.aspx";
            li2.Style["background"] = "rgb(144,175,199)";
            LinkButton2.Style["color"] = "white";
            li1.Style["background"] = "white";
            LinkButton1.Style["color"] = "rgb(144,175,199)";
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Out.Style["display"] = "none";
            iframe1.Style["display"] = "block";
            iframe1.Attributes["src"] = "ModifyPassword.aspx";
            li1.Style["background"] = "rgb(144,175,199)";
            LinkButton1.Style["color"] = "white";
            li2.Style["background"] = "white";
            LinkButton2.Style["color"] = "rgb(144,175,199)";
        }


        //动态创建作业显示table控件
        private void BindTable()
        {
            //获取系统时间
            DateTime now = DateTime.Now;
            //this.tabShow.Rows.Clear(); //将数据清空
            DataTable dt = new DataTable();//将教师布置的作业信息读取出来进行存储
            DataTable dt1 = new DataTable();//将学生完成作业的信息读取出来进行存储            

            //对于数据库的选择要根据学生的当前所选的课程，先默认选择C语言
            //(按照时间顺序罗列出该班的作业)
            dt = StuExam.DAL.Exam.GetList("Professional_class='" + Session["student_Class"].ToString() + "'");//对于where后面的条件语句要根据学生登录时的专业班级进行传值
            //拼接条件字段
            string strWhere = "Id in (";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i != 0)
                    strWhere += ", '" + dt.Rows[i]["Id"].ToString() + "'";
                else
                    strWhere += "'" + dt.Rows[i]["Id"].ToString() + "'";
            }
            strWhere += ")";
            dt1 = StuExam.DAL.Exam_Student.GetList(strWhere + " and StudentId='" + Session["student_Number"].ToString() + "'");//对于where后面的条件语句要根据数据库里学生的学号

            if (dt.Rows.Count != 0 && dt1.Rows.Count != 0)
            {
                Session["jiaoshi"] = dt;
                Session["xuesheng"] = dt1;
            }
            else
            {
                this.Page.RegisterStartupScript("ss", "<script>alert('获取信息失败，请重新登录!')</script>");
                return;
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //int count = Convert.ToInt32(((DataTable)Session["xuesheng"]).Rows[i]["count_answer"]);
                DateTime stoptime = Convert.ToDateTime(((DataTable)Session["jiaoshi"]).Rows[i]["stoptime"]);
                string situation = ((DataTable)Session["xuesheng"]).Rows[i]["State"].ToString();

                TableRow row = new TableRow();//行

                TableCell cell6 = new TableCell();
                cell6.Text = (((DataTable)Session["jiaoshi"]).Rows[i]["Describe"]).ToString(); //获取发布时间;
                cell6.Style["color"] = "#777777";
                row.Cells.Add(cell6);

                TableCell cell2 = new TableCell();
                cell2.Text = Convert.ToDateTime(((DataTable)Session["jiaoshi"]).Rows[i]["actiontime"]).ToString("yyyy-MM-dd"); //获取发布时间;
                cell2.Style["color"] = "#777777";
                row.Cells.Add(cell2);

                TableCell cell3 = new TableCell();
                string time = Convert.ToDateTime(((DataTable)Session["jiaoshi"]).Rows[i]["stoptime"]).ToString("yyyy-MM-dd"); //获取截止时间
                cell3.Text = time;
                cell3.Style["color"] = "#777777";
                row.Cells.Add(cell3);

                TableCell cell4 = new TableCell();//设置答题情况
                row.Cells.Add(cell4); //将列添加到行

                TableCell cell5 = new TableCell();//设置得分
                cell5.Style["color"] = "#777777";
                row.Cells.Add(cell5);

                TableCell cell8 = new TableCell();//显示用时
                cell8.Style["color"] = "#777777";
                row.Cells.Add(cell8);

                TableCell cell7 = new TableCell();//操作列
                LinkButton Lb1 = new LinkButton(); //答题链接
                Lb1.Text = "答题";
                Lb1.Style["text-decoration"] = "none";//去掉下划线
                Lb1.CommandArgument = i.ToString();//
                if (situation == "已完成")
                {
                    Lb1.Enabled = false;
                    Lb1.Text = "已完成";
                    Lb1.Style["color"] = "#777777";
                }
                if (situation == "未答卷")
                {
                    Lb1.Command += new CommandEventHandler(this.lnk_favourite_Command);//为重做链接添加单击事件
                    Lb1.Enabled = true;
                    Lb1.Style["color"] = "#cc0fe9";
                    Lb1.CommandName = "未答卷";
                }
                if (situation == "掉线")
                {
                    Lb1.Command += new CommandEventHandler(this.lnk_favourite_Command);//为重做链接添加单击事件
                    Lb1.Enabled = true;
                    Lb1.Text = "重连";
                    Lb1.Style["color"] = "#cc0fe9";
                    Lb1.CommandName = "掉线";
                }
                DateTime time1 = Convert.ToDateTime(time);
                DateTime time2 = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                if (DateTime.Compare(time1, time2) < 0)
                {
                    Lb1.Enabled = false;
                    Lb1.Style["color"] = "#777777";
                }
                //if (DateTime.Compare(Convert.ToDateTime(cell3.Text.ToString()), DateTime.Now) < 0)
                //    Lb1.Enabled = false;
                cell7.Controls.Add(Lb1); //将链接添加到列
                row.Cells.Add(cell7);

                this.tabShow.Rows.Add(row); //最后将行添加到拖的tabShow中
            }
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                tabShow.Rows[i + 1].Cells[3].Text = ((DataTable)Session["xuesheng"]).Rows[i]["State"].ToString().Trim();
                if (((DataTable)Session["xuesheng"]).Rows[i]["State"].ToString().Trim() == "未完成")
                    tabShow.Rows[i + 1].Cells[3].Style["color"] = "#093";
                else
                    tabShow.Rows[i + 1].Cells[3].Style["color"] = "#777777";
                tabShow.Rows[i + 1].Cells[4].Text = ((DataTable)Session["xuesheng"]).Rows[i]["Score"].ToString().Trim();
                tabShow.Rows[i + 1].Cells[5].Text = (120 - Convert.ToInt32(((DataTable)Session["xuesheng"]).Rows[i]["RemainTime"].ToString())).ToString();
            }

        }


        //为答题链接添加单击事件
        protected void lnk_favourite_Command(object sender, CommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            Session["ExamId"] = ((DataTable)Session["xuesheng"]).Rows[index]["Id"].ToString();
            Session["RemainTime"] = ((DataTable)Session["xuesheng"]).Rows[index]["RemainTime"].ToString();
            if (e.CommandName == "掉线")
                Session["RemainTime"] = 120 - Convert.ToInt32(((DataTable)Session["xuesheng"]).Rows[index]["RemainTime"].ToString());
            else
                Session["RemainTime"] = 120;
            Out.Style["display"] = "none";
            op.Style["display"] = "none";
            iframe1.Style["display"] = "block";
            iframe1.Attributes["src"] = "Practice.aspx";
        }


        //确定按钮
        protected void Button2_Click(object sender, EventArgs e)
        {
            paper.Style["display"] = "none";
            if (Convert.ToInt32(Session["spare_model"]) == 1)
            {
                iframe1.Attributes["src"] = "";
            }
            if (Convert.ToInt32(Session["Model"]) == 4)
            {
                LinkButton1_Click(sender, e);//密码修改
            }
            else if (Convert.ToInt32(Session["Model"]) == 5)
            {
                LinkButton1_Click(sender, e);//我的作业
            }
            else
            {
                //LinkButton5_Click(sender, e);//返回首页
            }
        }
        //取消按钮
        protected void Button4_Click(object sender, EventArgs e)
        {
            paper.Style["display"] = "none";
            if (Convert.ToInt32(Session["spare_model"]) == 1)
                Session["Model"] = 1;
            if (Convert.ToInt32(Session["spare_model"]) == 2)
                Session["Model"] = 2;
        }
    }
}