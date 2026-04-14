Imports System.Data
Imports System.Data.SqlClient
Imports Transporte.Utils

Public Class TipoMultaDB
    Private helper As New DbHelper()

    ' Listar todos los tipos de multa
    Public Function ListarTiposMulta() As DataTable
        Dim sql As String = "SELECT * FROM TipoMulta"
        Return helper.ExecuteQuery(sql, Nothing)
    End Function

    ' Insertar nuevo tipo de multa
    Public Sub InsertarTipoMulta(descripcion As String, monto As Decimal, activa As Boolean)
        Dim sql As String = "
INSERT INTO TipoMulta (Descripcion, MontoBase, Activa)
VALUES (@Descripcion, @Monto, @Activa)"
        Dim params As New List(Of SqlParameter) From {
            New SqlParameter("@Descripcion", descripcion),
            New SqlParameter("@Monto", monto),
            New SqlParameter("@Activa", activa)
        }
        helper.ExecuteNonQuery(sql, params)
    End Sub

    ' Eliminar tipo de multa con control de FK
    Public Function EliminarTipoMultaSeguro(id As Integer, ByRef mensaje As String) As Boolean
        Try
            Dim sql As String = "DELETE FROM TipoMulta WHERE IdTipoMulta = @Id"
            Dim params As New List(Of SqlParameter) From {
                New SqlParameter("@Id", id)
            }
            Dim filas As Integer = helper.ExecuteNonQuery(sql, params)
            If filas > 0 Then
                mensaje = "Tipo de multa eliminado correctamente."
                Return True
            Else
                mensaje = "No se encontró el tipo de multa."
                Return False
            End If
        Catch ex As SqlException
            If ex.Number = 547 Then
                mensaje = "No se puede eliminar este tipo de multa porque ya está relacionada con otros registros."
            Else
                mensaje = "Error al eliminar el tipo de multa: " & ex.Message
            End If
            Return False
        End Try
    End Function

End Class
