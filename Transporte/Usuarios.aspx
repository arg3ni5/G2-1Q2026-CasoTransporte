<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Usuarios.aspx.vb" Inherits="Transporte.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <%--USERNAME--%>
    <div class="form form-group">
        <asp:Label ID="LblUsername" runat="server" Text=" Ingrese Username" CssClass="form-label"></asp:Label>
        <asp:TextBox ID="TxtUsername" runat="server" placeholder="Username" CssClass="form-control"></asp:TextBox>
    </div>

    <asp:RequiredFieldValidator
        ID="RequiredFieldValidator1"
        runat="server"
        Display="Dynamic"
        ControlToValidate="TxtUsername"
        ErrorMessage="Username es requerido."></asp:RequiredFieldValidator>

    <%--PASSWORD--%>
    <div class="form form-group">
        <asp:Label ID="LblPassword" runat="server" Text=" Ingrese Password" CssClass="form-label"></asp:Label>
        <asp:TextBox ID="TxtPassword" runat="server" placeholder="Password" CssClass="form-control"></asp:TextBox>
    </div>

    
    <asp:RequiredFieldValidator
        ID="RequiredFieldValidator2"
        runat="server"
        Display="Dynamic"
        ControlToValidate="TxtPassword"
        ErrorMessage="Password es requerido."></asp:RequiredFieldValidator>

    <%--ROL--%>
    <div class="form form-group">
        <asp:Label ID="LblRol" runat="server" Text="Seleccione Rol" CssClass="form-label"></asp:Label>
        <asp:DropDownList ID="DdlRol" runat="server" CssClass="form-control">
            <asp:ListItem Value="Admin">Admin</asp:ListItem>
            <asp:ListItem Value="User">User</asp:ListItem>
        </asp:DropDownList>

   </div>
     <asp:RequiredFieldValidator
     ID="RequiredFieldValidator3"
     runat="server"
     Display="Dynamic"
     ControlToValidate="TxtPassword"
     ErrorMessage="Password es requerido."></asp:RequiredFieldValidator>

    <%--BTN GUARDAR--%>
    <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" OnClick="Button1_Click" CssClass="btn btn-primary"/>


    <asp:GridView ID="GridView1" runat="server"></asp:GridView>

</asp:Content>
