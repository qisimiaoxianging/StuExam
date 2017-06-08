<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Practice.aspx.cs" Inherits="StuExam.Students.Practice" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>C语言在线练习系统</title>
    <link href="../Styles/Proctice.css" type="text/css" rel="Stylesheet"/>    
    <script src="../scripts/jquery-1.10.2.min.js" type="text/javascript"></script>
    <%--禁用复制黏贴的功能--%>
    <script language="Javascript">
        document.oncontextmenu = new Function("event.returnValue=false");
        document.onselectstart = new Function("event.returnValue=false");
        $(function () {
            $("#countscore tr").css("background", "rgb(240,240,240)");
            $("#countscore tr:odd").css("background", "white");
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">    
    <div style="position:relative;float:left; margin:0;"> 
        <div class="top">           
            <div class="font"><h1 class="posi_font">在线考试</h1></div>             
            <div class="xuanxiang"><%--答题倒计时--%>
                <asp:Image ID="Image4" runat="server" ImageUrl="~/images/clock.png" Height="40px" Width="40px" style="float:left"/>
                <h1 style="float:left;color:red" runat="server" id="Time">剩余120分钟</h1>
            </div>           
        </div>
        <%--选题栏1--%>
        <div class="left" style="overflow:auto">
            <asp:TreeView ID="TreeView1" runat="server" style="color:Black" 
                onselectednodechanged="TreeView1_SelectedNodeChanged1" ForeColor="Black">
                <Nodes>
                    <asp:TreeNode Text="单项选择题" Value="单项选择题" ImageUrl="~/images/item1.png">
                        <asp:TreeNode Text="第1题" Value="1" ImageUrl="~/images/item1.png"></asp:TreeNode>
                        <asp:TreeNode Text="第2题" Value="2" ImageUrl="~/images/item1.png"></asp:TreeNode>
                        <asp:TreeNode Text="第3题" Value="3" ImageUrl="~/images/item1.png"></asp:TreeNode>
                        <asp:TreeNode Text="第4题" Value="4" ImageUrl="~/images/item1.png"></asp:TreeNode>
                        <asp:TreeNode Text="第5题" Value="5" ImageUrl="~/images/item1.png"></asp:TreeNode>
                        <asp:TreeNode Text="第6题" Value="6" ImageUrl="~/images/item1.png"></asp:TreeNode>
                        <asp:TreeNode Text="第7题" Value="7" ImageUrl="~/images/item1.png"></asp:TreeNode>
                        <asp:TreeNode Text="第8题" Value="8" ImageUrl="~/images/item1.png"></asp:TreeNode>
                        <asp:TreeNode Text="第9题" Value="9" ImageUrl="~/images/item1.png"></asp:TreeNode>
                        <asp:TreeNode Text="第10题" Value="10" ImageUrl="~/images/item1.png"></asp:TreeNode>
                        <asp:TreeNode Text="第11题" Value="11" ImageUrl="~/images/item1.png"></asp:TreeNode>
                        <asp:TreeNode Text="第12题" Value="12" ImageUrl="~/images/item1.png"></asp:TreeNode>
                        <asp:TreeNode Text="第13题" Value="13" ImageUrl="~/images/item1.png"></asp:TreeNode>
                        <asp:TreeNode Text="第14题" Value="14" ImageUrl="~/images/item1.png"></asp:TreeNode>
                        <asp:TreeNode Text="第15题" Value="15" ImageUrl="~/images/item1.png"></asp:TreeNode>
                        <asp:TreeNode Text="第16题" Value="16" ImageUrl="~/images/item1.png"></asp:TreeNode>
                        <asp:TreeNode Text="第17题" Value="17" ImageUrl="~/images/item1.png"></asp:TreeNode>
                        <asp:TreeNode Text="第18题" Value="18" ImageUrl="~/images/item1.png"></asp:TreeNode>
                        <asp:TreeNode Text="第19题" Value="19" ImageUrl="~/images/item1.png"></asp:TreeNode>
                        <asp:TreeNode Text="第20题" Value="20" ImageUrl="~/images/item1.png"></asp:TreeNode>
                        <asp:TreeNode Text="第21题" Value="21" ImageUrl="~/images/item1.png"></asp:TreeNode>
                        <asp:TreeNode Text="第22题" Value="22" ImageUrl="~/images/item1.png"></asp:TreeNode>
                        <asp:TreeNode Text="第23题" Value="23" ImageUrl="~/images/item1.png"></asp:TreeNode>
                    </asp:TreeNode>
                </Nodes>
                <Nodes>
                    <asp:TreeNode Text="程序填空题" Value="程序填空题" ImageUrl="~/images/item1.png">
                        <asp:TreeNode Text="第1题" Value="101" ImageUrl="~/images/item1.png"></asp:TreeNode>
                        <asp:TreeNode Text="第2题" Value="102" ImageUrl="~/images/item1.png"></asp:TreeNode>
                        <asp:TreeNode Text="第3题" Value="103" ImageUrl="~/images/item1.png"></asp:TreeNode>
                        <asp:TreeNode Text="第4题" Value="104" ImageUrl="~/images/item1.png"></asp:TreeNode>
                    </asp:TreeNode>
                </Nodes>
                <SelectedNodeStyle CssClass="changeimage" />
            </asp:TreeView>
        </div>
        <%--选题栏2--%>
        <div class="Select_Title">
            <%--小题选择--%>
            <div class="select_xiaoti" runat="server" id="xiao">
                <div id="xiaoti1" runat="server">1</div>
                <div id="xiaoti2" runat="server">2</div>
                <div id="xiaoti3" runat="server">3</div>
                <div id="xiaoti4" runat="server">4</div>
                <div id="xiaoti5" runat="server">5</div>
                <div id="xiaoti6" runat="server">6</div>
                <div id="xiaoti7" runat="server">7</div>
                <div id="xiaoti8" runat="server">8</div>
                <div id="xiaoti9" runat="server">9</div>
                <div id="xiaoti10" runat="server">10</div>
                <div id="xiaoti11" runat="server">11</div>
                <div id="xiaoti12" runat="server">12</div>
                <div id="xiaoti13" runat="server">13</div>
                <div id="xiaoti14" runat="server">14</div>
                <div id="xiaoti15" runat="server">15</div>
                <div id="xiaoti16" runat="server">16</div>
                <div id="xiaoti17" runat="server">17</div>
                <div id="xiaoti18" runat="server">18</div>
                <div id="xiaoti19" runat="server">19</div>
                <div id="xiaoti20" runat="server">20</div>
                <div id="xiaoti21" runat="server">21</div>
                <div id="xiaoti22" runat="server">22</div>
                <div id="xiaoti23" runat="server">23</div>    
                <div id="xiaoti24" runat="server">24</div>
                <div id="xiaoti25" runat="server">25</div>
                <div id="xiaoti26" runat="server">26</div>
                <div id="xiaoti27" runat="server">27</div> 
                <div id="xiaoti28" runat="server">28</div>
                <div id="xiaoti29" runat="server">29</div>
                <div id="xiaoti30" runat="server">30</div> 


                <div id="xiaoti101" runat="server">1</div>
                <div id="xiaoti102" runat="server">2</div>
                <div id="xiaoti103" runat="server">3</div>
                <div id="xiaoti104" runat="server">4</div>  
                <div id="xiaoti105" runat="server">5</div>
                <div id="xiaoti106" runat="server">6</div>
                <div id="xiaoti107" runat="server">7</div>
                <div id="xiaoti108" runat="server">8</div> 
                <div id="xiaoti109" runat="server">9</div>
                <div id="xiaoti110" runat="server">10</div>
                
                
<%--                <div id="xiaoti28" runat="server">1</div>
                <div id="xiaoti29" runat="server">2</div>
                <div id="xiaoti30" runat="server">3</div>--%>
                <div id="xiaoti31" runat="server">4</div> 
                <div id="xiaoti32" runat="server">5</div> 
                
                
                <div id="xiaoti33" runat="server">1</div> 
                <div id="xiaoti34" runat="server">2</div> 
                <div id="xiaoti35" runat="server">3</div>           
            </div>
            <%--当前位图哪个大题中--%>
            <div class="Pot_dati">
               <asp:Label ID="dati" runat="server" Text="单项选择题：每题2分。" CssClass="subjectType"></asp:Label>     
               <asp:Label ID="xiaoti" runat="server" CssClass="subjectType" ForeColor="Red"></asp:Label>          
            </div>
            <%--右侧的题目做的情况--%>
            <div class="logo">
                <div class="zikuang" style="position:absolute;top:65px;"><div style="background-color:rgb(0,192,0);width:10px;height:10px;"></div><div style="float:left;width:30px;position:relative;left:12px;top:-12px;">已做</div></div>                
                <div class="zikuang" style="position:absolute;top:65px;left:80px;"><div style="background-color:rgb(211,211,211);width:10px;height:10px;"></div><div style="float:left;width:30px;position:relative;left:12px;top:-12px;">未做</div></div>                
                <div class="zikuang" style="position:absolute;top:65px;left:160px;"><div style="background-color:rgb(255,128,128);width:10px;height:10px;"></div><div style="float:left;width:30px;position:relative;left:12px;top:-12px;">当前</div></div> 
            </div>
        </div>
        <%--具体题目栏--%>
        <div class="Title" id="Title" runat="server">
            <%--用于显示题目--%>
            <asp:Label ID="Subject_title" runat="server" CssClass="subject" Height="435px" Width="998px">               
            </asp:Label>            
            <div style="display:none;width:300px;height:200px;position:relative;right:37px;top:-228px;overflow:hidden;float:right" id="show_image" runat="server">
                <asp:Image ID="a_image" runat="server" CssClass="a_image" style="display:none"/>
            </div>
        </div>
      
        <%--答案栏--%>
        <div class="Answer" id="answer" runat="server">
            <p class="border_font">答案</p>            
            <%--选择题答题栏--%>
            <div class="choice" runat="server" id="choice1">
                <asp:RadioButton runat="server" ID="one1A" GroupName="option1" Text="A" style="padding:10px 110px 10px 0px;"/>
                <asp:RadioButton runat="server" ID="one1B" GroupName="option1" Text="B" style="padding:10px 110px 10px 0px;"/>
                <asp:RadioButton runat="server" ID="one1C" GroupName="option1" Text="C" style="padding:10px 110px 10px 0px;"/>
                <asp:RadioButton runat="server" ID="one1D" GroupName="option1" Text="D" style="padding:10px 110px 10px 0px;"/>
            </div>
            <%--填空题答题栏--%>
            <div class="filling" runat="server" id="filling1">
                1.<asp:TextBox ID="two11" runat="server" Width="234px" Height="28px" CssClass="xuanze"></asp:TextBox>
                2.<asp:TextBox ID="two12" runat="server" Width="234px" Height="28px" CssClass="xuanze"></asp:TextBox>
                3.<asp:TextBox ID="two13" runat="server" Width="234px" Height="28px" CssClass="xuanze"></asp:TextBox>
            </div>
        </div>
        <%--底层栏--%>
        <div class="bottom">
            <asp:Button ID="change" runat="server" Text="改卷" style="position:relative; top:20px; left:20px;" 
             Width="120px" Height="35px" OnClick="Change_Click"/>
            <asp:Button ID="PreTitle" runat="server" Text="上一题" Width="120px" Height="35px" 
                style="position:relative; top:20px; left:574px" onclick="PreTitle_Click"/>
            <asp:Button ID="NextTitle" runat="server" Text="下一题" Width="120px" Height="35px" 
                style="position:relative; top:20px; left:589px" onclick="NextTitle_Click"/>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Enabled="False">
            </asp:Timer>
        </div>
    </div>
    <%--未完成答题时的确认答题框--%>
    <div style="position: fixed;width:100%;height:100%;background:rgba(0,0,0,0.7);margin:auto;display:none" id="paper" runat="server">
		<div style="position: fixed;margin:0 auto;top:210px;left:0;right:0;width:300px;height:146px;
		    background-color:white;border:10px solid rgb(207,223,244);border-radius:10px;z-index:999;opacity:1">
			<div style="width:100%;height:50px;line-height: 25px;text-align: center;padding-top: 30px;opacity:1;font-weight:bold;color:Black;" >
				当前仍有题目未答完，是否交卷
			</div>
			<div style="width:70px;height:30px;float: left;
			    margin:0px 40px;z-index:999;" id="affirm" runat="server" >
                <asp:Button ID="Button1" runat="server" Text="交卷" Height="30px" Width="70px" CssClass="Affirm" onclick="Button1_Click"/>
			</div>
			<div style="width:70px;height:30px;float: right;
			    margin:0px 40px;z-index:999;" id="cancel">
                <asp:Button ID="Button2" runat="server" Text="取消" Height="30px" Width="70px" CssClass="cancel" onclick="Button2_Click"/>
			</div>
		</div>
    </div>
    <%--登录超时session过期--%>
    <div style="position: fixed;width:100%;height:100%;background:rgba(0,0,0,0.7);margin:auto;display:none" id="overdue" runat="server">
		<div style="position: fixed;margin:0 auto;top:210px;left:0;right:0;width:300px;height:146px;
		    background-color:white;border:10px solid rgb(207,223,244);border-radius:10px;z-index:999;opacity:1">
			<div style="width:100%;height:50px;line-height: 25px;text-align: center;padding-top: 10px;opacity:1;font-weight:bold;color:Black;">
                <p style="font-weight:bold;color:red;font-size:20px;text-align:left">提示:</p>
				<p style="font-weight:bold;">当前登录状态已过期请重新登录</p>
                <div style="width:290px;height:30px;" runat="server" id="p"></div>
			</div>
			<div style="width:70px;height:30px;float: left;margin:25px 110px;z-index:999;" id="login" runat="server">
                <asp:Button ID="Button3" runat="server" Text="确定" Height="30px" Width="70px" CssClass="Affirm" onclick="Button3_Click"/>
			</div>			
		</div>
    </div>
    <%--显示得分--%>
    <div style="position: fixed;width:100%;height:100%;background:rgba(0,0,0,0.7);margin:auto;display:none;z-index:900;overflow:auto" id="showscore" runat="server">
        <asp:Table ID="countscore" runat="server">
            <asp:TableRow>
                <asp:TableHeaderCell >题型</asp:TableHeaderCell>                   
                <asp:TableHeaderCell >小题</asp:TableHeaderCell>
                <asp:TableHeaderCell >得分</asp:TableHeaderCell>
            </asp:TableRow>
        </asp:Table>
        <div class="table_bottom">
            <asp:Button ID="Button6" runat="server" Text="关闭" CssClass="button1" OnClick="Button6_Click"/>
        </div>
    </div>
    </form>
</body>
</html>
