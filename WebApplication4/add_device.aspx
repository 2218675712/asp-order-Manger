<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add_device.aspx.cs" Inherits="WebApplication4.add_device" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
<form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>设备编号：</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>

            </tr>
            <tr>
                <td>数量：</td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <asp:Button ID="Button1" runat="server" Text="确认" OnClick="Button1_Click"/>
    </div>
</form>
</body>
</html>