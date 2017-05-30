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
                <asp:TemplateField HeaderText="章节" SortExpression="Chapter">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Chapter") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="TextBox11" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("Chapter") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False" HeaderText="编辑">
                    <EditItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Up" Text="更新" CommandArgument='<%# Container.DataItemIndex %>'></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消"></asp:LinkButton>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="添加" />
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Edit" Text="编辑"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="删除" ShowHeader="False">
                    <FooterTemplate>
                        <asp:Button ID="Button2" runat="server" Text="取消" OnClick="Button2_Click" />
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" CommandName="Delete" Text="删除"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:con %>" DeleteCommand="DELETE FROM [Filling] WHERE [Number] = @Number" InsertCommand="INSERT INTO [Filling] ([Subject], [Answer1], [Answer2], [Answer3], [Chapter]) VALUES (@Subject, @Answer1, @Answer2, @Answer3, @Chapter)" SelectCommand="SELECT [Number], [Subject], [Answer1], [Answer2], [Answer3], [Chapter] FROM [Filling]" UpdateCommand="UPDATE [Filling] SET [Subject] = @Subject, [Answer1] = @Answer1, [Answer2] = @Answer2, [Answer3] = @Answer3, [Chapter] = @Chapter WHERE [Number] = @Number">
            <DeleteParameters>
                <asp:Parameter Name="Number" Type="Int64" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Subject" Type="String" />
                <asp:Parameter Name="Answer1" Type="String" />
                <asp:Parameter Name="Answer2" Type="String" />
                <asp:Parameter Name="Answer3" Type="String" />
                <asp:Parameter Name="Chapter" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Subject" Type="String" />
                <asp:Parameter Name="Answer1" Type="String" />
                <asp:Parameter Name="Answer2" Type="String" />
                <asp:Parameter Name="Answer3" Type="String" />
                <asp:Parameter Name="Chapter" Type="Int32" />
                <asp:Parameter Name="Number" Type="Int64" />
            </UpdateParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
