﻿Imports cs3.utils.databaseLogic

Public Class panoramagalleryRow
    Implements IGenericRow

    Private _panoramagalleryid As Integer
    Public Property panoramagalleryid() As Integer
        Get
            Return _panoramagalleryid
        End Get
        Set(ByVal Value As Integer)
            _panoramagalleryid = Value
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

    Private _pic1 As String
    Public Property pic1() As String
        Get
            Return _pic1
        End Get
        Set(ByVal Value As String)
            _pic1 = Value
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

    Public ReadOnly Property primaryKey() As String Implements IGenericRow.primaryKey
        Get
            Return "panoramagalleryid"
        End Get
    End Property

    Public ReadOnly Property tableName() As String Implements IGenericRow.tableName
        Get
            Return "panoramagallery"
        End Get
    End Property

    Public Sub Fill(ByVal reader As System.Data.IDataReader) Implements IGenericRow.Fill
        _panoramagalleryid = toNothing(reader("panoramagalleryid"))
        _name = toNothing(reader("name"))
        _pic = toNothing(reader("pic"))
        _pic1 = toNothing(reader("pic1"))
        _hide = toNothing(reader("hide"))
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

Public Class panoramagalleryAdapter
    Inherits baseAdapter(Of panoramagalleryRow)

End Class
