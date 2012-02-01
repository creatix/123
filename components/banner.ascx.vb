Imports cs3

Partial Class components_banner
    Inherits System.Web.UI.UserControl

    Public table As tableLogic.tableAdapter
    Public bannerName As String = ""
    Public width As Integer = 200
    Public height As Integer = 50

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        loadBanner()
    End Sub

    Sub loadBanner()
        If bannerName = "" Then Exit Sub
        table = New tableLogic.tableAdapter("banners")
        Dim tr As tableLogic.tableRow = table.GetItem("name='" & bannerName & "'")
        If tr Is Nothing Then
            Exit Sub
        End If
        bannercontainer.Text = getBannerString(tr)
    End Sub

    Function getBannerString(ByRef tr As tableLogic.tableRow) As String
        Dim str As String = ""
        Select Case tr("type")
            Case "image"
                str = "<a href=""" & tr("link") & """ class=""tlink""><img src=""images/" & tr("pic") & """ width=""" & width & """ border=""0"" /></a>"
            Case "flash"
                str = "<script type=""text/javascript"">swfobject.embedSWF('images/" & tr("pic") & "', 'placeholder_" & tr("name").Replace(" ", "") & "', """ & width & """, """ & height & """, '9.0.0', 'swf/expressInstall.swf', {}, { wmode: 'transparent' }, {});</script><div id=""placeholder_" & tr("name").Replace(" ", "") & """></div>"
            Case "text"
                If tr("link").ToString = "" Then
                    str = tr("bannercontent")
                Else
                    str = "<a href=""" & tr("link") & """ class=""tlink"">" & tr("bannercontent") & "</a>"
                End If
        End Select
        Return str
    End Function

End Class
