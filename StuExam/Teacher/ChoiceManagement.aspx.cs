﻿using System;
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
                String Subject = ((TextBox)(GridView1.Rows[rowIndex].Cells[0].FindControl("TextBox1"))).Text.ToString();
                Subject = Subject.Replace("\r\n", "<br/>").Replace(" ", "&nbsp;");
                String Anewer = ((TextBox)(GridView1.Rows[rowIndex].Cells[1].FindControl("TextBox2"))).Text.ToString();
                String Chapter = ((TextBox)(GridView1.Rows[rowIndex].Cells[2].FindControl("TextBox3"))).Text.ToString();
                String Number = GridView1.DataKeys[rowIndex].Value.ToString();
                if (StuExam.DAL.Choice.updateing(Number, Subject, Anewer, Chapter))
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
        //取消修改
        protected void Butt_Cancel_Click(object sender, EventArgs e)
        {
            ((TextBox)GridView1.FooterRow.FindControl("Text_Subject")).Text = null;
            ((TextBox)GridView1.FooterRow.FindControl("Text_Answer")).Text = null;
            ((TextBox)GridView1.FooterRow.FindControl("Text_Chapter")).Text = null;
        }

        //确认插入新的题目
        protected void Butt_Submit_Click(object sender, EventArgs e)
        {

        }
    }
}