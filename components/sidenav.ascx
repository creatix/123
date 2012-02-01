<%@ Control Language="VB" AutoEventWireup="false" CodeFile="sidenav.ascx.vb" Inherits="components_sidenav" %>


<asp:Repeater ID="medrep" runat="server">
    <HeaderTemplate><ul><div class="navdivsep"></div></HeaderTemplate>
    <ItemTemplate>
        <li><a href="javascript:showsecond('<%#Eval("pagesid")%>');" class="<%#getclass(Eval("pagesid"))%>" id="lia<%#Eval("pagesid")%>"><%#Eval("name")%></a>
        <%#getSubPages(Eval("pagesid"))%></li>
        <div class="navdivsep"></div>
    </ItemTemplate>
    <FooterTemplate></ul></FooterTemplate>
</asp:Repeater>

