namespace MVCtest.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

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
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Shipper> Shippers { get; set; }
        public virtual DbSet<SSub_Category> SSub_Category { get; set; }
        public virtual DbSet<Sub_Categroy> Sub_Categroy { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryGroup>()
                .Property(e => e.Category_Name)
                .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .Property(e => e.Customer_E_mail)
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

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.Seller_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Products1)
                .WithRequired(e => e.Customer1)
                .HasForeignKey(e => e.Seller_ID)
                .WillCascadeOnDelete(false);

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
                .Property(e => e.Product_Image)
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

            modelBuilder.Entity<SSub_Category>()
                .Property(e => e.Category_Name)
                .IsFixedLength();

            modelBuilder.Entity<SSub_Category>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.SSub_Category)
                .HasForeignKey(e => e.Category_Id);

            modelBuilder.Entity<Sub_Categroy>()
                .Property(e => e.Category_Name)
                .IsFixedLength();
        }
    }
}
