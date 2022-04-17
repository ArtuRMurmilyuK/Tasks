using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Pavlov_Bot
{
    public partial class SneakersShopDBContext : DbContext
    {
        public SneakersShopDBContext()
        {
        }

        public SneakersShopDBContext(DbContextOptions<SneakersShopDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<OrdersList> OrdersLists { get; set; }
        public virtual DbSet<ShopCartItem> ShopCartItems { get; set; }
        public virtual DbSet<SizeSneaker> SizeSneakers { get; set; }
        public virtual DbSet<Sneaker> Sneakers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SneakersShopDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(7)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasDefaultValueSql("(N'')");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetail");

                entity.HasIndex(e => e.OrderId, "IX_OrderDetail_OrderId");

                entity.HasIndex(e => e.SneakerId, "IX_OrderDetail_SneakerId");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId);

                entity.HasOne(d => d.Sneaker)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.SneakerId);
            });

            modelBuilder.Entity<OrdersList>(entity =>
            {
                entity.ToTable("OrdersList");

                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(7)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasDefaultValueSql("(N'')");
            });

            modelBuilder.Entity<ShopCartItem>(entity =>
            {
                entity.ToTable("ShopCartItem");

                entity.HasIndex(e => e.SneakerId, "IX_ShopCartItem_SneakerId");

                entity.HasOne(d => d.Sneaker)
                    .WithMany(p => p.ShopCartItems)
                    .HasForeignKey(d => d.SneakerId);
            });

            modelBuilder.Entity<SizeSneaker>(entity =>
            {
                entity.ToTable("SizeSneaker");

                entity.HasIndex(e => e.SneakerId, "IX_SizeSneaker_SneakerId")
                    .IsUnique();

                entity.HasOne(d => d.Sneaker)
                    .WithOne(p => p.SizeSneaker)
                    .HasForeignKey<SizeSneaker>(d => d.SneakerId);
            });

            modelBuilder.Entity<Sneaker>(entity =>
            {
                entity.HasIndex(e => e.CategoryId, "IX_Sneakers_CategoryId");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Sneakers)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Sn eakers_Categories_CategoryId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
