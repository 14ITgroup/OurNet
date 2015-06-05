<%@ Page Title="后台管理登录" Language="C#" MasterPageFile="~/admin/BackStage.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="admin_login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title">
        <h1><%: Title %></h1>
    </hgroup>
    <section id="loginForm">
        
        <asp:Login ID="Login1" runat="server" ViewStateMode="Disabled" RenderOuterTable="false" OnAuthenticate="Login1_Authenticate" DestinationPageUrl="~/admin/index.aspx" FailureText="您输入的用户名或密码不正确，请重新输入。">
            <LayoutTemplate>
                <p class="validation-summary-errors">
                    <asp:Literal runat="server" ID="FailureText" />
                </p>
                <fieldset>
                    <legend>登录表单</legend>
                    <ol>
                        <li>
                            <asp:Label ID="Label1" runat="server" AssociatedControlID="UserName">用户名</asp:Label>
                            <asp:TextBox runat="server" ID="UserName" Columns="24" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="UserName" CssClass="field-validation-error" ErrorMessage="用户名字段是必填字段。" />
                        </li>
                        <li>
                            <asp:Label ID="Label2" runat="server" AssociatedControlID="Password">密码</asp:Label>
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" Columns="24" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Password" CssClass="field-validation-error" ErrorMessage="密码字段是必填字段。" />
                        </li>
                        <li>
                            <asp:Label ID="LblCaptcha" runat="server" AssociatedControlID="TxtCaptcha">验证码</asp:Label>
                            <asp:TextBox ID="TxtCaptcha" runat="server" placeholder="不区分大小写，点击图片刷新" Columns="24" />
                            <asp:Image ID="ImgCaptcha" runat="server" ImageUrl="~/admin/getCaptcha.aspx" onclick="changeCaptcha()" style="position:relative;top:7px;" />
                            <asp:RequiredFieldValidator ID="RfvCaptcha" runat="server" ControlToValidate="TxtCaptcha" CssClass="field-validation-error" ErrorMessage="验证码是必填字段。" />
                        </li>
                        <li>
                            <asp:CheckBox runat="server" ID="RememberMe" />
                            <asp:Label ID="Label3" runat="server" AssociatedControlID="RememberMe" CssClass="checkbox">记住我</asp:Label>
                        </li>
                    </ol>
                    <asp:Button ID="BtnLogin" runat="server" CommandName="Login" Text="登录" />
                </fieldset>
            </LayoutTemplate>
        </asp:Login>
    </section>

    <section id="socialLoginForm">
        <h2>爱特工作室</h2>
        <img src="Images/banner.jpg" height="300" width="533" />
    </section>

    <script type="text/javascript">
        function changeCaptcha() {
            var d = new Date();
            var captcha = document.getElementById('<%=Login1.FindControl("ImgCaptcha").ClientID%>');
            captcha.src = 'getCaptcha.aspx?nonsense='+d.getTime(); //强制浏览器刷新
        }
    </script>
</asp:Content>

