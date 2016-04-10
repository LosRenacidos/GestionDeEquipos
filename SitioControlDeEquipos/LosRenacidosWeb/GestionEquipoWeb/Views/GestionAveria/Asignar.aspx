<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GestionEquipoWeb.Models.Averia>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Asignar
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Asignar</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Campos</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Codigo) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Codigo) %>
               
            </div>
              
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Proveedor) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Proveedor) %>
                <%: Html.ValidationMessageFor(model => model.Proveedor) %>
            </div>        
          
            <p>
                <input type="submit" value="Aceptar" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Regresar a la lista", "Index") %>
    </div>

</asp:Content>
