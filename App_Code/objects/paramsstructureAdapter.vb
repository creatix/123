Imports cs3.utils.databaseLogic

Public Class paramsstructureRow
    Implements IGenericRow

    Private _paramsstructureid As Integer
    Public Property paramsstructureid() As Integer
        Get
            Return _paramsstructureid
        End Get
        Set(ByVal Value As Integer)
            _paramsstructureid = Value
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

    Private _catid As Integer
    Public Property catid() As Integer
        Get
            Return _catid
        End Get
        Set(ByVal Value As Integer)
            _catid = Value
        End Set
    End Property

    Private _componentname As String
    Public Property componentname() As String
        Get
            Return _componentname
        End Get
        Set(ByVal Value As String)
            _componentname = Value
        End Set
    End Property

    Private _controlparams As String
    Public Property controlparams() As String
        Get
            Return _controlparams
        End Get
        Set(ByVal Value As String)
            _controlparams = Value
        End Set
    End Property

    Public ReadOnly Property primaryKey() As String Implements IGenericRow.primaryKey
        Get
            Return "paramsstructureid"
        End Get
    End Property

    Public ReadOnly Property tableName() As String Implements IGenericRow.tableName
        Get
            Return "paramsstructure"
        End Get
    End Property

    Public Sub Fill(ByVal reader As System.Data.IDataReader) Implements IGenericRow.Fill
        _paramsstructureid = toNothing(reader("paramsstructureid"))
        _name = toNothing(reader("name"))
        _catid = toNothing(reader("catid"))
        _componentname = toNothing(reader("componentname"))
        _controlparams = toNothing(reader("controlparams"))
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

Public Class paramsstructureAdapter
    Inherits baseAdapter(Of paramsstructureRow)

End Class
