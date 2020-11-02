<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="out_device_list.aspx.cs" Inherits="WebApplication4.out_device_list" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
<form id="form1" runat="server">
    <div>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem Value="">是否删除</asp:ListItem>
            <asp:ListItem Value="0">未删除</asp:ListItem>
            <asp:ListItem Value="1">以删除</asp:ListItem>
        </asp:DropDownList>
        <div>
            <asp:Menu ID="Menu1" runat="server">
                <Items>
                    <asp:MenuItem NavigateUrl="manage_staff.aspx" Text="员工列表" Value="员工列表"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="device_list.aspx" Text="设备列表" Value="设备列表"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="manage_info.aspx" Text="个人信息" Value="个人信息"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="out_device_list.aspx" Text="出库列表" Value="出库列表"></asp:MenuItem>
                </Items>
            </asp:Menu>
        </div>
        <table>
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                <HeaderTemplate>
                    <tr>
                        <td>设备编号</td>
                        <td>库存数量</td>
                        <td>是否删除</td>
                        <td>出库数量</td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("device_number") %></td>
                        <td><%#Eval("device_count") %></td>
                                              <td><%#Eval("is_delete").ToString()=="True"?"已删除":"未删除"%></td>

                        <td><%#Eval("out_quantity") %></td>
                        <%-- 隐藏控件设备主键 --%>
                            <asp:HiddenField runat="server" ID="HiddenField1" Value='<%#Eval("id") %>'/>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
</form>
</body>
</html>