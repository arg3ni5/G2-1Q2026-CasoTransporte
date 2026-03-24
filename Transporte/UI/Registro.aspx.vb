Public Class Registro
    Inherits System.Web.UI.Page

    Private dbPersona As New PersonaDB()
    Private dbUsuario As New UsuarioDB()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnRegistrar_Click(sender As Object, e As EventArgs)
        Dim persona As New Persona()
        Dim usuario As New Usuario()

        persona.NombreCompleto = txtNombre.Text
        persona.Identificacion = txtIdentificacion.Text
        persona.Correo = txtEmail.Text
        usuario.Username = txtUsername.Text

        Dim encryptor As New Simple3Des("your-encryption-key")
        usuario.PasswordHash = encryptor.EncryptData(txtPass.Text)

        usuario.Rol = ddlRol.SelectedValue
        usuario.Activo = True

        Dim errorMessage As String = String.Empty

        If dbPersona.CrearPersona(persona, errorMessage) Then
            If dbUsuario.CrearUsuario(usuario, errorMessage) Then
                SwalUtils.ShowSwal(Me, "Registro exitoso", "El usuario ha sido registrado correctamente.")
                ClearForm()
            Else
                SwalUtils.ShowSwalError(Me, "Error al registrar usuario", errorMessage)
            End If
        Else
            SwalUtils.ShowSwalError(Me, "Error al registrar persona", errorMessage)
        End If
    End Sub

    Private Sub ClearForm()
        txtNombre.Text = String.Empty
        txtIdentificacion.Text = String.Empty
        txtEmail.Text = String.Empty
        txtUsername.Text = String.Empty
        txtPass.Text = String.Empty
        ddlRol.SelectedIndex = 0
    End Sub
End Class