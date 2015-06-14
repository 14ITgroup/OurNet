<%@ Page Title="" Language="C#" MasterPageFile="~/Itshow.master" AutoEventWireup="true" CodeFile="personal_display.aspx.cs" Inherits="personal_display" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>personal_display</title>
    <link href="css/index.css" rel="stylesheet" />
    <script type="text/javascript" src="js/jquery-1.11.2.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- 电脑端界面 -->
    <div class="main">
        <asp:Repeater ID="RptMenber" runat="server">
            <ItemTemplate>
                <img src="./upload/memberPhoto/<%#Eval("photo") %>" alt="person">
                <div></div>
                <h1><%#Eval("name") %></h1>
                <ul>
                    <img src="./images/personal_line.jpg" alt="">
                    <p>since 2009</p>
                    <img src="./images/personal_line.jpg" alt="">
                </ul>
                <h5>
                    <asp:Label ID="Label1" runat="server" Text=""><%#Eval("introduction") %></asp:Label></h5>
                <br />
                <p>方向：<a> <%#Eval("direction") %></a></p>
                <br />
            </ItemTemplate>
        </asp:Repeater>
         <div></div>
        <p>主要作品</p>

        <asp:Repeater ID="RptWorks" runat="server">
            <HeaderTemplate>
                <ul class="clr"></ul>
            </HeaderTemplate>

            <ItemTemplate>
                <div>
                    <ul class="work-pres-personal">
                        <a href="#">
                            <img src="./upload/workPicture/<%#Eval("photo") %>" alt="pic1" />
                            <img src="./upload/workPicture/<%#Eval("photo") %>" alt="作品" />
                        </a>
                        <h3><a href="#"><%#Eval("introduction") %></a></h3>
                        <p><%#Eval("time") %></p>
                        <p><%#Eval("title") %></p>
                    </ul>
                </div>
            </ItemTemplate>

            <FooterTemplate>
                <div class="clr"></div>
            </FooterTemplate>
        </asp:Repeater>
    </div>

    <!-- 移动端界面 -->
    <div class="main-mobile-person">
        <img src="images/person-dis-mobile_03.png" alt="成员展示" />
        <asp:Repeater ID="RptMember2" runat="server">
            <ItemTemplate>
                <img src="./upload/memberPhoto/<%#Eval("photo") %>" alt="照片" />
                <h1><%#Eval("name") %></h1>
                <p>
                    <%#Eval("introduction") %>
                </p>
                <div>
<%--                    <h3>星座：未知</h3>
                    <h3>血型：未知</h3>
                    <h3>爱好：妹子吧</h3>--%>
                    <h4>方向： <%#Eval("direction") %></h4>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <img src="images/work-mobile-pres_03.png" alt="作品展示" />
        <ul>
            <asp:Repeater ID="RptWorks2" runat="server">
                <ItemTemplate>
                    <li>
                        <a href="#">
                            <img src="./upload/workPicture/<%#Eval("photo") %>" alt="作品" />
                        </a>
                        <h2><%#Eval("introduction") %></h2>
                        <p><%#Eval("time") %></p>
                        <p><%#Eval("title") %></p>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
            <div style="clear: both"></div>
        </ul>
        <ul>
            <asp:Repeater ID="RptWorks3" runat="server">
                <ItemTemplate>
                    <li>
                        <a href="#">
                            <img src="./upload/workPicture/<%#Eval("photo") %>" alt="作品" />
                        </a>
                        <h2><%#Eval("introduction") %></h2>
                        <p><%#Eval("time") %></p>
                        <p><%#Eval("title") %></p>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
            <div style="clear: both"></div>
        </ul>
    </div>

    <script type="text/javascript">
        $(".work-pres-personal>a img+img").css('display', 'none');
        $(".work-pres-personal>a").mouseover(function (event) {
            $(this).children('img+img').css('display', 'block');
            $(this).children('img:first-child').css('display', 'none');
        });
        $(".work-pres-personal>a").mouseout(function (event) {
            $(this).children('img:first-child').css('display', 'block');
            $(this).children('img+img').css('display', 'none');
        });
    </script>

</asp:Content>

