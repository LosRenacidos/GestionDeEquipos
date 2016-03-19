using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SitioControl.equiServiciosRef;



namespace SitioControl
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        

       

        protected void Buscar_equipo_Click(object sender, EventArgs e)
        {
            lbldescripcion.Visible = true;
            lblmarca.Visible = true;
            lblmodelo.Visible = true;
            lblresponsable.Visible = true;
            lblserie.Visible = true;
            lblubicacion.Visible = true;
           
            marca_equipo.Visible = true;
            descripcion_equipo.Visible = true;
            modelo_equipo.Visible = true;
            serie_equipo.Visible = true;
            responsable_equipo.Visible = true;
            ubicacion_equipo.Visible = true;
            editar_equipo.Visible = true;
            
                        EquiposClient cliente = new EquiposClient();
            Equipo equipo = new Equipo();
            if (codigo_equipo.Text.Trim() != "")
            {
                equipo = cliente.ObtenerEquipo(int.Parse(codigo_equipo.Text));
              
                marca_equipo.Text = equipo.marca_equipo;
                modelo_equipo.Text = equipo.modelo_equipo;
                descripcion_equipo.Text = equipo.descripcion_equipo;
                serie_equipo.Text = equipo.serie_equipo;
                responsable_equipo.Text = equipo.responsable_equipo;
                ubicacion_equipo.Text = equipo.ubicacion_equipo;
            }

            else
            {
                lblbusquedaError.Text = "Ingrese un codigo de equipo para su busqueda";

            }
        }

       

        protected void Registrar_equipo_Click(object sender, EventArgs e)
        {
            codigo_equipo.Text = "";
            marca_equipo.Text = "";

            descripcion_equipo.Text = "";
            modelo_equipo.Text = "";
            serie_equipo.Text = "";
            responsable_equipo.Text = "";
            ubicacion_equipo.Text = "";
            Registrar_equipo.Visible = false;
            lbldescripcion.Visible = true;
            lblmarca.Visible = true;
            lblmodelo.Visible = true;
            lblresponsable.Visible = true;
            lblserie.Visible = true;
            lblubicacion.Visible = true;
            lblbusquedaError.Visible = false;
            marca_equipo.Visible = true;
            descripcion_equipo.Visible = true;
            modelo_equipo.Visible = true;
            serie_equipo.Visible = true;
            editar_equipo.Visible = false;
            responsable_equipo.Visible = true;
            ubicacion_equipo.Visible = true;
            Buscar_equipo.Visible = false;
            lblcreacion.Text = "Por favor ingresar los datos para registrar";
            grabar_equipo.Visible = true;
        }

       

        protected void grabar_equipo_Click(object sender, EventArgs e)
        {

            try { 
            EquiposClient cliente = new EquiposClient();
            Equipo equipo = new Equipo();
            equipo.codigo_equipo = int.Parse(codigo_equipo.Text);
            equipo.marca_equipo = marca_equipo.Text;
            equipo.modelo_equipo = modelo_equipo.Text;
            equipo.descripcion_equipo = descripcion_equipo.Text;
            equipo.serie_equipo = serie_equipo.Text;
            equipo.responsable_equipo = responsable_equipo.Text;
            equipo.ubicacion_equipo = ubicacion_equipo.Text;
            lblbusquedaError.Visible = true;
       
            codigo_equipo.Text = "";
            marca_equipo.Text = "";

            descripcion_equipo.Text = "";
            modelo_equipo.Text = "";
            serie_equipo.Text = "";
            responsable_equipo.Text = "";
            ubicacion_equipo.Text = "";

            cliente.CrearEquipo(equipo);
                }
            catch
            {

                lblbusquedaError.Text = "No se puedo registrar, el codigo de equipo ya se encuentra registrado ...";
            }
        }

        protected void editar_equipo_Click(object sender, EventArgs e)
        {
            
            
            EquiposClient cliente = new EquiposClient();
            Equipo equipo = new Equipo();
            equipo.codigo_equipo = int.Parse(codigo_equipo.Text);
          
            equipo.marca_equipo = marca_equipo.Text;
            equipo.modelo_equipo = modelo_equipo.Text;
            equipo.descripcion_equipo = descripcion_equipo.Text;
            equipo.serie_equipo = serie_equipo.Text;
            equipo.responsable_equipo = responsable_equipo.Text;
            equipo.ubicacion_equipo = ubicacion_equipo.Text;
            lblbusquedaError.Visible = true;
            lblbusquedaError.Text = "Se realizo la modificacion...";
            codigo_equipo.Text = "";
            marca_equipo.Text = "";

            descripcion_equipo.Text = "";
            modelo_equipo.Text = "";
            serie_equipo.Text = "";
            responsable_equipo.Text = "";
            ubicacion_equipo.Text = "";
            

           cliente.ModificarEquipo(equipo);
        }
}
}