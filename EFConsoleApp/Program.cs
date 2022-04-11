using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Linq;

namespace EFConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var sw = new Stopwatch();
            //sw.Start();

            //// Do something
            //for(int i = 0; i < 5; i++)
            //    System.Threading.Thread.Sleep(1000);

            //sw.Stop();
            //Console.WriteLine(sw.Elapsed);

                RepositoryProductos MisAplicaciones = new RepositoryProductos();
                int opcion;
                do
                {

                    Console.WriteLine("Introduzca la opcion deseada");
                    Console.WriteLine("0 - TERMINAR");
                    Console.WriteLine("1 - AGREGAR");
                    Console.WriteLine("2 - MOSTRAR PRODUCTS DB");
                    Console.WriteLine("3 - BUSQUEDA SINGLE");
                    Console.WriteLine("4 - BUSCAR POR CATEGORIA");
                    Console.WriteLine("5 - ELIMINAR");
                    Console.WriteLine("6- ACTUALIZAR PRODUCTO");



                opcion = int.Parse(Console.ReadLine());

                    switch (opcion)
                    {
                        case 0:
                            Console.WriteLine("Gracias por utilizar nuestros servicios");
                            break;

                        case 1:
                            Productos Agregar = new Productos();

                            System.Console.WriteLine("introduce codigo");
                            int codigo = int.Parse(Console.ReadLine());
                            System.Console.WriteLine("introduce nombre del producto");
                            string nombre = Console.ReadLine();
                            System.Console.WriteLine("introduce la descripcion");
                            string descripcion = Console.ReadLine();
                            System.Console.WriteLine("introduce el precio");
                            double precio = double.Parse(Console.ReadLine());
                            System.Console.WriteLine("introduce cant existencias");
                            int existencia = int.Parse(Console.ReadLine());

                            Agregar.IdCodigo = codigo;
                            Agregar.Nombre = nombre;
                            Agregar.Descripcion = descripcion;
                            Agregar.Precio = precio;
                            Agregar.Cantidad = existencia;

                        Console.WriteLine("...Insertando producto en la DB...");
                            try
                            {
                                MisAplicaciones.Añadir(Agregar);
                                Console.WriteLine("Producto añadido satisfactoriamente");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Ha habido un error!!!!");
                                Console.WriteLine(ex.Message);
                            }

                            break;

                        case 2:
                            //Muestra la tabla Productos ordenada por nombre
                            // var DB = Aplicaciones.Productos.ToList().OrderBy(a => a.Nombre);
                            try
                            {
                                Console.WriteLine("...Actualizando la BD.....");
                                MisAplicaciones.MostrarBD();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }                       
                            break;

                        case 3:
                            Console.WriteLine("Introduce el nombre del producto a buscar");
                            string Nombre = Console.ReadLine();
                            Console.WriteLine("Introduce la descripcion del producto a buscar");
                            string Descripcion = Console.ReadLine();
                            try
                            {
                                Console.WriteLine("...Buscando en la BD.....");
                                MisAplicaciones.BuscarSingle(Nombre, Descripcion);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("!!!Ups, Producto no encontrado");
                                Console.WriteLine(ex.Message);
                            }

                            break;


                        case 4:
                            Console.WriteLine("introduce el nombre de la categoria");
                            string Categoria = Console.ReadLine();
                            try
                            {
                                Console.WriteLine("...Buscando en la BD.....");
                                MisAplicaciones.BuscarCategoria(Categoria);
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                            break;

                        case 5:
                            Console.WriteLine("introduce el nombre del producto");
                            string NombreProductoEliminar = Console.ReadLine();
                            Console.WriteLine("introduce la descripcion del producto");
                            string DescripcionProductoEliminar = Console.ReadLine();
                            MisAplicaciones.Eliminar(NombreProductoEliminar, DescripcionProductoEliminar);

                            break;

                        case 6:
                            Console.WriteLine("Introdusca el Id del producto");
                            int Id = int.Parse(Console.ReadLine()); 
                            Console.WriteLine("Introdusca el nuevo precio");
                            double NuevoPrecio = double.Parse(Console.ReadLine());
                            Console.WriteLine("Introdusca la nueva cantidad");
                            int NuevaCantidad = int.Parse(Console.ReadLine());
                            MisAplicaciones.Actualizar(Id, NuevaCantidad, NuevoPrecio);
                            break;

                        
                    }
                }
                while (opcion != 0);
        }
    }
}
