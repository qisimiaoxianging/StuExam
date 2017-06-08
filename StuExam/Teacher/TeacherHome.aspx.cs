using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StuExam.Teacher
{
    public partial class TeacherHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label3.Text = Session["teacher_Name"].ToString();
            Label2.Text = Session["teacher_Number"].ToString();
            li3.Style["background"] = "white";
            LinkButton3.Style["color"] = "rgb(144,175,199)";
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            iframe1.Attributes["src"] = "Item.aspx";
            iframe1.Style["display"] = "block";
            li1.Style["background"] = "rgb(144,175,199)";
            li3.Style["background"] = "rgb(144,175,199)";
            LinkButton1.Style["color"] = "white";
            LinkButton3.Style["color"] = "white";
            li2.Style["background"] = "white";
            LinkButton2.Style["color"] = "rgb(144,175,199)";
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            iframe1.Attributes["src"] = "ModifyPassword.aspx";
            iframe1.Style["display"] = "block";
            li2.Style["background"] = "rgb(144,175,199)";
            li3.Style["background"] = "rgb(144,175,199)";
            LinkButton2.Style["color"] = "white";
            LinkButton3.Style["color"] = "white";
            li1.Style["background"] = "white";
            LinkButton1.Style["color"] = "rgb(144,175,199)";
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            iframe1.Attributes["src"] = "Assignment_work.aspx";
            iframe1.Style["display"] = "block";
            li2.Style["background"] = "rgb(144,175,199)";
            li1.Style["background"] = "rgb(144,175,199)";
            LinkButton2.Style["color"] = "white";
            LinkButton1.Style["color"] = "white";
            li3.Style["background"] = "white";
            LinkButton3.Style["color"] = "rgb(144,175,199)";
        }
    }
}