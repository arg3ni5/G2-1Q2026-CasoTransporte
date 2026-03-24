Imports System.Web.Script.Serialization

Public Module SwalUtils

    Private Function ToJson(value As String) As String
        Dim serializer As New JavaScriptSerializer()
        Return serializer.Serialize(value)
    End Function

    Public Sub ShowSwalMessage(page As System.Web.UI.Page, title As String, message As String, icon As String)

        Dim script As String = $"Swal.fire({{
                title: {ToJson(title)},
                text: {ToJson(message)},
                icon: {ToJson(icon)}
            }});"

        ScriptManager.RegisterStartupScript(
            page,
            page.GetType(),
            Guid.NewGuid().ToString(),
            script,
            True
        )
    End Sub

    Public Sub ShowSwalError(page As System.Web.UI.Page, title As String, message As String)
        ShowSwalMessage(page, title, message, "error")
    End Sub

    Public Sub ShowSwalError(page As System.Web.UI.Page, message As String)
        ShowSwalMessage(page, "Error", message, "error")
    End Sub

    Public Sub ShowSwal(page As System.Web.UI.Page,
                        title As String,
                        Optional message As String = "",
                        Optional icon As String = "success")

        ShowSwalMessage(page, title, message, icon)
    End Sub

End Module
