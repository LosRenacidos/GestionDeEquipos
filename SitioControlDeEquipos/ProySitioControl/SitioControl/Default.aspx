<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SitioControl._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
                <h2>Proyecto - Sistema de Gestión de Equipos de Cómputo.</h2>
            </hgroup>
            <p>
                El siguiente proyecto tiene como objetivo el desarrollo de un sistema sostenible para los requerimientos previamente detectadas y analizados en la gestión de equipos de cómputo.
                
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>&nbsp;Información :</h3>
    <ol class="round">
        <li class="one">
            <h5>Datos generales</h5>
            Equipo: Los Renacidos<br>
             Proyecto: Gestión de equipos de computo<br>
            Repositorio: [URL del Repositorio de Código]<br>
        </li>
        <li class="two">
            <h5>Integrantes</h5>
            Angel Gutierrez - U201423065<br>
        Javier Bellido -  U201419805<br>
        Luis Ramos -  U201421444<br>
        Paul Angulo -<br>
        Yuri Mateo - U201420476<br>
    
        </li>
        <li class="three">
            <h5>Datos del curso</h5>
           Ciclo: 2016-0<br>
        Sección: A61B<br>
        Profesor: Héctor Saira
        </li>
    </ol>
</asp:Content>
