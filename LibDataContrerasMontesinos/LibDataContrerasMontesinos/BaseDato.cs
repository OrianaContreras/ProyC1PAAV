using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibNegContrerasMontesinos;

namespace LibDataContrerasMontesinos
{
    public class BaseDato
    {
        private string strConn = ConfigurationManager.AppSettings["strConexion"];

        #region
        public Inventario ingresar(Inventario objInventario)
        {

            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Connection = new SqlConnection(strConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_ingresar";

                cmd.Parameters.Add("@codigo", SqlDbType.Int).Value = objInventario.Codigo;
                cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = objInventario.Fecha;
                cmd.Parameters.Add("@seccion", SqlDbType.Int).Value = objInventario.Seccion;
                cmd.Parameters.Add("@nombreArticulo", SqlDbType.VarChar, 50).Value = objInventario.NombreArticulo;
                cmd.Parameters.Add("@estado", SqlDbType.VarChar, 20).Value = objInventario.Estado;
                cmd.Parameters.Add("@etiquetado", SqlDbType.Bit).Value = objInventario.Etiquetado;
                cmd.Parameters.Add("@realizadoPor", SqlDbType.VarChar, 50).Value = objInventario.RealizadoPor;
                cmd.Parameters.Add("@eliminado", SqlDbType.Bit).Value = objInventario.Eliminado;

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                //objInventario.EsExito = true;
            }
            catch (SqlException ex)
            {
                //objInventario.Mensaje = "Excepcion Capturada: {0} " + ex.ToString();
                //objInventario.EsExito = false;
            }
            return objInventario;
        }// fin ingresar


        #endregion

    }
}
