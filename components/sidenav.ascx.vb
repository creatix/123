
Partial Class components_sidenav
    Inherits System.Web.UI.UserControl

    Dim pagesTree As pList(Of pagesRow)
    Dim _pagesAdapter As New pagesAdapter
    Dim _pageLogic As New pageLogic
    Public hide1 As Boolean = False
    Public hide2 As Boolean = False

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        loadPages()
    End Sub

    Sub loadPages()

        If Not IsNumeric(Request("id")) Then
            Exit Sub
        End If

        pagesTree = _pageLogic.getPageTree(CInt(Request("id")))

  
            Dim pagesList As List(Of pagesRow) = _pagesAdapter.GetList("fatherid=32 AND isnull(hide, 0) <> 1", "sort")
            medrep.DataSource = pagesList
            medrep.DataBind()
          
   


    End Sub

    Function isReletive(ByVal pageid As Integer) As Boolean
        For Each p As pagesRow In pagesTree
            If p.pagesid = pageid Then
                Return True
            End If
        Next
        Return False
    End Function

    Function getSubPages(ByVal pageid As Integer) As String
        If Not IsNumeric(Request("id")) Then
            Return ""
        End If

        Dim str As String = ""
        Dim pageList As pList(Of pagesRow) = _pagesAdapter.GetList("fatherid=" & pageid)
        For Each p As pagesRow In pageList
            'If Request("id") = CStr(p.pagesid) Then
            'str &= "<li class=""Med_C3_selected2""><a href=""" & pageLogic.GetPageLink("page", p.pagesid, p.name, p.page_link) & """>" & p.title & " <span>-</span></a></li>"
            'Else

            Dim c As String = "f2"
            If isReletive(p.pagesid) Then
                c = "f2selected"
            End If

            str &= "<li><a href=""javascript:showthird('" & p.pagesid & "');"" class=""" & c & """ id=""lia" & p.pagesid & """>" & p.name & " <span><</span></a>"
            str &= getSubPagesThird(p.pagesid)
            str &= "</li>"
            'End If
        Next
        If str = "" Then
            Return ""
        End If
        Dim display As String = "style=""display:none;"""
        If isReletive(Request("id")) And isReletive(pageid) Then
            display = ""
        End If
        Return "<ul id=""second" & pageid & """ " & display & ">" & str & "<div class=""bottomspace""></div></ul>"
    End Function

    Function getSubPagesThird(ByVal pageid As Integer) As String
        If Not IsNumeric(Request("id")) Then
            Return ""
        End If
        'If Not isReletive(pageid) Then
        'Return ""
        'End If
        Dim str As String = ""
        Dim pageList As pList(Of pagesRow) = _pagesAdapter.GetList("fatherid=" & pageid)
        For Each p As pagesRow In pageList
            'If Request("id") = CStr(p.pagesid) Then

            Dim c As String = "f3"
            If isReletive(p.pagesid) Then
                c = "f3selected"
            End If

            str &= "<li><a href=""" & pageLogic.GetPageLink("page", p.pagesid, p.name, p.page_link) & """ class=""" & c & """ id=""lia" & p.pagesid & """>" & p.name & " <span>-</span></a></li>"
            'Else
            'str &= "<li><a href=""" & pageLogic.GetPageLink("page", p.pagesid, p.name, p.page_link) & """>" & p.title & " <span><</span></a></li>"
            'End If
        Next
        If str = "" Then
            Return ""
        End If
        Dim display As String = "style=""display:none;"""
        If isReletive(Request("id")) And isReletive(pageid) Then
            display = ""
        End If
        Return "<ul id=""third" & pageid & """ " & display & ">" & str & "<div class=""bottomspace""></div></ul>"
    End Function

    Function getclass(ByVal pagesid As Integer) As String
        If isReletive(pagesid) Then
            Return "f1selected"
        End If
        Return "f1"
    End Function

End Class
