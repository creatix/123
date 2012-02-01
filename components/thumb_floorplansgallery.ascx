<%@ Control Language="vb" %>

<script language="VB" runat="server">
    Public dataSource As floorplansgalleryRow
</script>

<%
	dim pic as string = dataSource.pic
	if dataSource.pic1 <> "" then
		pic = dataSource.pic1
	end if
	
	dim link as string = "<a href=""images/" + pic & """ rel=""milkbox[gall1]"" title=""" & dataSource.name & """>" & dataSource.name & "</a>"
	
	if dataSource.pdffile <> "" then
		link = "<a href=""images/" & dataSource.pdffile & """ title=""" & dataSource.name & """ target=_blank><img src=""img/pdf_icon.png"" width=""11"" height=""13"" align=""absmiddle"" />&nbsp;&nbsp;" & dataSource.name & "</a>"
	end if
	
%>

<div class="box_img"> <a href="images/<%=pic%>" rel="milkbox[gall1]" title="<%=dataSource.name%>"><div class="gallerythumb"><img src="components/img.aspx?img=images\<%=dataSource.pic%>&amp;width=188" alt="" width="188" /></div></a>
	<%=link%>
</div>

