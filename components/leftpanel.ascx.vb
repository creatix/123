
Partial Class components_leftpanel
    Inherits System.Web.UI.UserControl

    Dim pagesTree As pList(Of pagesRow)
    Dim _pagesAdapter As New pagesAdapter
    Dim _pageLogic As New pageLogic
    Public show1 As Boolean = False
    Public show2 As Boolean = False

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        loadPages()
        If Not show2 Then
            getpage(58)
        End If
    End Sub

    Sub loadPages()

        If Not IsNumeric(Request("id")) Then
            Exit Sub
        End If

        pagesTree = _pageLogic.getPageTree(CInt(Request("id")))

        If isReletive(48) Then
            show2 = True
        End If

        If isReletive(49) Then
            show1 = True
        End If

    End Sub

    Function isReletive(ByVal pageid As Integer) As Boolean
        For Each p As pagesRow In pagesTree
            If p.pagesid = pageid Then
                Return True
            End If
        Next
        Return False
    End Function

    Public pageRow As pagesRow

    Sub getpage(ByVal page_id As Integer)
        If IsNumeric(page_id) Then
            Dim _pageAdapter As New pagesAdapter
            pageRow = _pageAdapter.GetItem(page_id)
            If Not pageRow Is Nothing Then
                textlbl.Text = pageRow.content1
            End If
        End If
    End Sub
End Class
