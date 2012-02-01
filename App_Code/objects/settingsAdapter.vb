Imports cs3.utils.databaseLogic

Public Class settingsRow
    Implements IGenericRow

    Private _settingsid As Integer
    Public Property settingsid() As Integer
        Get
            Return _settingsid
        End Get
        Set(ByVal Value As Integer)
            _settingsid = Value
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
            Return "settingsid"
        End Get
    End Property

    Public ReadOnly Property tableName() As String Implements IGenericRow.tableName
        Get
            Return "settings"
        End Get
    End Property

    Public Sub Fill(ByVal reader As System.Data.IDataReader) Implements IGenericRow.Fill
        _settingsid = getReaderObject(reader, "settingsid")
        _name = getReaderObject(reader, "name")
        _value = getReaderObject(reader, "value")
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

Public Class settingsAdapter
    Inherits baseAdapter(Of settingsRow)

End Class
