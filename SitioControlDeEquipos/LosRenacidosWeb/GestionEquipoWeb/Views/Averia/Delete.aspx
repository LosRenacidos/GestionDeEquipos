<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GestionEquipoWeb.Models.Averia>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	LosRenacidos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Eliminación</h2>

    <h3>Esta seguro(a) de eliminar esta averia?</h3>
    <fieldset>
        <legend>Campos</legend>
        
        <div class="display-label">Codigo</div>
        <div class="display-field"><%: Model.Codigo %></div>
        
        <div class="display-label">Estado</div>
        <div class="display-field"><%: Model.Estado %></div>
        
        <div class="display-label">FechaRegistro</div>
        <div class="display-field"><%: Model.FechaRegistro %></div>
        
        <div class="display-label">FechaCierre</div>
        <div class="display-field"><%: Model.FechaCierre %></div>
        
        <div class="display-label">Proveedor</div>
        <div class="display-field"><%: Model.Proveedor %></div>
        
        <div class="display-label">CodigoEquipo</div>
        <div class="display-field"><%: Model.CodigoEquipo %></div>
        
        <div class="display-label">TecnicoAsignado</div>
        <div class="display-field"><%: Model.TecnicoAsignado %></div>
        
        <div class="display-label">TipoReparacion</div>
        <div class="display-field"><%: Model.TipoReparacion %></div>
        
        <div class="display-label">Descripcion</div>
        <div class="display-field"><%: Model.Descripcion %></div>
        
    </fieldset>
    <% using (Html.BeginForm()) { %>
        <p>
		    <input type="submit" value="Eliminar" /> |
		    <%: Html.ActionLink("Regresar a la lista", "Index") %>
        </p>
    <% } %>

</asp:Content>

