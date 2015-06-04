<%@ Page Title="注销" Language="C#" MasterPageFile="~/admin/BackStage.master" AutoEventWireup="true" CodeFile="logout.aspx.cs" Inherits="admin_logout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <hgroup class="title">
        <h1><%: Title %></h1>
    </hgroup>
    <asp:Label ID="LblStatus" runat="server"></asp:Label>
    <asp:HyperLink ID="HlkLogin" runat="server" NavigateUrl="~/admin/login.aspx" Target="_self">登录</asp:HyperLink>
</asp:Content>

