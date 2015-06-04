<%@ Page Title="管理申请" Language="C#" MasterPageFile="~/admin/BackStage.master" AutoEventWireup="true" CodeFile="Applications.aspx.cs" Inherits="Applications" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
             <h2>申请列表</h2>
    <p>
        当前共有
        <asp:Literal ID="LtlApplicationsCount" runat="server"></asp:Literal>
        位申请人
    </p>
    每页<asp:DropDownList ID="DdlPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DdlPageSize_SelectedIndexChanged" Height="16px">
        <asp:ListItem>3</asp:ListItem>
        <asp:ListItem>10</asp:ListItem>
        <asp:ListItem>20</asp:ListItem>
    </asp:DropDownList>人
    <asp:Repeater ID="RptApplication" runat="server" OnItemCommand="RptArticles_ItemCommand">
        <HeaderTemplate>
            <table>
                <tr>
                    <th>名字</th>
                    <th>性别</th>
                    <th>专业</th>
                    <th>方向</th>
                    <th>联系电话</th>
                    <th>申请时间</th>
                    <th>介绍</th>
                    <th>操作</th>
                </tr>
        </HeaderTemplate>

        <ItemTemplate>
            <tr>
                <td>
                    <%#Eval("name")%>
                </td>
                <td>
                    <%#Eval("gender")%>
                </td>
                <td>
                    <%#Eval("major")%>
                </td>
                <td>
                    <%#Eval("job")%>
                </td>
                <td>
                    <%#Eval("tel") %>
                </td>
                <td>
                    <%#Eval("time")%>
                </td>
                <td>
                    <%#Eval("introduction")%>
                </td>
                <td>
                    <asp:Button ID="BtnDelete" runat="server" Text="删除" CommandName="delete" CommandArgument='<%#Eval("id")%>'
                        OnClientClick="return confirm('你真的要删除吗？');" />
                </td>
            </tr>
        </ItemTemplate>

        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <br />
    <asp:Button ID="BtnPreviousPage" runat="server" OnClick="BtnPreviousPage_Click" Text="前一页" />
    <asp:Button ID="BtnNextPage" runat="server" OnClick="BtnNextPage_Click" Text="后一页" />
    <asp:Button ID="BtnHomePage" runat="server" OnClick="BtnHomePage_Click" Text="首页" />
    <asp:Button ID="BtnTrailerPage" runat="server" OnClick="BtnTrailerPage_Click" Text="尾页" />
    <asp:TextBox ID="TxtPageNum" runat="server" Height="22px" style="font-size: large" Width="37px">1</asp:TextBox>
    <asp:Button ID="BtnJumpPage" runat="server" OnClick="BtnJumpPage_Click" Text="跳页" />
    <asp:DropDownList ID="DdlSelect" runat="server" Height="36px"  Width="99px" CssClass="site-title" Font-Size="Large">
        <asp:ListItem Value="1">美术设计</asp:ListItem>
        <asp:ListItem Value="2">程序开发</asp:ListItem>
        <asp:ListItem Value="3">系统维护</asp:ListItem>
    </asp:DropDownList>
    <asp:Button ID="BtnImport" runat="server" OnClick="BtnImport_Click" Text="导出" />
</asp:Content>

