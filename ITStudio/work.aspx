<%@ Page Title="" Language="C#" MasterPageFile="~/Itshow.master" AutoEventWireup="true" CodeFile="work.aspx.cs" Inherits="_Default"%>

<%--<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <meta http-equiv="Content-Type" content="text/html;charset=UTF-8"/>
	<title>Work</title>
	<link rel="stylesheet" href="./css/decoration_work.css"/>
	<link rel="stylesheet" href="./css/index.css" />
<%--    <style type="text/css">
        .rig_fenye{ height:36px; margin:0 auto; margin-left:150px;}
        .rig_fenye li{ width:37px; height:36px; float:left; background:url(../index_img/shuzi.gif); line-height:32px; text-align:center;}
        .rig_fenye li:hover{ width:37px; height:36px; float:left; background:url(../index_img/dang.gif); line-height:31px; text-align:center;}
        .rig_fenye li a{ color:#3c383b; font-size:14px; font-family:Arial; font-weight:bolder; text-decoration:none; display:block; margin-right:1px;}
        .rig_fenye li a:hover{ color:#752900; font-size:14px; font-family:Arial; font-weight:bolder;}

        .paginator a { float:left; height:36px; line-height:32px; padding:0px 14px; background:url(/images/shuzi.gif) no-repeat center center; text-align:center;text-decoration:none; color:#333;
         font-size:14px; font-family:Arial; font-weight:bolder; }
        .paginator .cpb { float:left; height:36px; padding:0px 14px; line-height:32px;  background:url(/images/dang.gif) no-repeat center center; text-align:center;text-decoration:none; color:#752900;
         font-size:14px; font-family:Arial; font-weight:bolder; }
        .paginator a:hover { float:left; height:36px; padding:0px 14px; line-height:32px; background:url(/images/dang.gif) no-repeat center center; text-align:center;text-decoration:none; color:#752900;
         font-size:14px; font-family:Arial; font-weight:bolder;}
         .npb{ float:left;}
    </style>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<div class="hide" style="display:none;">
			<div class="X"><a href="work.html"></a></div>
			<div class="arrp arrl"><a href="#"></a></div>
			<img src="./images/84.jpg" alt=""/>
			<div class="arrp arrr"><a href="#"></a></div>
			<p>After spending many afternoons learning and observing how we worked, Modulus was able to design different spaces for the needs of our team. They spent countless hours going back and forth with us discussing everything from lighting to acoustics. It was incredible. Designing for a bunch of designers isn't the easiest of jobs.</p>
	</div>
	<div class="countainer">
		<div class="main">
			<div class="all">
				<ul class="index_works">
					<li>
						<a href="work.aspx"><img src="./images/all.png" height="19" width="19" alt=""/>All Design</a>
					</li>
					<li>
						<a href="work.aspx?page=1&type=1"><img src="./images/web_design.png" height="27" width="32" alt=""/>Web Design</a>
					</li>
					<li>
						<a href="work.aspx?page=1&type=2"><img src="./images/App_design.png" height="28" width="19" alt=""/>App Design</a>
					</li>
					<li>
						<a href="work.aspx?page=1&type=3"><img src="./images/Pic_design.png" height="25" width="25" alt=""/>Pic Design</a>
					</li>
					<li>
						<a href="work.aspx?page=1&type=4"><img src="./images/band_design.png" height="25" width="25" alt=""/>Band Design</a>
					</li>
				</ul>
			</div>
			<div class="works">
				<ul class="display_works">
                     <asp:Repeater ID="rptWorks" runat="server">
                        <ItemTemplate>
                            <li>
<%--                            <asp:ImageButton ID="imgWork" runat="server" CommandName="imgWork" CommandArgument='<%#Eval("id")%>' ImageUrl='<%#"upload/workPicture/"+Eval("picture")%>' c"/>--%>
                                <asp:Image ID="imgWork" runat="server" ImageUrl='<%#"upload/workPicture/"+Eval("picture")%>' Height="200px" Width="330px"/>
						        <p><a href="#"><%#Eval("title")%></a></p>
						        <p><a href="#"><%#Eval("time")%></a></p>
                                <p><a href='#' onclick="window.open('<%#Eval("link")%>')" target="_blank"><%#Eval("link")%></a></p>
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
                    <li id="LiDots1" Visible="false" runat="server">...</li>
                    <asp:Repeater ID="RptPageNums" runat="server">
                        <ItemTemplate>
                            <li><a href="work.aspx?page=<%#(Container.DataItem as string).ToString() %>&type=<%=Request.QueryString["type"] %>">
                                <%#(Container.DataItem as string).ToString() %>
                                </a>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                    
					<li id="LiDots2" Visible="false" runat="server">...</li>
					<li id="LiLastPage" runat="server">
                        <asp:HyperLink ID="HlLastPage" runat="server"></asp:HyperLink></li>
					<li>
                        <asp:HyperLink  ID="HlNextPage" runat="server"><div></div></asp:HyperLink>
                    </li>
				</ul>
			</div>
        <%--<div class="rig_fenye" style="position:relative; top: -7px; left: 306px;">
            <webdiyer:AspNetPager ID="AspNetPager" runat="server" HorizontalAlign="Center" NumericButtonType="Text" MoreButtonType="Text"
              ShowFirstLast="false" PagingButtonType="Text" ImagePath="/images/" ButtonImageExtension=".gif" ButtonImageNameExtension="n"
               DisabledButtonImageNameExtension="g" ShowPageIndexBox="Never" CurrentPageButtonClass="cpb" NextPrevButtonClass="npb" ButtonImageAlign="left"
              CssClass="paginator" CurrentPageButtonPosition="Center" OnPageChanged="AspNetPager_PageChanged" NumericButtonCount="4" PageSize="6" AlwaysShow="True">
            </webdiyer:AspNetPager>
		</div>--%>
      </div>
		<div class="clr"></div>
</div>
     


<script type="text/javascript" src="./js/jquery-1.11.2.min.js"></script>

<script type="text/javascript">
$(document).ready(function() {
	$(".display_works>li>a").click(function(){
 		$(".hide").show();
 		$(".index-menu").hide();
 	});
 	$(".hide .X").click(function(){
  		$(".hide").hide();
	});	
 });
	
</script>
</asp:Content>

