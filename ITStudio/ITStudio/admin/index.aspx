<%@ Page Title="后台管理首页" Language="C#" MasterPageFile="~/admin/BackStage.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ITStudio.admin.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title">
        <h1><%: Title %></h1>
    </hgroup>
</asp:Content>
