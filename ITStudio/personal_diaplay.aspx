<%@ Page Title="" Language="C#" MasterPageFile="~/Itshow.master" AutoEventWireup="true" CodeFile="personal_diaplay.aspx.cs" Inherits="personal_diaplay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Personal_display</title>
    <link href="css/index.css" rel="stylesheet" />
    <script type="text/javascript" src="js/jquery-1.11.2.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="countainer">
        <ul class="index-menu">
            <a href="index.aspx">
                <img src="images/it-ico.png" alt="IT-Logo"></a>
            <li><a href="index.aspx">首页</a></li>
            <li><a href="index.aspx#intro-team">简介</a></li>
            <li><a href="work.aspx">作品</a></li>
            <li><a href="personal_display.aspx">团队</a></li>
            <li><a href="#">留言板</a></li>
            <a href="index.aspx#join-us" class="nav-join">Join us now</a>
            <div style="clear: both"></div>
        </ul>

        <!-- 电脑端界面 -->
        <div class="main">
            <div>
            <asp:Repeater ID="RptMenber" runat="server">
                <HeaderTemplate>

                </HeaderTemplate>

                <ItemTemplate>
                    <img src="<%#Eval("photo") %>" alt="person">
                    <h1><%#Eval("name") %></h1>
                    <ul>
                       <img src="./images/personal_line.jpg" alt="">
                       <p>since <%#Eval("grade") %></p>
                       <img src="./images/personal_line.jpg" alt="">
                    </ul>
                    <h5><%#Eval("introduction") %></h5>
                    方向：<%#Eval("direction") %>
                </ItemTemplate>

                <FooterTemplate>

                </FooterTemplate>
            </asp:Repeater>
                </div>
            <p>主要作品</p>
            <ul class="clr"></ul>
            <div>
                <asp:Repeater ID="RptWork" runat="server">
                    <HeaderTemplate>
                        <ul class="work-pres-personal">
                    </HeaderTemplate>

                    <ItemTemplate>
                        <a href="work.aspx">
                            <img src="<%#Eval("picture") %>" alt="pic1">
                            <img src="<%#Eval("picture") %>" alt="作品">
                        </a>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<h3><a href="#"><%#Eval("introduction") %></a></h3>
                        <p><%#Eval("time") %></p>
                        <p><%#Eval("title") %></p>
                    </ItemTemplate>

                    <FooterTemplate>
                        </ul>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
            <div class="clr"></div>
        </div>

        <!-- 移动端界面 -->
        <div class="main-mobile-person">
            <img src="images/person-dis-mobile_03.png" alt="成员展示">
            <img src="images/personal_pic.gif" alt="照片">
            <h1>赵飞</h1>
            <p>
                性格开朗、稳重、有活力，待人热情、真诚。工作认真负责，积极主动，能吃苦耐劳。有较强的组织能力、实际动手能力和团体协作精神，能迅速的适应各种环境，并融合其中
            </p>
            <div>
                <h3>星座：未知</h3>
                <h3>血型：未知</h3>
                <h3>爱好：妹子吧</h3>
                <h3>方向：美术设计/平面设计/html/css/<br>
                javascript/jquery/用户体验设计</h4>
            </div>
            <img src="images/work-mobile-pres_03.png" alt="作品展示">
            <ul>
                <li>
                    <a href="#">
                        <img src="images/display1.jpg" alt="作品">
                    </a>
                    <h2>Design for TRAVIS</h2>
                    <p>2014.12.25</p>
                    <p>Troye Sivan</p>
                </li>
                <li>
                    <a href="#">
                        <img src="images/display2.jpg" alt="作品">
                    </a>
                    <h2>Design for TRAVIS</h2>
                    <p>2014.12.25</p>
                    <p>Troye Sivan</p>
                </li>
                <div style="clear: both"></div>
            </ul>
            <ul>
                <li>
                    <a href="#">
                        <img src="images/display3.jpg" alt="作品">
                    </a>
                    <h2>Design for TRAVIS</h2>
                    <p>2014.12.25</p>
                    <p>Troye Sivan</p>
                </li>
                <li>
                    <a href="#">
                        <img src="images/display4.jpg" alt="作品">
                    </a>
                    <h2>Design for TRAVIS</h2>
                    <p>2014.12.25</p>
                    <p>Troye Sivan</p>
                </li>
                <div style="clear: both"></div>
            </ul>
        </div>
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

