using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.BaseDatos.Models;

namespace Datos.BaseDatos
{
    public class TiendaContext : DbContext
    {
        public TiendaContext() : base ("name = TiendaPeliculas")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>(); //Utilizamos using System.Data.Entity.ModelConfiguration.Conventions;
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); //No queremos Nombres en plural
        }

       public DbSet<Peliculas> Peliculas { get; set;}
        public DbSet<Clientes> Clientes { get; set;}
        public DbSet<Renta> Renta { get; set;}


    }
}
