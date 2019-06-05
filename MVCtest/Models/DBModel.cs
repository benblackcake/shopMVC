namespace MVCtest.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using ViewModels;

    public partial class DBModel : DbContext
    {
        public DBModel()
            : base("name=DBcontext")
        {
        }


        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CategoryGroup> CategoryGroups { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Master> Masters { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Shipper> Shippers { get; set; }
        public virtual DbSet<Sub_Categroy> Sub_Categroy { get; set; }

        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(e => e.Customer_Email)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Customer_Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.User_Password)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Carts)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Comments)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.recipient_Name)
                .IsFixedLength();

            modelBuilder.Entity<Order>()
                .Property(e => e.recipient_Phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.Product_Name)
                .IsFixedLength();

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.Product_Detail)
                .IsFixedLength();

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.UnitPrice)
                .IsFixedLength();

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.Quantity)
                .IsFixedLength();

            modelBuilder.Entity<Payment>()
                .Property(e => e.Payment_Name)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.UnitPrice)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.Stock)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.Size)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Carts)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Comments)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Shipper>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Sub_Categroy>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Sub_Categroy)
                .HasForeignKey(e => e.Category_Id);
        }
    }
}
