using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StuExam.Teacher
{
    public partial class ChoiceManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //修改命令
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //自定义更新操作
            if (e.CommandName == "Up")
            {
                //获取当前行
                int rowIndex = Convert.ToInt32(e.CommandArgument); ;
                //获取各参数
                String Subject = ((TextBox)(GridView1.Rows[rowIndex].Cells[0].FindControl("TextBox1"))).Text.ToString().Trim();
                //
                String Anewer = ((TextBox)(GridView1.Rows[rowIndex].Cells[1].FindControl("TextBox2"))).Text.ToString().Trim();
                String Chapter = ((TextBox)(GridView1.Rows[rowIndex].Cells[2].FindControl("TextBox3"))).Text.ToString().Trim();
                
                String Number = GridView1.DataKeys[rowIndex].Value.ToString();
                if (StuExam.DAL.Choice.updateing(Number, Subject, Anewer, Chapter))
                {
                    this.Page.RegisterStartupScript("ss", "<script>alert('更新成功!')</script>");
                }
                else
                {
                    this.Page.RegisterStartupScript("ss", "<script>alert('更新失败!')</script>");
                }       
            }
        }
        //取消修改
        protected void Butt_Cancel_Click(object sender, EventArgs e)
        {
            ((TextBox)GridView1.FooterRow.FindControl("Text_Subject")).Text = null;
            ((TextBox)GridView1.FooterRow.FindControl("Text_Answer")).Text = null;
            ((TextBox)GridView1.FooterRow.FindControl("Text_Chapter")).Text = null;
            ((TextBox)GridView1.FooterRow.FindControl("Text_Number")).Text = null;
        }

        //确认插入新的题目
        protected void Butt_Submit_Click(object sender, EventArgs e)
        {
            StuExam.Model.Choice model = new StuExam.Model.Choice();
            model.Subject = ((TextBox)GridView1.FooterRow.FindControl("Text_Subject")).Text.ToString().Replace("\r\n", "<br/>").Replace(" ", "&nbsp;");
            model.Answer = ((TextBox)GridView1.FooterRow.FindControl("Text_Answer")).Text.ToString().Trim();
            Console.WriteLine(model.Answer);
            Console.WriteLine(model.Subject);
            if (model.Answer.Length != 1 || (model.Answer[0] < 'A' || model.Answer[0] > 'D'))
            {
                this.Page.RegisterStartupScript("ss", "<script>alert('您输入的答案有误!')</script>");
                return;
            }

            try
            {
                model.Chapter = int.Parse(((TextBox)GridView1.FooterRow.FindControl("Text_Chapter")).Text.ToString().Trim());
            }
            catch (Exception ex)
            {
                this.Page.RegisterStartupScript("ss", "<script>alert('您输入的章节有误!')</script>");
                return;
            }
            if (StuExam.DAL.Choice.Add(model) != 0)
                this.Page.RegisterStartupScript("ss", "<script>alert('插入成功!')</script>");
            else
                this.Page.RegisterStartupScript("ss", "<script>alert('插入失败!')</script>");
        }
    }
}