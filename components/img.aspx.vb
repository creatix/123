Imports System.Drawing.Imaging
Imports System.Drawing
Imports System.IO

Public Class img1
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Function ThumbnailCallback() As Boolean
        Return False
    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Response.ContentType = "image/jpeg"

        Dim adminUser As New cs3.adminLogic.adminUser
        Dim image_path_ex As String = Server.MapPath("../")
        Dim imageUrl As String = Request.QueryString("img")
        Dim is_exists As Boolean = True

        If (imageUrl.IndexOf("/") >= 0 Or imageUrl.IndexOf("\") >= 0) Then
            If imageUrl.IndexOf("cat\") = -1 And imageUrl.IndexOf("images\") = -1 Then
                Response.End()
            End If
        End If

        imageUrl = image_path_ex & imageUrl

        Dim fullSizeImg As Bitmap

        Try
            fullSizeImg = System.Drawing.Image.FromFile(imageUrl)
            is_exists = True
        Catch
            fullSizeImg = System.Drawing.Image.FromFile(Server.MapPath("..\") & "images\not_found.gif")
            is_exists = False
        End Try

        Dim req_width As String = Request.QueryString("width")
        Dim req_height As String = Request.QueryString("height")
        Dim img_width As Integer = fullSizeImg.Width
        Dim img_height As Integer = fullSizeImg.Height
        Dim img_ratio As Double = img_height / img_width

        If IsNumeric(req_width) Then
            img_width = CInt(req_width)
            img_height = img_width * img_ratio
        Else
            req_width = img_width
        End If

        If IsNumeric(req_height) Then
            'If img_height > CInt(req_height) Then
            img_height = CInt(req_height)
            img_width = img_height / img_ratio
            'End If
        Else
        req_height = img_height
        End If

        If img_width > fullSizeImg.Width And is_exists Then
            fullSizeImg.Save(Response.OutputStream, ImageFormat.Jpeg)
        Else
            draw_sized_image(fullSizeImg, img_width, img_height, req_width, req_height)
        End If

        fullSizeImg.Dispose()

        'If img_width < 150 Then

        'Else
        '    draw_sized_image(fullSizeImg, img_width, img_height)
        'End If

    End Sub


    Private Function DrawImageCallback(ByVal callBackData As IntPtr) As Boolean
        If callBackData.Equals(IntPtr.Zero) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub draw_sized_image(ByVal oImg As Bitmap, ByVal new_width As Integer, ByVal new_height As Integer, ByVal req_width As Integer, ByVal req_height As Integer)

        Try

            Dim oThumbNail As System.Drawing.Image = New Bitmap(req_width, req_height, oImg.PixelFormat)

            Dim oGraphic As Graphics = Graphics.FromImage(oThumbNail)
            oGraphic.Clear(Color.FromArgb(255, 77, 78, 83))

            oGraphic.CompositingQuality = Drawing2D.CompositingQuality.HighQuality

            oGraphic.SmoothingMode = Drawing2D.SmoothingMode.HighQuality

            oGraphic.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic

            Dim tempx As Integer = (req_width / 2) - (new_width / 2)
            Dim tempy As Integer = (req_height / 2) - (new_height / 2)

            Dim oRectangle As Rectangle = New Rectangle(tempx - 1, tempy - 1, new_width, new_height)

            oGraphic.DrawImage(oImg, oRectangle)

            'oThumbNail.Save(Response.OutputStream, ImageFormat.Jpeg)

            Dim objImageCodecInfo() As ImageCodecInfo
            objImageCodecInfo = ImageCodecInfo.GetImageEncoders
            Dim objEncParams As New EncoderParameters(1)
            Dim objEncParam As New EncoderParameter(Encoder.Quality, 100)
            objEncParams.Param(0) = objEncParam
            oThumbNail.Save(Response.OutputStream, objImageCodecInfo(1), objEncParams)

            oImg.Dispose()

        Catch
            draw_tumb(oImg, req_width, req_height)
        End Try

    End Sub

    Public Sub draw_sized_image1(ByVal originalImage As Bitmap, ByVal new_width As Integer, ByVal new_height As Integer)

        Dim imageCallback As New _
        Graphics.DrawImageAbort(AddressOf DrawImageCallback)
        Dim imageCallbackData As New IntPtr(1)

        Dim newImage As New Bitmap(new_width, new_height)

        Dim destRect1 As New Rectangle(0, 0, originalImage.Width, originalImage.Height)

        Dim x As Integer = 0
        Dim y As Integer = 0
        Dim width As Integer = originalImage.Width
        Dim height As Integer = originalImage.Height
        Dim units As GraphicsUnit = GraphicsUnit.Pixel

        Dim destRect2 As New Rectangle(0, 0, new_width, new_height)

        Dim imageAttr As New ImageAttributes
        'imageAttr.SetGamma(4.0F)

        'Dim objBitMap As New Bitmap(width, height, PixelFormat.Format24bppRgb)
        Dim objGraphics As Graphics = Graphics.FromImage(newImage)

        'objGraphics = Graphics.FromImage(objBitMap)
        objGraphics.Clear(Color.White)
        'objGraphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        'objGraphics.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
        'objGraphics.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAliasGridFit

        Try

            Response.ContentType = "image/jpeg"

            objGraphics.DrawImage(originalImage, destRect2, x, y, width, _
            height, units, imageAttr, imageCallback, imageCallbackData)

        Catch ex As Exception

            objGraphics.DrawString(ex.ToString(), New Font("Arial", 8), _
            Brushes.Black, New PointF(0, 0))

        End Try

        newImage.Save(Response.OutputStream, ImageFormat.Jpeg)
        newImage.Dispose()
        objGraphics.Dispose()

    End Sub

    Sub draw_tumb(ByVal fullSizeImg As Bitmap, ByVal img_width As Integer, ByVal img_height As Integer)
        '<%@ OutputCache duration="60" varybyparam="img;width" %>

        Dim dummyCallBack As System.Drawing.Image.GetThumbnailImageAbort
        dummyCallBack = New _
        System.Drawing.Image.GetThumbnailImageAbort(AddressOf ThumbnailCallback)

        Dim thumbNailImg As System.Drawing.Image
        thumbNailImg = fullSizeImg.GetThumbnailImage(img_width, img_height, _
                 dummyCallBack, IntPtr.Zero)

        ' fullSizeImg.Save(Response.OutputStream, ImageFormat.Jpeg)  
        thumbNailImg.Save(Response.OutputStream, ImageFormat.Jpeg)

    End Sub

End Class
