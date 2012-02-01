Imports cs3

Partial Class paget
    Inherits System.Web.UI.Page

    Public pageRow As pagesRow

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim page_id As String = Request("id")

        If IsNumeric(page_id) Then
            Dim _pageAdapter As New pagesAdapter
            pageRow = _pageAdapter.GetItem(page_id)
            pagecontent.Text = pageRow.content1
            pagename.Text = pageRow.title
      
            Dim pl As New pageLogic
            If pageRow.metatitle = "" Then
                Title = pageRow.name
            End If
            pl.setPageTitle(pageRow.metatitle, pageRow.metadescription, pageRow.metakeywords, Page)
           
        End If

    End Sub

End Class

