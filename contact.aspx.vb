Imports cs3
Imports System.IO
Imports System.Web.Mail

Partial Class contact
    Inherits System.Web.UI.Page

    Public table As tableLogic.tableAdapter
    Public pagRow As pagesRow

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        loadPage()
        If Not Request("Msg") Is Nothing Then
            divContact.Visible = False
            divMessage.Visible = True
        Else
            divContact.Visible = True
            divMessage.Visible = False
        End If
        sendmail()
    End Sub

    Sub loadPage()

        Dim pagesA As New pagesAdapter
        pagRow = pagesA.GetItem(34)

        If Not pagRow Is Nothing Then
            Dim pl As New pageLogic
            pagecontentlbl.Text = pagRow.content1
          
        End If

    End Sub

    Sub sendmail()

        If Request("submited") <> "true" Then
            Exit Sub
        End If

        Dim Name As String = nametxt.Value
        Dim phone As String = phonetxt.Value
        Dim email As String = emailtxt.Value
        Dim Message As String = msgtxt.Value
        Dim EmailTo As String = "office@eo-im.com"
        If siteLogic.Config("contactemail") <> "" Then
            EmailTo = siteLogic.Config("contactemail")
        End If

        If Name = "" Then
            lblMessage.Text = "אנא הכנס שם<br><br>"
            Exit Sub
        End If
        If phone = "" Then
            lblMessage.Text = "אנא הכנס טלפון<br><br>"
            Exit Sub
        End If
        If Email = "" Then
            lblMessage.Text = "אנא הכנס אימייל<br><br>"
            Exit Sub
        End If
        If Email.IndexOf("@") = -1 Or Email.IndexOf(".") = -1 Then
            lblMessage.Text = "אנא הכנס אימייל תקין<br><br>"
            Exit Sub
        End If

        Dim msg As String
        msg = "<div style=""font-size:18px;color:Red;""> Details </div><br>"
        msg &= "Name: " & Name
        msg &= "<br/>"
        msg &= "Phone " & phone
        msg &= "<br/>"
        msg &= "Email: " & Email
        msg &= "<br/>"
        msg &= "Company name: " & companyname.Value
        msg &= "<br/>"
        msg &= "Message: " & Message
        msg &= "<br/>"

        Dim e_msg As New MailMessage

        e_msg.From = Email
        e_msg.To = EmailTo
        e_msg.Subject = "Contact From E&O Initiation & Management"
        e_msg.Body = msg
        e_msg.BodyFormat = MailFormat.Html

        SmtpMail.Send(e_msg)

        e_msg.To = "office@eo-im.com"
        SmtpMail.Send(e_msg)

        Dim _usersAdapter As New usersAdapter
        Dim newUser As New usersRow
        newUser.fullname = Name
        newUser.phone = phone
        newUser.email = email
        newUser.message = Message
        _usersAdapter.Insert(newUser)

        'Try

        'smtpClient.Send(e_msg)

        'Catch ex As Exception
        'lblMessage.Text = "ישנן בעיות בשליחת דואר האלקטרוני"
        'Exit Sub
        'End Try

        Response.Redirect("contact.aspx?Msg=true")

    End Sub

End Class
