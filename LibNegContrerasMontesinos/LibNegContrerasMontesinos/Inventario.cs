using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibDataContrerasMontesinos;

namespace LibNegContrerasMontesinos
{
    public class Inventario
    {
        #region atributos
        private string _codigo, _fecha, _seccion, _nombreArticulo, _estado, _etiquetado, _realizadoPor;
        private string _mensaje;
        private int _id;
        private DataSet _ds = new DataSet();

        //private bool _esExito = false;
        #endregion

        #region propiedades

        public string Codigo { get => _codigo; set => _codigo = value; }
        public string Fecha { get => _fecha; set => _fecha = value; }
        public string Seccion { get => _seccion; set => _seccion = value; }
        public string NombreArticulo { get => _nombreArticulo; set => _nombreArticulo = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public string Etiquetado { get => _etiquetado; set => _etiquetado = value; }
        public string RealizadoPor { get => _realizadoPor; set => _realizadoPor = value; }
        public string Mensaje { get => _mensaje; set => _mensaje = value; }
        public int Id { get => _id; set => _id = value; }

        #endregion

        #region operaciones
        public Inventario ingresar(Inventario objInventario)
        {
            BaseDato objDB = new BaseDato();
            objInventario = objDB.ingresar(objInventario);
            return objInventario;
        }// fin ingresar

        //public Inventario mostrar(Inventario objInventario)
        //{
        //    BaseDato objDB = new BaseDato();
        //    objInventario = objDB.mostrar(objInventario);
        //    return objInventario;
        //}// fin mostrar

        //public Inventario eliminar(Inventario objInventario)
        //{
        //    BaseDato objDB = new BaseDato();
        //    objInventario = objDB.eliminar(objInventario);
        //    return objInventario;
        //}// fin eliminar

        //public Inventario modificar(Inventario objInventario)
        //{
        //    BaseDato objDB = new BaseDato();
        //    objInventario = objDB.modificar(objInventario);
        //    return objInventario;
        //}// fin modificar

        #endregion


    }// Fin Class
}// Fin namesapace
