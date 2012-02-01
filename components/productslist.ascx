<%@ Control Language="VB" AutoEventWireup="false" CodeFile="productslist.ascx.vb" Inherits="components_productslist" %>

    <asp:Repeater ID="catsRepeater" runat="server">
        <itemtemplate>
            <div class="<%=style%>">
                <a href="<%# pageLogic.GetPageLink("product", Eval("productsid"), Eval("name"), "")%>"><img src="components/img.aspx?img=images\<%#Eval("pic")%>&width=120&height=91" alt="" width="120" height="91" /></a>
                <div class="clear"></div>
                <span><%#Eval("name")%></span>
                <div class="clear"></div>
            </div>
        </itemtemplate>
    </asp:Repeater>
