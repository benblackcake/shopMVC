namespace MVCtest.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<CategoryGroup> CategoryGroup { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Master> Master { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Product_Detail> Product_Detail { get; set; }
        public virtual DbSet<Sale> Sale { get; set; }
        public virtual DbSet<Shippers> Shippers { get; set; }
        public virtual DbSet<Sub_Categroy> Sub_Categroy { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoles>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

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
                .HasMany(e => e.Cart)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Comment)
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
                .HasMany(e => e.OrderDetail)
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
                .HasMany(e => e.Cart)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Comment)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderDetail)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Product_Detail)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product_Detail>()
                .Property(e => e.Size)
                .IsUnicode(false);

            modelBuilder.Entity<Sale>()
                .Property(e => e.Sale_UnPrice)
                .IsFixedLength();

            modelBuilder.Entity<Shippers>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Sub_Categroy>()
                .HasMany(e => e.Product)
                .WithOptional(e => e.Sub_Categroy)
                .HasForeignKey(e => e.Category_Id);
        }
    }
}
