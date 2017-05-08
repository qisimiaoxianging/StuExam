using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StuExam
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btXs_Click(object sender, EventArgs e)
        {
            if (username.Text.Trim().Length == 8)
            {
                if (StuExam.DAL.Teacher.Exists(username.Text.Trim(), password.Text.Trim()) == 0)
                {
                    Error1.Text = "账号或者密码错误";
                    return;
                }
                else
                {
                    Session["teacher_Number"] = username.Text.Trim();//存储老师的工号
                    StuExam.Model.Teacher model = new StuExam.Model.Teacher();
                    model = StuExam.DAL.Teacher.GetModel(username.Text.Trim(), password.Text.Trim());
                    Session["teacher_Name"] = model.Name;//获取该教师的名字
                    Response.Redirect("./Teacher/TeacherHome.aspx");
                }
            }
            else if (username.Text.Trim().Length == 12)
            {
                if (StuExam.DAL.Student.Exists(username.Text.Trim(), password.Text.Trim()) == 0)
                {
                    Error1.Text = "账号或者密码错误";
                    return;
                }
                else
                {
                    Session["student_Number"] = username.Text.Trim();//存储学生的学号
                    StuExam.Model.Student model = new StuExam.Model.Student();
                    model = StuExam.DAL.Student.GetModel(username.Text.Trim(), password.Text.Trim());
                    Session["student_Profession"] = model.Profession;//获取该生的专业
                    Session["student_Class"] = model.Class;//获取该生的专业班级
                    Session["student_Name"] = model.Name;//获取该生的名字
                    Session["number"] = 0;
                    Session["first_Management"] = 0;
                    Session["student_in"] = 2;
                    Response.Redirect("./Students/Management.aspx");
                }
            }
            else
            {
                Error1.Text = "请输入12位学号或者8位工号";
                return;
            }
        }
    }
}