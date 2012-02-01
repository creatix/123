<%@ Page Language="VB" AutoEventWireup="false" CodeFile="contact.aspx.vb" Inherits="contact" MasterPageFile="~/main.master" %>
<%@ Register TagPrefix="modulus" TagName="footer" Src="components/footer.ascx" %>
<%@ Register TagPrefix="modulus" TagName="mainnav" Src="components/mainnav.ascx" %>
<%@ Register TagPrefix="modulus" TagName="sidenav" Src="components/sidenav.ascx" %>
<%@ Register TagPrefix="modulus" TagName="sidebanner" Src="components/sidebanner.ascx" %>
<%@ Register TagPrefix="modulus" TagName="leftpanel" Src="components/leftpanel.ascx" %>

<asp:Content ID="Main" ContentPlaceHolderID="Main" runat="server">
  <div class="clear"></div>
  


      <div class="inner_cont_left">
        <h2>צור קשר</h2>
        <div class="inner_top_links"> <a href="#">שתף</a> <a class="text" href="#">גרסת הדפסה</a> </div>
        <p>	<asp:Literal ID="pagecontent" runat="server"></asp:Literal>
        
        
        <br />
        
        
        
        <div class="content2">

      
      
      <div id="divContact" visible="true" runat="server">
        
        <div style="padding-right:20px;"><asp:Label ID="lblMessage" runat="server" ForeColor="#FF0000"></asp:Label></div>
        
        <div class="clear"></div>
            <form id="form1" runat="server" style="margin-top:7px;">
            
              
              <label><b style="color:#F00;">*</b> שם מלא:</label>
        <input type="text" value="" id="nametxt" runat="server" />
        <br />  <br />
        <label>שם חברה:</label>
        <input type="text" value="" id="companyname" runat="server" />
        <br />  <br />
        <label><b style="color:#F00;">*</b> טלפון:</label>
        <input type="text" value="" id="phonetxt" runat="server" />
        <br />  <br />
        <label><b style="color:#F00;">*</b> דוא''ל:</label>
        <input type="text" value="" id="emailtxt" runat="server" />
        <br />  <br />
        <label style="margin-top:22px;">טקסט חופשי:</label>
        <textarea rows="4" cols="40" id="msgtxt" runat="server"></textarea>
        <br />  <br />
        <div class="clear"></div>
        <input type="hidden" name="submited" id="submited" value="true" />
        <br />  <br />
        <input type="submit" value="שלח" class="submit" runat="server" id="btnSend" />
              

            </form>
        </div>
        <div id="divMessage" runat="server" visible="false" style="font-size:16px;text-align:right; padding-right:20px;">
        	<br /><br />
        	אנו מודים על פנייתכם לחברת E&O יזמות וניהול.<br />
נציגנו ייצור עמכם קשר בהקדם.
        </div>
        
        
        
        
        
        
        <div class="clear"></div>
      <h4>
      
      	<asp:Literal id="pagecontentlbl" runat="server"></asp:Literal>
      
      
     
      </h4>
      
        
    </div>
        
        </p>
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