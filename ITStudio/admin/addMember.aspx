<%@ Page Title="" Language="C#" MasterPageFile="~/admin/BackStage.master" AutoEventWireup="true" CodeFile="addMember.aspx.cs" Inherits="admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            font-size: x-large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <hgroup class="title">
        <h1 class="auto-style1"><%: Title %></h1>
    </hgroup>

    <div>
        <span class="auto-style1">姓名：<asp:TextBox ID="txtName" runat="server" placeholder="请填写姓名" Font-Bold="True" Font-Size="X-Large" MaxLength="40" Width="157px" onfocus="checkForm()" onblur="checkForm()"></asp:TextBox>
        
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        年级：<asp:DropDownList ID="ddlGrade" runat="server" style="font-size: x-large" Width="91px">
                <asp:ListItem Value="2011">2011</asp:ListItem>
                <asp:ListItem>2012</asp:ListItem>
                <asp:ListItem>2013</asp:ListItem>
                <asp:ListItem>2014</asp:ListItem>
                <asp:ListItem>2015</asp:ListItem>
                <asp:ListItem>2016</asp:ListItem>
            </asp:DropDownList>
            </span><br />
        
        <br />
        <br />
        &nbsp;<span class="auto-style1">部门：<asp:DropDownList ID="ddlDeparement" runat="server" style="font-size: x-large">
                <asp:ListItem>程序开发</asp:ListItem>
                <asp:ListItem>美术设计</asp:ListItem>
                <asp:ListItem>系统维护</asp:ListItem>
            </asp:DropDownList>
        
            <br />
        <br />
        计算机研究方向：<asp:TextBox ID="txtDirection" runat="server" placeholder="请填写研究方向" Font-Bold="True" Font-Size="X-Large" MaxLength="40" Width="255px" onfocus="checkForm()" onblur="checkForm()"></asp:TextBox>
        
            </span>
        <br />
        <br />
        <br />
        <div onmouseover="checkForm()">
            <span class="auto-style1">上传照片：</span><asp:FileUpload ID="fulPhoto" runat="server" style="font-size: x-large" />
            <asp:Label ID="lblUploadMessage" runat="server" Font-Size="20pt" Text="状态正常" Visible="False"></asp:Label>
            <br />
            <br />
            <span class="auto-style1">简介：<br />
        <textarea id="txtIntroduction" name="txtIntroduction" style="width: 636px; height: 284px;" onfocus="checkForm()" onblur="checkForm()" runat="server"></textarea><br />
        
            </span>
            <br />

            <asp:Button ID="btnSubmit" runat="server" Text="提交" Font-Bold="True" Font-Size="XX-Large" OnClick="BtnSubmit_Click" Enabled="False" Height="68px" />
            <asp:Label ID="LblStatus" runat="server" Font-Bold="True" Text="状态" Visible="False"></asp:Label>
        </div>

        <script type="text/javascript">
            function checkForm() {
                var txtTitle = document.getElementById('<%=txtName.ClientID%>');
                var txtIntroduction = document.getElementById('<%=txtIntroduction.ClientID%>');
                var txtDirection = document.getElementById('<%=txtDirection.ClientID%>');
                var fulPhoto = document.getElementById('<%=fulPhoto.ClientID%>');
                var btnSubmit = document.getElementById('<%=btnSubmit.ClientID%>');

                if (txtTitle.value == '' || txtIntroduction.value == "" || fulPhoto.value == '' || txtDirection.value == "") {
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

</asp:Content>

