Imports System.Data
Imports Transporte.Utils



Public Class Usuarios
    Inherits System.Web.UI.Page



    Private usuarioDB As New UsuarioDB()



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarUsuarios()
            BtnModificar.Enabled = False
        End If
    End Sub



    Private Sub CargarUsuarios()
        Dim errorMessage As String = ""
        Dim dt As DataTable = usuarioDB.ListarUsuarios(errorMessage)



        If dt IsNot Nothing Then
            GvUsuarios.DataSource = dt
            GvUsuarios.DataBind()
        Else
            SwalUtils.ShowSwalError(Me, "Error", "No se pudieron cargar los usuarios. " & errorMessage)
        End If
    End Sub



    Protected Sub Button1_Click(sender As Object, e As EventArgs)
        Dim errorMessage As String = ""



        If TxtUsername.Text.Trim() = "" Or TxtPassword.Text.Trim() = "" Or DdlRol.SelectedValue = "" Then
            SwalUtils.ShowSwal(Me, "Atención", "Debe completar Username, Password y Rol.", "warning")
            Return
        End If



        If usuarioDB.ExisteUsername(TxtUsername.Text.Trim(), errorMessage) Then
            SwalUtils.ShowSwal(Me, "Atención", "Ese nombre de usuario ya existe.", "warning")
            Return
        End If



        Dim usuario As New Models.Usuario()
        usuario.IdPersona = 0
        usuario.Username = TxtUsername.Text.Trim()
        usuario.PasswordHash = TxtPassword.Text.Trim()
        usuario.Rol = DdlRol.SelectedValue
        usuario.Activo = ChkActivo.Checked



        Dim creado As Boolean = usuarioDB.CrearUsuario(usuario, errorMessage)



        If creado Then
            LblInformacion.Text = "Usuario creado correctamente."
            SwalUtils.ShowSwal(Me, "Registrado", "Usuario registrado correctamente.", "success")
            CargarUsuarios()
            LimpiarFormulario()
        Else
            SwalUtils.ShowSwalError(Me, "Error", "No se pudo registrar. " & errorMessage)
        End If
    End Sub



    Protected Sub Modificar_Click(sender As Object, e As EventArgs)
        Dim errorMessage As String = ""



        If LblIdPersona.Text.Trim() = "" Then
            SwalUtils.ShowSwal(Me, "Atención", "Debe seleccionar un usuario para modificar.", "warning")
            Return
        End If



        If TxtUsername.Text.Trim() = "" Or TxtPassword.Text.Trim() = "" Or DdlRol.SelectedValue = "" Then
            SwalUtils.ShowSwal(Me, "Atención", "Debe completar Username, Password y Rol.", "warning")
            Return
        End If



        Dim usuario As New Models.Usuario()
        usuario.IdPersona = Convert.ToInt32(LblIdPersona.Text)
        usuario.Username = TxtUsername.Text.Trim()
        usuario.PasswordHash = TxtPassword.Text.Trim()
        usuario.Rol = DdlRol.SelectedValue
        usuario.Activo = ChkActivo.Checked



        Dim actualizado As Boolean = usuarioDB.ActualizarUsuario(usuario, errorMessage)



        If actualizado Then
            SwalUtils.ShowSwal(Me, "Actualizado", "Usuario actualizado correctamente.", "success")
            CargarUsuarios()
            LimpiarFormulario()
        Else
            SwalUtils.ShowSwalError(Me, "Error", "No se pudo actualizar. " & errorMessage)
        End If
    End Sub



    Protected Sub BtnCancelar_Click(sender As Object, e As EventArgs)
        LimpiarFormulario()
    End Sub



    Protected Sub GvUsuarios_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Dim errorMessage As String = ""
        Dim idPersona As Integer = Convert.ToInt32(GvUsuarios.DataKeys(e.RowIndex).Value)



        Dim eliminado As Boolean = usuarioDB.EliminarUsuario(idPersona, errorMessage)



        If eliminado Then
            SwalUtils.ShowSwal(Me, "Eliminado", "Usuario eliminado correctamente.", "success")
            CargarUsuarios()
            LimpiarFormulario()
        Else
            SwalUtils.ShowSwalError(Me, "Error", "No se pudo eliminar. " & errorMessage)
        End If
    End Sub



    Protected Sub GvUsuarios_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim errorMessage As String = ""
        Dim idPersona As Integer = Convert.ToInt32(GvUsuarios.SelectedDataKey.Value)



        Dim dt As DataTable = usuarioDB.ObtenerUsuarioPorId(idPersona, errorMessage)



        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            Dim fila As DataRow = dt.Rows(0)



            LblIdPersona.Text = fila("IdPersona").ToString()
            TxtUsername.Text = fila("Username").ToString()
            TxtPassword.Text = fila("PasswordHash").ToString()
            DdlRol.SelectedValue = fila("Rol").ToString()
            ChkActivo.Checked = Convert.ToBoolean(fila("Activo"))



            BtnModificar.Enabled = True
            BtnGuardar.Enabled = False
        Else
            SwalUtils.ShowSwalError(Me, "Error", "No se pudo cargar el usuario. " & errorMessage)
        End If
    End Sub



    Private Sub LimpiarFormulario()
        LblIdPersona.Text = ""
        TxtUsername.Text = ""
        TxtPassword.Text = ""
        DdlRol.SelectedIndex = 0
        ChkActivo.Checked = True
        LblInformacion.Text = ""



        BtnGuardar.Enabled = True
        BtnModificar.Enabled = False
    End Sub



End Class