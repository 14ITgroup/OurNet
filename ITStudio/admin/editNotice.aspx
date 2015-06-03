<%@ Page Title="编辑公告" Language="C#" MasterPageFile="~/admin/BackStage.master" AutoEventWireup="true" CodeFile="editNotice.aspx.cs" Inherits="admin_editNotice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <script type="text/javascript" charset="utf-8" src="../admin/ueditor/ueditor.config.js"></script>
    <script type="text/javascript" charset="utf-8" src="../admin/ueditor/ueditor.all.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../admin/ueditor/lang/zh-cn/zh-cn.js"></script>
    <style type="text/css">
        .auto-style1 {
            font-size: x-large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
         <hgroup class="title">
        <h1><%: Title %></h1>
    </hgroup>

    <div>
        <span class="auto-style1">标题：<br />
        </span>
     <asp:TextBox ID="txtTitle" runat="server" placeholder="请填写标题" Font-Bold="True" Font-Size="X-Large" MaxLength="40" Width="1024px" onfocus="checkForm()" onblur="checkForm()"></asp:TextBox>
     <br />
        <span class="auto-style1">内容：</span><br />
        <textarea id="ueditor" name="ueditor" style="width: 1024px; height: 287px;" onfocus="checkForm()" onblur="checkForm()" runat="server"></textarea>
        <br />
        <div onmouseover="checkForm()">
            <br />

            <asp:Button ID="btnSubmit" runat="server" Text="提交" Font-Bold="True" Font-Size="XX-Large" OnClick="BtnSubmit_Click" Enabled="False" Height="56px" />
            <asp:Label ID="LblStatus" runat="server" Font-Bold="True" Text="状态" Visible="False"></asp:Label>
        </div>

        <script type="text/javascript">
            function checkForm() {
                var txtTitle = document.getElementById('<%=txtTitle.ClientID%>');
                var btnSubmit = document.getElementById('<%=btnSubmit.ClientID%>');
                if (txtTitle.value == '' || !(UE.getEditor('<%=ueditor.ClientID%>').hasContents())) {
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