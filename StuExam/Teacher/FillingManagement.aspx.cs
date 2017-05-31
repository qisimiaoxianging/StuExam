using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StuExam.Teacher
{
    public partial class FillingManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Up")
            {
                //获取当前行
                int rowIndex = Convert.ToInt32(e.CommandArgument); ;
                //获取各参数
                String Subject = ((TextBox)(GridView1.Rows[rowIndex].Cells[0].FindControl("TextBox1"))).Text.ToString();
                Subject = Subject.Replace("\r\n", "<br/>").Replace(" ", "&nbsp;");
                String Anewer1 = ((TextBox)(GridView1.Rows[rowIndex].Cells[1].FindControl("TextBox2"))).Text.ToString();
                Anewer1 = Anewer1.Replace("\r\n", "<br/>").Replace(" ", "&nbsp;");
                String Anewer2 = ((TextBox)(GridView1.Rows[rowIndex].Cells[1].FindControl("TextBox3"))).Text.ToString();
                Anewer2 = Anewer2.Replace("\r\n", "<br/>").Replace(" ", "&nbsp;");
                String Anewer3 = ((TextBox)(GridView1.Rows[rowIndex].Cells[1].FindControl("TextBox4"))).Text.ToString();
                Anewer3 = Anewer3.Replace("\r\n", "<br/>").Replace(" ", "&nbsp;");
                String Chapter = ((TextBox)(GridView1.Rows[rowIndex].Cells[2].FindControl("TextBox5"))).Text.ToString();
                String Number = GridView1.DataKeys[rowIndex].Value.ToString();
                StuExam.Model.Filling model = new Model.Filling();
                model.Number = Convert.ToUInt32(Number);
                model.Subject = Subject;
                model.Answer1 = Anewer1;
                model.Answer2 = Anewer2;
                model.Answer3 = Anewer3;
                model.Chapter = Convert.ToInt32(Chapter);
                if (StuExam.DAL.Filling.Update(model))
                {
                    this.Page.RegisterStartupScript("ss", "<script>alert('更新成功!')</script>");
                }
                else
                {
                    this.Page.RegisterStartupScript("ss", "<script>alert('更新失败!')</script>");
                }
                GridView1.EditIndex = -1;
            }
        }

        //确认插入新的题目
        protected void Button1_Click(object sender, EventArgs e)
        {
            StuExam.Model.Filling model = new StuExam.Model.Filling();
            model.Subject = ((TextBox)GridView1.FooterRow.FindControl("TextBox7")).Text.ToString().Replace("\r\n", "<br/>").Replace(" ", "&nbsp;");
            model.Answer1 = ((TextBox)GridView1.FooterRow.FindControl("TextBox8")).Text.ToString().ToString().Replace("\r\n", "<br/>").Replace(" ", "&nbsp;");
            model.Answer2 = ((TextBox)GridView1.FooterRow.FindControl("TextBox9")).Text.ToString().ToString().Replace("\r\n", "<br/>").Replace(" ", "&nbsp;");
            model.Answer3 = ((TextBox)GridView1.FooterRow.FindControl("TextBox10")).Text.ToString().ToString().Replace("\r\n", "<br/>").Replace(" ", "&nbsp;");
            try
            {
                model.Chapter = int.Parse(((TextBox)GridView1.FooterRow.FindControl("TextBox11")).Text.ToString().Trim());
            }
            catch (Exception ex)
            {
                this.Page.RegisterStartupScript("ss", "<script>alert('您输入的章节有误!')</script>");
                return;
            }

            try
            {
                model.Chapter = int.Parse(((TextBox)GridView1.FooterRow.FindControl("TextBox11")).Text.ToString().Trim());
            }
            catch (Exception ex)
            {
                this.Page.RegisterStartupScript("ss", "<script>alert('您输入的章节有误!')</script>");
                return;
            }
            if (StuExam.DAL.Filling.Add(model) != 0)
                this.Page.RegisterStartupScript("ss", "<script>alert('插入成功!')</script>");
            else
                this.Page.RegisterStartupScript("ss", "<script>alert('插入失败!')</script>");

        }

        //取消修改
        protected void Button2_Click(object sender, EventArgs e)
        {

        }
    }
}