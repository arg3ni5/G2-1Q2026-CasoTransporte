<%@ Page Title="Propietario" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Propietario.aspx.vb" Inherits="Propietario.Propietario1" %>

<asp:Content ID="Propietario" ContentPlaceHolderID="MainContent" runat="server">


    <%-----IdPersona-----%>
    <div class="form-group">
        <asp:Label ID="lblIdPersona" runat="server" Text="Identificación:" CssClass="control-label"> </asp:Label>
        <asp:TextBox ID="txtIdPersona" runat="server" Text="" placeholder="" CssClass="form-control"></asp:TextBox>
    </div>
    <%--validar idPersona--%>
    <asp:RequiredFieldValidator ID="rfvIdIdPersona" runat="server"
        CssClass="text-danger"
        Display="Dynamic"
        ControlToValidate="txtIdPersona"
        ErrorMessage="Es necesario indicar su identificación"></asp:RequiredFieldValidator>


    <%--Telefono--%>
    <div class="form-group">
        <asp:Label ID="lblTelefono" runat="server" Text="Telefono" CssClass="control-label"> </asp:Label>
        <asp:TextBox ID="txtTelefono" runat="server" placeholder="" CssClass="form-control" TextMode="Number"></asp:TextBox>
    </div>

    <%--Validar telefono--%>
    <asp:RequiredFieldValidator ID="rfvTelefono" runat="server"
        CssClass="text-danger"
        Display="Dynamic"
        ControlToValidate="txtTelefono"
        ErrorMessage="Es necesario indicar el telefono"></asp:RequiredFieldValidator>

    <%--Dirección--%>
    <div class="form-group">
        <asp:Label ID="lblDireccion" runat="server" Text="Dirección:" CssClass="control-label"> </asp:Label>
        <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
    </div>
    <%--Validar Direccion--%>
    <asp:RequiredFieldValidator ID="rfvDireccion" runat="server"
        CssClass="text-danger"
        Display="Dynamic"
        ControlToValidate="txtDireccion"
        ErrorMessage="Es necesario indicar una dirección"></asp:RequiredFieldValidator>


    <asp:HiddenField ID="hfIdPersona" runat="server" />
    <div class="py-3 d-flex gap-2">
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-warning" OnClick="btnActualizar_Click" Visible="false" />
         <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-primary" OnClick="btnCancelar_Click" Visible="false" />
    </div>
    <asp:Label ID="lblMensaje" runat="server" Text="Mensaje" CssClass="d-none"> </asp:Label>
    <div class="table-responsive rounded-3 overflow-hidden border border-secondary bg-dark">
        <asp:GridView ID="gvPropietario" runat="server" AutoGenerateColumns="False" DataKeyNames="IdPersona" DataSourceID="SqlDataSource1" 
            OnSelectedIndexChanged="gvPropietario_SelectedIndexChanged"
            OnRowDeleting="gvPripoetario_RowDeleting"
            CssClass="table table-dark mb-0 table-striped table-hover">
            <Columns>
                <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="btn btn-primary" SelectText="<i class='bi bi-pencil-square'></i>" />
                <asp:BoundField DataField="IdPersona" HeaderText="IdPersona" InsertVisible="False" ReadOnly="True" SortExpression="IdPersona" />
                <asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono" />
                <asp:BoundField DataField="Direcion" HeaderText="Direccion" SortExpression="Direccion" />
                <asp:CommandField ShowDeleteButton="True" ControlStyle-CssClass="btn btn-danger" DeleteText="<i class='bi bi-trash'>" />
            </Columns>
        </asp:GridView>
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TransporteDBConnectionString %>" ProviderName="<%$ ConnectionStrings:TransporteDBConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [IdPersonas] ORDER BY [Telefono]"></asp:SqlDataSource>
</asp:Content>

