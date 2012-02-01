Imports cs3.tableLogic

Partial Class components_productslist
    Inherits System.Web.UI.UserControl

    Public quary As String
    Public sortBy As String = ""
    Public currentPage As Integer = 1
    Public pageSize As Integer = 10
    Public style As String = "PD_area"
    Dim tl As pList(Of productsRow)

    Protected Sub catsRepeater_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles catsRepeater.Load

        loadProducts()

    End Sub

    Sub loadProducts()

        'If quary = "" Then
        'Exit Sub
        'End If
        'Dim _productsAdapter As New productsAdapter
        'tl = _productsAdapter.GetList(quary, sortBy, currentPage, pageSize)

        If Not IsNumeric(Request("id")) And quary = "" Then
            Exit Sub
        End If

        Dim _productLogic As New productLogic
        tl = _productLogic.getProductsList(Request("id"), pageSize, quary, True, False)

        catsRepeater.DataSource = tl
        catsRepeater.DataBind()

    End Sub

    Dim counter As Integer = 0

    Public Function getLastPadding() As String
        counter += 1
        If counter = tl.Count Then
            Return "style=""padding:0px;"""
        End If
        Return ""
    End Function

End Class
