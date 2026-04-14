Imports System.Data
Imports System.Data.SqlClient


Public Class MultaDB

    Private _helper As New MultaDB()

    Public Function ListarVehiculos() As DataTable
        Return _helper.ExecuteQuery(
            "SELECT IdVehiculo, Placa FROM Vehiculos", Nothing)
    End Function

    Private Function ExecuteQuery(v As String, value As Object) As DataTable
        Throw New NotImplementedException()
    End Function

    Public Function ListarTiposMulta() As DataTable
        Return _helper.ExecuteQuery(
            "SELECT IdTipoMulta, Descripcion FROM TipoMulta WHERE Activa = 1", Nothing)
    End Function

    Public Function ListarMultas() As DataTable
        Dim sql As String = "
        SELECT m.IdMulta, v.Placa, t.Descripcion AS TipoMulta, m.Fecha
        FROM Multas m
        INNER JOIN Vehiculos v ON m.IdVehiculo = v.IdVehiculo
        INNER JOIN TipoMulta t ON m.IdTipoMulta = t.IdTipoMulta"
        Return _helper.ExecuteQuery(sql, Nothing)
    End Function

    Public Sub InsertarMulta(idVehiculo As Integer, idTipoMulta As Integer, fecha As Date)
        Dim sql As String = "
        INSERT INTO Multas (IdVehiculo, IdTipoMulta, Fecha)
        VALUES (@v, @t, @f)"

        Dim p As New List(Of SqlParameter) From {
            New SqlParameter("@v", idVehiculo),
            New SqlParameter("@t", idTipoMulta),
            New SqlParameter("@f", fecha)
        }

        _helper.ExecuteNonQuery(sql, p)
    End Sub

    Private Sub ExecuteNonQuery(sql As String, p As List(Of SqlParameter))
        Throw New NotImplementedException()
    End Sub

    Public Sub EliminarMulta(id As Integer)
        Dim sql As String = "DELETE FROM Multas WHERE IdMulta = @id"
        helper.ExecuteNonQuery(sql,
            New List(Of SqlParameter) From {
                New SqlParameter("@id", id)
            })
    End Sub

    Friend Sub InsertarMulta(v1 As Integer, v2 As Integer, [date] As Date)
        Throw New NotImplementedException()
    End Sub
End Class
