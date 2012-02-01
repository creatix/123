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
	if len(titlestr) > 35 then
		titlestr = titlestr.substring(0, 35) & " ..."
	end if
%>

<div class="C3_LL">
	<a href="<%=link%>" <%=target%>><%=titlestr%></a>
</div>
<div class="C3_LR">
	<h2><%=dataSource.insertdate.day%></h2>
	<h3><%=dataSource.insertdate.month%>/<%=dataSource.insertdate.ToString("yyyy")%></h3>
</div>
