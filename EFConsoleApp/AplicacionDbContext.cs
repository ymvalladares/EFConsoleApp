using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFConsoleApp
{
    internal class AplicacionDbContext : DbContext
    {
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Categorias> Categorias { get; set; }

        //public void ConexionDB(string[] args)
        //{
        //    var configurarBD = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build();
        //    var optionConexionBD = new DbContextOptionsBuilder<AplicacionDbContext>();
        //    optionConexionBD.UseMySQL(configurarBD["ConnectionStrings:DefaultConnection"]);
        //}


       // clase conexionDB
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySQL("Server = localhost; User=root; Database=tienda; Port=3306; Password=123456");
        }
    }

   //1 PASO
   //Creamos el formato de la BD(tablas)
   [Table("productos")]
    public class Productos
    {
        [Column("idproductos")]
        [Key]
        public int IdProducto { get; set; }

        [Column("idCodigo")]
        [ForeignKey("Categorias")]
        public int IdCodigo { get; set; }
        [Column("nombre")]
        public string Nombre { get; set; }
        [Column("descripcion")]
        public string Descripcion { get; set; }
        [Column("precio")]
        public double Precio { get; set; }
        [Column("cantidad")]
        public int Cantidad { get; set; }

        public string NombreMercado { get; set; }

        public Categorias Categorias { get; set; }

        //public ICollection<Categorias> Categorias { get; set; }

        public override string ToString()
        {
            return $"{IdProducto}  --  {Nombre}  --  {Descripcion}  --  {Precio}  --  {Cantidad}";
        }
    }

    [Table("categorias")]
    public class Categorias

    {
        [Key]
        [Column("idcategorias")]
        public int Idcategorias { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("codigo")]
        public int Codigo { get; set; }

        public override string ToString()
        {
            return $"{Idcategorias}  --  {Name}  --  {Codigo}";
        }
    }
}
