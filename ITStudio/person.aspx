<%@ Page Title="" Language="C#" MasterPageFile="~/Itshow.master" AutoEventWireup="true" CodeFile="person.aspx.cs" Inherits="person" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Persona</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main">
        <div style="margin: 216px 0 0 0;"></div>
        <img src="./images/Team_sun.png" alt="" />
        <a href="">
            <img src="./images/Team_buttonl.png" alt="" /></a>
        <img src="./images/Team_flag.png" alt="" />
        <p></p>
        <div class="line" style="background: url(./images/Team_bg1.png) no-repeat 100%; background-size: 100% 100%; min-height: 850px; min-width: 80%; margin-bottom: 50px;">
            <ul>
                <asp:Repeater ID="RptMember1" runat="server">
                    <ItemTemplate>

                        <li>
                            <a href="personal.aspx?id=<%#Eval("id")%>>">
                                <div>
                                <img src="./upload/memberPhoto/<%#Eval("photo")%>" alt="赵飞"/>
                                  <%#Eval("name")%><br>
                                <span><%#Eval("direction") %>></span>

                                </div>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
            <ul>
                <asp:Repeater ID="RptMember2" runat="server">
                    <ItemTemplate>

                        <li>
                            <a href="personal.aspx?id=<%#Eval("id")%>>">
                                <div>
                                <img src="./upload/memberPhoto/<%#Eval("photo")%>" alt="赵飞"/>
                                  <%#Eval("name")%><br>
                                <span><%#Eval("direction") %>></span>

                                </div>

                            </a>
        
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <ul id="one" style="margin-bottom: 100px;">
        </ul>
        <ul class="clr"></ul>
        <a href="">
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
                <li><a href="">2010</a></li>
                <li><a href="#">2011</a></li>
                <li><a href="#">2012</a></li>
                <li><a href="#">2013</a></li>
                <li><a href="#">2014</a></li>
            </ul>
        </div>
        <div style="clear: both"></div>
        <ul class="dis-mobile">
            <asp:Repeater ID="RptMember" runat="server">
                <ItemTemplate>

                    <li>
                        <a href="personal.aspx?id=<%#Eval("id")%>>">
                            <img src="<%#Eval("photo")%>" alt="赵飞"></a>
                        <h3><%#Eval("name")%><br>
                            <span><%#Eval("direction") %>></span>
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
    </script>
</asp:Content>

