Imports cs3.utils.databaseLogic

Public Class paramsvaluesRow
    Implements IGenericRow

    Private _paramsvaluesid As Integer
    Public Property paramsvaluesid() As Integer
        Get
            Return _paramsvaluesid
        End Get
        Set(ByVal Value As Integer)
            _paramsvaluesid = Value
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

    Private _catid As Integer
    Public Property catid() As Integer
        Get
            Return _catid
        End Get
        Set(ByVal Value As Integer)
            _catid = Value
        End Set
    End Property

    Private _paramsstructureid As Integer
    Public Property paramsstructureid() As Integer
        Get
            Return _paramsstructureid
        End Get
        Set(ByVal Value As Integer)
            _paramsstructureid = Value
        End Set
    End Property

    Private _value As String
    Public Property value() As String
        Get
            Return _value
        End Get
        Set(ByVal Value As String)
            _value = Value
        End Set
    End Property

    Public ReadOnly Property primaryKey() As String Implements IGenericRow.primaryKey
        Get
            Return "paramsvaluesid"
        End Get
    End Property

    Public ReadOnly Property tableName() As String Implements IGenericRow.tableName
        Get
            Return "paramsvalues"
        End Get
    End Property

    Public Sub Fill(ByVal reader As System.Data.IDataReader) Implements IGenericRow.Fill
        _paramsvaluesid = toNothing(reader("paramsvaluesid"))
        _productid = toNothing(reader("productid"))
        _catid = toNothing(reader("catid"))
        _paramsstructureid = toNothing(reader("paramsstructureid"))
        _value = toNothing(reader("value"))
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

Public Class paramsvaluesAdapter
    Inherits baseAdapter(Of paramsvaluesRow)

End Class
