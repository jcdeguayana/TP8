using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Dao
{
    public class DaoSucursales
    {
        string Ruta = "Data Source=EXOR9CE\\SQLEXPRESS;Initial Catalog=BDSucursales;Integrated Security=True;";

        public DaoSucursales()
        {
            // TODO: Agregar aquí la lógica del constructor
        }


        public SqlConnection ObtenerConexion()
        {
            SqlConnection cn = new SqlConnection(Ruta);
            try
            {
                cn.Open();
                return cn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public SqlDataAdapter ObtenerAdaptador(String consultaSql)
        {
            SqlDataAdapter adaptador;
            try
            {
                adaptador = new SqlDataAdapter(consultaSql, ObtenerConexion());
                return adaptador;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int EjecutarProcedimientoAlmacenado(SqlCommand Comando, String NombreSP) //comando que recibe tiene los parametros incluidos
        {
            int FilasCambiadas;
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand();
            cmd = Comando;
            cmd.Connection = Conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = NombreSP;
            FilasCambiadas = cmd.ExecuteNonQuery();
            Conexion.Close();
            return FilasCambiadas;
        }

        //public void CargarProvincias(DropDownList ddlProvincia)
        //{
        //    SqlConnection conexion3 = new SqlConnection(Ruta);
        //    conexion3.Open();
        //    SqlDataAdapter adaptador = new SqlDataAdapter("Select * from Provincia", conexion3);

        //    DataSet ds = new DataSet();

        //    adaptador.Fill(ds, "Provincia");

        //    foreach (DataRow dr in ds.Tables["Provincia"].Rows)
        //    {
        //        ddlProvincia.Items.Add(dr["Id_Provincia"] + "- " + dr["DescripcionProvincia"]);
        //    }

        //    conexion3.Close();
        //}

        public DropDownList preCargarDDL(String consulta, DropDownList ddlACargar)
        {
            SqlConnection Conexion = ObtenerConexion();

            SqlCommand comando = new SqlCommand();
            comando.CommandText = consulta;
            comando.Connection = Conexion;

            SqlDataReader lector = comando.ExecuteReader();

            ddlACargar.DataSource = lector;
            ddlACargar.DataTextField = "DescripcionProvincia";
            ddlACargar.DataValueField = "Id_Provincia";

            ddlACargar.DataBind();

            Conexion.Close();

            return ddlACargar;
        }

        //public void CargarGrilla(GridView gridView)
        //{
        //    using (SqlConnection cn = new SqlConnection(Ruta))
        //    {
        //        cn.Open();
        //        SqlCommand cmd = new SqlCommand("SELECT Sucursal.Id_Sucursal,Sucursal.NombreSucursal,Sucursal.DescripcionSucursal,Provincia.DescripcionProvincia,Sucursal.DireccionSucursal FROM Sucursal INNER JOIN Provincia ON Sucursal.Id_ProvinciaSucursal = Provincia.Id_Provincia;", cn);
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        gridView.DataSource = dr;
        //        gridView.DataBind();
        //        cn.Close();
        //    }
        //}

        public void cargarGrid(string consulta, GridView gv)
        {
            SqlConnection conexion = ObtenerConexion();

            SqlCommand comando = new SqlCommand();
            comando.CommandText = consulta;
            comando.Connection = conexion;

            SqlDataReader lector = comando.ExecuteReader();

            gv.DataSource = lector;
            gv.DataBind();


            conexion.Close();
        }

        public int Ejecutar(string consulta)
        {
            SqlConnection conexion4 = new SqlConnection(Ruta);
            conexion4.Open();

            SqlCommand comando = new SqlCommand(consulta, conexion4);

            int FilasAfectadas = comando.ExecuteNonQuery();

            return FilasAfectadas;
        }

    }
}
