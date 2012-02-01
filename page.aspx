<%@ Page Language="VB" AutoEventWireup="false" CodeFile="page.aspx.vb" Inherits="paget" MasterPageFile="~/Main.master" %>
<%@ Register TagPrefix="modulus" TagName="footer" Src="components/footer.ascx" %>
<%@ Register TagPrefix="modulus" TagName="mainnav" Src="components/mainnav.ascx" %>
<%@ Register TagPrefix="modulus" TagName="sidenav" Src="components/sidenav.ascx" %>
<%@ Register TagPrefix="modulus" TagName="sidebanner" Src="components/sidebanner.ascx" %>
<%@ Register TagPrefix="modulus" TagName="leftpanel" Src="components/leftpanel.ascx" %>

<asp:Content ID="Main" ContentPlaceHolderID="Main" runat="server">


  
  
  
  
  
  

      <div class="inner_cont_left">
        <h2><asp:Literal ID="pagename" runat="server"></asp:Literal></h2>
        <div class="inner_top_links"> <a href="#">שתף</a> <a class="text" href="#">גרסת הדפסה</a> </div>
        <p>	<asp:Literal ID="pagecontent" runat="server"></asp:Literal></p>
      </div>
      <div class="inner_cont_right">
      <modulus:sidenav ID="sidenav1" runat="server"></modulus:sidenav> 
        <ul>
          <li><a href="#">תת עמוד</a></li>
          <li><a href="#">תת עמוד</a></li>
          <li><a href="#">תת עמוד</a></li>
          <li><a href="#">תת עמוד</a></li>
          <li><a href="#">תת עמוד</a></li>
        </ul>
      </div>
    


</asp:Content>



