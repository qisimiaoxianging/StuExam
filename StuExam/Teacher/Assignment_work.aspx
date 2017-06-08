<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Assignment_work.aspx.cs" Inherits="StuExam.Teacher.Assignment_work" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../Content/bootstrap.min.css" type="text/css" rel="stylesheet"/>
    <link href="../Content/bootstrap-datetimepicker.min.css" type="text/css" rel="stylesheet"/>
    <script type="text/javascript" src="../scripts/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="../scripts/bootstrap.min.js"></script>
    <script type="text/javascript" src="../scripts/bootstrap-datetimepicker.js"></script>
    <script type="text/javascript" src="../scripts/bootstrap-datetimepicker.fr.js"></script>
    <script type="text/javascript">

        $(function () {
            $.fn.datetimepicker.dates['zh'] = {
                days: ["星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六", "星期日"],
                daysShort: ["日", "一", "二", "三", "四", "五", "六", "日"],
                daysMin: ["日", "一", "二", "三", "四", "五", "六", "日"],
                months: ["一月", "二月", "三月", "四月", "五月", "六月", "七月", "八月", "九月", "十月", "十一月", "十二月"],
                monthsShort: ["一", "二", "三", "四", "五", "六", "七", "八", "九", "十", "十一", "十二"],
                meridiem: ["上午", "下午"], 
                today: "今天"
            };
            var mydate = new Date();
            var str = "" + mydate.getFullYear() + "-";
            str += (mydate.getMonth() + 1) + "-";
            str += mydate.getDate();
            $("#addtime").val(str);

            $('.form_datetime').datetimepicker({
                minView: "month", 
                language: 'zh',
                format: 'yyyy-mm-dd',
                todayBtn: 1,
                autoclose: 1,
            });

            var top = parseInt($("#tabShow").css("height")) + parseInt($("#select").css("height")) + 20;
            var left1 = parseInt($("#homework").css("left"));
            var left2 = parseInt($("#homework").css("width"));
            var left = left1 + left2 / 2 - parseInt($("#Mod").css("width")) / 2;
            $("#Create").css("display", "block");
            $("#Create").css("top", top + "px").css("left", left + "px");
        })

    </script>
    <title>生成作业</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="position:relative;left: 600px;top:20px;" id="select">
            学年:<asp:DropDownList ID="DropDownList3" runat="server" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            学期:<asp:DropDownList ID="DropDownList4" runat="server" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem>第一学期(冬季)</asp:ListItem> 
                    <asp:ListItem>第二学期(夏季)</asp:ListItem>
                 </asp:DropDownList>
            专业班级:<asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            专业课程:<asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>
        </div>
        <div style="position:relative;width:1233px;height:1px;top: 35px;left: 377px;" runat="server" id="homework">                       
            <asp:Table ID="tabShow" runat="server" CssClass="table table-hover">         
                <asp:TableRow>
                    <asp:TableHeaderCell CssClass="head">起始章</asp:TableHeaderCell> 
                    <asp:TableHeaderCell CssClass="head">终止章</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="head">基本信息</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="head">发布日期</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="head">截止日期</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="head">操作</asp:TableHeaderCell>
                </asp:TableRow>
                <asp:TableRow Visible="false">
                    <asp:TableCell>
                        <asp:DropDownList ID="DropDownList5" runat="server" OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem>第1章</asp:ListItem> 
                            <asp:ListItem>第2章</asp:ListItem>          
                            <asp:ListItem>第3章</asp:ListItem>          
                            <asp:ListItem>第4章</asp:ListItem>          
                            <asp:ListItem>第5章</asp:ListItem>          
                            <asp:ListItem>第6章</asp:ListItem>          
                            <asp:ListItem>第7章</asp:ListItem>          
                            <asp:ListItem>第8章</asp:ListItem>          
                            <asp:ListItem>第9章</asp:ListItem>          
                            <asp:ListItem>第10章</asp:ListItem>                                        
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="DropDownList6" runat="server">
                            <asp:ListItem>第1节</asp:ListItem>
                            <asp:ListItem>第2节</asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="DropDownList7" runat="server" OnSelectedIndexChanged="DropDownList7_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem>第1章</asp:ListItem> 
                            <asp:ListItem>第2章</asp:ListItem>          
                            <asp:ListItem>第3章</asp:ListItem>          
                            <asp:ListItem>第4章</asp:ListItem>          
                            <asp:ListItem>第5章</asp:ListItem>          
                            <asp:ListItem>第6章</asp:ListItem>          
                            <asp:ListItem>第7章</asp:ListItem>          
                            <asp:ListItem>第8章</asp:ListItem>          
                            <asp:ListItem>第9章</asp:ListItem>          
                            <asp:ListItem>第10章</asp:ListItem>                 
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="DropDownList8" runat="server">
                            <asp:ListItem>第1节</asp:ListItem>
                            <asp:ListItem>第2节</asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                    <%--<asp:TableCell>
                        <asp:DropDownList ID="DropDownList9" runat="server">
                            <asp:ListItem>易(1~2)</asp:ListItem>
                            <asp:ListItem>中(3~4)</asp:ListItem>
                            <asp:ListItem>难(5~6)</asp:ListItem>
                            <asp:ListItem>随机</asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>--%>
                    <asp:TableCell>
                        <asp:Label ID="actiontime" runat="server" Text="Label"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:LinkButton ID="calenderButton" runat="server" OnClick="LinkButton1_Click" Text="添加截止日期"></asp:LinkButton>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:LinkButton ID="create" runat="server" OnClick="LinkButton2_Click" Text="生成"></asp:LinkButton>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>           
        </div>
        <div id="Check" runat="server" class="check">
        <asp:Table ID="check_situation" runat="server" CssClass="tablehomework">
        </asp:Table>
    </div>  
             <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog" style="width:40%;height:100px">
        <div class="modal-content" >
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <h4 class="modal-title" id="myModalLabel">添加考试信息</h4>
            </div>
            <div class="modal-body">                
                    <div class="calenders" runat="server" id="calender" style="display:none">
                    <asp:Calendar ID="Calendar1" runat="server" TodayDayStyle-BackColor="#999999"  
                        OnSelectionChanged="Calendar1_SelectionChanged" BackColor="#FFFFCC" BorderColor="#FFCC66" 
                        BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" Enabled="false" 
                        ForeColor="#663399" Height="270px" ShowGridLines="True" Width="350px" OnDayRender="Calendar1_DayRender">
                        <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                        <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                        <OtherMonthDayStyle ForeColor="#CC9966" />
                        <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                        <SelectorStyle BackColor="#FFCC66" />
                        <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                        <TodayDayStyle BackColor="#FFCC66" ForeColor="White"></TodayDayStyle>            
                    </asp:Calendar>
                </div>
                <table class="table" style="height:100px">
                    <tr>
                        <td colspan="5"><label style="color:#000000;font-size:16px">一、添加考试基本信息:</label></td>
                    </tr>
                    <tr>
                        <td colspan="5" style="vertical-align:middle"><label style="color:#000000;font-size:14px">1、基础信息:</label></td>
                    </tr>
                    <tr>
                        <td style="text-align:center;vertical-align:middle;width:15%">简介:</td>
                        <td colspan="2"><asp:TextBox ID="TextBox10" runat="server" CssClass="form-control"></asp:TextBox></td>
                        <td style="text-align:center;vertical-align:middle;width:15%">截止时间:</td>
                        <td style="vertical-align:middle">
                                <div class="input-group">
                                  <input type="text" class="form-control form_datetime" id="addtime" name="addtime" readonly="true" runat="server" />
                                  <span class="input-group-addon" id="basic-addon2"><span class="glyphicon glyphicon-time" aria-hidden="true"></span></span>
                                </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5" style="vertical-align:middle"><label style="color:#000000;font-size:14px">2、范围:</label></td>
                    </tr>
                    <tr>
                        <td style="text-align:center;vertical-align:middle">起始章:</td>                        
                        <td><asp:DropDownList ID="DropDownList9" runat="server">
                            <asp:ListItem>第1章</asp:ListItem> 
                            <asp:ListItem>第2章</asp:ListItem>          
                            <asp:ListItem>第3章</asp:ListItem>          
                            <asp:ListItem>第4章</asp:ListItem>          
                            <asp:ListItem>第5章</asp:ListItem>          
                            <asp:ListItem>第6章</asp:ListItem>          
                            <asp:ListItem>第7章</asp:ListItem>          
                            <asp:ListItem>第8章</asp:ListItem>          
                            <asp:ListItem>第9章</asp:ListItem>          
                            <asp:ListItem>第10章</asp:ListItem>                 
                            </asp:DropDownList>
                        </td>
                        <td style="text-align:center;vertical-align:middle">终止章:</td>                        
                        <td><asp:DropDownList ID="DropDownList10" runat="server" >
                            <asp:ListItem>第1章</asp:ListItem> 
                            <asp:ListItem>第2章</asp:ListItem>          
                            <asp:ListItem>第3章</asp:ListItem>          
                            <asp:ListItem>第4章</asp:ListItem>          
                            <asp:ListItem>第5章</asp:ListItem>          
                            <asp:ListItem>第6章</asp:ListItem>          
                            <asp:ListItem>第7章</asp:ListItem>          
                            <asp:ListItem>第8章</asp:ListItem>          
                            <asp:ListItem>第9章</asp:ListItem>          
                            <asp:ListItem>第10章</asp:ListItem>                 
                            </asp:DropDownList>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td colspan="5"><label style="color:#000000;font-size:16px">二、添加选择题:</label></td>
                    </tr>
                    <tr>
                        <td><label style="color:#000000;font-size:14px">1、选择题1:</label></td>
                        <td style="text-align:center;vertical-align:middle">个数:</td>
                        <td><asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" Text="10"></asp:TextBox></td>
                        <td style="text-align:center;vertical-align:middle">每题分值</td>
                        <td><asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" Text="1"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><label style="color:#000000;font-size:14px">1、选择题2:</label></td>
                        <td style="text-align:center;vertical-align:middle">个数:</td>
                        <td><asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" Text="20"></asp:TextBox></td>
                        <td style="text-align:center;vertical-align:middle">每题分值</td>
                        <td><asp:TextBox ID="TextBox5" runat="server" CssClass="form-control" Text="3"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="5"><label style="color:#000000;font-size:16px">三、添加填空题(每题3空):</label></td>
                    </tr>
                    <tr>
                        <td><label style="color:#000000;font-size:14px">1、填空题1:</label></td>
                        <td style="text-align:center;vertical-align:middle">个数:</td>
                        <td><asp:TextBox ID="TextBox6" runat="server" CssClass="form-control" Text="5"></asp:TextBox></td>
                        <td style="text-align:center;vertical-align:middle">每空分值</td>
                        <td><asp:TextBox ID="TextBox7" runat="server" CssClass="form-control" Text="2"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><label style="color:#000000;font-size:14px">1、填空题2:</label></td>
                        <td style="text-align:center;vertical-align:middle">个数:</td>
                        <td><asp:TextBox ID="TextBox8" runat="server" CssClass="form-control" Text="0"></asp:TextBox></td>
                        <td style="text-align:center;vertical-align:middle">每空分值</td>
                        <td><asp:TextBox ID="TextBox9" runat="server" CssClass="form-control" Text="0"></asp:TextBox></td>
                    </tr>
                </table>
            </div>
            <div class="modal-footer">
                <asp:Button ID="Button1" runat="server" Text="关闭" CssClass="btn btn-default"  data-dismiss="modal"/>
                <asp:Button ID="Button2" runat="server" Text="生成考试" CssClass="btn btn-default" OnClick="LinkButton2_Click" />
            </div>
        </div><!-- /.modal-content -->
    </div><!-- /.modal -->
    </div>   
    </form>
    <div id="Create" style="position:relative">
        <button id="Mod" class="btn btn-primary btn-lg" data-toggle="modal" data-target="#myModal" >发布考试</button>
    </div>
 
</body>
</html>
