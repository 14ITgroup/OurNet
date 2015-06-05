<%@ Page Title="管理员管理" Language="C#" MasterPageFile="~/admin/BackStage.master" AutoEventWireup="true" CodeFile="Admins.aspx.cs" Inherits="admin_Admins" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="Server">
    <hgroup class="title">
        <h1><%#Eval("name")%></h1>
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
                    <input id="TxtAdminIdHidden" type="text" value="<%#Eval("id") %>" hidden="hidden" />
                </td>
                <td>
                    <%#Eval("name")%>
                </td>
                <td>
                    <asp:LinkButton ID="BtnDelete" runat="server" Text="删除" CommandName="delete_admin" 
                        CommandArgument='<%#Eval("id") %>' OnClientClick='<%# "return confirm(\x27确定删除管理员 "+Eval("name")+" 吗？\x27)" %>'></asp:LinkButton>
                </td>
                <td>
                    <asp:LinkButton ID="BtnChange" runat="server" Text="修改密码" CommandName="change_admin"
                         CommandArgument='<%#Eval("id") %>' OnClientClick='<%# "return confirm(\x27确定修改管理员 "+Eval("name")+" 吗？\x27)" %>'></asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>

        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <br />
    <asp:TextBox ID="TxtIdToChange" runat="server" Visible="False"></asp:TextBox>
    <asp:Table ID="TblChangePassword" runat="server">
        <asp:TableRow>
            <asp:TableCell>
                原密码
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="TxtOldPassword" runat="server" TextMode="Password" MaxLength="16"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                新密码
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="TxtNewPassword" runat="server" TextMode="Password" MaxLength="16" placeholder="密码长度为6到16位"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Button ID="BtnChange" runat="server" Text="提交修改" OnClick="BtnChange_Click" />
    <br />

    <hr />
    <h2>添加管理员</h2>
    <table>
        <tr>
            <td>用户名</td>
            <td>
                <asp:TextBox ID="TxtNewAdminName" runat="server" MaxLength="16" placeholder="登录名最大长度16位"></asp:TextBox></td>
        </tr>
        <tr>
            <td>密码</td>
            <td>
                <asp:TextBox ID="TxtNewAdminPassword" runat="server" TextMode="Password" MaxLength="16" placeholder="密码长度为6到16位"></asp:TextBox></td>
        </tr>
        <tr>
            <td>再次输入密码</td>
            <td>
                <asp:TextBox ID="TxtNewAdminPasswordAgain" runat="server" TextMode="Password" MaxLength="16" placeholder="密码长度为6到16位"></asp:TextBox></td>
        </tr>
    </table>
    <asp:Button ID="BtnAddAdmin" runat="server" Text="添加管理员" OnClick="BtnAddAdmin_Click" />
</asp:Content>

