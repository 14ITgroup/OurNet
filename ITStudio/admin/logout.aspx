<%@ Page Title="注销" Language="C#" MasterPageFile="~/admin/BackStage.master" AutoEventWireup="true" CodeFile="logout.aspx.cs" Inherits="admin_logout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="Server">
    <hgroup class="title">
        <h1><%: Title %></h1>
    </hgroup>
    <h2>
        <asp:Label ID="LblStatus" runat="server"></asp:Label>
    </h2>

    <asp:HyperLink ID="HlkLogin" runat="server" NavigateUrl="~/admin/login.aspx" Target="_self">
        <asp:Label ID="LblLoginTxt" runat="server" Text=""></asp:Label>
    </asp:HyperLink>
</asp:Content>

