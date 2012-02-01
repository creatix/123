
Partial Class components_footernav
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        loadpages()

    End Sub

    Sub loadpages()

        Dim _pagesAdapter As New pagesAdapter
        Dim pagesList As List(Of pagesRow) = _pagesAdapter.GetList("fatherid=0 AND isnull(hide, 0) <> 1 AND isnull(hidefromfooter, 0) <> 1", "sort")
        rptPages.DataSource = pagesList
        rptPages.DataBind()

    End Sub

End Class
