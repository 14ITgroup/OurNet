<%@ Page Title="管理员管理" Language="C#" MasterPageFile="~/admin/BackStage.master" AutoEventWireup="true" CodeFile="Admins.aspx.cs" Inherits="admin_Admins" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <hgroup class="title">
        <h1><%: Title %></h1>
    </hgroup>
    <hr />
    <h2>管理员列表</h2>
    <asp:Repeater ID="RptAdmins" runat="server" OnItemCommand="RptAdmins_ItemCommand">
        <HeaderTemplate>
            <table>
                <tr>
                    <th>
                        <input id="adminID" type="text" hidden="hidden" />
                    </th>
                    <th>管理员名</th>
                    <th>操作</th>
                    <th>操作</th>
                </tr>
        </HeaderTemplate>

        <ItemTemplate>
            <tr>
                <td>
                    <input id="adminsID" type="text" value="<%#Eval("id") %>" hidden="hidden" />
                </td>
                <td>
                    <%#Eval("name")%>
                </td>
                <td>
                    <asp:LinkButton ID="Btn_Delete" runat="server" Text="删除" CommandName="delete_admin" CommandArgument='<%#Eval("id") %>' OnClientClick="return confirm('你真的要删除吗？');"></asp:LinkButton>
                </td>
                <td>
                    <asp:LinkButton ID="Btn_Change" runat="server" Text="修改密码" CommandName="change_admin" CommandArgument='<%#Eval("id") %>' OnClientClick="return confirm('你真的要修改吗')"></asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>

        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <br />
    
    <table>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="20px" Height="35px" Text="原密码"></asp:Label></td>
            <td>
                <asp:TextBox ID="oldPassword" runat="server" TextMode="Password"></asp:TextBox></td>
            <td>
                <asp:TextBox ID="HideBox" runat="server" Visible="False"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="20px" Height="35px" Text="新密码"></asp:Label></td>
            <td>
                <asp:TextBox ID="newPassword" runat="server" TextMode="Password"></asp:TextBox></td>
            <td></td>
        </tr>
    </table>
    <br />
    <asp:Button ID="Btn_change" runat="server" Text="提交修改" OnClick="Btn_change_Click" />
    <br />
    <hr />
    <h2>添加管理员</h2>
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="用户名" Font-Bold="True" Font-Size="20px" Height="35px"></asp:Label></td>
            <td>
                <asp:TextBox ID="newAdmin" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="密码" Font-Bold="True" Font-Size="20px" Height="35px"></asp:Label></td>
            <td>
                <asp:TextBox ID="newPassword1" runat="server" TextMode="Password"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="再次输入密码" Font-Bold="True" Font-Size="20px" Height="35px"></asp:Label></td>
            <td>
                <asp:TextBox ID="newPassword2" runat="server" TextMode="Password"></asp:TextBox></td>
        </tr>
    </table>
    <asp:Button ID="add" runat="server" Text="添加管理员" OnClick="add_Click" />
</asp:Content>

