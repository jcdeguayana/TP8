using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Dao;

namespace Negocio
{
    public class GestionSucursal
    {
        public GestionSucursal()
        {

        }
        public DropDownList cargarDDL(DropDownList ddlProvincia)
        {
            DaoSucursales datos = new DaoSucursales();
            ddlProvincia = datos.preCargarDDL("SELECT * FROM Provincia", ddlProvincia);
            return ddlProvincia;
        }

        public void cargarGrid(String consulta, GridView gv)
        {
            DaoSucursales datos = new DaoSucursales();
            datos.cargarGrid(consulta, gv);
        }

        public int AgregarSucursal(String nombre, String descripcion, int provincia, String direccion)
        {
            string consulta = "insert into Sucursal(NombreSucursal, DescripcionSucursal, DireccionSucursal, Id_ProvinciaSucursal) " +
            "values('" + nombre + "','" + descripcion + "', '" + direccion + "', " + provincia + ")";

            DaoSucursales datos = new DaoSucursales();
            return datos.Ejecutar(consulta);
        }

        public int EliminarSucursal(int Id_Sucursal)
        {
            string consulta = "DELETE FROM Sucursal WHERE Id_Sucursal=" + Id_Sucursal + "AND Id_Sucursal IS NOT NULL";
            DaoSucursales datos = new DaoSucursales();
            return datos.Ejecutar(consulta);
        }
    }
}
