using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FashionShop_BE.Entity;

public partial class FashionShopDbContext : DbContext
{
    public FashionShopDbContext()
    {
    }

    public FashionShopDbContext(DbContextOptions<FashionShopDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<About> Abouts { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<CartItem> CartItems { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Coupon> Coupons { get; set; }

    public virtual DbSet<Favorite> Favorites { get; set; }

    public virtual DbSet<FeedBack> FeedBacks { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<SizeProduct> SizeProducts { get; set; }

    public virtual DbSet<Slider> Sliders { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //Use In Home
        /*=> optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS01;Initial Catalog=FashionShop_DB;Integrated Security=True;Trust Server Certificate=True");*/
        //Use In Company
        => optionsBuilder.UseSqlServer("Data Source=DOHAIDEV;Initial Catalog=FashionShop_DB;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<About>(entity =>
        {
            entity.ToTable("About");

            entity.Property(e => e.AboutId).HasColumnName("AboutID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Detail).HasColumnType("ntext");
            entity.Property(e => e.Image).HasMaxLength(250);
            entity.Property(e => e.MetaDescriptions).HasMaxLength(250);
            entity.Property(e => e.MetaKeywords).HasMaxLength(250);
            entity.Property(e => e.MetaTitle)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Status).HasDefaultValueSql("((1))");
            entity.Property(e => e.Title).HasMaxLength(250);
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.ToTable("Cart");

            entity.Property(e => e.CartId).HasColumnName("CartID");
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.Content).HasColumnType("text");
            entity.Property(e => e.Country).HasMaxLength(50);
            entity.Property(e => e.CouponId).HasColumnName("CouponID");
            entity.Property(e => e.CreateAt).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.FullName).HasMaxLength(150);
            entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(12)
                .IsFixedLength();
            entity.Property(e => e.Province).HasMaxLength(50);
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Vat).HasColumnName("VAT");

            entity.HasOne(d => d.Coupon).WithMany(p => p.Carts)
                .HasForeignKey(d => d.CouponId)
                .HasConstraintName("FK_Cart_Coupon");

            entity.HasOne(d => d.Payment).WithMany(p => p.Carts)
                .HasForeignKey(d => d.PaymentId)
                .HasConstraintName("FK_Cart_Payment");
        });

        modelBuilder.Entity<CartItem>(entity =>
        {
            entity.ToTable("Cart_Item");

            entity.Property(e => e.CartItemId).HasColumnName("CartItemID");
            entity.Property(e => e.CartId).HasColumnName("CartID");
            entity.Property(e => e.Content).HasColumnType("text");
            entity.Property(e => e.CreateAt).HasColumnType("datetime");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Cart).WithMany(p => p.CartItems)
                .HasForeignKey(d => d.CartId)
                .HasConstraintName("FK_Cart_Item_Cart");

            entity.HasOne(d => d.Product).WithMany(p => p.CartItems)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Cart_Item_Product");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.MetaDescriptions).HasMaxLength(250);
            entity.Property(e => e.MetaKeywords).HasMaxLength(250);
            entity.Property(e => e.MetaTitle).HasMaxLength(250);
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.SeoTitle).HasMaxLength(250);
            entity.Property(e => e.Status).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.Property(e => e.CommentId).HasColumnName("CommentID");
            entity.Property(e => e.CommentText).HasMaxLength(500);
            entity.Property(e => e.CreateAt).HasColumnType("datetime");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Product).WithMany(p => p.Comments)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Comments_Product");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Comments_User");
        });

        modelBuilder.Entity<Coupon>(entity =>
        {
            entity.ToTable("Coupon");

            entity.Property(e => e.CouponId).HasColumnName("CouponID");
            entity.Property(e => e.Code)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Describe).HasMaxLength(250);
        });

        modelBuilder.Entity<Favorite>(entity =>
        {
            entity.ToTable("Favorite");

            entity.Property(e => e.FavoriteId).HasColumnName("FavoriteID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Product).WithMany(p => p.Favorites)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Favorite_Product");

            entity.HasOne(d => d.User).WithMany(p => p.Favorites)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Favorite_User");
        });

        modelBuilder.Entity<FeedBack>(entity =>
        {
            entity.ToTable("FeedBack");

            entity.Property(e => e.FeedbackId).HasColumnName("FeedbackID");
            entity.Property(e => e.Address).HasMaxLength(250);
            entity.Property(e => e.Content).HasMaxLength(250);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(12);
            entity.Property(e => e.Status).HasDefaultValueSql("((1))");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.FeedBacks)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_FeedBack_User");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.ToTable("Payment");

            entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
            entity.Property(e => e.PaymentName).HasMaxLength(150);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Detail).HasColumnType("ntext");
            entity.Property(e => e.IncludeVat).HasColumnName("IncludeVAT");
            entity.Property(e => e.MetaDescriptions).HasMaxLength(250);
            entity.Property(e => e.MetaKeywords).HasMaxLength(250);
            entity.Property(e => e.MetaTitle)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.MoreImages).HasColumnType("xml");
            entity.Property(e => e.Price)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ProductCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ProductImage).HasMaxLength(250);
            entity.Property(e => e.ProductName).HasMaxLength(250);
            entity.Property(e => e.Quantity).HasDefaultValueSql("((0))");
            entity.Property(e => e.SizeId).HasColumnName("SizeID");
            entity.Property(e => e.Status).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Category");

            entity.HasOne(d => d.Size).WithMany(p => p.Products)
                .HasForeignKey(d => d.SizeId)
                .HasConstraintName("FK_Product_SizeProduct");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RolesId);

            entity.Property(e => e.RolesId).HasColumnName("RolesID");
            entity.Property(e => e.RolesName).HasMaxLength(100);
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.ToTable("Sale");

            entity.Property(e => e.SaleId).HasColumnName("SaleID");
            entity.Property(e => e.Describe).HasMaxLength(250);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.Product).WithMany(p => p.Sales)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Sale_Product");
        });

        modelBuilder.Entity<SizeProduct>(entity =>
        {
            entity.HasKey(e => e.SizeId);

            entity.ToTable("SizeProduct");

            entity.Property(e => e.SizeId).HasColumnName("SizeID");
            entity.Property(e => e.SizeName)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Slider>(entity =>
        {
            entity.HasKey(e => e.SlideId);

            entity.ToTable("Slider");

            entity.Property(e => e.SlideId).HasColumnName("SlideID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.Image).HasMaxLength(250);
            entity.Property(e => e.Link).HasMaxLength(250);
            entity.Property(e => e.Status).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Address).HasMaxLength(250);
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(12)
                .IsFixedLength();
            entity.Property(e => e.RolesId).HasColumnName("RolesID");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Roles).WithMany(p => p.Users)
                .HasForeignKey(d => d.RolesId)
                .HasConstraintName("FK_User_Roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
