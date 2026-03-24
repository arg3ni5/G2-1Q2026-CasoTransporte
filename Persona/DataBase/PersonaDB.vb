Imports System.Data.SqlClient
Imports Persona.Utils
Public Class PersonaDB
    Private db As New DbHealper()
    'Crear Persona
    Public Function CrearPersona(ByVal pPersona As Models.Persona, ByRef errorMessage As String) As Boolean
        'Lógica para crear una nueva persona en la base de datos
        Using db.GetConnection()
            Dim query As String = "INSERT INTO Personas (TipoDocumento, Documento, Nombre, Apellidos, FechaNac, Correo) 
            VALUES (@TipoDocumento, @Documento, @Nombre, @Apellidos, @FechaNac, @Correo)"


            Dim parameters As New Dictionary(Of String, Object) From {
              {"@Nombre", pPersona.Nombre},
              {"@FechaNac", pPersona.FechaNacimiento},
              {"@Correo", pPersona.Correo},
              {"@Apellidos", pPersona.Apellidos},
              {"@Documento", pPersona.NumeroDocumento},
              {"@TipoDocumento", pPersona.TipoDocumento}
            }

            Return db.ExecuteNonQuery(query, parameters, errorMessage)
        End Using
        Return True
    End Function

    Public Function EliminarPersona(ByVal id As Integer, ByRef errorMessage As String) As Boolean

        Dim query As String = "DELETE FROM Personas WHERE IDPersona = @Id"
        Dim parameters As New Dictionary(Of String, Object) From {
                {"@Id", id}
            }
        Return db.ExecuteNonQuery(query, parameters, errorMessage)

    End Function

    Friend Function ConsultarPersona(id As String, errorMessage As String) As Models.Persona
        Throw New NotImplementedException()
    End Function
End Class
