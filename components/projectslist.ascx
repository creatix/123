<%@ Control Language="VB" AutoEventWireup="false" CodeFile="projectslist.ascx.vb" Inherits="components_projectslist" %>
<asp:Repeater ID="projectsRepeater" runat="server">
    <ItemTemplate>
        <a href="javascript:load_project(<%#Eval("projectsid")%>);" class="L_box" <%# removebottomline(Eval("projectsid"))%>>
            <img src="images/<%#Eval("smallpic")%>" alt="" width="82" height="54" />
            <h3 id="ph3<%#Eval("projectsid")%>"><%#Eval("name")%><br /><%#Eval("city")%></h3>
            <div class="clear"></div>
        </a>
    </ItemTemplate>
</asp:Repeater>

<%  If projectsRepeater.DataSource.count > 0 Then%>
<script>
    setTimeout('load_project(<%=projectsRepeater.DataSource(0).projectsid%>);', 100);
</script>
<% end if %>