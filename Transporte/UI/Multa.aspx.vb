


Public Class Multa
    Inherits System.Web.UI.Page

    Private db As New MultaDB()



    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarVehiculos()
            CargarTiposMulta()
            CargarMultas()
        End If
    End Sub

    Private Sub CargarVehiculos()

        ddlVehiculo.DataTextField = "Placa"
        ddlVehiculo.DataValueField = "IdVehiculo"
        ddlVehiculo.DataBind()
    End Sub

    Private Sub CargarTiposMulta()

        ddlTipoMulta.DataTextField = "Descripcion"
        ddlTipoMulta.DataValueField = "IdTipoMulta"
        ddlTipoMulta.DataBind()
    End Sub

    Private Sub CargarMultas()
        gvMultas.DataBind()
    End Sub



    Protected Sub gvMultas_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        db.EliminarMulta(CInt(gvMultas.DataKeys(e.RowIndex).Value))
        CargarMultas()
    End Sub

End Class
