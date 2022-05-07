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

                //cmd.Parameters.Add("@rut", SqlDbType.VarChar, 12).Value = objInventario.Rut;
                //cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 20).Value = objInventario.Nombre;
                //cmd.Parameters.Add("@apPaterno", SqlDbType.VarChar, 20).Value = objInventario.ApPaterno;
                //cmd.Parameters.Add("@apMaterno", SqlDbType.VarChar, 20).Value = objInventario.ApMaterno;
                //cmd.Parameters.Add("@edad", SqlDbType.Int).Value = objInventario.Edad;
                //cmd.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = objInventario.Direccion;
                //cmd.Parameters.Add("@fono", SqlDbType.VarChar, 20).Value = objInventario.Fono;
                //cmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = objInventario.Email;

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
