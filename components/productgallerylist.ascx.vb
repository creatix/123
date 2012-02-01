
Partial Class components_productgallerylist
    Inherits System.Web.UI.UserControl

    Public productid As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If productid = 0 Then Exit Sub
        Dim _productgalleryAdapter As New productgalleryAdapter
        productGalleryRepeater.DataSource = _productgalleryAdapter.GetList("productid=" & productid)
        productGalleryRepeater.DataBind()
    End Sub
End Class
