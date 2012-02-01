<%@ Control Language="VB" AutoEventWireup="false" CodeFile="mainnav.ascx.vb" Inherits="templates_panels_mainnav" %>
      
      <ul>
      	<asp:Repeater ID="rptPages" runat="server">
            	<ItemTemplate>
                	<li <%# getselected(Eval("pagesid"), Eval("page_link"))%>><a href="<%# pageLogic.GetPageLink("page", Eval("pagesid"), Eval("name"), Eval("page_link"))%>"><%#Eval("title")%></a></li>
                </ItemTemplate>
            </asp:Repeater>
      </ul>