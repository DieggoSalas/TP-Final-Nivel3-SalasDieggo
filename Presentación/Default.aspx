<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Presentación.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h1>Hola Mundo</h1>
    <div class="p-3">
        <div class="row row-cols-1 row-cols-md-4 g-3">
            <asp:Repeater ID="RepArticulos" runat="server">
                <ItemTemplate>
                    <div class="col">
                        <div class="card text-bg-dark card h-100">
                            <img src="<%# Eval("ImagenUrl")%>" class="rounded card-img-fluid mx-auto d-block" style="width: 150px; height: 150px;" alt="https://editorial.unc.edu.ar/wp-content/uploads/sites/33/2022/09/placeholder.png">
                                <div class="card-body text-center">
                                    <h5 class="card-title text-center"><%# Eval("Nombre")%></h5>
                                    <asp:UpdatePanel ID="UP1" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btnDetalles" Text="Ver Detalles" runat="server" CssClass="btn btn-warning" data-bs-toggle="modal" data-bs-target="#ModalDetalle" OnClick="btnDetalles_Click" CommandName="ArtId" CommandArgument='<%# Eval("Id")%>' />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    <asp:UpdatePanel ID="UP2" runat="server">
        <ContentTemplate>
        <!-- Modal "Detalle"-->
    <div class="modal fade" id="ModalDetalle" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable">
            <div class="modal-content bg-dark">
                <div class="modal-header border-primary text-light">
                    <h1 class="modal-title fs-5" id="exampleModalLabel">Detalles del Producto</h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body border-primary text-light">
                    <div class="text-center">
                        <asp:Label ID="lblNombre"  runat="server" CssClass="col-form-label-lg text-center pb-2" />
                    </div>
                    <div class="row">
                        <div class="col-6">
                            <div class="mb-3">
                                <asp:Image ID="imgUrl" ImageUrl="imageurl" runat="server" CssClass="img-fluid" />
                            </div>
                        </div>
                        <div class="col-6 pt-3">
                            <div class="mb-3">
                                <asp:Label ID="lblDescripcion" runat="server" CssClass="form-label text-light" />
                            </div>
                            <div class="mb-3">
                                <label>Marca:</label>
                                <asp:Label ID="lblMarca" runat="server" CssClass="form-label" />
                            </div>
                            <div class="mb-3">
                                <label>Categoria:</label>
                                <asp:Label ID="lblCategoria" runat="server" CssClass="form-label" />
                            </div>
                            <div class="mb-3">
                                <label>Precio:</label>
                                <asp:Label ID="lblPrecio" runat="server" CssClass="form-label" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer border-primary">
                    <button type="button" class="btn btn-primary" data-bs-dismiss="modal">Cerrar</button>                                   
                </div>
            </div>
        </div>
    </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <!--Modal Opcional Por si el primero no funciona jaja-->
    <%--<ajaxToolkit:ModalPopupExtender ID="ModalPopup" runat="server" OkControlID="" TargetControlID="" PopupControlID="" BackgroundCssClass=""></ajaxToolkit:ModalPopupExtender>--%>
</asp:Content>
