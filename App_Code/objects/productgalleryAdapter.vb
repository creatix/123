Imports cs3.utils.databaseLogic

Public Class productgalleryRow
    Implements IGenericRow

    Private _productgalleryid As Integer
    Public Property productgalleryid() As Integer
        Get
            Return _productgalleryid
        End Get
        Set(ByVal Value As Integer)
            _productgalleryid = Value
        End Set
    End Property

    Private _productid As Integer
    Public Property productid() As Integer
        Get
            Return _productid
        End Get
        Set(ByVal Value As Integer)
            _productid = Value
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

    Public ReadOnly Property primaryKey() As String Implements IGenericRow.primaryKey
        Get
            Return "productgalleryid"
        End Get
    End Property

    Public ReadOnly Property tableName() As String Implements IGenericRow.tableName
        Get
            Return "productgallery"
        End Get
    End Property

    Public Sub Fill(ByVal reader As System.Data.IDataReader) Implements IGenericRow.Fill
        _productid = toNothing(reader("productid"))
        _url = toNothing(reader("url"))
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

Public Class productgalleryAdapter
    Inherits baseAdapter(Of productgalleryRow)

End Class
