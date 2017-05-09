using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StuExam.Students
{
    public partial class Management : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label2.Text = Session["student_Number"].ToString();
            Label3.Text = Session["student_Name"].ToString();
            Label4.Text = Session["student_Profession"].ToString();
            Label5.Text = Session["student_Class"].ToString();
        }
    }
}