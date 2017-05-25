<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Item.aspx.cs" Inherits="StuExam.Teacher.WItem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>密码修改</title>
    <link rel="Stylesheet" href="../Styles/Modify.css" type="text/css"/>
    <script type="text/javascript" src="../scripts/jquery-1.9.1.min.js"></script>
    <script type="text/javascript">
        $(function () {
            var width = $(window).width() - parseInt($(".left").css("width")) - 10;
            $("#Man").css("width", width + "px");

            var height = $(window).height() - 10;
            $(".left").css("height", height + "px")
            $("#Man").css("height", height + "px");
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div class="left">
            <div style="border-bottom: 1px dashed #fff;line-height: 40px;"></div>
            <div class="left_nav_menu">
                <ul>
                    <li id ="li1" runat="server"><asp:LinkButton ID="LinkButton1" style="TEXT-DECORATION: none;color:white" runat="server" OnClick="LinkButton1_Click">选择题修改</asp:LinkButton></li>
                    <li id ="li2" runat="server"><asp:LinkButton ID="LinkButton2" style="TEXT-DECORATION: none;color:white" runat="server" OnClick="LinkButton2_Click">填空题修改</asp:LinkButton></li>
                </ul>
            </div>
        </div>
            <iframe id="Man" style="float:left" name="iframe1" runat="server" width="100%" height="820px" frameborder="0" src="ChoiceManagement.aspx" ></iframe>
        
    </div>
    </form>
</body>
</html>
