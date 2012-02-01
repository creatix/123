Imports cs3.utils.databaseLogic

Public Class productsRow
    Implements IGenericRow

    Private _productsid As Integer
    Public Property productsid() As Integer
        Get
            Return _productsid
        End Get
        Set(ByVal Value As Integer)
            _productsid = Value
        End Set
    End Property

    Private _catalogno As String
    Public Property catalogno() As String
        Get
            Return _catalogno
        End Get
        Set(ByVal Value As String)
            _catalogno = Value
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

    Private _price As Double
    Public Property price() As Double
        Get
            Return _price
        End Get
        Set(ByVal Value As Double)
            _price = Value
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

    Private _pic As String
    Public Property pic() As String
        Get
            Return _pic
        End Get
        Set(ByVal Value As String)
            _pic = Value
        End Set
    End Property

    Private _shortdescription As String
    Public Property shortdescription() As String
        Get
            Return _shortdescription
        End Get
        Set(ByVal Value As String)
            _shortdescription = Value
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

    Private _similarproducts As String
    Public Property similarproducts() As String
        Get
            Return _similarproducts
        End Get
        Set(ByVal Value As String)
            _similarproducts = Value
        End Set
    End Property

    Private _relatedproducts As String
    Public Property relatedproducts() As String
        Get
            Return _relatedproducts
        End Get
        Set(ByVal Value As String)
            _relatedproducts = Value
        End Set
    End Property

    Private _pdffile As String
    Public Property pdffile() As String
        Get
            Return _pdffile
        End Get
        Set(ByVal Value As String)
            _pdffile = Value
        End Set
    End Property

    Private _pdffilename As String
    Public Property pdffilename() As String
        Get
            Return _pdffilename
        End Get
        Set(ByVal Value As String)
            _pdffilename = Value
        End Set
    End Property

    Private _pdffile1 As String
    Public Property pdffile1() As String
        Get
            Return _pdffile1
        End Get
        Set(ByVal Value As String)
            _pdffile1 = Value
        End Set
    End Property

    Private _pdffilename1 As String
    Public Property pdffilename1() As String
        Get
            Return _pdffilename1
        End Get
        Set(ByVal Value As String)
            _pdffilename1 = Value
        End Set
    End Property

    Private _pdffile2 As String
    Public Property pdffile2() As String
        Get
            Return _pdffile2
        End Get
        Set(ByVal Value As String)
            _pdffile2 = Value
        End Set
    End Property

    Private _pdffilename2 As String
    Public Property pdffilename2() As String
        Get
            Return _pdffilename2
        End Get
        Set(ByVal Value As String)
            _pdffilename2 = Value
        End Set
    End Property

    Private _movie As String
    Public Property movie() As String
        Get
            Return _movie
        End Get
        Set(ByVal Value As String)
            _movie = Value
        End Set
    End Property

    Public ReadOnly Property primaryKey() As String Implements IGenericRow.primaryKey
        Get
            Return "productsid"
        End Get
    End Property

    Public ReadOnly Property tableName() As String Implements IGenericRow.tableName
        Get
            Return "products"
        End Get
    End Property

    Public Sub Fill(ByVal reader As System.Data.IDataReader) Implements IGenericRow.Fill
        _productsid = toNothing(reader("productsid"))
        _catalogno = toNothing(reader("catalogno"))
        _name = toNothing(reader("name"))
        _price = toNothing(reader("price"))
        _catid = toNothing(reader("catid"))
        _pic = toNothing(reader("pic"))
        _shortdescription = toNothing(reader("shortdescription"))
        _description = toNothing(reader("description"))
        _similarproducts = toNothing(reader("similarproducts"))
        _relatedproducts = toNothing(reader("relatedproducts"))
        _pdffile = toNothing(reader("pdffile"))
        _pdffilename = toNothing(reader("pdffilename"))
        _pdffile1 = toNothing(reader("pdffile1"))
        _pdffilename1 = toNothing(reader("pdffilename1"))
        _pdffile2 = toNothing(reader("pdffile2"))
        _pdffilename2 = toNothing(reader("pdffilename2"))
        _movie = toNothing(reader("movie"))
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

Public Class productsAdapter
    Inherits baseAdapter(Of productsRow)

End Class
