using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace P0DbContext
{
    public partial class P0Context : DbContext
    {
        public P0Context()
        {
        }

        public P0Context(DbContextOptions<P0Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomersAddress> CustomersAddresses { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderProduct> OrderProducts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductDept> ProductDepts { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<StoreInventory> StoreInventories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS01;Database=P0;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustId)
                    .HasName("PK__Customer__A1B71F901C106AC9");

                entity.Property(e => e.CustId).HasColumnName("cust_id");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.CustEmail)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("cust_email");

                entity.Property(e => e.CustFname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("cust_Fname");

                entity.Property(e => e.CustLname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("cust_Lname");

                entity.Property(e => e.CustPassword)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("cust_password");

                entity.Property(e => e.CustPhoneNum)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("cust_phoneNum");

                entity.Property(e => e.CustUsername)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("cust_username");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK__Customers__addre__160F4887");
            });

            modelBuilder.Entity<CustomersAddress>(entity =>
            {
                entity.HasKey(e => e.AddressId)
                    .HasName("PK__Customer__CAA247C8D4C0C9CC");

                entity.ToTable("CustomersAddress");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.AddressCity)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("address_city");

                entity.Property(e => e.AddressState)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("address_state");

                entity.Property(e => e.AddressStreet)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address_street");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.CustId).HasColumnName("cust_id");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasColumnName("order_date");

                entity.Property(e => e.OrderTotal)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("order_total");

                entity.Property(e => e.StoreId).HasColumnName("store_id");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustId)
                    .HasConstraintName("FK__Orders__cust_id__19DFD96B");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__Orders__store_id__18EBB532");
            });

            modelBuilder.Entity<OrderProduct>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId })
                    .HasName("PK_order_products");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.ProductOrderQuantity).HasColumnName("product_order_quantity");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderProducts)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderProd__order__1CBC4616");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderProd__produ__1DB06A4F");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.DeptId).HasColumnName("dept_id");

                entity.Property(e => e.ProductDesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("product_desc");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("product_name");

                entity.Property(e => e.ProductPrice)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("product_price");

                entity.HasOne(d => d.Dept)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.DeptId)
                    .HasConstraintName("FK__Products__dept_i__04E4BC85");
            });

            modelBuilder.Entity<ProductDept>(entity =>
            {
                entity.HasKey(e => e.DeptId)
                    .HasName("PK__ProductD__DCA65974380A1FC2");

                entity.ToTable("ProductDept");

                entity.Property(e => e.DeptId).HasColumnName("dept_id");

                entity.Property(e => e.ProductDept1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("product_dept");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.Property(e => e.StoreId).HasColumnName("store_id");

                entity.Property(e => e.StoreAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("store_address");

                entity.Property(e => e.StoreName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("store_name");
            });

            modelBuilder.Entity<StoreInventory>(entity =>
            {
                entity.HasKey(e => new { e.StoreId, e.ProductId })
                    .HasName("PK_store_inventory");

                entity.ToTable("StoreInventory");

                entity.Property(e => e.StoreId).HasColumnName("store_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.ProductQuantity).HasColumnName("product_quantity");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.StoreInventories)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StoreInve__produ__08B54D69");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.StoreInventories)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StoreInve__store__07C12930");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
