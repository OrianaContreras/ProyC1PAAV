using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibNegContrerasMontesinos;

namespace MantC1PAAContrerasMontesisnos
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                int op = 0;
                do
                {
                    menu();
                    op = int.Parse(Console.ReadLine());
                    if (!(op > 0 && op < 6))
                    {
                        Console.WriteLine("\nDebe ingresar una opción válida ");
                        pausa();
                    }
                } while (!(op > 0 && op < 6));

                switch (op)
                {
                    case 1:
                        ingresar();
                        break;
                    case 2:
                        mostrar();
                        break;
                    case 3:
                        modificar();
                        break;
                    case 4:
                        eliminar();
                        break;
                    case 5:
                        Console.WriteLine("Muchas gracias por utilizar \"Nuestros Servicios de Inventario\"");
                        break;
                    default:
                        Console.WriteLine("No es una opción válida");
                        break;
                }// fin switch

            } while (true);
        }// fin main

        public static void menu()
        {
            Console.WriteLine("Menú Inventario");
            Console.WriteLine("===============");
            Console.WriteLine("1.- Ingresar");
            Console.WriteLine("2.- Mostrar");
            Console.WriteLine("3.- Modificar");
            Console.WriteLine("4.- Eliminar");
            Console.WriteLine("5.- Salir");
            Console.Write("\nIngrese opcion [1-5]: ");
        }// fin menu

        public static void pausa()
        {
            Console.WriteLine("\n\n\nPresione una tecla para continuar....");
            Console.ReadKey();
            Console.Clear();
        }// fin pausa

        public static void ingresar()
        {
            bool esExito = false;
            Inventario objInventario = new Inventario();

            Console.WriteLine("Ingreso de Registo al Inventario:");
            Console.WriteLine("=======================");
            Console.Write("Ingrese Código      : ");
            objInventario.Codigo = obtenerNumero();
            //Console.Write("Ingrese Fecha   : ");
            //string fecha = Console.ReadLine();
            objInventario.Fecha = DateTime.Now;
            Console.Write("Ingrese Sección: ");
            objInventario.Seccion = obtenerNumero();
            Console.Write("Ingrese Nombre Artículo: ");
            objInventario.NombreArticulo = Console.ReadLine();
            Console.Write("Ingrese Estado     : ");
            objInventario.Estado = Console.ReadLine();
            Console.Write("Ingrese Etiquetado: ");
            bool etiquetado = obtenerBool();
            objInventario.Etiquetado = etiquetado;
            Console.Write("Ingrese Realizado Por     : ");
            objInventario.RealizadoPor = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Mostrando Datos de Registro");
            Console.WriteLine("========================");
            Console.WriteLine("Código        : {0}", objInventario.Codigo);
            Console.WriteLine("Fecha     : {0}", objInventario.Fecha);
            Console.WriteLine("Sección: {0}", objInventario.Seccion);
            Console.WriteLine("Nombre Artículo: {0}", objInventario.NombreArticulo);
            Console.WriteLine("Estado       : {0}", objInventario.Estado);
            Console.WriteLine("Etiquetado  : {0}", objInventario.Etiquetado);
            Console.WriteLine("Realizado Por       : {0}", objInventario.RealizadoPor);

            //Console.Write("\nLos datos mostrados son correctos? [S/N]: ");
            //string resp = Console.ReadLine();

            //if (resp.Equals("S") || resp.Equals("s"))
            //{
            //    Console.WriteLine("Continuamos con el Ingreso de Datos en la Base de Datos");
            //}
            //else
            //{
            //    Console.WriteLine("Reingreso Datos Contacto");
            //    Console.WriteLine("=======================");
            //    Console.WriteLine("Por favor indique cuales desea modificar:");
            //    if (true)
            //    {
            //        Console.Write("Ingrese Codigo      : ");
            //        objInventario.Codigo = Console.ReadLine();

            //    }
            //    else if (true)
            //    {
            //        Console.Write("Ingrese Fecha   : ");
            //        objInventario.Fecha = Console.ReadLine();
            //    }
            //    else if (true)
            //    {
            //        Console.Write("Ingrese Seccion: ");
            //        objInventario.Seccion = Console.ReadLine();
            //    }
            //    else if (true)
            //    {
            //        Console.Write("Ingrese NombreArticulo: ");
            //        objInventario.NombreArticulo = Console.ReadLine();
            //    }
            //    else if (true)
            //    {
            //        Console.Write("Ingrese Etiquetado: ");
            //        objInventario.Etiquetado = Console.ReadLine();
            //    }
            //    else if (true)
            //    {
            //        Console.Write("Ingrese Estado     : ");
            //        objInventario.Estado = int.Parse(Console.ReadLine());
            //    }
            //    else if (true)
            //    {
            //        Console.Write("Ingrese RealizadoPor     : ");
            //        objInventario.RealizadoPor = Console.ReadLine();
            //    }
            //    else
            //    {
            //        Console.Write("Ingrese correo   : ");
            //        objInventario.Email = Console.ReadLine();
            //    }

            //    Console.Clear();
            //    Console.WriteLine("Mostrando Datos Contacto");
            //    Console.WriteLine("========================");
            //    Console.WriteLine("Codigo        : {0}", objInventario.Codigo);
            //    Console.WriteLine("Fecha     : {0}", objInventario.Fecha);
            //    Console.WriteLine("Ap. Paterno: {0}", objInventario.Seccion);
            //    Console.WriteLine("Ap. Materno: {0}", objInventario.NombreArticulo);
            //    Console.WriteLine("Etiquetado  : {0}", objInventario.Etiquetado);
            //    Console.WriteLine("Estado       : {0}", objInventario.Estado);
            //    Console.WriteLine("RealizadoPor       : {0}", objInventario.RealizadoPor);

            //    Console.Write("\nLos datos mostrados son correctos? [S/N]: ");
            //    // string resp = Console.ReadLine();

            //}
            //pausa();

            objInventario = objInventario.ingresar(objInventario);

            //if (objInventario.EsExito)
            //{
            //    Console.WriteLine("Los Datos fueron ingresados correctamente........");
            //}
            //else
            //{
            //    Console.WriteLine("E R R O R Datos no ingresados. !!!!!!!!!");
            //}
        }

        public static void mostrar()
        {
            DataSet ds = new DataSet();
            Inventario objInventario = new Inventario();

            Console.WriteLine("Ingrese Código");
            objInventario.Codigo = int.Parse(Console.ReadLine());

            objInventario = objInventario.mostrar(objInventario);

            Console.WriteLine("Mostrando XML: {0} ", objInventario.Ds.GetXml().ToString());
            pausa();
            Console.WriteLine("Mostrando datos sin formato XML: ");
            foreach (DataRow fila in objInventario.Ds.Tables["Table"].Rows)
            {
                Console.WriteLine("\nId \t\t: {0}", fila["id"].ToString());
                Console.WriteLine("Código \t\t: {0}", fila["Codigo"].ToString());
                Console.WriteLine("Fecha \t\t: {0}", fila["Fecha"].ToString());
                Console.WriteLine("Sección    : {0}", fila["Seccion"].ToString());
                Console.WriteLine("Nombre Artículo    : {0}", fila["NombreArticulo"].ToString());
                Console.WriteLine("Estado \t\t: {0}", fila["Estado"].ToString());
                Console.WriteLine("Etiquetado \t: {0}", fila["Etiquetado"].ToString());
                Console.WriteLine("Realizado Por \t\t: {0}", fila["RealizadoPor"].ToString());
            }
        }

        public static void modificar()
        {
            Inventario objInventario = new Inventario();

            Console.WriteLine("Actualización de Registro:");
            Console.WriteLine("=======================");
            Console.Write("Ingrese Id      : ");
            objInventario.Id = obtenerNumero();
            Console.Write("Ingrese Código      : ");
            objInventario.Codigo = obtenerNumero();
            //Console.Write("Ingrese Fecha   : ");
            //string fecha = Console.ReadLine();
            //objInventario.Fecha = DateTime.Now;
            Console.Write("Ingrese Sección: ");
            objInventario.Seccion = obtenerNumero();
            Console.Write("Ingrese Nombre Artículo: ");
            objInventario.NombreArticulo = Console.ReadLine();
            Console.Write("Ingrese Estado     : ");
            objInventario.Estado = Console.ReadLine();
            Console.Write("Ingrese Etiquetado: ");
            bool etiquetado = obtenerBool();
            objInventario.Etiquetado = etiquetado;
            Console.Write("Ingrese Realizado Por     : ");
            objInventario.RealizadoPor = Console.ReadLine();

            objInventario.modificar(objInventario);
        }

        public static void eliminar()
        {
            Inventario objInventario = new Inventario();

            Console.WriteLine("Ingrese Id del registro que desea eliminar:");
            objInventario.Id = int.Parse(Console.ReadLine());

            objInventario.eliminar(objInventario);
        }

        public static bool obtenerBool()
        {
            bool valor = false;
            bool esValido = false;

            do
            {
                Console.WriteLine("Ingrese [S] para Sí o [N] en caso contrario.");
                string inputString = Console.ReadLine().ToLower();

                if (String.IsNullOrEmpty(inputString))
                {
                    continue;
                }
                if (string.Equals(inputString, "s"))
                {
                    valor = true;
                    esValido = true;
                }
                else if (string.Equals(inputString, "n"))
                {
                    valor = false;
                    esValido = true;
                }
            } while (!esValido);

            return valor;
        }

        public static int obtenerNumero()
        {
            int valor = 0;
            bool esValido = false;

            do
            {
                string inputString = Console.ReadLine().ToLower();

                if (String.IsNullOrEmpty(inputString))
                {
                    continue;
                }
                try
                {
                    valor = int.Parse(inputString);
                    esValido = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                if (!esValido)
                {
                    Console.WriteLine("Por favor intente nuevamente:");
                }
                
            } while (!esValido);

            return valor;
        }
    }// fin class
}// fin namespace
