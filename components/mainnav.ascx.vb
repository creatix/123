
Partial Class templates_panels_mainnav
    Inherits System.Web.UI.UserControl

    Dim page_name As String = ""
    Dim page_id As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        loadpages()

    End Sub

    Sub loadpages()

        Dim _pagesAdapter As New pagesAdapter
        Dim pagesList As List(Of pagesRow) = _pagesAdapter.GetList("fatherid=0 AND isnull(hide, 0) <> 1 AND isnull(hidefromheader, 0) <> 1", "sort")
        
        rptPages.DataSource = pagesList
        rptPages.DataBind()

    End Sub

    Public Function GetTabClass(ByVal PageName As String, ByVal pagesid As String) As String
        If PageName = "home" And page_name = "index.aspx" Then
            Return "class='CurrentTab'"
        Else
            If pagesid = page_id Then
                Return "class='CurrentTab'"
            Else
                Return "class='topbut'"
            End If
        End If
    End Function

    Public Function GetClass(ByVal title As String) As String
        If title = "Home" Then
            Return "class='first'"
        Else
            Return ""
        End If

    End Function

    Function getselected(ByVal pagesid As Integer, ByVal pagelink As String) As String
        If pagesid = Request("id") Then
            Return "class=""sel"""
        End If
        If Not pagelink Is Nothing Then
            If pagelink.ToString <> "" And Request.Url.ToString.IndexOf(pagelink.ToString) > -1 Then
                Return "class=""sel"""
            End If
        End If
        Return ""
    End Function

End Class
