<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FillingManagement.aspx.cs" Inherits="StuExam.Teacher.FillingManagement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../Content/bootstrap.min.css" type="text/css" rel="stylesheet"/>
    <script type="text/javascript" src="../scripts/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="../scripts/bootstrap.min.js"></script>
    <title>填空题管理</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1"  runat="server" AutoGenerateColumns="False" CssClass="table table-hover" DataKeyNames="Number" DataSourceID="SqlDataSource1" OnRowCommand="GridView1_RowCommand" ShowFooter="True" AllowPaging="True">
            <Columns>
                <asp:TemplateField HeaderText="Number" InsertVisible="False" SortExpression="Number" Visible="False">
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Number") %>'></asp:Label>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Number") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="题目" SortExpression="Subject">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1"   Height="300px" Width="100%" runat="server" Text='<%# Eval("Subject").ToString().Replace("<br/>", "\n").Replace("&", "").Replace("nbsp;", " ") %>' TextMode="MultiLine"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="TextBox7" Height="300px" Width="100%" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2"   Width="400px"  runat="server" Text='<%# Eval("Subject").ToString().Replace("<br/>", "\n").Replace("&", "").Replace("nbsp;", " ") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="答案1" SortExpression="Answer1">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2"  Height="300px" Width="100%" runat="server" Text='<%# Bind("Answer1") %>' TextMode="MultiLine"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="TextBox8" Height="300px" Width="100%" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("Answer1") %>' Width="200px"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="答案2" SortExpression="Answer2">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" Height="300px" Width="100%" runat="server" Text='<%# Bind("Answer2") %>' TextMode="MultiLine"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="TextBox9" Height="300px" Width="100%" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("Answer2") %>' Width="200px"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="答案3" SortExpression="Answer3">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" Height="300px" Width="100%" runat="server" Text='<%# Bind("Answer3") %>' TextMode="MultiLine"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="TextBox10" Height="300px" Width="100%" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("Answer3") %>' Width="200px"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
