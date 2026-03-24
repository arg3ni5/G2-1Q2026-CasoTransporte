Public Class Propietario
    Private _IdPersona As String
    Private _Telefono As String
    Private _Direccion As String

    'constructor vacio 
    Public Sub New()
    End Sub

    'constructor completo
    Public Sub New(IdPersona As Integer, Telefono As String, Direccion As String)
        Me.IdPersona = IdPersona
        Me.Telefono = Telefono
        Me.Direccion = Direccion
    End Sub
    Public Property IdPersona As String
        Get
            Return _IdPersona
        End Get
        Set(value As String)
            _IdPersona = value
        End Set
    End Property

    Public Property Telefono As String
        Get
            Return _Telefono
        End Get
        Set(value As String)
            _Telefono = value
        End Set
    End Property

    Public Property Direccion As String
        Get
            Return _Direccion
        End Get
        Set(value As String)
            _Direccion = value
        End Set
    End Property
End Class
