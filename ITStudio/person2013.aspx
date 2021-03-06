﻿<%@ Page Title="2013级成员" Language="C#" MasterPageFile="~/Itshow.master" AutoEventWireup="true" CodeFile="person2013.aspx.cs" Inherits="person2013" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .main > img + p {
            background: url(images/cao12.png) no-repeat;
        }

        .main > a + p {
            background: url(images/cao14.png) no-repeat;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main">
        <div style="margin: 216px 0 0 0;"></div>
        <img src="./images/Team13.png" alt="" />
        <a href="person2012.aspx">
            <img src="./images/Team_buttonl.png" alt="" /></a>
        <img src="./images/Team_flag.png" alt="" />
        <p></p>
        <div class="line" style="background: url(./images/Team_bg1.png) no-repeat 100%; background-size: 100% 100%; min-height: 850px; min-width: 80%; margin-bottom: 50px;">
            <ul>
                <asp:Repeater ID="RptMember11" runat="server">
                    <ItemTemplate>
                        <li>
                            <img src="./upload/memberPhoto/<%#Eval("ico")%>" alt="团队成员">
                            <a href="personal_display.aspx?id=<%#Eval("id")%>">
                                <h3><%#Eval("name")%></h3>
                                <h4><%#Eval("job")%></h4>
                            </a>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
            <ul>
                <asp:Repeater ID="RptMember12" runat="server">
                    <ItemTemplate>
                        <li>
                            <img src="./upload/memberPhoto/<%#Eval("ico")%>" alt="团队成员">
                            <a href="personal_display.aspx?id=<%#Eval("id")%>">
                                <h3><%#Eval("name")%></h3>
                                <h4><%#Eval("job")%></h4>
                            </a>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <ul class="clr"></ul>
        <a href="person2014.aspx">
            <img src="./images/Team_buttonr.png" alt="" /></a>
        <p></p>
        <img src="./images/Team_flag.png" alt="" />
        <ul class="clr"></ul>
    </div>
    <div class="main-mobile">
        <img src="images/person-dis-mobile_03.png" alt="成员展示" />
        <h2>2009</h2>
        <div>
            <a href="#" class="button-grade" id="show">
                <img src="images/person-dis-button_07.png" alt="请点击" />
            </a>
            <ul class="hide-per" id="b">
                <li><a href="person2010.aspx">2010</a></li>
                <li><a href="person2011.aspx">2011</a></li>
                <li><a href="person2012.aspx">2012</a></li>
                <li><a href="#">2013</a></li>
                <li><a href="person2014.aspx">2014</a></li>
            </ul>
        </div>
        <div style="clear: both"></div>
        <ul class="dis-mobile">
            <asp:Repeater ID="RptMember2" runat="server">
                <ItemTemplate>
                    <li>
                        <a href="personal_display.aspx?id=<%#Eval("id")%>">
                            <img src="./upload/memberPhoto/<%#Eval("ico")%>" alt="赵飞"></a>
                        <h3><%#Eval("name")%><br>
                            <span><%#Eval("job")%></span>
                        </h3>
                        <div style="clear: both"></div>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>

    </div>
    <script type="text/javascript">
        $(".hide-per").css('display', 'none');
        var $b = $("#b");
        $("#show").on({
            "click": function () {
                $b.slideDown();
                return false;
            }
        });
        $(document).on({
            "click": function (e) {
                var src = e.target;

                if (src.id && src.id === "b") {
                    return false;
                } else {
                    $b.hide();
                };
            }
        });

        $(".line ul a").css('display', 'none');
        $(".line ul li").mouseenter(function (event) {
            $(this).children('a').show();
            $(this).children('img').hide();

        });
        $(".line ul li").mouseleave(function (event) {
            $(this).children('img').show()
            $(this).children('a').hide();

        });
    </script>
</asp:Content>

