using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularApi.DTO;


namespace AngularApi.Models
{


    public class DataContext : IdentityDbContext
    {
        
        public DataContext(DbContextOptions options):base(options)
        {

        }

        public DataContext()
        {
        }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Wishlist> WishLists { get; set; }
        public virtual DbSet<CartProduct> CartProducts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<AngularApi.DTO.ProductDto> ProductDto { get; set; }


    }

}
