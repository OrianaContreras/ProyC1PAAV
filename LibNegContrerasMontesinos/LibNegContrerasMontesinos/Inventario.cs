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
        private string _nombreArticulo, _estado, _realizadoPor;
        private DateTime _fecha;
        private string _mensaje;
        private bool _etiquetado, _eliminado;
        private int _id, _codigo, _seccion;
        private DataSet _ds = new DataSet();
        #endregion

        #region propiedades

        public string NombreArticulo { get => _nombreArticulo; set => _nombreArticulo = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public string RealizadoPor { get => _realizadoPor; set => _realizadoPor = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        public string Mensaje { get => _mensaje; set => _mensaje = value; }
        public bool Etiquetado { get => _etiquetado; set => _etiquetado = value; }
        public bool Eliminado { get => _eliminado; set => _eliminado = value; }
        public int Id { get => _id; set => _id = value; }
        public int Codigo { get => _codigo; set => _codigo = value; }
        public int Seccion { get => _seccion; set => _seccion = value; }
        public DataSet Ds { get => _ds; set => _ds = value; }

        #endregion

        #region operaciones
        public Inventario ingresar(Inventario objInventario)
        {
            BaseDato objDB = new BaseDato();
            objInventario = objDB.ingresar(objInventario);
            return objInventario;
        }// fin ingresar

        public Inventario mostrar(Inventario objInventario)
        {
            BaseDato objDB = new BaseDato();
            objInventario = objDB.mostrar(objInventario);
            return objInventario;
        }// fin mostrar
        
        public Inventario modificar(Inventario objInventario)
        {
            BaseDato objDB = new BaseDato();
            objInventario = objDB.modificar(objInventario);
            return objInventario;
        }// fin modificar

        public Inventario eliminar(Inventario objInventario)
        {
            BaseDato objDB = new BaseDato();
            objInventario.Eliminado = true;
            objInventario = objDB.eliminar(objInventario);
            return objInventario;
        }// fin eliminar

        #endregion

        public bool validacionNumeroNegativo(int valor)
        {
            return valor <= 0;
        }

        public bool validacionCampoVacio(string valor)
        {
            return String.IsNullOrEmpty(valor);
        }


    }// Fin Class
}// Fin namesapace
