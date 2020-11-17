<%@ Page Language="C#" MasterPageFile="~/NavBar.Master" AutoEventWireup="true" CodeBehind="device_list.aspx.cs" Inherits="WebApplication4.device_list" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem Value="">是否删除</asp:ListItem>
            <asp:ListItem Value="0">未删除</asp:ListItem>
            <asp:ListItem Value="1">以删除</asp:ListItem>
        </asp:DropDownList>
        <table>
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                <HeaderTemplate>
                    <tr>
                        <td>设备编号</td>
                        <td>库存数量</td>
                        <td>是否删除</td>
                        <td>更新</td>
                        <td>删除</td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("device_number") %></td>
                        <td><%#Eval("device_count") %></td>
                        <td><%#Eval("is_delete").ToString() == "True" ? "已删除" : "未删除" %></td>
                        <%-- 隐藏控件设备主键 --%>
                        <asp:HiddenField runat="server" ID="HiddenField1" Value='<%#Eval("id") %>'/>
                        <td>
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edit">更新</asp:LinkButton>
                        </td>
                        <td>
                            <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Delete">删除</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <asp:Button runat="server" ID="Button3" Text="添加设备" OnClick="Button3_Click"/>
        <div class="am-fr">
            <webdiyer:AspNetPager
                runat="server"
                ID="AspNetPager1"
                FirstPageText="首页"
                HorizontalAlign="Center"
                AlwaysShow="True"
                PageSize="3"
                LastPageText="尾页"
                NextPageText="下一页"
                PrevPageText="上一页"
                OnPageChanged="AspNetPager1_OnPageChanged">
            </webdiyer:AspNetPager>
        </div>

    </div>
</asp:Content>