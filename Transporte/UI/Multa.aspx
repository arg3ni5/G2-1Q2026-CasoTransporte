<%@ Page Language="vb" MasterPageFile="~/Site.Master"  AutoEventWireup="false" CodeBehind ="~/UI/Multa.aspx.vb" Inherits="Transporte.Multa" %>




<asp:Content ID="Content1"
    ContentPlaceHolderID="ContentPlaceHolder1"
    runat="server">

    <div class="container mt-4">

        <h2 class="text-center mb-4 text-danger">Gestión de Multas</h2>

        <!-- FORMULARIO -->
        <div class="card shadow mb-4">
            <div class="card-header bg-danger text-white">
                Registrar Multa
            </div>

            <div class="card-body">

                <div class="row mb-3">
                    <div class="col-md-6">
                        <label>Tipo de Vehículo</label>
                        <asp:DropDownList ID="ddlVehiculo" runat="server"
                            CssClass="form-select" />
                    </div>

                 <div class="row mb-3">
                    <div class="col-md-6">
                        <label>Num. Placa</label>
                        <asp:TextBox ID="txtPlaca" runat="server"
                            CssClass="form-control" />
                    </div>


                 <div class="row mb-3">
                    <div class="col-md-6">
                        <label>Monto</label>
                        <asp:TextBox ID="txtMonto" runat="server"
                            CssClass="form-control" />
                    </div>


                    <div class="col-md-6">
                        <label>Tipo de Multa</label>
                        <asp:DropDownList ID="ddlTipoMulta" runat="server"
                            CssClass="form-select" />
                    </div>
                </div>

                <div class="mb-3">
                    <label>Fecha</label>
                    <asp:TextBox ID="txtFecha" runat="server"
                        CssClass="form-control"
                        TextMode="Date" />
                </div>

          

                <br /><br />
                <asp:Label ID="lblMensaje" runat="server"
                    CssClass="fw-bold text-success" />

            </div>
        </div>

        <!-- LISTA -->
        <div class="card shadow">
            <div class="card-header bg-dark text-white">
                Multas Registradas
            </div>

            <div class="card-body">
                <asp:GridView ID="gvMultas" runat="server"
                    CssClass="table table-bordered table-striped"
                    AutoGenerateColumns="False"
                    DataKeyNames="IdMulta"
                    OnRowDeleting="gvMultas_RowDeleting">

                    <Columns>
                        <asp:BoundField DataField="IdMulta" HeaderText="ID" />
                        <asp:BoundField DataField="Placa" HeaderText="Vehículo" />
                        <asp:BoundField DataField="TipoMulta" HeaderText="Tipo" />
                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton runat="server"
                                    CommandName="Delete"
                                    CssClass="btn btn-danger btn-sm"
                                    OnClientClick="return confirm('¿Eliminar multa?');">
                                    Eliminar
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                </asp:GridView>
            </div>
        </div>

    </div>

</asp:Content>
