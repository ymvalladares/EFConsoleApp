using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EFConsoleApp
{
    internal class RepositoryProductos
    {
        
        string nombre;
        string descripcion;
        string nombreProducto;
        int id;
        int cantidad;
        double precio;


        public void Añadir(Productos productos)
        {
            using(var db = new AplicacionDbContext())
            {
                db.Productos.Add(productos);
                db.SaveChanges();
            }
        }
        public void MostrarBD()
        {
            using (var DB = new AplicacionDbContext())
            {
                //var Base =  DB.Productos.Include(b => b.Categorias).ToList();
                var Base = DB.Productos.ToList();
                foreach (var Busco in Base)
                {
                    Console.WriteLine(Busco);
                }
            }
                
        }

        //busqueda de producto single
        public void BuscarSingle(string nombre, string descripcion)
        {
            using (var Busqueda = new AplicacionDbContext())
            {
                this.nombre = nombre;
                this.descripcion = descripcion;

                var BuscoNombre = Busqueda.Productos.Single(b => b.Nombre == nombre && b.Descripcion == descripcion);
                Console.WriteLine(BuscoNombre); ;
            }
        }

        public void BuscarCategoria(string nombreProducto)
        {
            using (var BuscarCategoria = new AplicacionDbContext())
            {
                this.nombreProducto = nombre;
                var BuscoNombre = BuscarCategoria.Productos.Where(b => b.Nombre.Contains(nombreProducto)).ToList();

                if (BuscoNombre != null)
                {
                    foreach (var Encontrados in BuscoNombre)
                    {
                        Console.WriteLine(Encontrados);
                    }

                    //OTRA FORMA DE PEDIR LOS VALORES POR COLUMNA
                    //foreach (var Encontrados in BuscoNombre)
                    //{
                    //    Console.WriteLine(Encontrados.Nombre + " -- " + Encontrados.Descripcion + "....");
                    //}
                }
                else
                {
                    Console.WriteLine("No hay registros con ese nombre");
                }
            }
        }

        public void Eliminar(string nombre, string descripcion)
        {
            this.nombre = nombre;
            this.descripcion= descripcion;
            using(var Eliminar = new AplicacionDbContext())
            {
                var BuscoProducto = Eliminar.Productos.Single(x => x.Nombre == nombre && x.Descripcion == descripcion); //returns a single item.
                try
                {
                    if (BuscoProducto != null)
                    {
                        Console.WriteLine("...Eliminando producto...");
                        Eliminar.Productos.Remove((Productos)BuscoProducto);
                        Eliminar.SaveChanges();
                        Console.WriteLine("Registro eliminado satisfactoriamente");
                    }
                    else
                    {
                        Console.WriteLine("El nombre del producto no esta en nuestra base de datos");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        public void Actualizar(int Id, int Cantidad, double Precio)
        {
            
            using(var Actualizar = new AplicacionDbContext())
            {
                var EstoyBuscandoProducto = Actualizar.Productos.Single(y => y.IdProducto == Id);
                try
                {
                    if (EstoyBuscandoProducto != null)
                    {
                        EstoyBuscandoProducto.Cantidad = Cantidad;
                        EstoyBuscandoProducto.Precio = Precio;
                        Actualizar.SaveChanges();
                        Console.WriteLine("...Actualizando la DB....");
                        Console.WriteLine(EstoyBuscandoProducto);
                        Console.WriteLine("DB actualizada correctamente");
                    }
                    else
                    {
                        Console.WriteLine($"El producto con Id: {EstoyBuscandoProducto.IdProducto} no se encuentra en DB");
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
