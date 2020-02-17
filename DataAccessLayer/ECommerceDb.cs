namespace DataAccessLayer
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using DataAccessLayer.Entities;

    public partial class ECommerceDb : DbContext
    {
        public ECommerceDb()
            : base("name=ECommerceDb")
        {
        }

        private static ECommerceDb _ctx;
        public static ECommerceDb CreateInstanceSingleton()
        {
            if (_ctx == null)
                _ctx = new ECommerceDb();
            return _ctx;
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Banner> Banners { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.SubCategories)
                .WithOptional(e => e.ParentCategory)
                .HasForeignKey(e => e.ParentCategory_Id);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Category)
                .HasForeignKey(e => e.Category_Id);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductImages)
                .WithOptional(e => e.Product)
                .HasForeignKey(e => e.Product_Id);

            


        }
    }
}
