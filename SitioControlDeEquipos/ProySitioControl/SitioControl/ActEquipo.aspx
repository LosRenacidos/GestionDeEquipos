<%@ Page Title="Actualizar Equipo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ActEquipo.aspx.cs" Inherits="SitioControl.Contact" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1 class="auto-style2">Datos de Equipo de cómputo<br /></h1>  </hgroup >
            &nbsp;&nbsp;&nbsp;&nbsp;<strong><asp:Label ID="lblcreacion" runat="server" style="font-size: medium;font-style :italic; color: #FF0000" Text=""></asp:Label>
            
            </strong>&nbsp;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
            <asp:Button ID="Buscar_equipo" runat="server"  Text="Buscar equipo" Height="39px" Width="124px" OnClick="Buscar_equipo_Click"   /> 
    
                                
            
            <asp:Button ID="Registrar_equipo" runat="server"  Text="Registrar equipo" Height="39px" Width="133px" OnClick="Registrar_equipo_Click"   /> 
    
                                
            
            <br />
            <span class="auto-style1">Codigo de Equipo</span><br class="auto-style1" />
            
            <asp:TextBox ID="codigo_equipo" runat="server" CssClass="auto-style1"></asp:TextBox>
            
            <asp:Label ID="lblbusquedaError" runat="server" style="font-size: medium;font-style :italic; color: #FF0000" Text=""></asp:Label>
            
            <br class="auto-style1" />
            <br class="auto-style1" />
            <span class="auto-style1"><asp:Label ID="lblmarca" runat="server" Text="Marca" visible="false"></asp:Label></span><br class="auto-style1" />
            
            <asp:TextBox ID="marca_equipo" runat="server" CssClass="auto-style1" visible="false" ></asp:TextBox>
            
            <span class="auto-style1">
            <br class="auto-style1" />
            <br class="auto-style1" />
            <asp:Label ID="lblmodelo" runat="server" Text="Modelo" visible="false"></asp:Label><br class="auto-style1" />
            </span>
            
            <asp:TextBox ID="modelo_equipo" runat="server" CssClass="auto-style1" visible="false"></asp:TextBox>
            
            <span class="auto-style1">
            <br class="auto-style1" />
            <br class="auto-style1" />
            <asp:Label ID="lblserie" runat="server" Text="Numero de serie" visible="false"></asp:Label><br class="auto-style1" />
            </span>
            
            <asp:TextBox ID="serie_equipo" runat="server" CssClass="auto-style1" visible="false"></asp:TextBox>
            
            <span class="auto-style1">
            <br class="auto-style1" />
            <br class="auto-style1" />
            <asp:Label ID="lbldescripcion" runat="server" Text="Descripcion" visible="false"></asp:Label><br class="auto-style1" />
            </span>
            
            <asp:TextBox ID="descripcion_equipo" runat="server" CssClass="auto-style1" visible="false"></asp:TextBox>
            
            <span class="auto-style1">
            <br class="auto-style1" />
            <br class="auto-style1" />
            <asp:Label ID="lblresponsable" runat="server" Text="Responsable" visible="false"></asp:Label><br class="auto-style1" />
            </span>
            
            <asp:TextBox ID="responsable_equipo" runat="server" CssClass="auto-style1" visible="false"></asp:TextBox>
            
            <span class="auto-style1">
            <br class="auto-style1" />
            <br class="auto-style1"  />
            <asp:Label ID="lblubicacion" runat="server" Text="Ubicacion" visible="false"></asp:Label>
    <br class="auto-style1" />
            </span>
            
            <asp:TextBox ID="ubicacion_equipo" runat="server" CssClass="auto-style1" visible="false"></asp:TextBox>
            
            <br />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="editar_equipo" runat="server" Height="33px" OnClick="editar_equipo_Click" Text="Editar" Width="103px" visible="false" />
    <asp:Button ID="grabar_equipo" runat="server" Height="33px" OnClick="grabar_equipo_Click" Text="Grabar" Width="103px" visible="false" />
    <br />
            
            <br class="auto-style1" />

            
<%--<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
</asp:Content>--%>
    <style type="text/css">
    .auto-style1 {
        font-size: small;
    }
        .auto-style2 {
            font-size: x-large;
        }
    </style>
</asp:Content>
