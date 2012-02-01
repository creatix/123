Imports cs3.DataLayer

Partial Class productsRow

    Public ReadOnly Property finalprice() As Double
        Get
            Return price
        End Get
    End Property

End Class

Public Class productLogic

    Dim productsLogic As New productsAdapter

    Function getProductsList(ByVal catid As Integer, Optional ByVal pagesize As Integer = 10, Optional ByVal quary As String = "", Optional ByVal showChildrenCatProducts As Boolean = True, Optional ByVal showLinkedCatProducts As Boolean = True) As pList(Of productsRow)

        If catid <= 0 And quary = "" Then
            Return Nothing
        End If

        If catid > 0 And quary = "" Then

            If showChildrenCatProducts Then
                quary = "catid IN (SELECT catsid FROM dbo.getcatchildren(" & catid & "))"
            Else
                quary = "catid=" & catid
            End If

            If showLinkedCatProducts Then
                quary &= " OR productsid IN (SELECT productid FROM productcats WHERE catid='" & catid & "')"
            End If

        End If

        Dim currentPage As Integer = 1
        If IsNumeric(HttpContext.Current.Request("page")) Then
            currentPage = CInt(HttpContext.Current.Request("page"))
        End If

        Dim productsList As pList(Of productsRow) = productsLogic.GetList(quary, "sort", currentPage, pagesize)

        Return productsList

    End Function

End Class

Public Class catLogic

    Dim dataTableAdapter As New TableAdapter

    'Function getCatTree(ByVal catid As Integer) As pList(Of catsRow)

    'Dim _catsAdapter As New catsAdapter
    'Dim _catsList As pList(Of catsRow) = _catsAdapter.GetList(, , , , , "SELECT * FROM getcatsparents('" & catid & "')")
    'Return _catsList

    'End Function

End Class