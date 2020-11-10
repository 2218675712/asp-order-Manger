<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="order_list.aspx.cs" Inherits="WebApplication4.order_list" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
<form id="form1" runat="server">
    <div>
        <table >
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <tr>
                        <td>订单编号</td>
                        <td>设备编号</td>
                        <td>数量</td>
                        <td>员工姓名</td>
                        <td>订单时间</td>
                        <td>
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Add" OnClick="LinkButton1_Click">添加</asp:LinkButton>
                        </td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("order_number") %></td>
                        <td><%#Eval("device_number") %></td>
                        <td><%#Eval("device_count") %></td>
                        <td><%#Eval("worker_name") %></td>
                        <td><%#Eval("order_date") %></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <asp:Button ID="Button1" runat="server" Text="退出登录" OnClick="Button1_Click" />
    </div>
</form>
</body>
</html>