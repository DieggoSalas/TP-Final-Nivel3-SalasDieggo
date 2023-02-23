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
                <img src="<%: art.ImagenUrl %>" class="card-img-top" alt="https://coffeesearch.guatemalancoffees.com//uploads/coverPhoto.png" width="200px" height="200px">
                <div class="card-body">
                    <h5 class="card-title"><%: art.Nombre %></h5>
                    <p class="card-text"><%: art.Marca.Descripcion %></p>
                </div>
            </div>
        </div>
        <%} %>
    </div>
</asp:Content>
