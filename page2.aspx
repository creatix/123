<%@ Page Language="VB" AutoEventWireup="false" CodeFile="page.aspx.vb" Inherits="paget" MasterPageFile="~/inner.master" %>

<asp:Content ID="Main" ContentPlaceHolderID="Main" runat="server">

<h6>דף הבית > <asp:Literal ID="pagename" runat="server"></asp:Literal></h6>
<div class="clear"></div>
    
<div class="content5">
	<h1><img alt="" src="images/<%=pageRow.titleimage%>" /></h1>
	
    <div class="clear">&nbsp;</div>
    
    <asp:Literal ID="pagecontent" runat="server"></asp:Literal>
	
	<div class="clear">&nbsp;</div>
    
	<div class="cont_img">&nbsp;</div>
    
</div>
<div class="content2">
	<% if pageRow.sideimage = "map.jpg" then %>
		<a href="images/map_01.swf" rel="milkbox[gall1]" title="מיקום הפרוייקט" rev="width:1000,height:500">
    <% end if %>
		<img alt="" src="images/<%=pageRow.sideimage%>" />
    <% if pageRow.sideimage = "map.jpg" then %>
    	</a>
    <% end if %>
</div>
</asp:Content>




