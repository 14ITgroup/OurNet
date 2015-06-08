<%@ Page Title="" Language="C#" MasterPageFile="~/Itshow.master" AutoEventWireup="true" CodeFile="work.aspx.cs" Inherits="_Default"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <meta http-equiv="Content-Type" content="text/html;charset=UTF-8">
	<title>Work</title>
	<link rel="stylesheet" href="./css/decoration_work.css">
	<link rel="stylesheet" href="./css/index.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<div class="hide" style="display:none;">
			<div class="X"><a href="work.html"></a></div>
			<div class="arrp arrl"><a href="#"></a></div>
			<img src="./images/84.jpg" alt="">
			<div class="arrp arrr"><a href="#"></a></div>
			<p>After spending many afternoons learning and observing how we worked, Modulus was able to design different spaces for the needs of our team. They spent countless hours going back and forth with us discussing everything from lighting to acoustics. It was incredible. Designing for a bunch of designers isn't the easiest of jobs.</p>
	</div>
	<div class="countainer">
		<div class="main">
			<div class="all">
				<ul class="index_works">
					<li>
						<a href="#"><img src="./images/all.png" height="19" width="19" alt=""/>All Design</a>
					</li>
					<li>
						<a href="#"><img src="./images/web_design.png" height="27" width="32" alt=""/>Web Design</a>
					</li>
					<li>
						<a href="#"><img src="./images/App_design.png" height="28" width="19" alt=""/>App Design</a>
					</li>
					<li>
						<a href="#"><img src="./images/Pic_design.png" height="25" width="25" alt=""/>Pic Design</a>
					</li>
					<li>
						<a href="#"><img src="./images/band_design.png" height="25" width="25" alt=""/>Band Design</a>
					</li>
				</ul>
			</div>
			<div class="works">
				<ul class="display_works">
                     <asp:Repeater ID="rptWorks" runat="server" OnItemCommand="rptWorks_ItemCommand">
                        <ItemTemplate>
                            <li>
                                <asp:ImageButton ID="imgWork" runat="server" CommandName="imgWork" CommandArgument='<%#Eval("id")%>' ImageUrl='<%#Eval("picture")%>' Height="200px" Width="330px"/>
						        <p><a href="#"><%#Eval("title")%></a></p>
						        <p><a href="#"><%#Eval("time")%></a></p>
						        <p><a href="#" runat="server"><%#Eval("link")%></a></p>
				        	</li>
                        </ItemTemplate>
                    </asp:Repeater>
                  
				</ul>
			</div>
			<div class="clr"></div>
			<div class="pages">
				<ul>
					<li><a href=""><div></div></a></li>
					<li><a href="">1</a></li>
					<li><a href="">2</a></li>
					<li><a href="">3</a></li>
					<li><a href="">4</a></li>
					<li><a href="">5</a></li>
					<li>...</li>
					<li><a href="">25</a></li>
					<li><a href=""><div></div></a></li>
				</ul>
			</div>
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

