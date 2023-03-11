using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FashionShop_BE.Migrations
{
    /// <inheritdoc />
    public partial class FashionShop_DB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "About",
                columns: table => new
                {
                    AboutID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MetaTitle = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Detail = table.Column<string>(type: "ntext", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedBy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    MetaKeywords = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MetaDescriptions = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_About", x => x.AboutID);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MetaTitle = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SeoTitle = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MetaKeywords = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MetaDescriptions = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Coupon",
                columns: table => new
                {
                    CouponID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Count = table.Column<int>(type: "int", nullable: true),
                    Promotion = table.Column<int>(type: "int", nullable: true),
                    Describe = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupon", x => x.CouponID);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RolesID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolesName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RolesID);
                });

            migrationBuilder.CreateTable(
                name: "SizeProduct",
                columns: table => new
                {
                    SizeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SizeName = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SizeProduct", x => x.SizeID);
                });

            migrationBuilder.CreateTable(
                name: "Slider",
                columns: table => new
                {
                    SlideID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Link = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedBy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slider", x => x.SlideID);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    CartID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    PaymentID = table.Column<int>(type: "int", nullable: true),
                    CouponID = table.Column<int>(type: "int", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nchar(12)", fixedLength: true, maxLength: 12, nullable: true),
                    Email = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Province = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ItemDiscount = table.Column<double>(type: "float", nullable: true),
                    VAT = table.Column<double>(type: "float", nullable: true),
                    Shipping = table.Column<double>(type: "float", nullable: true),
                    Total = table.Column<double>(type: "float", nullable: true),
                    Discount = table.Column<double>(type: "float", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.CartID);
                    table.ForeignKey(
                        name: "FK_Cart_Coupon",
                        column: x => x.CouponID,
                        principalTable: "Coupon",
                        principalColumn: "CouponID");
                    table.ForeignKey(
                        name: "FK_Cart_Payment",
                        column: x => x.PaymentID,
                        principalTable: "Payment",
                        principalColumn: "PaymentID");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Gender = table.Column<bool>(type: "bit", nullable: true),
                    Email = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nchar(12)", fixedLength: true, maxLength: 12, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RolesID = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_User_Roles",
                        column: x => x.RolesID,
                        principalTable: "Roles",
                        principalColumn: "RolesID");
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCode = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MetaTitle = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ProductImage = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SizeID = table.Column<int>(type: "int", nullable: true),
                    MoreImages = table.Column<string>(type: "xml", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,0)", nullable: true, defaultValueSql: "((0))"),
                    IncludeVAT = table.Column<bool>(type: "bit", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    Detail = table.Column<string>(type: "ntext", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedBy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    MetaKeywords = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MetaDescriptions = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    ViewCounts = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Product_Category",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "CategoryID");
                    table.ForeignKey(
                        name: "FK_Product_SizeProduct",
                        column: x => x.SizeID,
                        principalTable: "SizeProduct",
                        principalColumn: "SizeID");
                });

            migrationBuilder.CreateTable(
                name: "FeedBack",
                columns: table => new
                {
                    FeedbackID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedBack", x => x.FeedbackID);
                    table.ForeignKey(
                        name: "FK_FeedBack_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Cart_Item",
                columns: table => new
                {
                    CartItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: true),
                    CartID = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    Discount = table.Column<double>(type: "float", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart_Item", x => x.CartItemID);
                    table.ForeignKey(
                        name: "FK_Cart_Item_Cart",
                        column: x => x.CartID,
                        principalTable: "Cart",
                        principalColumn: "CartID");
                    table.ForeignKey(
                        name: "FK_Cart_Item_Product",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    ProductID = table.Column<int>(type: "int", nullable: true),
                    CommentText = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentID);
                    table.ForeignKey(
                        name: "FK_Comments_Product",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID");
                    table.ForeignKey(
                        name: "FK_Comments_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Favorite",
                columns: table => new
                {
                    FavoriteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    ProductID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorite", x => x.FavoriteID);
                    table.ForeignKey(
                        name: "FK_Favorite_Product",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID");
                    table.ForeignKey(
                        name: "FK_Favorite_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    SaleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Promotion = table.Column<int>(type: "int", nullable: true),
                    Describe = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ProductID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.SaleID);
                    table.ForeignKey(
                        name: "FK_Sale_Product",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cart_CouponID",
                table: "Cart",
                column: "CouponID");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_PaymentID",
                table: "Cart",
                column: "PaymentID");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_Item_CartID",
                table: "Cart_Item",
                column: "CartID");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_Item_ProductID",
                table: "Cart_Item",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProductID",
                table: "Comments",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserID",
                table: "Comments",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Favorite_ProductID",
                table: "Favorite",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Favorite_UserID",
                table: "Favorite",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_FeedBack_UserID",
                table: "FeedBack",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryID",
                table: "Product",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_SizeID",
                table: "Product",
                column: "SizeID");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_ProductID",
                table: "Sale",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_User_RolesID",
                table: "User",
                column: "RolesID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "About");

            migrationBuilder.DropTable(
                name: "Cart_Item");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Favorite");

            migrationBuilder.DropTable(
                name: "FeedBack");

            migrationBuilder.DropTable(
                name: "Sale");

            migrationBuilder.DropTable(
                name: "Slider");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Coupon");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "SizeProduct");
        }
    }
}
