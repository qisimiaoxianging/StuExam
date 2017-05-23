<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyPassword.aspx.cs" Inherits="StuExam.Teacher.ModifyPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="Stylesheet" href="../Styles/Modify.css" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div>
    <div class="out" id="Out" runat="server">
        <div class="password_frame">
            <div><span style="font-size:18px;">修改密码</span></div>
            <div class="info_box">
                <div class="info_box1">
                    <span>用户名：</span>
                    <span>原密码：</span>
                    <span>新密码：</span>
                    <span>确认新密码：</span>
                </div>
                <div class="info_box2">
                    <div><asp:Label runat="server" ID="Label1"></asp:Label></div>
                    <div><asp:TextBox runat="server" ID="Ori_Password"  TextMode="Password" CssClass="input" placeholder="请填写原密码"></asp:TextBox></div>
                    <div>
                        <asp:TextBox runat="server" ID="New_Password"  TextMode="Password" CssClass="input" placeholder="请填写新密码"></asp:TextBox>                   
                        <div class="ruo"></div><p style="font-size: 21px;color: red;display: none;float: right;position: relative;right: 359px;top: -13px;" id="ruo">弱</p>
                        <div class="zhong"></div><p style="font-size: 21px;color: orange;display: none;top: -13px;float: right;position: relative;right: 259px;" id="zhong">中</p>
                        <div class="qiang"></div><p style="font-size: 21px;color: green;display: none;float: right;position: relative;right: 160px;top: -13px;" id="qiang">强</p>  
                    </div>
                    <div>
                         <asp:TextBox runat="server" ID="New_Password1" TextMode="Password" CssClass="input" placeholder="请确认新密码"></asp:TextBox>
                        <p style="font-size:12px;color:Red;display:none;float:right;position: absolute;right: 458px;top: 223px;" id="information">
                            ×&nbsp;两次输入的密码不一致
                        </p>  
                        <p style="font-size:22px;color:green;display:none;float:right;position:relative;right:380px;top:-20px;font-weight:bold;" id="information1">
                            ✔
                        </p>
                        <p style="font-size:12px;color:Red;display:none;float:right;position: absolute;right: 505px;top: 222px;" id="information2">
                            验证密码不能为空
                        </p>   
                    </div>
                    <div>
                        <asp:Button runat="server" ID="Button1" Text="清空" Width="100px"  Height="32px" CssClass="return" onclick="Button1_Click"/>
                        <asp:Button runat="server" ID="Button2" Text="修改" Width="100px"  Height="32px"  CssClass="acknowledge" onclick="Button2_Click"/>
                    </div>
                </div>                
            </div>
            <div style="padding-top: 10px; line-height: 16px; color: #777">
                    <span>登录密码修改规则说明：</span>
                    <p>1.密码长度为6~16位，必须包含字母或字母和数字，不能以数字开头，字母区分大小写</p>
                    <p>2.密码不可与账号相同</p>
                    <p>3.密码不可用于身份证后几位相同</p>
            </div>
        </div>      
    </div>    
    </div>
    </div>
    </form>
</body>
</html>
