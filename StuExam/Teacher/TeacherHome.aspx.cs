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
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            iframe1.Attributes["src"] = "Item.aspx";
            iframe1.Style["display"] = "block";
            li2.Style["background"] = "rgb(144,175,199)";
            LinkButton2.Style["color"] = "white";
        }
    }
}