Public Class SiteMaster
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("Usuario") IsNot Nothing Then
            lblUsuario.Text = Session("Usuario").ToString()
        End If
    End Sub

    Protected Sub btnSalir_Click(sender As Object, e As EventArgs)
        Session.Clear()
        Session.Abandon()
        Response.Redirect("~/Login.aspx")
    End Sub

End Class