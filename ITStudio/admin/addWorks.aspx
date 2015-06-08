<%@ Page Title="添加作品" Language="C#" MasterPageFile="~/admin/BackStage.master" AutoEventWireup="true" CodeFile="addWorks.aspx.cs" Inherits="admin_addWorks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
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
        <h1 class="auto-style1"><%: Title %></h1>
    </hgroup>

    <div>
        <span class="auto-style1">作品名称：</span><br />
        <asp:TextBox ID="txtTitle" runat="server" placeholder="请填写标题" Font-Bold="True" Font-Size="X-Large" MaxLength="40" Width="1024px" onfocus="checkForm()" onblur="checkForm()"></asp:TextBox>
        
        <br />
        <span class="auto-style1">作品描述：</span><br />
        <textarea id="txtIntroduction" name="txtIntroduction" style="width: 1024px; height: 342px;" onfocus="checkForm()" onblur="checkForm()" runat="server"></textarea>
        <br />
        <br />
        <div onmouseover="checkForm()">
            <span class="auto-style1">上传作品图片：<br />
            </span><asp:FileUpload ID="fulPicture" runat="server" style="font-size: x-large" />
            <asp:Label ID="lblUploadMessage" runat="server" Font-Size="20pt" Text="状态正常" Visible="False"></asp:Label>
            <br />
            <span class="auto-style1">作品类型：<br />
            <asp:DropDownList ID="ddlType" runat="server" style="font-size: x-large">
                <asp:ListItem Value="1">网站作品</asp:ListItem>
                <asp:ListItem Value="2">CG作品</asp:ListItem>
                <asp:ListItem Value="3">FLASH作品</asp:ListItem>
                <asp:ListItem Value="4">其他作品</asp:ListItem>
            </asp:DropDownList>
            <br />
            作品完成时间：<br /><asp:TextBox ID="txtTime" runat="server" placeholder="请填写时间" Font-Bold="True" Font-Size="X-Large" MaxLength="40" Width="459px" onfocus="checkForm()" onblur="checkForm()"></asp:TextBox>
        
        
            <br />
            网站链接(可不填写)：<br />
        <asp:TextBox ID="txtLink" runat="server" placeholder="请填写网站链接" Font-Bold="True" Font-Size="X-Large" MaxLength="40" Width="459px" onfocus="checkForm()" onblur="checkForm()"></asp:TextBox>
        
            </span>
            <br />

            <asp:Button ID="btnSubmit" runat="server" Text="提交" Font-Bold="True" Font-Size="XX-Large" OnClick="BtnSubmit_Click" Enabled="False" Height="68px" />
            <asp:Label ID="LblStatus" runat="server" Font-Bold="True" Text="状态" Visible="False"></asp:Label>
        </div>

        <script type="text/javascript">
            function checkForm() {
                var txtTitle = document.getElementById('<%=txtTitle.ClientID%>');
                var txtTime = document.getElementById('<%=txtTime.ClientID%>');
                var fulPicture = document.getElementById('<%=fulPicture.ClientID%>');
                var txtIntroduction = document.getElementById('<%=txtIntroduction.ClientID%>');
                var btnSubmit = document.getElementById('<%=btnSubmit.ClientID%>');

                if (txtTitle.value == '' || txtIntroduction.value == "" || fulPicture.value == '' || txtTime.value == "") {
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
</asp:Content>

