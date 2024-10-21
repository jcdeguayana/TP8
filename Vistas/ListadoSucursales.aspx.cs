using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
namespace Vistas
{
    public partial class ListadoSucursales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string consulta = "SELECT Sucursal.Id_Sucursal,Sucursal.NombreSucursal,Sucursal.DescripcionSucursal,Provincia.DescripcionProvincia,Sucursal.DireccionSucursal FROM Sucursal INNER JOIN Provincia ON Sucursal.Id_ProvinciaSucursal = Provincia.Id_Provincia;";
                GestionSucursal cn = new GestionSucursal();
                cn.cargarGrid(consulta,grdSucursales);
            }
        }

        protected void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            string consulta = "SELECT Sucursal.Id_Sucursal,Sucursal.NombreSucursal,Sucursal.DescripcionSucursal,Provincia.DescripcionProvincia,Sucursal.DireccionSucursal FROM Sucursal INNER JOIN Provincia ON Sucursal.Id_ProvinciaSucursal = Provincia.Id_Provincia;";
            GestionSucursal cn = new GestionSucursal();
            cn.cargarGrid(consulta, grdSucursales);
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            GestionSucursal negocio = new GestionSucursal();
            negocio.cargarGrid("SELECT Id_Sucursal, NombreSucursal, DescripcionSucursal, Provincia.DescripcionProvincia, DireccionSucursal  FROM Sucursal INNER JOIN Provincia ON Sucursal.Id_ProvinciaSucursal = Provincia.Id_Provincia WHERE Id_Sucursal = '" + txtSucursal.Text + "'", grdSucursales);
            txtSucursal.Text = "";
        }
    }
}