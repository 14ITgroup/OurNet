<%@ Page Title="" Language="C#" MasterPageFile="~/admin/BackStage.Master" AutoEventWireup="true" CodeBehind="addArticle.aspx.cs" Inherits="ITStudio.admin.addArticle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
  <script type="text/javascript" charset="utf-8" src="../admin/ueditor/ueditor.config.js"></script>
    <script type="text/javascript" charset="utf-8" src="../admin/ueditor/ueditor.all.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../admin/ueditor/lang/zh-cn/zh-cn.js"></script>
    <style type="text/css">
        .auto-style1 {
            font-size: large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
     <div style="float: right">
        当前帐户：<asp:Label ID="LblAdminName" runat="server"></asp:Label>
        <asp:HyperLink ID="HlkLogout" runat="server" NavigateUrl="~/admin/logout.aspx" Target="_self">注销</asp:HyperLink>
        <a href="newArticle.aspx">写新文章</a>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
     <hgroup class="title">
        <h1><%: Title %></h1>
    </hgroup>

    <div>
     <asp:TextBox ID="TxtTitle" runat="server" placeholder="请填写标题" Font-Bold="True" Font-Size="X-Large" MaxLength="40" Width="1024px" onfocus="checkForm()" onblur="checkForm()"></asp:TextBox>
     <br />
        <br />
        <textarea id="ueditor" name="ueditor" style="width: 1024px; height: 500px;" onfocus="checkForm()" onblur="checkForm()" runat="server"></textarea>
        <br />
        <br />
        <div onmouseover="checkForm()">
            <span class="auto-style1">上传封面图片：</span><asp:FileUpload ID="FulCoverPic" runat="server" />
            <asp:Label ID="LblUploadMessage" runat="server" Font-Size="20pt" Text="状态正常" Visible="False"></asp:Label>
            <br />
            <span class="auto-style1">文章分类：</span><asp:DropDownList ID="DdlCategories" runat="server" CssClass="auto-style1"></asp:DropDownList>
            <br />
            <br />
            <span class="auto-style1">选择标签：</span><asp:CheckBoxList ID="ChklstTags" runat="server" RepeatDirection="Horizontal"></asp:CheckBoxList>
            <asp:TextBox ID="TxtNewTag" runat="server"></asp:TextBox><asp:Button ID="BtnAddTag" runat="server" Text="新增标签" OnClick="BtnAddTag_Click" />
            <br />

            <asp:Button ID="BtnSubmit" runat="server" Text="提交" Font-Bold="True" Font-Size="XX-Large" OnClick="BtnSubmit_Click" Enabled="False" />
            <asp:Label ID="LblStatus" runat="server" Font-Bold="True" Text="状态" Visible="False"></asp:Label>
        </div>

        <script type="text/javascript">
            function checkForm() {
                var txtTitle = document.getElementById('<%=TxtTitle.ClientID%>');
            var file = document.getElementById('<%=FulCoverPic.ClientID%>');
            var btnSubmit = document.getElementById('<%=BtnSubmit.ClientID%>');
            if (txtTitle.value == '' || !(UE.getEditor('<%=ueditor.ClientID%>').hasContents()) || file.value == '') {
                btnSubmit.disabled = true;
                btnSubmit.value = '请填写完整';
            }
            else {
                btnSubmit.disabled = false;
                btnSubmit.value = '提交';
            }
        }
        </script>
    </div>

    <br />
    <br />

    <script type="text/javascript">
        window.onload = function getUEditor() {
        //实例化编辑器
        var ue = UE.getEditor('<%= ueditor.ClientID%>');
        }
    </script>
</asp:Content>
