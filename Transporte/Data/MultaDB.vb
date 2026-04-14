Imports System.Data
Imports System.Data.SqlClient
Imports Transporte.Utils

Public Class MultaDB
    Private helper As New DbHelper()


    ' Listar todas las multas
    Public Function ListarMultas() As DataTable
        Dim sql As String = "
SELECT 
    m.IdMulta,
    v.Placa,
    p.NombreCompleto AS Propietario,
    tm.Descripcion AS TipoMulta,
    tm.MontoBase,
    m.Fecha,
    m.Pagada
FROM Multas m
INNER JOIN Vehiculos v ON m.IdVehiculo = v.IdVehiculo
INNER JOIN Propietarios pr ON v.IdPropietario = pr.IdPersona
INNER JOIN Personas p ON pr.IdPersona = p.IdPersona
INNER JOIN TipoMulta tm ON m.IdTipoMulta = tm.IdTipoMulta"
        Return helper.ExecuteQuery(sql, Nothing)
    End Function

    ' Listar vehículos para dropdown
    Public Function ListarVehiculos() As DataTable
        Dim sql As String = "SELECT IdVehiculo, Placa FROM Vehiculos"
        Return helper.ExecuteQuery(sql, Nothing)
    End Function

    ' Listar tipos de multa activos para dropdown
    Public Function ListarTiposMulta() As DataTable
        Dim sql As String = "SELECT IdTipoMulta, Descripcion FROM TipoMulta WHERE Activa = 1"
        Return helper.ExecuteQuery(sql, Nothing)
    End Function

    ' Insertar nueva multa
    Public Sub InsertarMulta(idVehiculo As Integer, idTipoMulta As Integer, fecha As Date)
        Dim sql As String = "
INSERT INTO Multas (IdVehiculo, IdTipoMulta, Fecha, Pagada)
VALUES (@Vehiculo, @Tipo, @Fecha, 0)"
        Dim params As New List(Of SqlParameter) From {
            New SqlParameter("@Vehiculo", idVehiculo),
            New SqlParameter("@Tipo", idTipoMulta),
            New SqlParameter("@Fecha", fecha)
        }
        helper.ExecuteNonQuery(sql, params)
    End Sub

    ' Eliminar multa con control de FK
    Public Function EliminarMultaSeguro(id As Integer, ByRef mensaje As String) As Boolean
        Try
            Dim sql As String = "DELETE FROM Multas WHERE IdMulta = @Id"
            Dim params As New List(Of SqlParameter) From {
                New SqlParameter("@Id", id)
            }
            helper.ExecuteNonQuery(sql, params)
            helper.ExecuteNonQuery(sql, params)
            mensaje = "Multa eliminada exitosamente."
            Return True
        Catch ex As SqlException
            If ex.Number = 547 Then
                mensaje = "No se puede eliminar esta multa porque ya está relacionada con otros registros."
            Else
                mensaje = "Error al eliminar: " & ex.Message
            End If
            Return False
        End Try
    End Function

End Class
