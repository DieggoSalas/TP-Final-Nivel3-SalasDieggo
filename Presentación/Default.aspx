<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Presentación.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Hola Mundo</h1>
    <div class="row row-cols-1 row-cols-md-3 g-4">
        <% foreach (Clases.Articulo art in Lista)
            {%>
        <div class="col">
            <div class="card h-100">
                <div>
                    <img src="<%: art.ImagenUrl %>" class="img-fluid" alt="https://coffeesearch.guatemalancoffees.com//uploads/coverPhoto.png" width="200px" height="200px">
                </div>
                <div class="card-body">
                    <h5 class="card-title"><%: art.Nombre %></h5>
                    <button type="button" class="btn btn-warning" data-bs-toggle="modal" data-bs-target="#ModalDetalle"></button>
                </div>
            </div>
        </div>
        <%} %>
    </div>
    <!-- Modal "Detalle"-->
<div class="modal fade" id="ModalDetalle" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable">
    <div class="modal-content">
      <div class="modal-header">
        <h1 class="modal-title fs-5" id="exampleModalLabel">Detalles del Producto</h1>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body">
        ...
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-primary" data-bs-dismiss="modal">Cerrar</button>
        <!--<button type="button" class="btn btn-primary">Save changes</button>-->
      </div>
    </div>
  </div>
</div>
</asp:Content>
