
Partial Class components_paramslist
    Inherits System.Web.UI.UserControl

    Public productid As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If productId > 0 Then
            Dim _paramsvaluesAdapter As New paramsvaluesAdapter
            paramsRepeater.DataSource = _paramsvaluesAdapter.GetList("productid=" & productid, , , 0)
            paramsRepeater.DataBind()
        End If

    End Sub

    Dim _paramsstructureAdapter As New paramsstructureAdapter

    Public Function getParamName(ByVal paramsstructureid As Integer) As String
        Dim ps As paramsstructureRow
        ps = _paramsstructureAdapter.GetItem(paramsstructureid)
        Return ps.name
    End Function

End Class
