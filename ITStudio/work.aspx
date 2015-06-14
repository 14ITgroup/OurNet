<%@ Page Title="作品展示" Language="C#" MasterPageFile="~/Itshow.master" AutoEventWireup="true" CodeFile="work.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <meta http-equiv="Content-Type" content="text/html;charset=UTF-8" />
    <link rel="stylesheet" href="./css/index.css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="hide" style="display: none;">
        <div class="X"><a href="work.html"></a></div>
        <div class="arrp arrl"><a href="#"></a></div>
        <img src="./images/84.jpg" alt="" />
        <div class="arrp arrr"><a href="#"></a></div>
        <p>After spending many afternoons learning and observing how we worked, Modulus was able to design different spaces for the needs of our team. They spent countless hours going back and forth with us discussing everything from lighting to acoustics. It was incredible. Designing for a bunch of designers isn't the easiest of jobs.</p>
    </div>
    <div class="countainer">
        <div class="main">
            <div class="all">
                <ul class="index_works">
                    <li>
                        <a href="work.aspx">
                            <img src="./images/all.png" height="19" width="19" alt="" />All Design</a>
                    </li>
                    <li>
                        <a href="work.aspx?type=1">
                            <img src="./images/web_design.png" height="27" width="32" alt="" />Web Design</a>
                    </li>
                    <li>
                        <a href="work.aspx?type=2">
                            <img src="./images/App_design.png" height="28" width="19" alt="" />App Design</a>
                    </li>
                    <li>
                        <a href="work.aspx?type=3">
                            <img src="./images/Pic_design.png" height="25" width="25" alt="" />Pic Design</a>
                    </li>
                    <li>
                        <a href="work.aspx?type=4">
                            <img src="./images/band_design.png" height="25" width="25" alt="" />Band Design</a>
                    </li>
                </ul>
            </div>
            <div class="works">
                <ul class="display_works">
                    <asp:Repeater ID="rptWorks" runat="server">
                        <ItemTemplate>
                            <li>
                                <a href="#">
                                    <img src='<%#"upload/workPicture/"+Eval("picture")%>' height="200px" width="330px" />
                                </a>
                                <a href=""><p><%#Eval("title")%></p></a>
                                <p><%#Eval("time")%></p>
                                <p><a href="<%#Eval("link")%>"><%#Eval("link")%></a></p>
                                <div>
                                    <img src='<%#"upload/workPicture/"+Eval("picture")%>' alt="作品大图展示">
                                    <a href="#" class="X"></a>
                                    <p><%#Eval("introduction")%></p>
                                </div>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>

                </ul>
            </div>
            <div class="clr"></div>
            <div class="pages">
                <ul>
                    <li>
                        <asp:HyperLink ID="HlPreviousPage" runat="server"><div></div></asp:HyperLink>
                    </li>
                    <li><a href="work.aspx?page=1&type=<%=Request.QueryString["type"] %>">1</a></li>
                    <li id="LiDots1" visible="false" runat="server">...</li>
                    <asp:Repeater ID="RptPageNums" runat="server">
                        <ItemTemplate>
                            <li><a href="work.aspx?page=<%#(Container.DataItem as string).ToString() %>&type=<%=Request.QueryString["type"] %>">
                                <%#(Container.DataItem as string).ToString() %>
                            </a>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>

                    <li id="LiDots2" visible="false" runat="server">...</li>
                    <li id="LiLastPage" runat="server">
                        <asp:HyperLink ID="HlLastPage" runat="server"></asp:HyperLink></li>
                    <li>
                        <asp:HyperLink ID="HlNextPage" runat="server"><div></div></asp:HyperLink>
                    </li>
                </ul>
            </div>

        </div>
    </div>
    <div class="clr"></div>
    <div class="main_mobile">
        <div class="all">
            <ul>
                <img src="./images/personal_line.jpg" alt="">
                <p>作品展示</p>
                <img src="./images/personal_line.jpg" alt="">
            </ul>
        </div>
        <div class="clr"></div>
        <p>ALL</p>
        <a href="#" id="button-mobile-work">
            <img src="./images/work_mobile_button.png" alt="">
        </a>
        <ul class="hide2" id="hide2">
            <li><a href="">
                <p>网页制作</p>
            </a></li>
            <li><a href="">
                <p>APP设计</p>
            </a></li>
            <li><a href="">
                <p>海报设计</p>
            </a></li>
            <li><a href="">
                <p>图片设计</p>
            </a></li>
        </ul>
        <div class="works">
            <ul class="display_works">
                <asp:Repeater ID="RptWorkOnMobile" runat="server">

                    <ItemTemplate>
                        <li>
                            <a href="#">
                                <img src="<%#"upload/workPicture/"+Eval("picture")%>" alt=""></a>
                            <a href="#">
                                <p><%#Eval("title")%></p>
                            </a>
                            <p><%#Eval("time")%></p>
                            <p><%#Eval("introduction")%></p>
                        </li>
                    </ItemTemplate>

                </asp:Repeater>
            </ul>
        </div>
        <div class="clr"></div>
        <div class="pages">
            <ul>
                <li><a href="">
                    <div></div>
                </a></li>
                <li><a href="">1</a></li>
                <li><a href="">2</a></li>
                <li><a href="">3</a></li>
                <li><a href="">4</a></li>
                <li><a href="">5</a></li>
                <li>...</li>
                <li><a href="">25</a></li>
                <li><a href="">
                    <div></div>
                </a></li>
            </ul>
        </div>
    </div>
    <div class="clr"></div>
    </div>



    <script type="text/javascript" src="./js/jquery-1.11.2.min.js"></script>

    <%--<script type="text/javascript">
        $(document).ready(function () {
            $(".display_works>li>a").click(function () {
                $(".hide").show();
                $(".index-menu").hide();
            });
            $(".hide .X").click(function () {
                $(".hide").hide();
            });
        });

    </script>--%>
    <script type="text/javascript">
        $(document).ready(function () {
            var winWidth = 0;
            function findWH() {
                // 获取窗口宽度
                if (window.innerWidth)
                    winWidth = window.innerWidth;
                else if ((document.body) && (document.body.
                    clientWidth))
                    winWidth = document.body.clientWidth;
                //通过深入Document内部对body进行检测，获取窗口大小
                if (document.documentElement && document.documentElement.clientWidth) {
                    winWidth = document.documentElement.clientWidth;
                }
            };
            findWH();
            window.onresize = findWH;
            $(".main .display_works li div").css('display', 'none');
            if (winWidth > 1280) {
                $(".display_works>li>a").click(function () {
                    $(".index-menu").hide();
                    $(this).siblings('div').addClass('show-presention');
                    $(".show-presention").fadeIn();
                });
                $(document).on('click', '.X', function (event) {
                    $(".index-menu").fadeIn();
                    console.log(this)
                    $(this).parent().removeClass('show-presention').fadeOut();
                });
            };//if end

            var $a = $("#hide2");
            $("#button-mobile-work").on({
                "click": function () {
                    $a.slideDown();
                    return false;
                }
            });
            $(document).on({
                "click": function (e) {
                    var src = e.target;

                    if (src.id && src.id === "hide2") {
                        return false;
                    } else {
                        $a.hide();
                    };
                }
            });
        });

</script>
</asp:Content>

