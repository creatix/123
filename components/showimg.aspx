<%@ Page Language="vb" AutoEventWireup="false" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
  <head>
    <title>Enlarged Picture</title>
  <meta http-equiv="Content-Type" content="text/html;"><style type="text/css">
<!--
body {
	margin-left: 5px;
	margin-top: 5px;
	margin-right: 5px;
	margin-bottom: 5px;
}
-->
</style></head>
  <body><img src="img.aspx?img=images\<%=request("img")%>&width=800&height=600" alt="<%=request("img")%>" id="image_obj"></body>
</html>
<script language=javascript>

	function resize_and_move() {
	
		var img_w = document.getElementById("image_obj").width+49;
		var img_h = document.getElementById("image_obj").height+80;
		
		var temp_x = screen.width / 2;
		var temp_y = screen.height / 2;
		
		window.resizeTo(img_w,img_h);
		
		window.moveTo(temp_x-(img_w/2),temp_y-(img_h/2));
	}

	window.onload = resize_and_move;
	
</script>