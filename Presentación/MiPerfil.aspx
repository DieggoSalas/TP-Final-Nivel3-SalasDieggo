<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="Presentación.Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Mi Perfil</h1>
    <div class="row">
        <div class="col-md-4 mx-5">
            <div class="mb-3">
                <label for="lblNombre" class="form-label">Nombre:</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="lblApellido" class="form-label">Apellido:</label>
                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="lblCorreo" class="form-label">Correo:</label>
                <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="lblContra" class="form-label">Contraseña:</label>
                <asp:TextBox ID="txtContra" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:CheckBox ID="chkAdmin" CssClass="form-check-input" runat="server" />
                <label class="form-check-label" for="chkAdmin">Administrador</label>
            </div>
        </div>
        <div class="col-md-4 mx-5">
            <div class="mb-3">
                <label class="form-label">Imagen de perfil:</label>
                <input id="txtImagen" type="file" runat="server" class="form-control">
            </div>
            <asp:Image ID="imgImagen" runat="server" ImageUrl="https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png" CssClass="img-fluid mb-3" />
        </div>
    </div>
    <div class="mb-3">
        <a class="btn btn-secondary" href="Default.aspx">Cancelar</a>
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar Cambios" CssClass="btn btn-primary" OnClick="btnGuardar_Click"/>
    </div>
</asp:Content>
