
Partial Class test
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim w As New WebReference.ws
        Dim p() As WebReference.Printer = w.GetPrinterList("73")
        Base64ToImage(p(0).Code, p(0).Pic)
    End Sub
    Public Function Base64ToImage(ByVal printerCode As String, ByVal base64String As String) As Boolean
        ' Convert Base64 String to byte[]
        Try
            Dim imageBytes As Byte() = Convert.FromBase64String(base64String)
            Dim ms As System.IO.MemoryStream = New System.IO.MemoryStream(imageBytes, 0, imageBytes.Length)
            'Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length)
            Dim img As System.Drawing.Image = System.Drawing.Image.FromStream(ms, True)
            img.Save("C:\inetpub\wwwroot\eo\test\" + printerCode + ".jpg")
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    
End Class
