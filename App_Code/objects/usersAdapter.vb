Imports cs3.utils.databaseLogic

Public Class usersRow
    Implements IGenericRow

    Private _usersid As Integer
    Public Property usersid() As Integer
        Get
            Return _usersid
        End Get
        Set(ByVal Value As Integer)
            _usersid = Value
        End Set
    End Property

    Private _firstname As String
    Public Property firstname() As String
        Get
            Return _firstname
        End Get
        Set(ByVal Value As String)
            _firstname = Value
        End Set
    End Property

    Private _lastname As String
    Public Property lastname() As String
        Get
            Return _lastname
        End Get
        Set(ByVal Value As String)
            _lastname = Value
        End Set
    End Property

    Private _email As String
    Public Property email() As String
        Get
            Return _email
        End Get
        Set(ByVal Value As String)
            _email = Value
        End Set
    End Property

    Private _password As String
    Public Property password() As String
        Get
            Return _password
        End Get
        Set(ByVal Value As String)
            _password = Value
        End Set
    End Property

    Private _isrecevingupdates As Integer
    Public Property isrecevingupdates() As Integer
        Get
            Return _isrecevingupdates
        End Get
        Set(ByVal Value As Integer)
            _isrecevingupdates = Value
        End Set
    End Property

    Private _insertdate As DateTime
    Public Property insertdate() As DateTime
        Get
            Return _insertdate
        End Get
        Set(ByVal Value As DateTime)
            _insertdate = Value
        End Set
    End Property

    Private _fullname As String
    Public Property fullname() As String
        Get
            Return _fullname
        End Get
        Set(ByVal Value As String)
            _fullname = Value
        End Set
    End Property

    Private _phone As String
    Public Property phone() As String
        Get
            Return _phone
        End Get
        Set(ByVal Value As String)
            _phone = Value
        End Set
    End Property

    Private _message As String
    Public Property message() As String
        Get
            Return _message
        End Get
        Set(ByVal Value As String)
            _message = Value
        End Set
    End Property

    Public Overridable Sub Fill(ByVal reader As System.Data.IDataReader) Implements IGenericRow.Fill
        _usersid = toNothing(reader("usersid"))
        _firstname = toNothing(reader("firstname"))
        _lastname = toNothing(reader("lastname"))
        _email = toNothing(reader("email"))
        _password = toNothing(reader("password"))
        _isrecevingupdates = toNothing(reader("isrecevingupdates"))
        _insertdate = toNothing(reader("insertdate"))
        _fullname = toNothing(reader("fullname"))
        _phone = toNothing(reader("phone"))
        _message = toNothing(reader("message"))
    End Sub

    Public ReadOnly Property primaryKey() As String Implements IGenericRow.primaryKey
        Get
            Return "usersid"
        End Get
    End Property

    Public ReadOnly Property tableName() As String Implements IGenericRow.tableName
        Get
            Return "users"
        End Get
    End Property

    Private _rowState As New rowInfo
    Public Property rowState() As rowInfo Implements IGenericRow.rowState
        Get
            Return _rowState
        End Get
        Set(ByVal Value As rowInfo)
            _rowState = Value
        End Set
    End Property

End Class

Public Class usersAdapter
    Inherits baseAdapter(Of usersRow)

End Class