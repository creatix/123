<%@ Page Language="VB" AutoEventWireup="false" CodeFile="articles.aspx.vb" Inherits="articles" MasterPageFile="~/Main.master" %>
<%@ Register TagPrefix="modulus" TagName="footer" Src="components/footer.ascx" %>
<%@ Register TagPrefix="modulus" TagName="mainnav" Src="components/mainnav.ascx" %>
<%@ Register TagPrefix="modulus" TagName="sidenav" Src="components/sidenav.ascx" %>
<%@ Register TagPrefix="modulus" TagName="sidebanner" Src="components/sidebanner.ascx" %>
<%@ Register TagPrefix="modulus" TagName="leftpanel" Src="components/leftpanel.ascx" %>
<%@ Register TagPrefix="modulus" TagName="sidecats" Src="components/sidecats.ascx" %>
<%@ Register TagPrefix="modulus" TagName="grid" Src="components/grid.ascx" %>

<asp:Content ID="Main" ContentPlaceHolderID="Main" runat="server">


  
  
  
  
  
  

      <div class="inner_cont_left">
        <h2>מאמרים</h2>
        <div class="inner_top_links"> <a href="#">שתף</a> <a class="text" href="#">גרסת הדפסה</a> </div>
        <p>
        	<modulus:grid id="newslist" runat="server" view="news" colNum="1"></modulus:grid>
        </p>
      </div>
      <div class="inner_cont_right">
      
      <modulus:sidecats ID="sidecats1" runat="server"></modulus:sidecats> 
        
      </div>
    


</asp:Content>



