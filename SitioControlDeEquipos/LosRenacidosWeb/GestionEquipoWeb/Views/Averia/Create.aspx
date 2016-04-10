<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GestionEquipoWeb.Models.Averia>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	LosRenacidos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Registrar</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Campos</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Codigo) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Codigo) %>
                <%: Html.ValidationMessageFor(model => model.Codigo) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Estado) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Estado) %>
                <%: Html.ValidationMessageFor(model => model.Estado) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.FechaRegistro) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.FechaRegistro) %>
                <%: Html.ValidationMessageFor(model => model.FechaRegistro) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.FechaCierre) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.FechaCierre) %>
                <%: Html.ValidationMessageFor(model => model.FechaCierre) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Proveedor) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Proveedor) %>
                <%: Html.ValidationMessageFor(model => model.Proveedor) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.CodigoEquipo) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.CodigoEquipo) %>
                <%: Html.ValidationMessageFor(model => model.CodigoEquipo) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.TecnicoAsignado) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.TecnicoAsignado) %>
                <%: Html.ValidationMessageFor(model => model.TecnicoAsignado) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.TipoReparacion) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.TipoReparacion) %>
                <%: Html.ValidationMessageFor(model => model.TipoReparacion) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Descripcion) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Descripcion) %>
                <%: Html.ValidationMessageFor(model => model.Descripcion) %>
            </div>
            
            <p>
                <input type="submit" value="Registrar" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Regresar a la Lista", "Index") %>
    </div>

</asp:Content>

