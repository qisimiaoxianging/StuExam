using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StuExam.Students
{
    public partial class ModifyPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = Session["student_Name"].ToString();
            //success.Style["display"] = "none";
            //fail.Style["display"] = "none";
            //overdue.Style["display"] = "none";
        }
        //清空填入项
        protected void Button1_Click(object sender, EventArgs e)
        {
            Ori_Password.Text = "";
            New_Password.Text = "";
            New_Password1.Text = "";
        }
        //修改密码按钮
        protected void Button2_Click(object sender, EventArgs e)
        {
            //先判断之前的密码是否为空
            if (Ori_Password.Text.Trim() == string.Empty)
            {
                this.Page.RegisterStartupScript("ss", "<script>alert('请输入更新前的密码!')</script>");
                return;
            }
            if (New_Password.Text.Trim() == "")
            {
                this.Page.RegisterStartupScript("ss", "<script>alert('密码长度不能小于6位!')</script>");
                return;
            }
            if (New_Password.Text.Trim() != New_Password1.Text.Trim())
            {
                this.Page.RegisterStartupScript("ss", "<script>alert('两次输入的密码不一致!')</script>");
                return;
            }
            StuExam.Model.Student StuId = new Model.Student();
            StuId = StuExam.DAL.Student.GetModel(Session["student_Number"].ToString(), Ori_Password.Text.Trim());
            if (StuId == null)//检验账号密码是否正确
            {
                this.Page.RegisterStartupScript("ss", "<script>alert('密码输入错误!')</script>");
                return;
            }
            else //检验正确，进入练习界面
            {
                if (Session["teacher_Name"] != null && Session["teacher_Number"] != null)
                {
                    StuExam.Model.Student model = new Model.Student();
                    model.Name = Session["student_Name"].ToString();
                    model.StudentId = Session["student_Name"].ToString();
                    model.Password = New_Password1.Text.Trim();
                    //密码输入正确，将数据库内的密码就行修改，并进行页面跳转
                    if (StuExam.DAL.Student.Update(model))
                    {
                        //ccess.Style["display"] = "block";
                        this.Page.RegisterStartupScript("ss", "<script>alert('密码修改成功!')</script>");
                    }
                    else
                    {
                        this.Page.RegisterStartupScript("ss", "<script>alert('密码修改失败!')</script>");
                        //fail.Style["display"] = "block";
                    }
                }
                else
                {
                    this.Page.RegisterStartupScript("ss", "<script>alert('登录超时请重新登录!')</script>");
                    //overdue.Style["display"] = "block";
                }
            }
        }
    }
}