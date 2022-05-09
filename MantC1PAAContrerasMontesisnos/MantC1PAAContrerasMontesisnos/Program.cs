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
            int op = 0;
            do
            {
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

            } while (op != 5);
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
            Inventario objInventario = new Inventario();

            Console.WriteLine("Ingreso de Registo al Inventario:");
            Console.WriteLine("=======================");
            
            objInventario = formulario(objInventario, esPrimerIngreso: true);

            Console.Clear();
            imprimirInventario(objInventario);

            Console.Write("\nLos datos mostrados son correctos? [S/N]: ");
            bool datosCorrectos = obtenerBool();

            if (!datosCorrectos)
            {
                Console.WriteLine("Reingreso Datos");
                Console.WriteLine("=======================");
                objInventario = formulario(objInventario, esPrimerIngreso: false);
            }

            objInventario = objInventario.ingresar(objInventario);

            bool noTieneError = String.IsNullOrEmpty(objInventario.Mensaje);
            
            if (noTieneError)
            {
                Console.WriteLine("Los Datos fueron ingresados correctamente........");
            }
            else
            {
                Console.WriteLine($"E R R O R Datos no ingresados. '{objInventario.Mensaje}' !!!!!!!!!");
            }
        }

        public static void mostrar()
        {
            DataSet ds = new DataSet();
            Inventario objInventario = new Inventario();
            Console.WriteLine("Mostrar");
            Console.WriteLine("=======================");
            Console.WriteLine("Si Ud. desea ver todos los registros ingrese un 0 , de lo contrario indique el código de registro deseado");
            Console.WriteLine("Ingrese Código:");
            objInventario.Codigo = obtenerNumero();

            objInventario = objInventario.mostrar(objInventario);
            bool noTieneError = String.IsNullOrEmpty(objInventario.Mensaje);
            if (noTieneError)
            {
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
            else
            {
                Console.WriteLine($"E R R O R. '{objInventario.Mensaje}'!!!!!");
            }

            
        }// fin mostrar

        public static void modificar()
        {
            Inventario objInventario = new Inventario();

            Console.WriteLine("Actualización de Registro:");
            Console.WriteLine("=======================");
            Console.Write("Ingrese Id      : ");
            objInventario.Id = obtenerNumero();
            objInventario = formulario(objInventario, esPrimerIngreso: true);

            objInventario.modificar(objInventario);
            bool noTieneError = String.IsNullOrEmpty(objInventario.Mensaje);

            if (noTieneError)
            {
                Console.WriteLine("Los Datos fueron modificados correctamente........");
            }
            else
            {
                Console.WriteLine($"E R R O R Datos no lograron ser modificados. '{objInventario.Mensaje}' !!!!!!!!!");
            }
        }// fin modificar

        public static void eliminar()
        {
            Inventario objInventario = new Inventario();

            Console.WriteLine("Ingrese Id del registro que desea eliminar:");
            objInventario.Id = int.Parse(Console.ReadLine());

            objInventario.eliminar(objInventario);

            bool noTieneError = String.IsNullOrEmpty(objInventario.Mensaje);

            if (noTieneError)
            {
                Console.WriteLine("El registro fue eliminado correctamente........");
            }
            else
            {
                Console.WriteLine($"E R R O R registro no fue eliminado. '{objInventario.Mensaje}' !!!!!!!!!");
            }
        }// fin eliminar

        public static void imprimirInventario(Inventario objInventario)
        {
            Console.WriteLine("Mostrando Datos de Registro");
            Console.WriteLine("========================");
            if (!objInventario.Id.Equals(0))
            {
                Console.WriteLine("Id        : {0}", objInventario.Id);
            }
            Console.WriteLine("Código        : {0}", objInventario.Codigo);
            Console.WriteLine("Fecha     : {0}", objInventario.Fecha);
            Console.WriteLine("Sección: {0}", objInventario.Seccion);
            Console.WriteLine("Nombre Artículo: {0}", objInventario.NombreArticulo);
            Console.WriteLine("Estado       : {0}", objInventario.Estado);
            Console.WriteLine("Etiquetado  : {0}", objInventario.Etiquetado);
            Console.WriteLine("Realizado Por       : {0}", objInventario.RealizadoPor);
        }// fin imprimirInventario

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
        }// fin obtenerBool

        public static int obtenerNumero()
        {
            int valor = 0;
            bool esValido = false;

            do
            {
                string inputString = Console.ReadLine().ToLower();

                if (String.IsNullOrEmpty(inputString))
                {
                    Console.WriteLine("El campo no debe estar vacío");
                    continue;
                }
                try
                {
                    valor = int.Parse(inputString);
                    esValido = true;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("El formato ingresado no es válido (este campo solo acepta números)");
                }
                catch(OverflowException e)
                {
                    Console.WriteLine("El largo del número ingresado no es válido");
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
        }// fin obtenerNumero

        public static Inventario formulario(Inventario objInventario, bool esPrimerIngreso)
        {
            objInventario = ingresarCodigo(objInventario, esPrimerIngreso: esPrimerIngreso);
            objInventario = ingresarFecha(objInventario, esPrimerIngreso: esPrimerIngreso);
            objInventario = ingresarSeccion(objInventario, esPrimerIngreso: esPrimerIngreso);
            objInventario = ingresarNombreArticulo(objInventario, esPrimerIngreso: esPrimerIngreso);
            objInventario = ingresarEstado(objInventario, esPrimerIngreso: esPrimerIngreso);
            objInventario = ingresarEtiquetado(objInventario, esPrimerIngreso: esPrimerIngreso);
            objInventario = ingresarRealizadoPor(objInventario, esPrimerIngreso: esPrimerIngreso);

            return objInventario;
        }//fin formulario

        public static Inventario ingresarCodigo(Inventario objInventario, bool esPrimerIngreso)
        {
            bool requiereModificacion = esPrimerIngreso;
            if (!esPrimerIngreso)
            {
                Console.WriteLine($"¿Desea modificar el Código {objInventario.Codigo} [S/N]?");
                requiereModificacion = obtenerBool();
            }
            
            if (requiereModificacion)
            {
                bool esCodigoNegativo = false;
                do
                {
                    Console.Write("Ingrese Código      : ");
                    int codigo = obtenerNumero();
                    esCodigoNegativo = objInventario.validacionNumeroNegativo(codigo);
                    if (esCodigoNegativo)
                    {
                        Console.WriteLine("El campo Código no admite números menores o iguales que 0.");
                    }
                    else
                    {
                        objInventario.Codigo = codigo;
                    }
                } while (esCodigoNegativo);
            }
            return objInventario;
        }// fin ingresarCodigo

        public static Inventario ingresarFecha(Inventario objInventario, bool esPrimerIngreso)
        {
            bool requiereModificacion = esPrimerIngreso;
            if (!esPrimerIngreso)
            {
                Console.WriteLine($"¿Desea modificar la Fecha: {objInventario.Fecha} [S/N]?");
                requiereModificacion = obtenerBool();
            }

            if (requiereModificacion)
            {
                Console.Write("Ingrese Fecha   : ");
                objInventario.Fecha = obtenerFecha();
            }
            return objInventario;
        }// fin ingresarFecha

        public static DateTime obtenerFecha()
        {
            DateTime valor = DateTime.Now;
            bool esValido = false;

            do
            {
                Console.WriteLine("Ingrese la fecha del registro en fomato DD/MM/AAAA");
                string inputString = Console.ReadLine();

                if (String.IsNullOrEmpty(inputString))
                {
                    continue;
                }
                try
                {
                    valor = DateTime.Parse(inputString);
                    Console.WriteLine("La fecha ingresada posee formato correcto: " + valor);
                    esValido = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("El formato ingresado no es correcto, por favor ingrese nuevamente la fecha.");
                }
            } while (!esValido);

            return valor;
        } // fin obtenerFecha

        public static Inventario ingresarSeccion(Inventario objInventario, bool esPrimerIngreso)
        {
            bool requiereModificacion = esPrimerIngreso;
            if (!esPrimerIngreso)
            {
                Console.WriteLine($"¿Desea modificar la Sección {objInventario.Seccion} [S/N]?");
                requiereModificacion = obtenerBool();
            }
            if (requiereModificacion)
            {
                bool esSeccionoNegativo = false;
                do
                {
                    Console.Write("Ingrese Sección      : ");
                    int seccion = obtenerNumero();
                    esSeccionoNegativo = objInventario.validacionNumeroNegativo(seccion);
                    if (esSeccionoNegativo)
                    {
                        Console.WriteLine("El campo Sección no admite números menores o iguales que 0.");
                    }
                    else
                    {
                        objInventario.Seccion = seccion;
                    }
                } while (esSeccionoNegativo);
            }
            return objInventario;
        }// fin ingresarSeccion

        public static Inventario ingresarNombreArticulo(Inventario objInventario, bool esPrimerIngreso)
        {
            bool requiereModificacion = esPrimerIngreso;
            if (!esPrimerIngreso)
            {
                Console.WriteLine($"¿Desea modificar el Nombre Artículo {objInventario.NombreArticulo} [S/N]?");
                requiereModificacion = obtenerBool();
            }
            if (requiereModificacion)
            {
                bool esValido = false;
                do
                {
                    Console.Write("Ingrese  Nombre Artículo      : ");
                    string valor = Console.ReadLine();
                    esValido = objInventario.validacionCampoVacio(valor);
                    if (esValido)
                    {
                        Console.WriteLine("El campo  Nombre Artículo no debe estar vacío.");
                    }
                    else
                    {
                        objInventario.NombreArticulo = valor;
                    }
                } while (esValido);
            }
            return objInventario;
        }// fin ingresarNombreArticulo

        public static Inventario ingresarEstado(Inventario objInventario, bool esPrimerIngreso)
        {
            bool requiereModificacion = esPrimerIngreso;
            if (!esPrimerIngreso)
            {
                Console.WriteLine($"¿Desea modificar el Estado {objInventario.Estado} [S/N]?");
                requiereModificacion = obtenerBool();
            }
            if (requiereModificacion)
            {
                bool esValido = false;
                do
                {
                    Console.Write("Ingrese Estado      : ");
                    string valor = Console.ReadLine();
                    esValido = objInventario.validacionCampoVacio(valor);
                    if (esValido)
                    {
                        Console.WriteLine("El campo Estado no debe estar vacío.");
                    }
                    else
                    {
                        objInventario.Estado = valor;
                    }
                } while (esValido);
            }
            return objInventario;
        }// fin ingresarEstado

        public static Inventario ingresarEtiquetado(Inventario objInventario, bool esPrimerIngreso)
        {
            bool requiereModificacion = esPrimerIngreso;
            if (!esPrimerIngreso)
            {
                Console.WriteLine($"¿Desea modificar el campo Etiquetado: {objInventario.Etiquetado} [S/N]?");
                requiereModificacion = obtenerBool();
            }
            if (requiereModificacion)
            {
                Console.Write("Ingrese Etiquetado: ");
                bool etiquetado = obtenerBool();
                objInventario.Etiquetado = etiquetado;
            }
            return objInventario;
        }// fin ingresarEtiquetado

        public static Inventario ingresarRealizadoPor(Inventario objInventario, bool esPrimerIngreso)
        {
            bool requiereModificacion = esPrimerIngreso;
            if (!esPrimerIngreso)
            {
                Console.WriteLine($"¿Desea modificar el campo Realizado Por: {objInventario.RealizadoPor} [S/N]?");
                requiereModificacion = obtenerBool();
            }
            if (requiereModificacion)
            {
                bool esValido = false;
                do
                {
                    Console.Write("Ingrese Realizado Por      : ");
                    string valor = Console.ReadLine();
                    esValido = objInventario.validacionCampoVacio(valor);
                    if (esValido)
                    {
                        Console.WriteLine("El campo Realizado Por no debe estar vacío.");
                    }
                    else
                    {
                        objInventario.RealizadoPor = valor;
                    }
                } while (esValido);
            }
            return objInventario;
        }//fin ingresarRealizadoPor
    }// fin class
}// fin namespace
