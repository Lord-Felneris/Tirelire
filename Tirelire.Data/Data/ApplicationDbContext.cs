using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Tirelire.Models;

namespace Tirelire.Data.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {
            
        }

        //create table "fabricant" database / 1-  update-database   2- add-migration "nameofmigration"   3-update-database
        public DbSet<Fabricant> Fabricants { get; set; }
        public DbSet<Produit> Tirelires { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Fabricant>().HasData(
                new Fabricant { Id = 1, Description = "Vendeur Tirelire cochon", Name = "BobTirelire", Pays = "France" },
                new Fabricant { Id = 2, Description = "Vendeur Tirelire oiseau", Name = "TimTirelire", Pays = "USA" }
                );

            //add data to tirelire table
            builder.Entity<Produit>().HasData(
                new Produit
                {
                    Id = 1,
                    Title = "TirelireCochon",
                    Couleur = "Rouge",
                    Description = "Facile à utiliser",
                    ImageUrl = "",
                    FabricantId = 1,
                    Height = 20,
                    Width = 20,
                    Poids = 10,
                    Prix = 20,
                    Longueur = 20,  
                    Capacite = 100
                }
                );

        }

    }
}
