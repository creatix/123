Imports cs3.utils.databaseLogic

Public Class bannersRow
    Implements IGenericRow

    Private _bannersid As Integer
    Public Property bannersid() As Integer
        Get
            Return _bannersid
        End Get
        Set(ByVal Value As Integer)
            _bannersid = Value
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

    Private _pic As String
    Public Property pic() As String
        Get
            Return _pic
        End Get
        Set(ByVal Value As String)
            _pic = Value
        End Set
    End Property

    Private _url As String
    Public Property url() As String
        Get
            Return _url
        End Get
        Set(ByVal Value As String)
            _url = Value
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

    Private _catid As Integer
    Public Property catid() As Integer
        Get
            Return _catid
        End Get
        Set(ByVal Value As Integer)
            _catid = Value
        End Set
    End Property

    Public ReadOnly Property primaryKey() As String Implements IGenericRow.primaryKey
        Get
            Return "bannersid"
        End Get
    End Property

    Public ReadOnly Property tableName() As String Implements IGenericRow.tableName
        Get
            Return "banners"
        End Get
    End Property

    Public Sub Fill(ByVal reader As System.Data.IDataReader) Implements IGenericRow.Fill
        _bannersid = getReaderObject(reader, "bannersid")
        _name = getReaderObject(reader, "name")
        _pic = getReaderObject(reader, "pic")
        _url = getReaderObject(reader, "url")
        _pic = getReaderObject(reader, "pic")
        _sort = getReaderObject(reader, "sort")
        _catid = getReaderObject(reader, "catid")
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

Public Class bannersAdapter
    Inherits baseAdapter(Of bannersRow)

End Class
