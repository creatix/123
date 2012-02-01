Imports cs3.tableLogic

Public Class userLogic

    Function getUserID() As Int64
        If HttpContext.Current.Session("UserId") Is Nothing Then
            HttpContext.Current.Session("UserId") = Now.Ticks
            Return HttpContext.Current.Session("UserId")
        Else
            Return HttpContext.Current.Session("UserId")
        End If
    End Function


End Class
