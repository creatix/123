Imports cs3.utils.databaseLogic

Public Class newsRow
    Implements IGenericRow

    Private _newsid As Integer
    Public Property newsid() As Integer
        Get
            Return _newsid
        End Get
        Set(ByVal Value As Integer)
            _newsid = Value
        End Set
    End Property

    Private _title As String
    Public Property title() As String
        Get
            Return _title
        End Get
        Set(ByVal Value As String)
            _title = Value
        End Set
    End Property

    Private _link As String
    Public Property link() As String
        Get
            Return _link
        End Get
        Set(ByVal Value As String)
            _link = Value
        End Set
    End Property

    Private _content1 As String
    Public Property content1() As String
        Get
            Return _content1
        End Get
        Set(ByVal Value As String)
            _content1 = Value
        End Set
    End Property

    Private _insertdate As Date
    Public Property insertdate() As Date
        Get
            Return _insertdate
        End Get
        Set(ByVal Value As Date)
            _insertdate = Value
        End Set
    End Property

    Private _type As String
    Public Property type() As String
        Get
            Return _type
        End Get
        Set(ByVal Value As String)
            _type = Value
        End Set
    End Property

    Public ReadOnly Property primaryKey() As String Implements IGenericRow.primaryKey
        Get
            Return "newsid"
        End Get
    End Property

    Public ReadOnly Property tableName() As String Implements IGenericRow.tableName
        Get
            Return "news"
        End Get
    End Property

    Public Sub Fill(ByVal reader As System.Data.IDataReader) Implements IGenericRow.Fill
        _newsid = getReaderObject(reader, "newsid")
        _title = getReaderObject(reader, "title")
        _link = getReaderObject(reader, "link")
        _content1 = getReaderObject(reader, "content1")
        _insertdate = getReaderObject(reader, "insertdate")
        _type = getReaderObject(reader, "type")
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

Public Class newsAdapter
    Inherits baseAdapter(Of newsRow)

End Class
