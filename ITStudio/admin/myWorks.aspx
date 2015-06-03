<%@ Page Title="管理作品" Language="C#" MasterPageFile="~/admin/BackStage.master" AutoEventWireup="true" CodeFile="myWorks.aspx.cs" Inherits="admin_myWorks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
      <h2>文章列表</h2>
    <p>
        当前共有
        <asp:Literal ID="LtlArticlesCount" runat="server"></asp:Literal>
        个作品
    </p>
    每页<asp:DropDownList ID="DdlPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DdlPageSize_SelectedIndexChanged">
        <asp:ListItem>3</asp:ListItem>
        <asp:ListItem>10</asp:ListItem>
        <asp:ListItem>20</asp:ListItem>
    </asp:DropDownList>篇
    <asp:Repeater ID="RptArticles" runat="server" OnItemCommand="RptArticles_ItemCommand">
        <HeaderTemplate>
            <table>
                <tr>
                    <th>标题</th>
                    <th>时间</th>
                    <th>链接</th>
                    <th>操作</th>
                    <th>操作</th>
                </tr>
        </HeaderTemplate>

        <ItemTemplate>
            <tr>
                <td>
                    <asp:HyperLink ID="HyperLinkArticle" runat="server" Text='<%#Eval("title")%>' Target="_blank"
                        NavigateUrl='<%#"no.aspx?id="+Eval("id") %>'>HyperLink</asp:HyperLink>
                </td>
                <td>
                    <%#Eval("time")%>
                </td>
                <td>
                    <%#Eval("link")%>
                </td>
                <td>
                    <asp:HyperLink ID="HlkEdit" runat="server" NavigateUrl='<%#"editWorks.aspx?id="+Eval("id")%>' Text="修改">修改</asp:HyperLink>
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
</asp:Content>