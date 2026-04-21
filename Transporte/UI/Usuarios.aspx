<%@ Page Title="Usuarios" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Usuarios.aspx.vb" Inherits="Transporte.Usuarios" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <div class="row">
            <div class="col-md-5">
                <div class="card shadow">
                    <div class="card-header bg-primary text-white">
                        <h4 class="mb-0">Registro de Usuarios</h4>
                    </div>

                    <div class="card-body">

                        <asp:Label ID="LblIdPersona" runat="server" Visible="false"></asp:Label>



                        <%-- USERNAME --%>
                        <div class="mb-3">
                            <asp:Label ID="LblUsername" runat="server" Text="Ingrese Username" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="TxtUsername" runat="server" placeholder="Username" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator
                                ID="RequiredFieldValidator1"
                                runat="server"
                                ControlToValidate="TxtUsername"
                                ErrorMessage="Username es requerido."
                                CssClass="text-danger"
                                Display="Dynamic">
                            </asp:RequiredFieldValidator>
                        </div>



                        <%-- PASSWORD --%>
                        <div class="mb-3">
                            <asp:Label ID="LblPassword" runat="server" Text="Ingrese Password" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password" placeholder="Password" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator
                                ID="RequiredFieldValidator2"
                                runat="server"
                                ControlToValidate="TxtPassword"
                                ErrorMessage="Password es requerido."
                                CssClass="text-danger"
                                Display="Dynamic">
                            </asp:RequiredFieldValidator>
                        </div>



                        <%-- ROL --%>
                        <div class="mb-3">
                            <asp:Label ID="LblRol" runat="server" Text="Seleccione Rol" CssClass="form-label"></asp:Label>
                            <asp:DropDownList ID="DdlRol" runat="server" CssClass="form-select">
                                <asp:ListItem Text="-- Seleccione un rol --" Value=""></asp:ListItem>
                                <asp:ListItem Text="Admin" Value="Admin"></asp:ListItem>
                                <asp:ListItem Text="User" Value="User"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator
                                ID="RequiredFieldValidator3"
                                runat="server"
                                ControlToValidate="DdlRol"
                                InitialValue=""
                                ErrorMessage="Debe seleccionar un rol."
                                CssClass="text-danger"
                                Display="Dynamic">
                            </asp:RequiredFieldValidator>
                        </div>



                        <%-- ACTIVO --%>
                        <div class="mb-3">
                            <asp:CheckBox ID="ChkActivo" runat="server" Text="Activo" Checked="true" />
                        </div>



                        <%-- BOTONES --%>
                        <div class="mb-3">
                            <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" OnClick="Button1_Click" CssClass="btn btn-primary me-2" />
                            <asp:Button ID="BtnModificar" runat="server" Text="Modificar" OnClick="Modificar_Click" CssClass="btn btn-warning me-2" />
                            <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" OnClick="BtnCancelar_Click" CssClass="btn btn-secondary" CausesValidation="false" />
                        </div>



                        <div class="mb-3">
                            <asp:Label ID="LblInformacion" runat="server" CssClass="fw-bold text-primary"></asp:Label>
                        </div>



                    </div>
                </div>



            </div>



            <div class="col-md-7">



                <div class="card shadow">
                    <div class="card-header bg-dark text-white">
                        <h4 class="mb-0">Lista de Usuarios</h4>
                    </div>



                    <div class="card-body">
                        <asp:GridView ID="GvUsuarios" runat="server"
                            CssClass="table table-bordered table-hover"
                            AutoGenerateColumns="False"
                            DataKeyNames="IdPersona"
                            OnRowDeleting="GvUsuarios_RowDeleting"
                            OnSelectedIndexChanged="GvUsuarios_SelectedIndexChanged">



                            <Columns>
                                <asp:BoundField DataField="IdPersona" HeaderText="ID" ReadOnly="True" />
                                <asp:BoundField DataField="Username" HeaderText="Username" />
                                <asp:BoundField DataField="PasswordHash" HeaderText="Password" />
                                <asp:BoundField DataField="Rol" HeaderText="Rol" />
                                <asp:CheckBoxField DataField="Activo" HeaderText="Activo" />



                                <asp:CommandField ShowSelectButton="True" SelectText="Editar" HeaderText="Editar" />
                                <asp:CommandField ShowDeleteButton="True" DeleteText="Eliminar" HeaderText="Eliminar" />
                            </Columns>



                        </asp:GridView>
                    </div>
                </div>



            </div>
        </div>
    </div>



</asp:Content>
