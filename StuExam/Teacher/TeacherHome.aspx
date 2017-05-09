<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherHome.aspx.cs" Inherits="StuExam.Teacher.TeacherHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link type="text/css" href="../Styles/TeacherHome.css" rel="Stylesheet"/>
    <title>教师首页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%--顶层头部--%>
        <div style="position:relative;height:74px;background: #e3eef9;padding-left:375px;"><%--顶部图片--%>
            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/logo_school.png" />
            <asp:Image ID="Image3" runat="server" ImageUrl="~/images/student_image.png" Width="50px" Height="50px" CssClass="top_image"/>
            <div class="Teainfor">
                <div style="width:140px">
                    <div>姓名:<asp:Label ID="Label3" runat="server" ></asp:Label></div>
                    <div>工号:<asp:Label ID="Label2" runat="server" ></asp:Label></div>                    
                </div>
            </div>
        </div>
        <div class="option">
            <ul id="nav">
                <li id="li1" runat="server"><asp:LinkButton ID="LinkButton1" runat="server">密码修改</asp:LinkButton></li>           
            </ul>
        </div>
        <%--中间层--%>
        <iframe id="iframe1" name="iframe1" runat="server" width="100%" height="820px" frameborder="0" ></iframe>
    </div>
    </form>
</body>
</html>