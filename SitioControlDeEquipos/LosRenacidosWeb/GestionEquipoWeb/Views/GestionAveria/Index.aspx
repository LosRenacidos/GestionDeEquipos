<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<GestionEquipoWeb.Models.Averia>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	LosRenacidos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Gestion de Averías</h2>

    <table>
        <tr>
            <th></th>
            <th>
                Codigo
            </th>
            <th>
                Estado
            </th>
            <th>
                FechaRegistro
            </th>
            <th>
                FechaCierre
            </th>
            <th>
                Proveedor
            </th>
            <th>
                CodigoEquipo
            </th>
            <th>
                TecnicoAsignado
            </th>
            <th>
                TipoReparacion
            </th>
            <th>
                Descripcion
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Asignar", "Asignar", new { id=item.Codigo}) %> |
                <%: Html.ActionLink("Confirmar Reparación", "Confirmar", new { id=item.Codigo })%> |
                <%: Html.ActionLink("Cerrar Averia", "Cerrar", new { id=item.Codigo })%>
            </td>
            <td>
                <%: item.Codigo %>
            </td>
            <td>
                <%: item.Estado %>
            </td>
            <td>
                <%: item.FechaRegistro %>
            </td>
            <td>
                <%: item.FechaCierre %>
            </td>
            <td>
                <%: item.Proveedor %>
            </td>
            <td>
                <%: item.CodigoEquipo %>
            </td>
            <td>
                <%: item.TecnicoAsignado %>
            </td>
            <td>
                <%: item.TipoReparacion %>
            </td>
            <td>
                <%: item.Descripcion %>
            </td>
        </tr>
    
    <% } %>

    </table>

 

</asp:Content>

