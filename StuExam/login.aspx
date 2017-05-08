<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="StuExam.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <title></title>    
    <link rel="stylesheet"  href="Styles/tab.css" />    
    <link rel="stylesheet"  href="Styles/login.css" />
    <style>
        .btn1 {
	        width: 86px;
	        height: 34px;
	        border: none;
	        background-color: #fff;
	        cursor: pointer
        }
        .btn-submit1 {
	        font-size: 14px;
	        color: #fff;
	        font-weight: bold
        }
    </style>
    <script>

    </script>
</head>
<body style="background:url(images/bg.jpg) " >
		<div class="container">
            <form class="bd" name="frmLogin" method="post" id="sLoginForm" runat="server">
			<div class="header">
				<header>
					<h1 class="logo"><a href="" target="_blank"><img src="images/logo_school.png"  width="210" height="44" ></a></h1>
				</header>
			</div>
			<div class="main_content">
				<section class="login">
					<div class="tab-content">
						<div  class="tab-pane active" id="stu_login">
								<h2 class="hd" id="">欢迎登录考试系统！</h2>
                                <div class="bd">
								<div class="item">
									<label class="name" for="userNameIpt">用户名</label>
                                    <asp:TextBox id="username" tabindex="1" type="text" class="ipt ipt-t" runat="server"></asp:TextBox>
								</div>
								<div class="item">
									<label class="name" for="pwdInput">密&nbsp;&nbsp; 码</label>
                                    <asp:TextBox id="password" name="password" tabindex="2" type="password" class="ipt ipt-t" runat="server"></asp:TextBox>
								</div>
								<div class="item submit">
                                    <asp:Button CssClass="btn btn-submit" ID="btXs" Text="登 录" runat="server" OnClick="btXs_Click" />
                                    <asp:Label CssClass="txt-err" ID="Error1" runat="server"></asp:Label>
								</div>
                                </div>
						</div>	
					</div>
				</section>
			</div>
            </form>
		</div>
</body>
</html>
