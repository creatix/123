<%@ Control Language="vb" %>

<script language="VB" runat="server">
    Public dataSource As newsRow
</script>

<%
	dim link as string = "newsitem.aspx?id=" & dataSource.newsid
	dim target as string = ""
	if dataSource.link <> "" then
		link = dataSource.link
		target = "target=""_blank"""
	end if
	dim titlestr as string = dataSource.title
	if len(titlestr) > 100 then
		titlestr = titlestr.substring(0, 100) & " ..."
	end if
%>

<div class="C3_LL">
	<a href="<%=link%>" <%=target%>>
	<p><%=titlestr%></p>
	<font style="color:#8fd400;">למידע נוסף...</font></a>
</div>
<div class="C3_LR">
    <h2><%=dataSource.insertdate.day%></h2>
    <h3><%=dataSource.insertdate.month%>/<%=dataSource.insertdate.ToString("yyyy")%></h3>
</div>
