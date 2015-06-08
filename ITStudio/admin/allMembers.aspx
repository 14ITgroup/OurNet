<%@ Page Title="" Language="C#" MasterPageFile="~/admin/BackStage.master" AutoEventWireup="true" CodeFile="allMembers.aspx.cs" Inherits="admin_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
        <hgroup class="title">
        <h1><%: Title %></h1>
    </hgroup>

    <h2>公告列表</h2>
    <p>
        当前共有
        <asp:Literal ID="LtlArticlesCount" runat="server"></asp:Literal>
        篇文章
    </p>
    每页<asp:DropDownList ID="DdlPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DdlPageSize_SelectedIndexChanged" Height="16px">
        <asp:ListItem>10</asp:ListItem>
        <asp:ListItem>20</asp:ListItem>
        <asp:ListItem>30</asp:ListItem>
        <asp:ListItem>50</asp:ListItem>
    </asp:DropDownList>人
    <asp:Repeater ID="RptArticles" runat="server" OnItemCommand="RptArticles_ItemCommand">
        <HeaderTemplate>
            <table>
                <tr>
                    <th>年级</th>
                    <th>姓名</th>
                    <th>操作</th>
                    <th>操作</th>
                </tr>
        </HeaderTemplate>

        <ItemTemplate>
            <tr>
                <td>
                    <%#Eval("grade")%>
                </td>
                <td>
                    <%#Eval("name")%>
                </td>
                 <td>
                    <%#Eval("direction")%>
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
    <asp:TextBox ID="TxtPageNum" runat="server" Height="22px" Style="font-size: large" Width="37px">1</asp:TextBox>
    <asp:Button ID="BtnJumpPage" runat="server" OnClick="BtnJumpPage_Click" Text="跳页" />
</asp:Content>

