
Imports System.Collections.Generic
Imports System.Data
Imports Transporte.Utils



Public Class UsuarioDB



    Private db As New DbHelper()



    ' Método para crear un nuevo usuario en la base de datos.
    Public Function CrearUsuario(ByVal pUsuario As Models.Usuario, ByRef errorMessage As String) As Boolean
        Dim query As String = "INSERT INTO Usuarios (IdPersona, Username, PasswordHash, Rol, Activo) " &
        "VALUES (@IdPersona, @Username, @PasswordHash, @Rol, @Activo)"



        Dim parameters As New Dictionary(Of String, Object) From {
        {"@IdPersona", pUsuario.IdPersona},
        {"@Username", pUsuario.Username},
        {"@PasswordHash", pUsuario.PasswordHash},
        {"@Rol", pUsuario.Rol},
        {"@Activo", pUsuario.Activo}
        }



        Return db.ExecuteNonQuery(query, parameters, errorMessage)
    End Function



    ' Método para listar todos los usuarios registrados.
    Public Function ListarUsuarios(ByRef errorMessage As String) As DataTable
        Dim query As String = "SELECT IdPersona, Username, PasswordHash, Rol, Activo " &
        "FROM Usuarios ORDER BY IdPersona ASC"



        Return db.ExecuteQuery(query, Nothing, errorMessage)
    End Function



    ' Método para obtener un usuario específico por su IdPersona.
    Public Function ObtenerUsuarioPorId(ByVal idPersona As Integer, ByRef errorMessage As String) As DataTable
        Dim query As String = "SELECT IdPersona, Username, PasswordHash, Rol, Activo " &
        "FROM Usuarios WHERE IdPersona = @IdPersona"



        Dim parameters As New Dictionary(Of String, Object) From {
        {"@IdPersona", idPersona}
        }



        Return db.ExecuteQuery(query, parameters, errorMessage)
    End Function



    ' Método para actualizar los datos de un usuario.
    Public Function ActualizarUsuario(ByVal pUsuario As Models.Usuario, ByRef errorMessage As String) As Boolean
        Dim query As String = "UPDATE Usuarios " &
        "SET Username = @Username, " &
        "    PasswordHash = @PasswordHash, " &
        "    Rol = @Rol, " &
        "    Activo = @Activo " &
        "WHERE IdPersona = @IdPersona"



        Dim parameters As New Dictionary(Of String, Object) From {
        {"@IdPersona", pUsuario.IdPersona},
        {"@Username", pUsuario.Username},
        {"@PasswordHash", pUsuario.PasswordHash},
        {"@Rol", pUsuario.Rol},
        {"@Activo", pUsuario.Activo}
        }



        Return db.ExecuteNonQuery(query, parameters, errorMessage)
    End Function



    ' Método para eliminar un usuario según su IdPersona.
    Public Function EliminarUsuario(ByVal idPersona As Integer, ByRef errorMessage As String) As Boolean
        Dim query As String = "DELETE FROM Usuarios WHERE IdPersona = @IdPersona"



        Dim parameters As New Dictionary(Of String, Object) From {
        {"@IdPersona", idPersona}
        }



        Return db.ExecuteNonQuery(query, parameters, errorMessage)
    End Function



    ' Método para validar el login del usuario.
    Public Function Login(ByVal username As String, ByVal passwordHash As String, ByRef errorMessage As String) As DataTable
        Dim query As String = "SELECT IdPersona, Username, Rol, Activo " &
        "FROM Usuarios " &
        "WHERE Username = @Username " &
        "AND PasswordHash = @PasswordHash " &
        "AND Activo = 1"



        Dim parameters As New Dictionary(Of String, Object) From {
        {"@Username", username},
        {"@PasswordHash", passwordHash}
        }



        Return db.ExecuteQuery(query, parameters, errorMessage)
    End Function



    ' Método para verificar si ya existe un nombre de usuario.
    Public Function ExisteUsername(ByVal username As String, ByRef errorMessage As String) As Boolean
        Dim query As String = "SELECT IdPersona FROM Usuarios WHERE Username = @Username"



        Dim parameters As New Dictionary(Of String, Object) From {
        {"@Username", username}
        }



        Dim dt As DataTable = db.ExecuteQuery(query, parameters, errorMessage)



        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            Return True
        End If



        Return False
    End Function



    ' Método para cambiar solamente el estado Activo de un usuario.
    Public Function CambiarEstadoUsuario(ByVal idPersona As Integer, ByVal activo As Boolean, ByRef errorMessage As String) As Boolean
        Dim query As String = "UPDATE Usuarios SET Activo = @Activo WHERE IdPersona = @IdPersona"



        Dim parameters As New Dictionary(Of String, Object) From {
        {"@IdPersona", idPersona},
        {"@Activo", activo}
        }



        Return db.ExecuteNonQuery(query, parameters, errorMessage)
    End Function



End Class

