<%@ Control Language="vb" %>

<script language="VB" runat="server">
    Public dataSource As panoramagalleryRow
</script>

<div class="pan_box">
		
		<div class="pan_BR">
			<h2>
				קומה</h2>
			<h3>
				<%=dataSource.name%></h3>
		</div>
        <a class="pan_BL" href="images/<%=dataSource.pic%>" rel="milkbox[gall1]" title="נוף קומה <%=dataSource.name%>" rev="width:1000,height:500">
			<img alt="" src="components/img.aspx?img=images\<%=dataSource.pic1%>&amp;width=845&amp;height=95" width="845" height="95" /></a>
		<div class="clear">&nbsp;</div>
	</div>