
Partial Class index
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim _pageAdapter As New pagesAdapter
        Dim pageRow As pagesRow = _pageAdapter.GetItem(73)
        pagecontent.Text = pageRow.content1
        Dim pl As New pageLogic
        pl.setPageTitle(pageRow.metatitle, pageRow.metadescription, pageRow.metakeywords, Page)

     

    End Sub

End Class
