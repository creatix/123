Imports System
Imports System.Web
Imports System.IO
Imports System.Reflection
Imports cs3.DataLayer

Public Class pageLogic

    'Dim basePage As Page

    'Sub New(ByVal p As Page)
    '    basePage = p
    'End Sub

    Public Shared Function GetPageLink(ByVal page As String, ByVal pagesid As String, ByVal name As String, ByVal page_link As Object) As String
        If IsDBNull(page_link) Then
            page_link = ""
        End If
        If page_link <> "" Then
            Return page_link
        Else
            If name = "" Then
                Return page & "-" & pagesid & "-" & page & ".aspx"
            Else
                If page = "page" Then
                    Return parseURL(name) & ".aspx"
                Else
                    Return page & "-" & pagesid & "-" & parseURL(name) & ".aspx"
                End If
            End If
        End If
    End Function

    Public Shared Function parseURL(ByVal url As String) As String
        url = url.Replace(" ", "_")
        url = url.Replace("-", "_")
        url = url.Replace("?", "")
        url = url.Replace("'", "")
        url = url.Replace("&", "")
        url = url.Replace("/", "")
        url = url.Replace("\", "")
        url = url.Replace("""", "")
        'url = Server.UrlEncode(url)
        Return url
    End Function

    Public Sub setPageTitle(ByVal metatitle As String, ByVal metadescription As String, ByVal metakeywords As String, ByVal page As System.Web.UI.Page)

        If Trim(metatitle) <> "" Then
            page.Title = metatitle
        End If

        Dim metaTag As New HtmlMeta

        If Trim(metadescription) <> "" Then
            metaTag.Name = "description"
            metaTag.Content = metadescription
            page.Header.Controls.Add(metaTag)
        End If

        If Trim(metakeywords) <> "" Then
            metaTag = New HtmlMeta
            metaTag.Name = "keywords"
            metaTag.Content = metakeywords
            page.Header.Controls.Add(metaTag)
        End If

    End Sub

    Public Function getPageContent(ByVal pageid As Integer) As String

        Dim _pagesAdapter As New pagesAdapter
        Dim pageRow As pagesRow = _pagesAdapter.GetItem(pageid)

        If pageRow Is Nothing Then
            Return ""
        End If

        If pageRow.layout = "" Then
            Return pageRow.content1
        End If

        Dim layout As String = ""
        layout = File.ReadAllText(HttpContext.Current.Server.MapPath("templates\layouts\" & pageRow.layout))

        Return loadPlaceholders(pageRow, layout)

    End Function

    Function loadPlaceholders(ByVal pageRow As pagesRow, ByVal layout As String) As String
        Dim Matches As MatchCollection = Regex.Matches(layout, "{.*}")
        For Each match As Match In Matches
            If match.Value.StartsWith("{data:") Then
                layout = layout.Replace(match.Value, loadData(pageRow, match.Value))
            End If
            If match.Value.StartsWith("{panel:") Then
                layout = layout.Replace(match.Value, loadPanel(match.Value))
            End If
        Next
        Return layout
    End Function

    Function loadData(ByVal pageRow As pagesRow, ByVal placeholder As String) As String
        Dim propertyName As String = placeholder.Replace("{data:", "")
        propertyName = propertyName.Replace("}", "")
        Dim inputType As Type = pageRow.GetType
        Dim typeProperties() As PropertyInfo = inputType.GetProperties
        For Each propInfo As PropertyInfo In typeProperties
            If propInfo.Name = propertyName Then
                Return propInfo.GetValue(pageRow, Nothing)
            End If
        Next
        Return placeholder
    End Function

    Function loadPanel(ByVal placeholder As String) As String
        Dim panelContent As String = ""
        Dim panelName As String = placeholder.Replace("{panel:", "")
        panelName = panelName.Replace("}", "")
        If Path.GetExtension(panelName) = ".ascx" Then
            Dim page As Page = New Page()
            Dim userControl As UserControl = page.LoadControl("templates\panels\" & panelName)
            page.Controls.Add(userControl)
            Dim textWriter As StringWriter = New StringWriter()
            HttpContext.Current.Server.Execute(page, textWriter, True)
            panelContent = textWriter.ToString()
        Else
            panelContent = File.ReadAllText(HttpContext.Current.Server.MapPath("templates\panels\" & panelName))
        End If
        Return loadPlaceholders(Nothing, panelContent)
    End Function

    Dim dataTableAdapter As New TableAdapter

    Function getPageTree(ByVal pageid As Integer) As pList(Of pagesRow)
        Dim _pagesAdapter As New pagesAdapter
        Dim _pagesList As pList(Of pagesRow) = _pagesAdapter.GetList(, , , , , "SELECT * FROM getpageparents('" & pageid & "')")
        Return _pagesList
    End Function

End Class

Public Class errorLogic

    Public Sub New(ByVal type As String, ByVal msg As String)
        Select Case type
            Case "error"
                HttpContext.Current.Session("errormsg") = msg
            Case "success"
                HttpContext.Current.Session("successmsg") = msg
            Case "notify"
                HttpContext.Current.Session("notifymsg") = msg
        End Select

    End Sub
End Class

Public Class URLRewriter
    Implements IHttpModule

    Public Sub Init(ByVal inst As System.Web.HttpApplication) Implements System.Web.IHttpModule.Init
        AddHandler inst.BeginRequest, AddressOf Me.OnBeginRequest
    End Sub

    Public Sub OnBeginRequest(ByVal app As Object, ByVal e As EventArgs)
        Dim inst As HttpApplication = CType(app, HttpApplication)
        Dim req_path As String = inst.Context.Request.Path
        If Path.GetExtension(req_path) <> ".aspx" Then
            Exit Sub
        End If
        Dim trans_path As String = ""
        Dim re As Regex = New Regex("cat-(.*)-(.*).aspx", RegexOptions.IgnoreCase)
        Dim match As Match = re.Match(req_path.ToLower())
        If match.Success Then
            trans_path = re.Replace(req_path.ToLower(), "cat.aspx?catid=$1&name=$2")
        Else
            trans_path = getDynamicTransferPage(req_path.ToLower())
        End If
        'If trans_path = "" Then trans_path = req_path

        If trans_path <> "" Then
            Dim sign As String = ""
            If trans_path.IndexOf("?") > -1 Then
                sign = "&"
            Else
                sign = "?"
            End If
            trans_path &= sign & HttpContext.Current.Request.QueryString.ToString()
            inst.Context.Server.Transfer(trans_path, True)
        End If

    End Sub

    Function getDynamicTransferPage(ByVal pageName As String) As String
        Dim pagesList As pList(Of pagesRow) = getPageByName(Path.GetFileNameWithoutExtension(pageName.ToLower()))
        If pagesList.Count > 0 Then
            Dim pageurl As String = "page.aspx"
            If pagesList(0).layout <> "" Then
                pageurl = pagesList(0).layout
            End If
            Return pageurl & "?id=" & pagesList(0).pagesid
        End If
        Return ""
    End Function

    Function getPageByName(ByVal pageName As String) As pList(Of pagesRow)
        pageName = pageName.Replace("_", " ")
        Dim _pagesAdatpter As New pagesAdapter
        Dim pagesList As pList(Of pagesRow) = _pagesAdatpter.GetList("name='" & pageName & "'")
        Return pagesList
    End Function

    Public Sub Dispose() Implements System.Web.IHttpModule.Dispose

    End Sub

End Class