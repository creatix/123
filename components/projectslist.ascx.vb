
Partial Class components_projectslist
    Inherits System.Web.UI.UserControl

    Public type As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        loadProjects()
    End Sub

    Sub loadProjects()

        If type = 0 Then Exit Sub

        Dim _projectsAdapter As New projectsAdapter
        projectsRepeater.DataSource = _projectsAdapter.GetList("type=" & type)
        projectsRepeater.DataBind()

    End Sub

    Public Function removebottomline(ByVal id As Integer) As String
        If id = projectsRepeater.DataSource(projectsRepeater.DataSource.count - 1).projectsid Then
            Return "style=""border:none;"""
        End If
        Return ""
    End Function

End Class
