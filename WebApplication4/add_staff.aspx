<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add_staff.aspx.cs" Inherits="WebApplication4.add_staff" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        label{
            width:100px;
            height:24px;
            display:block;
        }
    </style>
</head>
<body>
<form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    <label>员工账号:</label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <label>员工姓名:</label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <label>员工头像:</label>
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server"/>
                    <asp:Button ID="Button1" runat="server" Text="上传" OnClick="Button1_Click"/>
                </td>
                <td>
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    <asp:Image ID="Image1" runat="server" Width="50px" Height="50px"/>
                </td>
            </tr>
            <tr>
                <td>
                    <label>员工性别:</label>
                </td>
                <td>
                    <asp:RadioButtonList runat="server" ID="Sex_Tb" RepeatDirection="Horizontal" RepeatLayout="Table">
                        <asp:ListItem Value="1">男</asp:ListItem>
                        <asp:ListItem Value="0">女</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>
                    <label>员工年龄:</label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <label>手机号:</label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <label>密码:</label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                </td>
            </tr>
            <%-- todo 三联动 --%>
            <tr>
                <td>
                    <asp:Button ID="Button2" runat="server" Text="确定" CommandName="Insert" OnClick="Button2_Click"/>
                </td>
                <td>

                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button3" runat="server" Text="退出登录" OnClick="Button3_Click"  Visible="False"/>
                </td>
            </tr>
        </table>
    </div>
</form>
</body>
</html>