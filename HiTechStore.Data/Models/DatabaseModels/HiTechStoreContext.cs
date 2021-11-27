using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HiTechStore.Data.Models.DatabaseModels
{
    public partial class HiTechStoreContext : DbContext
    {
        public HiTechStoreContext()
        {
        }

        public HiTechStoreContext(DbContextOptions<HiTechStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CustomerContactDetail> CustomerContactDetails { get; set; }
        public virtual DbSet<CustomerOrder> CustomerOrders { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<LoyaltyCustomer> LoyaltyCustomers { get; set; }
        public virtual DbSet<OrderedItem> OrderedItems { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductType> ProductTypes { get; set; }
        public virtual DbSet<SystemUser> SystemUsers { get; set; }
        public virtual DbSet<SystemView> SystemViews { get; set; }
        public virtual DbSet<UserPrivilege> UserPrivileges { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=HiTechStore; Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CustomerContactDetail>(entity =>
            {
                entity.HasKey(e => e.customer_contact_id);

                entity.Property(e => e.address)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.city)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.contact_no)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.country)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.country_code)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.postal_code)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.state)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.customer)
                    .WithMany(p => p.CustomerContactDetails)
                    .HasForeignKey(d => d.customer_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_CustomerContactDetails");
            });

            modelBuilder.Entity<CustomerOrder>(entity =>
            {
                entity.HasKey(e => e.customer_order_id);

                entity.ToTable("CustomerOrder");

                entity.Property(e => e.created_at).HasColumnType("datetime");

                entity.HasOne(d => d.customer)
                    .WithMany(p => p.CustomerOrders)
                    .HasForeignKey(d => d.customer_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_Order");
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.HasKey(e => e.discount_id);

                entity.ToTable("Discount");

                entity.Property(e => e.discount1)
                    .HasColumnType("decimal(10, 0)")
                    .HasColumnName("discount");

                entity.Property(e => e.discounted_price).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.total_price).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.order)
                    .WithMany(p => p.Discounts)
                    .HasForeignKey(d => d.order_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerOrder_Discount");
            });

            modelBuilder.Entity<LoyaltyCustomer>(entity =>
            {
                entity.HasKey(e => e.loyalty_customer_id);

                entity.ToTable("LoyaltyCustomer");

                entity.Property(e => e.joined_at).HasColumnType("datetime");

                entity.HasOne(d => d.customer)
                    .WithMany(p => p.LoyaltyCustomers)
                    .HasForeignKey(d => d.customer_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_LoyaltyCustomer");
            });

            modelBuilder.Entity<OrderedItem>(entity =>
            {
                entity.HasKey(e => e.ordered_item_id);

                entity.ToTable("OrderedItem");

                entity.Property(e => e.price).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.item)
                    .WithMany(p => p.OrderedItems)
                    .HasForeignKey(d => d.item_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderedItem_Product");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.payment_id)
                    .HasName("PK_Table_1");

                entity.ToTable("Payment");

                entity.Property(e => e.amount_paid).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.status)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.total_amount).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.order)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.order_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Discount_Payment");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.product_id);

                entity.ToTable("Product");

                entity.Property(e => e.created_at).HasColumnType("datetime");

                entity.Property(e => e.image_url)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.price).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.sku)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.type)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.type_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductType_Product");
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.HasKey(e => e.product_type_id);

                entity.ToTable("ProductType");

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SystemUser>(entity =>
            {
                entity.HasKey(e => e.user_id);

                entity.ToTable("SystemUser");

                entity.Property(e => e.email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.first_name)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.last_name)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.password)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.user_role)
                    .WithMany(p => p.SystemUsers)
                    .HasForeignKey(d => d.user_role_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRole_SystemUser");
            });

            modelBuilder.Entity<SystemView>(entity =>
            {
                entity.HasKey(e => e.view_id);

                entity.ToTable("SystemView");

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserPrivilege>(entity =>
            {
                entity.HasKey(e => e.privilege_id);

                entity.ToTable("UserPrivilege");

                entity.HasOne(d => d.view)
                    .WithMany(p => p.UserPrivileges)
                    .HasForeignKey(d => d.view_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SystemView_Privilege");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.user_role_id);

                entity.ToTable("UserRole");

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
