Imports cs3.tableLogic
Imports System.IO
Imports System.Reflection

Public Class siteLogic

    Public Shared currency As String = "₪"

    Public Shared Function Config() As Dictionary(Of String, String)
        If HttpContext.Current.Cache("siteconfig") Is Nothing Then
            Dim _config As New Dictionary(Of String, String)
            Dim _settingsAdapter As New settingsAdapter
            Dim settingsList As List(Of settingsRow) = _settingsAdapter.GetList()
            For Each setting As settingsRow In settingsList
                _config.Add(setting.name, setting.value)
            Next
            'Dim productsTableDependency As New Caching.SqlCacheDependency("diamondstudio", "settings")
            'HttpContext.Current.Cache.Insert("siteconfig", _config, productsTableDependency, System.Web.Caching.Cache.NoAbsoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration)
            HttpContext.Current.Cache("siteconfig") = _config
        End If
        Return HttpContext.Current.Cache("siteconfig")
    End Function

End Class
