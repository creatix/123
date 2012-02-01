<%@ Control Language="vb" %>

<script language="VB" runat="server">
    Public dataSource As galleryRow
</script>

<%
	dim pic as string = dataSource.pic
	if dataSource.pic1 <> "" then
		pic = dataSource.pic1
	end if
%>

<div class="box_img"> <a href="images/<%=pic%>" rel="milkbox[gall<%=dataSource.galleryid%>]" title="<%=dataSource.name%>"><div class="gallerythumb"><img src="components/img.aspx?img=images\<%=dataSource.pic%>&amp;width=188" alt="" width="188" /></div></a>
	<a href="images/<%=pic%>" rel="milkbox[gall1]" title="<%=dataSource.name%>"><%=dataSource.name%></a>
</div>

