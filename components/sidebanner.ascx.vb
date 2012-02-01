
Partial Class components_sidebanner
    Inherits System.Web.UI.UserControl

    Public banner As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Trim(banner) = "" Then
            banner = "ban.jpg"
        End If

        Dim str As String = ""

        If banner.EndsWith(".swf") Then
            str &= "<div id=""shafir_line"" style=""width: 870px; height: 7px"">"
            str &= "<p align=""center"">"
            str &= "<font color=""#000"">In order to view this page you need Flash Player 9+ support.</font></p>"
            str &= "<p align=""center"">"
            str &= "<a href=""http://www.adobe.com/go/getflashplayer""><img alt=""Get Adobe Flash player"" border=""0"" src=""http://www.adobe.com/images/shared/download_buttons/get_flash_player.gif"" /></a></p>"
            str &= "</div>"
            str &= "<script type=""text/javascript"">var flashvars = {};var params = {};params.FlashVars = ""hetz=0"";params.quality = ""high"";params.wmode = ""transparent"";params.menu = ""false"";var attributes = {};attributes.id = ""shafir_line"";swfobject.embedSWF(""images/" & banner & """, ""shafir_line"", ""138"", ""239"", ""9.0.0"", false, flashvars, params, attributes);</script>"
        Else
            str = "<img src=""images/" & banner & """ width=""138"" />"
        End If
        
        bannerlbl.Text = str

    End Sub

End Class
