<%@ Control Language="VB" AutoEventWireup="false" CodeFile="footernav.ascx.vb" Inherits="components_footernav" %>

        <ul>
        	<asp:Repeater ID="rptPages" runat="server">
            	<ItemTemplate><li><a href="<%# pageLogic.GetPageLink("page", Eval("pagesid"), Eval("name"), Eval("page_link"))%>"><%#Eval("title")%></a></li></ItemTemplate>
            	<separatortemplate><li><a><span>|</span></a></li></separatortemplate>
            </asp:Repeater>
        </ul>

      