<%@ Page Title="Tipos de Multa"
Language="vb"
MasterPageFile="~/Site.Master"
AutoEventWireup="false"
CodeBehind="TipoMulta.aspx.vb"
Inherits="Transporte.TipoMulta" %>



<asp:Content ID="Content1"
    ContentPlaceHolderID="ContentPlaceHolder1"
    runat="server">


    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.0/css/all.min.css" rel="stylesheet" />

    <div class="container mt-5">

        <h2 class="text-center mb-4">Gestión de Tipos de Multa</h2>

        <div class="card shadow mb-4">
            <div class="card-header bg-warning">
                Registrar Tipo de Multa
            </div>

            <div class="card-body">

                <div class="mb-3">
                    <label>Descripción</label>
                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" />
                </div>

                <div class="mb-3">
                    <label>Monto Base</label>
                    <asp:TextBox ID="txtMonto" runat="server" CssClass="form-control" />
                </div>

                <div class="mb-3">
                    <label>Activa</label>
                    <asp:CheckBox ID="chkActiva" runat="server" />
                </div>

                <asp:Button ID="btnGuardar" runat="server"
                    Text="Guardar"
                    CssClass="btn btn-success" />

                <br /><br />
                <asp:Label ID="lblMensaje" runat="server" CssClass="text-success" />

            </div>
        </div>

    </div>

</asp:Content>

