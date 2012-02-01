Imports Microsoft.VisualBasic
Imports System.Data
Imports cs3.DataLayer
Imports System.Reflection

Public Interface IGenericRow
    Sub Fill(ByVal reader As IDataReader)
    ReadOnly Property tableName() As String
    ReadOnly Property primaryKey() As String
    Property rowState() As rowInfo
End Interface

Public Class pList(Of T)
    Inherits List(Of T)
    Public totalItems As Integer = 0
    Public currentPage As Integer = 1
    Public itemsPerPage As Integer = 10
    Public totalPages As Integer = 1
End Class

Public Enum RowState
    Unchanged
    Inserted
    Updated
    Deleted
End Enum

Public Class rowInfo
    Public state As RowState = RowState.Unchanged
    Public originalRow As IGenericRow
    Public Sub setState(ByVal _rowState As RowState)
        state = _rowState
    End Sub
End Class

Public Class baseAdapter(Of T As {IGenericRow, New})

    Dim dataTableAdapter As New TableAdapter

    Public Function GetItem(ByVal id As Integer, Optional ByVal quary As String = "") As T

        Dim dataItem As T = New T
        Dim dbReader As IDataReader
        If quary = "" Then
            quary = dataItem.primaryKey & "=" & id
        End If

        Try
            dbReader = dataTableAdapter.ExecuteReader(CommandType.Text, "SELECT * FROM " & dataItem.tableName & " " & GetWhereClause(quary))
            If Not IsNothing(dbReader) Then
                dbReader.Read()
                dataItem.Fill(dbReader)
            End If
        Catch
        Finally
            dbReader.Close()
        End Try

        Return dataItem

    End Function

    Public Function GetList(Optional ByVal whereQuery As String = "", Optional ByVal sortBy As String = "", Optional ByVal currentPage As Integer = 1, Optional ByVal pageSize As Integer = 10, Optional ByVal view As String = "", Optional ByVal query As String = "") As pList(Of T)

        Dim dataItem As New T
        Dim dbReader As IDataReader
        Dim sqlStr As String = ""
        Dim totalItems As Integer = 0
        If sortBy = "" Then sortBy = dataItem.primaryKey
        If view = "" Then view = dataItem.tableName

        If query = "" Then
            If pageSize > 0 Then
                Dim from As Integer = (currentPage - 1) * pageSize + 1
                Dim top As Integer = currentPage * pageSize
                sqlStr = "WITH temptbl AS ( SELECT ROW_NUMBER() OVER (ORDER BY " & sortBy & ")AS Row, * FROM " & view & " " & GetWhereClause(whereQuery) & ") SELECT * FROM temptbl WHERE (Row between " & from & " and " & top & ")"
                totalItems = dataTableAdapter.ExecuteScalar(CommandType.Text, "SELECT COUNT(" & dataItem.primaryKey & ") FROM " & view & " " & GetWhereClause(whereQuery))
            Else
                sqlStr = "SELECT * FROM " & view & " " & GetWhereClause(whereQuery) & " ORDER BY " & sortBy
            End If
        Else
            sqlStr = query
        End If

        Dim listItems As pList(Of T) = New pList(Of T)
        listItems.totalItems = totalItems
        listItems.currentPage = currentPage
        listItems.itemsPerPage = pageSize
        If totalItems > 0 Then
            listItems.totalPages = Math.Ceiling(totalItems / pageSize)
        End If

        Try
            dbReader = dataTableAdapter.ExecuteReader(CommandType.Text, sqlStr)
            If Not IsNothing(dbReader) Then
                While dbReader.Read()
                    dataItem = New T
                    dataItem.Fill(dbReader)
                    listItems.Add(dataItem)
                End While
            End If
        Catch e As Exception

        Finally
            dbReader.Close()
        End Try

        Return listItems

    End Function

    Function GetWhereClause(ByVal query As String, Optional ByVal preStr As String = "WHERE") As String

        Dim sqlStr As String = query
        If sqlStr <> "" Then sqlStr = preStr & " " & sqlStr
        Return sqlStr

    End Function

    Public Function UpdateList(ByVal InputClass As pList(Of T)) As Boolean

        For Each row As IGenericRow In InputClass
            getRowCommand(row)
        Next

        Return True

    End Function

    Public Function UpdateRow(ByVal InputClass As T) As Integer
        Return getRowCommand(InputClass)
    End Function

    Function getRowCommand(ByVal InputClass As T) As Integer
        Dim sqlStr As String = ""
        Dim returnValue As Integer = 0
        Select Case InputClass.rowState.state
            Case RowState.Inserted
                returnValue = Insert(InputClass)
            Case RowState.Updated
                returnValue = Update(InputClass)
            Case RowState.Deleted
                returnValue = Delete(InputClass)
        End Select
        Return returnValue
    End Function

    Function Insert(ByVal InputClass As T) As Integer

        Dim inputType As Type = InputClass.GetType
        Dim typeProperties() As PropertyInfo = inputType.GetProperties
        Dim sqlStr As String = ""
        Dim namesStr As String = ""
        Dim valuesStr As String = ""

        For Each propInfo As PropertyInfo In typeProperties
            If verifyProperty(propInfo, InputClass) Then
                namesStr &= propInfo.Name & ","
                valuesStr &= getPropertyValue(propInfo, InputClass) & ","
            End If
        Next

        If namesStr = "" Then Return False

        namesStr = namesStr.Remove(namesStr.Length - 1)
        valuesStr = valuesStr.Remove(valuesStr.Length - 1)

        sqlStr = "INSERT INTO " & InputClass.tableName & " (" & namesStr & ") VALUES (" & valuesStr & ") SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]"

        Return dataTableAdapter.ExecuteScalar(CommandType.Text, sqlStr)

    End Function

    Function Update(ByVal InputClass As T) As Integer

        Dim inputType As Type = InputClass.GetType
        Dim typeProperties() As PropertyInfo = inputType.GetProperties
        Dim sqlStr As String = ""
        Dim updateStr As String = ""
        Dim pkValue As Integer = 0

        For Each propInfo As PropertyInfo In typeProperties
            If propInfo.Name <> InputClass.primaryKey Then
                If verifyProperty(propInfo, InputClass) Then
                    updateStr &= propInfo.Name & "=" & getPropertyValue(propInfo, InputClass) & ","
                End If
            Else
                pkValue = getPropertyValue(propInfo, InputClass)
            End If
        Next

        If updateStr = "" Or pkValue = 0 Then Return False

        updateStr = updateStr.Remove(updateStr.Length - 1)

        sqlStr = "UPDATE " & InputClass.tableName & " SET " & updateStr & " WHERE " & InputClass.primaryKey & "=" & pkValue

        dataTableAdapter.ExecuteNonQuery(CommandType.Text, sqlStr)

        Return pkValue

    End Function

    Function Delete(ByVal InputClass As T) As Integer
        Dim pkValue As Integer = 0
        Dim inputType As Type = InputClass.GetType
        Dim typeProperties() As PropertyInfo = inputType.GetProperties
        For Each propInfo As PropertyInfo In typeProperties
            If propInfo.Name = InputClass.primaryKey Then
                pkValue = getPropertyValue(propInfo, InputClass)
            End If
        Next
        If Delete(pkValue) Then
            Return pkValue
        End If
        Return 0
    End Function

    Public Function Delete(ByVal id As Integer) As Boolean
        Dim dataItem As T = New T
        Dim sqlStr As String = "DELETE FROM " & dataItem.tableName & " WHERE " & dataItem.primaryKey & "=" & id
        dataTableAdapter.ExecuteNonQuery(CommandType.Text, sqlStr)
        Return True
    End Function

    Function verifyProperty(ByRef propInfo As PropertyInfo, ByRef InputClass As IGenericRow) As Boolean
        If propInfo.GetValue(InputClass, Nothing) Is Nothing Then
            Return False
        End If
        If Not propInfo.CanWrite Then
            Return False
        End If
        If propInfo.Name = InputClass.primaryKey Then
            Return False
        End If
        Select Case propInfo.PropertyType.ToString
            Case "Integer", "String", "Double", "System.DateTime", "System.Int32", "System.Int64", "System.String", "System.Double"
            Case Else
                Return False
        End Select
        Return True
    End Function

    Function getPropertyValue(ByRef propInfo As PropertyInfo, ByRef InputClass As IGenericRow) As String
        Dim val As String = propInfo.GetValue(InputClass, Nothing)
        Select Case propInfo.PropertyType.ToString
            Case "Integer", "System.Int32", "System.Int64"
                Return val
            Case Else
                If propInfo.Name = "insertdate" Then Return "GETDATE()"
                Return "'" & val.Replace("'", "''") & "'"
        End Select
        Return ""
    End Function

    Public Sub SaveItem(ByVal SaveObject As T, ByVal commandText As String)

        'Dim db As Database = DatabaseFactory.CreateDatabase()
        'Dim dbCommand As DbCommand = db.GetStoredProcCommand(commandText)

        'db.DiscoverParameters(dbCommand)

        'FillParameters(SaveObject, dbCommand)
        'db.ExecuteNonQuery(dbCommand)

    End Sub

    'Private Sub FillParameters(Of T As IBusinessEntity)(ByVal InputClass As T, ByRef CurrentCommand As DbCommand)

    'Dim inputType As Type = InputClass.GetType
    'Dim storedProcAttribute As StoredProcParameterAttribute
    'Dim typeProperties() As PropertyInfo = inputType.GetProperties
    'Dim attributes() As Attribute

    'For Each parameter As SqlParameter In CurrentCommand.Parameters

    'For Each propInfo As PropertyInfo In typeProperties
    'attributes = propInfo.GetCustomAttributes(GetType(StoredProcParameterAttribute), True)
    'If Not IsNothing(attributes) And attributes.Length = 1 Then
    'storedProcAttribute = attributes(0)
    'If Not IsNothing(storedProcAttribute) And storedProcAttribute.StoredProcParameter.Length > 0 Then
    'If storedProcAttribute.StoredProcParameter = Parameter.ParameterName Then
    'Parameter.Value = propInfo.GetValue(InputClass, Nothing)
    'Exit For
    'End If
    'End If
    'End If
    'Next
    'Next

    'End Sub

End Class
