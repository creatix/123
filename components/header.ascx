<%@ Control Language="VB" AutoEventWireup="false" CodeFile="header.ascx.vb" Inherits="components_header" %>
<%@ Register TagPrefix="modulus" TagName="mainnav" Src="mainnav.ascx" %>

<div class="header">
    <div class="navi">
    	<modulus:mainnav ID="mainnav1" runat="server"></modulus:mainnav>
    </div>
    <div class="logo"> <a href="index.aspx"><img src="img/logo.png" alt="" width="71" height="74" border="0" /></a> </div>
    <div class="clear"></div>
  </div>
  <div class="topsep"></div>