<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cookie_test.aspx.cs" Inherits="WebApplication4.cookie_test" %>

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
                <td>手机号:</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>密码:</td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server"  TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="CheckBox1" runat="server" Text="记住密码"/>
                </td>
                <td>
                    <asp:CheckBox  ID="CheckBox2" runat="server" Text="自动登录"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="登录" OnClick="Button1_Click"/>
                </td>

            </tr>
        </table>
    </div>
</form>
</body>
</html>