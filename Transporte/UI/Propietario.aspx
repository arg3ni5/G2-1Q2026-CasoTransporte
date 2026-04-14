<%@ Page Title="Propietario" Language="vb" AutoEventWireup="false"
    MasterPageFile="~/Site.Master"
    Codefile="Propietario.aspx.vb"
    Inherits="Propietario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- IdPersona -->
    <div class="form-group">
        <asp:Label ID="lblIdPersona" runat="server" Text="Identificación:" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="txtIdPersona" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <asp:RequiredFieldValidator ID="rfvIdPersona" runat="server"
        CssClass="text-danger"
        ControlToValidate="txtIdPersona"
        ErrorMessage="Es necesario indicar su identificación" />

    <!-- Telefono -->
    <div class="form-group">
        <asp:Label ID="lblTelefono" runat="server" Text="Telefono" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <asp:RequiredFieldValidator ID="rfvTelefono" runat="server"
        CssClass="text-danger"
        ControlToValidate="txtTelefono"
        ErrorMessage="Es necesario indicar el telefono" />

    <!-- Direccion -->
    <div class="form-group">
        <asp:Label ID="lblDireccion" runat="server" Text="Dirección:" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
    </div>

    <asp:RequiredFieldValidator ID="rfvDireccion" runat="server"
        CssClass="text-danger"
        ControlToValidate="txtDireccion"
        ErrorMessage="Es necesario indicar una dirección" />

    <asp:HiddenField ID="hfIdPersona" runat="server" />

    <div class="py-3">
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-warning" OnClick="btnActualizar_Click" Visible="false" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick="btnCancelar_Click" Visible="false" />
    </div>

    <asp:Label ID="lblMensaje" runat="server" CssClass="text-success"></asp:Label>

    <!-- GRID -->
    <asp:GridView ID="gvPropietario" runat="server"
        AutoGenerateColumns="False"
        DataKeyNames="IdPersona"
        DataSourceID="SqlDataSource1"
        OnSelectedIndexChanged="gvPropietario_SelectedIndexChanged"
        OnRowDeleting="gvPropietario_RowDeleting"
        CssClass="table table-striped">

        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="IdPersona" HeaderText="IdPersona" ReadOnly="True" />
            <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
            <asp:BoundField DataField="Direccion" HeaderText="Direccion" />
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server"
        ConnectionString="<%$ ConnectionStrings:TransporteDBConnectionString %>"
        SelectCommand="SELECT * FROM Personas">
    </asp:SqlDataSource>

</asp:Content>