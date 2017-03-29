namespace ProductShop.Data
{
    using ProductsShop.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ProductShopContext : DbContext
    {

        public ProductShopContext()
            : base("name=ProductShopContext")
        {
        }



        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasMany(p => p.Categories).WithMany(c => c.Products);

            modelBuilder.Entity<User>().HasMany(u => u.BoughtProducts).WithOptional(p => p.Buyer);

            modelBuilder.Entity<User>().HasMany(u => u.SoldProducts).WithRequired(p => p.Seller);

            //modelBuilder.Entity<User>().HasMany(u => u.Friends).WithMany();

            //modelBuilder.Entity<UserFriend>().HasRequired(uf => uf.User).WithMany(u => u.Friends).HasForeignKey(u => u.UserId).WillCascadeOnDelete(false);
            modelBuilder.Entity<User>().HasMany(u => u.Friends).WithMany().Map(mc =>
            {
                mc.MapLeftKey("UserId");
                mc.MapRightKey("FriendId");
                mc.ToTable("UserFriends");
            });

            base.OnModelCreating(modelBuilder);
        }

    }


}