using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
namespace Vistas
{
    public partial class EliminarSucursales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtSucursal.Text, out int id)) 
            {
                int filasAfectadas;
                GestionSucursal gs = new GestionSucursal();
                filasAfectadas = gs.EliminarSucursal(id);

                if (filasAfectadas > 0)
                {
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    lblMensaje.Text = "Sucursal eliminada correctamente.";
                }
                else
                {
                    lblMensaje.Text = "El ID ingresado es inexistente";
                }
                txtSucursal.Text = "";
            }
            else
            {
                lblMensaje.Text = "El valor a ingresar debe ser numérico";
            }
        }
    }
}