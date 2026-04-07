Public Class PersonaDB
    Private db As New DbHelper()
    'Crear Persona
    Public Function CrearPersona(ByVal pPersona As Models.Persona, ByRef errorMessage As String) As Integer
        'Lógica para crear una nueva persona en la base de datos
        Using db.GetConnection()
            Dim query As String = "INSERT INTO Personas (Identificacion, NombreCompleto, Correo) 
            VALUES (@Identificacion, @NombreCompleto, @Correo); SELECT SCOPE_IDENTITY()"


            Dim parameters As New Dictionary(Of String, Object) From {
              {"@Identificacion", pPersona.Identificacion},
              {"@NombreCompleto", pPersona.NombreCompleto},
              {"@Correo", pPersona.Correo}
            }

            Return Int32.Parse(db.ExecuteScalar(query, parameters, errorMessage))
        End Using
        Return True
    End Function
End Class
