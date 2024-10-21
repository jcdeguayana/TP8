using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
namespace Vistas
{
    public partial class AgregarSucursal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
                ddlProvincia.Items.Insert(0, new ListItem("--Seleccionar--", "0"));
                GestionSucursal gs = new GestionSucursal();
                gs.cargarDDL(ddlProvincia);
            }

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            int filasAfectadas;
            GestionSucursal negocio = new GestionSucursal();
            int prov = ddlProvincia.SelectedIndex + 1;
            filasAfectadas = negocio.AgregarSucursal(txtSucursal.Text, txtDescripcion.Text, prov, txtDireccion.Text);

            if (filasAfectadas > 0)
            {
                lblMensaje.ForeColor = System.Drawing.Color.Green;
                lblMensaje.Text = "Se agrego correctamente";
            }
            LimpiarCampos();
        }

        void LimpiarCampos()
        {
            txtSucursal.Text = "";
            txtDireccion.Text = "";
            txtDescripcion.Text = "";
        }
    }
}