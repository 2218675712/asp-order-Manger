<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="manage_staff.aspx.cs" Inherits="WebApplication4.manage_staff" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
<form id="form1" runat="server">
    <div>
        <table style="text-align:center;border:solid 1px #000000;">

            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                <HeaderTemplate>
                    <tr>
                        <td>员工工号</td>
                        <td>员工姓名</td>
                        <td>员工头像</td>
                        <td>性别</td>
                        <td>年龄</td>
                        <td>手机号</td>
                        <td>密码</td>
                    </tr>

                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("worker_num") %></td>
                        <td><%#Eval("worker_name") %></td>
                        <td>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("worker_avatar") %>' Width="50px" Height="50px"/>
                        </td>
                        <td><%#Eval("worker_sex").ToString() == "0" ? "女" : "男" %></td>
                        <td><%#Eval("worker_age") %></td>
                        <td><%#Eval("worker_mobile") %></td>
                        <td><%#Eval("worker_password") %></td>
                        <td>
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edit">更新</asp:LinkButton>
                            <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Delete">删除</asp:LinkButton>
                        </td>
                        <asp:HiddenField ID="staffId" runat="server" value='<%#Eval("Id") %>'/>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <asp:Button ID="Button1" runat="server" Text="新建用户" OnClick="Button1_Click"/>

    </div>
</form>
</body>
</html>