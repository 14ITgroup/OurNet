<%@ Page Title="后台管理首页" Language="C#" MasterPageFile="~/admin/BackStage.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="admin_index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .pictureLeft {
            height: 220px;
            background-color: #EFEEEF;
            float: left;
            transition: width 1s,height 0.5s;
            -moz-transition: width 1s,height 0.5s; /* Firefox 4 */
            -webkit-transition: width 1s,height 0.5s; /* Safari and Chrome */
            -o-transition: width 1s,height 0.5s; /* Opera */
        }

            .pictureLeft:hover {
                height: 235px;
            }

        .pictureRight {
            height: 220px;
            background-color: #EFEEEF;
            float: right;
            transition: width 1s,height 0.5s;
            -moz-transition: width 1s,height 0.5s; /* Firefox 4 */
            -webkit-transition: width 1s,height 0.5s; /* Safari and Chrome */
            -o-transition: width 1s,height 0.5s; /* Opera */
        }

            .pictureRight:hover {
                height: 235px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title">
        <h1><%: Title %></h1>
    </hgroup>
    <p>
        <abbr title="公告管理">
            <asp:HyperLink ID="HlkArticles" runat="server" NavigateUrl="myNotice.aspx">
                <asp:Image ID="ImgArticles" runat="server" CssClass="pictureLeft" ImageUrl="Images/notices.png" />
            </asp:HyperLink>
        </abbr>
        <abbr title="作品管理">
            <asp:HyperLink ID="HlkVideos" runat="server" NavigateUrl="myWorks.aspx">
                <asp:Image ID="ImgVideos" runat="server" CssClass="pictureRight" ImageUrl="Images/works.png" />
            </asp:HyperLink>
        </abbr>
    </p>
    <div style="clear: both">
    </div>
    <p>
        <abbr title="申请管理">
            <asp:HyperLink ID="HlkCategories" runat="server" NavigateUrl="Applications.aspx">
                <asp:Image ID="ImgCategories" runat="server" CssClass="pictureLeft" ImageUrl="Images/applications.png" />
            </asp:HyperLink>
        </abbr>
        <abbr title="管理员管理">
            <asp:HyperLink ID="HlkAdmins" runat="server" NavigateUrl="~/admin/Admins.aspx">
                <asp:Image ID="ImgAdmins" runat="server" CssClass="pictureRight" ImageUrl="~/admin/images/admins.png" />
            </asp:HyperLink>
        </abbr>
    </p>
</asp:Content>
