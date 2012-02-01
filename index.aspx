<%@ Page Language="VB" AutoEventWireup="false" CodeFile="index.aspx.vb" Inherits="index" MasterPageFile="~/Main.master" %>
<%@ Register TagPrefix="modulus" TagName="footer" Src="components/footer.ascx" %>
<%@ Register TagPrefix="modulus" TagName="sidenav" Src="components/sidenav.ascx" %>
<%@ Register TagPrefix="modulus" TagName="sidebanner" Src="components/sidebanner.ascx" %>
<%@ Register TagPrefix="modulus" TagName="leftpanel" Src="components/leftpanel.ascx" %>

<asp:Content ID="Main" ContentPlaceHolderID="Main" runat="server">

 
  
    	<h1><asp:Literal ID="pagename" runat="server"></asp:Literal></h1>
       <br />
      		<asp:Literal ID="pagecontent" runat="server"></asp:Literal>
      
 


</asp:Content>




