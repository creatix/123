<%@ Control Language="VB" AutoEventWireup="false" CodeFile="productgallerylist.ascx.vb" Inherits="components_productgallerylist" %>
<asp:Repeater ID="productGalleryRepeater" runat="server">
    <ItemTemplate>
        <img src="components/img.aspx?img=images\<%#Eval("url")%>&width=225&height=215" width="225" height="215">
    </ItemTemplate>
</asp:Repeater>