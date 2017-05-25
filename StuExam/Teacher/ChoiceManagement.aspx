<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChoiceManagement.aspx.cs" Inherits="StuExam.Teacher.ChoiceManagement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../Content/bootstrap.min.css" type="text/css" rel="stylesheet"/>
    <script type="text/javascript" src="../scripts/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="../scripts/bootstrap.min.js"></script>
    <style type="text/css">
        .label
        {
            overflow-y: auto;
            color:black;
            font-size:14px
        }
        </style>
    <title>题库管理</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" CssClass="table table-hover" AutoGenerateColumns="False"  DataSourceID="SqlDataSource1" OnRowCommand="GridView1_RowCommand" DataKeyNames="Number" ShowFooter="True" Width="100%">
            <Columns>
                <asp:TemplateField HeaderText="题目" SortExpression="Subject">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("Subject").ToString().Replace("<br/>", "\n").Replace("&", "").Replace("nbsp;", " ") %>' TextMode="MultiLine" Width="100%" Height="300px"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="Text_Subject" runat="server"  TextMode="MultiLine" Height="300px" Width="100%"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Subject")  %>' ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="答案" SortExpression="Answer">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Answer") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="Text_Answer" runat="server"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Answer") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="章节" SortExpression="Chapter">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Chapter") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="Text_Chapter" runat="server"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("Chapter") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="序号" InsertVisible="False" SortExpression="Number" Visible="False">
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Number") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("Number") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False" HeaderText="编辑">
                    <EditItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Up" Text="更新" CommandArgument='<%# Container.DataItemIndex %>'></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消"></asp:LinkButton>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:Button ID="Butt_Submit" runat="server" OnClick="Butt_Submit_Click" Text="确认提交" />
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Edit" Text="编辑"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="删除" ShowHeader="False">
                    <FooterTemplate>
                        <asp:Button ID="Butt_Cancel" runat="server" OnClick="Butt_Cancel_Click" Text="取消" />
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" CommandName="Delete" Text="删除"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:con %>" 
            DeleteCommand="DELETE FROM [Choice] WHERE [Number] = @Number" 
            InsertCommand="INSERT INTO [Choice] ([Subject], [Answer], [Chapter]) VALUES (@Subject, @Answer, @Chapter)" 
            SelectCommand="SELECT [Subject], [Answer], [Chapter], [Number] FROM [Choice]" >
            <DeleteParameters>
                <asp:Parameter Name="Number" Type="Int64" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Subject" Type="String" />
                <asp:Parameter Name="Answer" Type="String" />
                <asp:Parameter Name="Chapter" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Subject" Type="String" />
                <asp:Parameter Name="Answer" Type="String" />
                <asp:Parameter Name="Chapter" Type="Int32" />
                <asp:Parameter Name="Number" Type="Int64" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>