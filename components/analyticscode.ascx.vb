
Partial Class components_analyticscode
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim _analyticscode As String = siteLogic.Config("analyticscode")

        If _analyticscode = "" Then
            Exit Sub
        End If

        Dim str As String = ""
        str &= "<script src=""http://www.google-analytics.com/ga.js"" type=""text/javascript""></script>"
        str &= "<script type=""text/javascript"">"
        str &= "var pageTracker;"
        str &= "setTimeout('startGA();', 500);"
        str &= "function startGA() {"
        str &= "pageTracker = _gat._getTracker(""" & _analyticscode & """);"
        str &= "pageTracker._initData();"
        str &= "pageTracker._trackPageview();"
        str &= "}"
        str &= "</script>"

        analyticsCodelbl.Text = str

    End Sub

End Class
