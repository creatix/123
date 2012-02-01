<%@ Page Language="VB" AutoEventWireup="false" CodeFile="page.aspx.vb" Inherits="paget" MasterPageFile="~/inner.master" %>
<%@ Register TagPrefix="modulus" TagName="footer" Src="components/footer.ascx" %>
<%@ Register TagPrefix="modulus" TagName="mainnav" Src="components/mainnav.ascx" %>
<%@ Register TagPrefix="modulus" TagName="sidenav" Src="components/sidenav.ascx" %>
<%@ Register TagPrefix="modulus" TagName="sidebanner" Src="components/sidebanner.ascx" %>

<asp:Content ID="Main" ContentPlaceHolderID="Main" runat="server">

    <div class="navigation">
      <modulus:mainnav ID="mainnav1" runat="server"></modulus:mainnav>
      <div class="clear"></div>
    </div>
    <div class="content1">
      <div class="flags"> <img src="img/UK_flag.png" alt="" /> <img src="img/BW_flag.png" alt="" />
        <div class="clear"></div>
      </div>
      <div class="content1_T">
      	<modulus:sidebanner id="sidebanner1" runat="server"></modulus:sidebanner>
        <div class="clear"></div>
      </div>
      <div class="C1_nav">
        <ul>
          <li><a href="#">ברושור חברה (PDF)</a></li>
          <li style="border-bottom:1px dashed #d1d3d4;"><a href="#">מצגת חברה (PDF)</a></li>
        </ul>
      </div>
      <div class="clear"></div>
    </div>
    <div class="content2">
    	<h1><asp:Literal ID="pagename" runat="server"></asp:Literal></h1>
      	<asp:Literal ID="pagecontent" runat="server"></asp:Literal>
    </div>
    <div class="content3"> <modulus:sidenav ID="sidenav1" runat="server"></modulus:sidenav> </div>
    <div class="clear"></div>
    <modulus:footer ID="footer1" runat="server"></modulus:footer>
    
    <div class="clear"></div>
  


</asp:Content>
