using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StuExam.Teacher
{
    public partial class WItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                li1.Style["background"] = "white";
                LinkButton1.Style["color"] = "rgb(144,175,199)";
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Man.Attributes["src"] = "ChoiceManagement.aspx";
            li1.Style["background"] = "white";
            LinkButton1.Style["color"] = "rgb(144,175,199)";
            li2.Style["background"] = "rgb(144,175,199)";
            LinkButton2.Style["color"] = "white";
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Man.Attributes["src"] = "FillingManagement.aspx";
            li2.Style["background"] = "white";
            LinkButton2.Style["color"] = "rgb(144,175,199)";
            li1.Style["background"] = "rgb(144,175,199)";
            LinkButton1.Style["color"] = "white";
        }
    }
}