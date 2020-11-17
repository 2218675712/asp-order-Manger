﻿<%@ Page Language="C#" MasterPageFile="~/NavBar.Master" AutoEventWireup="true" CodeBehind="manage_staff.aspx.cs" Inherits="WebApplication4.manage_staff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem Value="">请选择性别</asp:ListItem>
            <asp:ListItem Value="0">女</asp:ListItem>
            <asp:ListItem Value="1">男</asp:ListItem>
        </asp:DropDownList>
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
                        <td>省份</td>
                        <td>城市</td>
                        <td>县区</td>
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
                        <td><%#Eval("s_province") %></td>
                        <td><%#Eval("s_city") %></td>
                        <td><%#Eval("s_district") %></td>
                        <td>
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edit">更新</asp:LinkButton>
                            <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Delete">删除</asp:LinkButton>
                        </td>
                        <asp:HiddenField ID="staffId" runat="server" value='<%#Eval("Id") %>'/>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>

    </div>
</asp:Content>