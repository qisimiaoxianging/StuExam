<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Management.aspx.cs" Inherits="StuExam.Students.Management" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>学生首页</title>
        <link type="text/css" href="../Styles/Management.css" rel="Stylesheet"/>
    <script src="../Scripts/jquery-1.11.1.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../Scripts/pagination.js"></script>
    <script type="text/javascript">
        $(function () {
            //控制文章推荐样式
            $("#Table1").css("border-collapse", "collapse");
            $("#Table1 tr:nth-child(even)").css("background", "rgb(225,225,225)");
            $("#Table1 tr:nth-child(odd)").css("background", "rgb(240,240,240)");
            $("#Table1 thead tr").css("background", "rgb(144,175,199)");
        });       
    </script>
    <script type="text/javascript">
        window.onload = function () {
            page = new Page(9, 'Table1', 'group_one');
            $("#addAimPage a:first()").addClass("current");

            $("#addAimPage a").click(function () {
                $("#addAimPage>a").removeClass("current");
                $(this).addClass("current");
                var text = $(this).text();
                $(this).bind("click", page.Page_Change(text));
            });
            //首页
            $("#pagination #first").click(function () {
                $("#addAimPage>a").removeClass("current");
                $("#addAimPage a:first()").addClass("current");
            });
            //尾页
            $("#pagination #last").click(function () {
                $("#addAimPage>a").removeClass("current");
                $("#addAimPage a:last()").addClass("current");
            });
            //上一页
            $("#pagination #Prev").click(function () {
                $("#addAimPage>a").removeClass("current");
                var current_page = page.pageIndex;
                if (current_page >= 0) {
                    $("#addAimPage a:eq(" + current_page + ")").addClass("current");
                }

            });
            //下一页
            $("#pagination #Next").click(function () {
                $("#addAimPage>a").removeClass("current");
                var current_page = page.pageIndex;
                $("#addAimPage a:eq(" + current_page + ")").addClass("current");
            });
            //跳转
            $("#pagination #jump").click(function () {
                $("#addAimPage>a").removeClass("current");
                var current_page = $("#pageno").val() - 1;
                $("#addAimPage a:eq(" + current_page + ")").addClass("current");
            });
            var body_width = document.body.clientWidth;//获取浏览器的宽度
            var div_width = $("#pagination").css("width");//获取盒子的宽度
            var width = div_width.substring(0, 3);
            var left = (body_width - width) / 2;//确定左边距
            $("#pagination").css("left", left + "px");
        };
    </script>  
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin:0 auto; width:100%" id="op" runat="server">
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
        <div class="option"  runat="server">
            <ul id="nav">
                <li id="li1" runat="server"><asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">密码修改</asp:LinkButton></li>   
                <li id="li2" runat="server"><asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">我的作业</asp:LinkButton></li>     
            </ul>
        </div>
        <div id="Out" runat="server">
            <div class="mark_course" runat="server" id="mark_course">
                <div class="ordinary_mark" style="display:none">
                    平时成绩:<asp:Label ID="Label1" runat="server" Text="100分" ForeColor="Red"></asp:Label>
                </div>
                <div class="choice_course"><%--课程选择--%>
                    课程选择:
                    <asp:DropDownList ID="course" runat="server">
                        <asp:ListItem>高级语言程序设计C语言</asp:ListItem> <%--此下拉列表的内容要根据学院专业班级动态改变--%>  
                        <asp:ListItem>高级语言程序设计VB</asp:ListItem>
                        <asp:ListItem>高级语言程序设计C#</asp:ListItem>                   
                    </asp:DropDownList>
                </div>
            </div>
            <div class="frame" runat="server" id="frame">                       
                <asp:Table ID="tabShow" runat="server" CssClass="homework">
                    <asp:TableRow>
                        <asp:TableHeaderCell CssClass="head">编号</asp:TableHeaderCell>                   
                        <asp:TableHeaderCell CssClass="head">发布时间</asp:TableHeaderCell>
                        <asp:TableHeaderCell CssClass="head">截止时间</asp:TableHeaderCell>
                        <asp:TableHeaderCell CssClass="head">答题情况</asp:TableHeaderCell>
                        <asp:TableHeaderCell CssClass="head">得分</asp:TableHeaderCell>
                        <asp:TableHeaderCell CssClass="head">用时</asp:TableHeaderCell>
                        <asp:TableHeaderCell CssClass="head">操作</asp:TableHeaderCell>
                    </asp:TableRow>
                </asp:Table>           
            </div>
        </div>
    </div>
    <iframe style="display:none;" id="iframe1" name="iframe1" runat="server" width="100%" height="810px" frameborder="0" ></iframe>
    <div class="pagination" id="pagination" runat="server" style="display:none"> 
        <a href="#" onclick="page.firstPage();" id="first">首 页</a>
        <a href="#" onclick="page.prePage();" id="Prev">上一页</a>
        <div id="addAimPage" style="display:inline">
                 
        </div>
        <a href="#" onclick="page.nextPage();" id="Next">下一页</a>
        <a href="#" onclick="page.lastPage();" id="last">末 页</a>
        <span id="divFood"></span>
        <p>第<input id="pageno" value="1" style="width:20px"/>页</p>
        <a href="#" onclick="page.aimPage();" id="jump">跳转</a>
    </div> 
    <%--两个按钮--%>
    <div style="position: fixed;width:100%;height:100%;background:rgba(0,0,0,0.7);margin:auto;z-index:998;display:none;top: 0px;" id="paper" runat="server">
		<div style="position: fixed;margin:0 auto;top:210px;left:0;right:0;width:300px;height:146px;
		    background-color:white;border:10px solid rgb(207,223,244);border-radius:10px;z-index:999;opacity:1">
			<div style="width:100%;height:50px;line-height: 25px;text-align: center;padding-top: 30px;opacity:1;font-weight:bold;color:Black;" id="p1" runat="server"></div>
			<div style="width:70px;height:30px;float: left;margin:0px 40px;z-index:999;" id="affirm" runat="server" >
                <asp:Button ID="Button2" runat="server" Text="继续" Height="30px" Width="70px" CssClass="Affirm" OnClick="Button2_Click" />
			</div>
			<div style="width:70px;height:30px;;float: right;margin:0px 40px;z-index:999;" id="cancel">
                <asp:Button ID="Button4" runat="server" Text="取消" Height="30px" Width="70px" CssClass="cancel" OnClick="Button4_Click" />
			</div>
		</div>
    </div> 
    <%--底层栏--%>
    <div class="footer">
        <div class="content">
            <div class="footer_info">
                <span>Copyright@ 2012-浙江农林大学 All Rights Reserved</span>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
