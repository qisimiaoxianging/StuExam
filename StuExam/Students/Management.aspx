<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Management.aspx.cs" Inherits="StuExam.Students.Management" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>学生首页</title>
    <link type="text/css" href="../Styles/Management.css" rel="Stylesheet"/>
    <script src="../Scripts/jquery-1.11.1.min.js" type="text/javascript"></script> 
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin:0 auto; width:100%">
        <div style="position:relative;height:74px;background: #e3eef9;padding-left:375px;"><%--顶部图片--%>
            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/logo_school.png" />
            <asp:Image ID="Image3" runat="server" ImageUrl="~/images/student_image.png" Width="50px" Height="50px" CssClass="top_image"/>
            <div class="stuinfor">
                <div style="width:140px">
                    <div>姓名:<asp:Label ID="Label3" runat="server" ></asp:Label></div>
                    <div>学号:<asp:Label ID="Label2" runat="server" ></asp:Label></div>                    
                </div>
                <div style="width: 146px;top: -51px;position: relative;left: 145px;">                   
                    <div>专业:<asp:Label ID="Label4" runat="server" ></asp:Label></div>
                    <div>班级:<asp:Label ID="Label5" runat="server" ></asp:Label></div>
                </div>
            </div>
        </div>
        <div class="option"  id="op" runat="server">
            <ul id="nav">
                <li id="li1" runat="server"><asp:LinkButton ID="LinkButton1" runat="server">密码修改</asp:LinkButton></li>        
            </ul>
        </div>
    </div>
    <iframe style="display:none;" id="iframe1" name="iframe1" runat="server" width="100%" height="810px" frameborder="0" ></iframe>
    </form>
</body>
</html>
