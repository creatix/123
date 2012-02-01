Imports cs3.utils.databaseLogic

Public Class projectsRow
    Implements IGenericRow

    Private _projectsid As Integer
    Public Property projectsid() As Integer
        Get
            Return _projectsid
        End Get
        Set(ByVal Value As Integer)
            _projectsid = Value
        End Set
    End Property

    Private _name As String
    Public Property name() As String
        Get
            Return _name
        End Get
        Set(ByVal Value As String)
            _name = Value
        End Set
    End Property

    Private _description As String
    Public Property description() As String
        Get
            Return _description
        End Get
        Set(ByVal Value As String)
            _description = Value
        End Set
    End Property

    Private _hide As Integer
    Public Property hide() As Integer
        Get
            Return _hide
        End Get
        Set(ByVal Value As Integer)
            _hide = Value
        End Set
    End Property

    Private _sort As Integer
    Public Property sort() As Integer
        Get
            Return _sort
        End Get
        Set(ByVal Value As Integer)
            _sort = Value
        End Set
    End Property

    Private _smallpic As String
    Public Property smallpic() As String
        Get
            Return _smallpic
        End Get
        Set(ByVal Value As String)
            _smallpic = Value
        End Set
    End Property

    Private _bigpic As String
    Public Property bigpic() As String
        Get
            Return _bigpic
        End Get
        Set(ByVal Value As String)
            _bigpic = Value
        End Set
    End Property

    Private _type As Integer
    Public Property type() As Integer
        Get
            Return _type
        End Get
        Set(ByVal Value As Integer)
            _type = Value
        End Set
    End Property

    Private _location As Integer
    Public Property location() As Integer
        Get
            Return _location
        End Get
        Set(ByVal Value As Integer)
            _location = Value
        End Set
    End Property

    Private _city As String
    Public Property city() As String
        Get
            Return _city
        End Get
        Set(ByVal Value As String)
            _city = Value
        End Set
    End Property

    Public ReadOnly Property primaryKey() As String Implements IGenericRow.primaryKey
        Get
            Return "projectsid"
        End Get
    End Property

    Public ReadOnly Property tableName() As String Implements IGenericRow.tableName
        Get
            Return "projects"
        End Get
    End Property

    Public Sub Fill(ByVal reader As System.Data.IDataReader) Implements IGenericRow.Fill
        _projectsid = getReaderObject(reader, "projectsid")
        _name = getReaderObject(reader, "name")
        _description = getReaderObject(reader, "description")
        _hide = getReaderObject(reader, "hide")
        _sort = getReaderObject(reader, "sort")
        _smallpic = getReaderObject(reader, "smallpic")
        _bigpic = getReaderObject(reader, "bigpic")
        _type = getReaderObject(reader, "type")
        _location = getReaderObject(reader, "location")
        _city = getReaderObject(reader, "city")
    End Sub

    Private _rowState As rowInfo
    Public Property rowState() As rowInfo Implements IGenericRow.rowState
        Get
            Return _rowState
        End Get
        Set(ByVal Value As rowInfo)
            _rowState = Value
        End Set
    End Property

End Class

Public Class projectsAdapter
    Inherits baseAdapter(Of projectsRow)

End Class
