<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Orderlist.aspx.cs" Inherits="WebApplication4.Orderlist" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        table, tr, td {
            border: 1px solid red;
        }

        td {
            padding: 5px;
        }

        tr, td {
            text-align: center;
        }

        table {
            border-collapse: collapse;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <table>
                        <tr>
                            <td>订单编号</td>
                            <td>设备编号</td>
                            <td>数量</td>
                            <td>员工数量</td>
                            <td>订单时间</td>
                        </tr>
                </HeaderTemplate>

                <ItemTemplate>
                    <tr>
                        <td><%#("OrderNum") %></td>
                        <td><%#("DeviceNum") %></td>
                        <td><%#("Quantity") %></td>
                        <td><%#("StaffName") %></td>
                        <td><%#("StaffTime") %></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
