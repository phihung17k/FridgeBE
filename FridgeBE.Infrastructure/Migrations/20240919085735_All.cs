using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FridgeBE.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class All : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LocalName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    UpdateTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    DeleteTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    CreateBy = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UpdateBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DeleteBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "permission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permission", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "useraccount",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Gender = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateOfBirth = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreateTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    UpdateTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    DeleteTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    CreateBy = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UpdateBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DeleteBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_useraccount", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ingredient",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LocalName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    UpdateTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    DeleteTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    CreateBy = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UpdateBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DeleteBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ingredient_category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "category",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "recipe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CookingTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    ServingSize = table.Column<int>(type: "int", nullable: true),
                    ImageUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserAccountId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreateTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    UpdateTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    DeleteTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    CreateBy = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UpdateBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DeleteBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recipe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_recipe_useraccount_UserAccountId",
                        column: x => x.UserAccountId,
                        principalTable: "useraccount",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "useraccountpermission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserAccountId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PermissionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_useraccountpermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_useraccountpermission_permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_useraccountpermission_useraccount_UserAccountId",
                        column: x => x.UserAccountId,
                        principalTable: "useraccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "userlogin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PasswordSalt = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RefreshToken = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RefreshTokenExpireTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UserAccountId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userlogin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_userlogin_useraccount_UserAccountId",
                        column: x => x.UserAccountId,
                        principalTable: "useraccount",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ingredientrecipe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IngredientQuantity = table.Column<int>(type: "int", nullable: true),
                    IngredientQuantityUnit = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IngredientId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RecipeId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingredientrecipe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ingredientrecipe_ingredient_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "ingredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ingredientrecipe_recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "step",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Content = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StepOrder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RecipeId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_step", x => x.Id);
                    table.ForeignKey(
                        name: "FK_step_recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "recipe",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "Id", "CreateBy", "CreateTime", "DeleteBy", "DeleteTime", "Description", "LocalName", "Name", "UpdateBy", "UpdateTime" },
                values: new object[,]
                {
                    { 1, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 34, 673, DateTimeKind.Unspecified).AddTicks(9198), new TimeSpan(0, 7, 0, 0, 0)), null, null, "Cereals", "Ngũ cốc", "Cereals", null, null },
                    { 2, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 34, 673, DateTimeKind.Unspecified).AddTicks(9198), new TimeSpan(0, 7, 0, 0, 0)), null, null, "Roots, tubers and plantains", "Khoai củ", "RootsTubersPlantains", null, null },
                    { 3, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 34, 673, DateTimeKind.Unspecified).AddTicks(9198), new TimeSpan(0, 7, 0, 0, 0)), null, null, "Legumes", "Đậu", "Legumes", null, null },
                    { 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 34, 673, DateTimeKind.Unspecified).AddTicks(9198), new TimeSpan(0, 7, 0, 0, 0)), null, null, "Vegetables", "Rau quả", "Vegetables", null, null },
                    { 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 34, 673, DateTimeKind.Unspecified).AddTicks(9198), new TimeSpan(0, 7, 0, 0, 0)), null, null, "Fruits", "Trái cây", "Fruits", null, null },
                    { 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 34, 673, DateTimeKind.Unspecified).AddTicks(9198), new TimeSpan(0, 7, 0, 0, 0)), null, null, "Seeds and nuts", "Hạt", "SeedsNuts", null, null },
                    { 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 34, 673, DateTimeKind.Unspecified).AddTicks(9198), new TimeSpan(0, 7, 0, 0, 0)), null, null, "Meat", "Thịt", "Meat", null, null },
                    { 8, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 34, 673, DateTimeKind.Unspecified).AddTicks(9198), new TimeSpan(0, 7, 0, 0, 0)), null, null, "Insects and grubs", "Côn trùng và sâu bọ", "InsectsGrubs", null, null },
                    { 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 34, 673, DateTimeKind.Unspecified).AddTicks(9198), new TimeSpan(0, 7, 0, 0, 0)), null, null, "Fish and shellfish", "Thủy sản", "FishShellfish", null, null },
                    { 10, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 34, 673, DateTimeKind.Unspecified).AddTicks(9198), new TimeSpan(0, 7, 0, 0, 0)), null, null, "Eggs", "Trứng", "Eggs", null, null },
                    { 11, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 34, 673, DateTimeKind.Unspecified).AddTicks(9198), new TimeSpan(0, 7, 0, 0, 0)), null, null, "Milk and dairy products", "Sữa", "MilkDairy", null, null },
                    { 12, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 34, 673, DateTimeKind.Unspecified).AddTicks(9198), new TimeSpan(0, 7, 0, 0, 0)), null, null, "Snacks", "Đồ ăn vặt", "Snacks", null, null },
                    { 13, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 34, 673, DateTimeKind.Unspecified).AddTicks(9198), new TimeSpan(0, 7, 0, 0, 0)), null, null, "Fats and oils", "Dầu, mỡ và bơ", "FatsOils", null, null },
                    { 14, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 34, 673, DateTimeKind.Unspecified).AddTicks(9198), new TimeSpan(0, 7, 0, 0, 0)), null, null, "Canned Food", "Đồ đóng hộp", "CannedFood", null, null },
                    { 15, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 34, 673, DateTimeKind.Unspecified).AddTicks(9198), new TimeSpan(0, 7, 0, 0, 0)), null, null, "Beverages", "Đồ uống", "Beverages", null, null },
                    { 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 34, 673, DateTimeKind.Unspecified).AddTicks(9198), new TimeSpan(0, 7, 0, 0, 0)), null, null, "Sweets and sugars", "Đồ ngọt", "SweetsSugars", null, null },
                    { 17, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 34, 673, DateTimeKind.Unspecified).AddTicks(9198), new TimeSpan(0, 7, 0, 0, 0)), null, null, "Spices, herbs and condiments", "Gia vị và nước chấm", "SpicesHerbsCondiments", null, null },
                    { 18, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 34, 673, DateTimeKind.Unspecified).AddTicks(9198), new TimeSpan(0, 7, 0, 0, 0)), null, null, "Food additives", "Phụ gia", "FoodAdditives", null, null }
                });

            migrationBuilder.InsertData(
                table: "ingredient",
                columns: new[] { "Id", "CategoryId", "CreateBy", "CreateTime", "DeleteBy", "DeleteTime", "Description", "ImageUrl", "LocalName", "Name", "UpdateBy", "UpdateTime" },
                values: new object[,]
                {
                    { new Guid("00282db1-b8e9-484a-ad38-859611c5d1a4"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Tép khô", "Tép khô", null, null },
                    { new Guid("019ffdd1-b979-4fb4-afb9-be6d36c4ea28"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Dưa bở", "Dưa bở", null, null },
                    { new Guid("01d3b990-45c1-4b21-b9da-c8d0463e8ede"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Rau đay", "Rau đay", null, null },
                    { new Guid("01e206e3-2f96-4d96-b004-f85847150ce8"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Sấu chín", "Sấu chín", null, null },
                    { new Guid("0250160d-8322-4370-9213-eb00b9483572"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "hạt", null, "Đậu đũa ", "Đậu đũa ", null, null },
                    { new Guid("02514204-bf5e-4b0f-aafe-115fd7ca8f71"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Thịt thỏ nhà", "Thịt thỏ nhà", null, null },
                    { new Guid("02dbb7b2-c952-468a-87e0-cd11c1a94e53"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "đậu tắt", null, "Đậu xanh ", "Đậu xanh ", null, null },
                    { new Guid("0364f839-5c7a-46f0-bb5f-513f3722bb42"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Phổi bò", "Phổi bò", null, null },
                    { new Guid("03c49126-3d23-4582-bf03-762a2a57ec5d"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cá mỡ", "Cá mỡ", null, null },
                    { new Guid("040a31eb-4338-4464-8b1b-af0d1713433b"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cá phèn", "Cá phèn", null, null },
                    { new Guid("0542993d-ebd6-42b3-bd8c-e312bb1620b8"), 2, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Khoai riềng", "Khoai riềng", null, null },
                    { new Guid("05935d5a-a5e1-424c-819a-f47156217e79"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Rau giền trắng", "Rau giền trắng", null, null },
                    { new Guid("06d346cc-80d5-468d-8837-e6e55de7429b"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Thịt trâu cổ", "Thịt trâu cổ", null, null },
                    { new Guid("07b3e79a-0987-48a4-b764-9e67682d0d89"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cá thu", "Cá thu", null, null },
                    { new Guid("07dc8e0c-45a1-4ce1-b15e-8a11f206a6d7"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Vải khô", "Vải khô", null, null },
                    { new Guid("08431582-8cd7-4355-972d-53872c7a4ea9"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cá đao", "Cá đao", null, null },
                    { new Guid("08c5576e-65d5-423d-9528-eb9ff2428dad"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Ôi", "Ôi", null, null },
                    { new Guid("08cd93c4-4b6d-42b9-93f1-645922534fff"), 3, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "hạt", null, "Đậu đen ", "Đậu đen ", null, null },
                    { new Guid("08d7c4ce-07f5-49a7-a7bb-9328a1340303"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Chuối tiêu", "Chuối tiêu", null, null },
                    { new Guid("096ec864-b983-4f40-8509-a7e40f92e6e1"), 15, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "cồn 24,2 g", null, "Rượu cam, chanh ", "Rượu cam, chanh ", null, null },
                    { new Guid("0aaff0cb-5f7d-4b46-b078-3c0a44b4560d"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "đậu nành", null, "Đậu tương ", "Đậu tương ", null, null },
                    { new Guid("0b2bbd64-1669-45d2-af5c-bc5bbf73ac59"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cá diếc", "Cá diếc", null, null },
                    { new Guid("0b3b9ebf-00b8-4e32-81eb-6a20684ef179"), 11, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Sữa bò tươi", "Sữa bò tươi", null, null },
                    { new Guid("0bb1dee2-2451-46bc-b770-47f410e111a9"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Măng tây", "Măng tây", null, null },
                    { new Guid("0c0c9f53-ce02-404a-a1cf-f45fa70e5d6e"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Rau sà lách", "Rau sà lách", null, null },
                    { new Guid("0d451d6b-d5b2-432a-9720-de3d957f4d07"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cá bống", "Cá bống", null, null },
                    { new Guid("0df00040-2a9e-40b0-a6db-724ac2d5ec5a"), 1, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Bánh phở", "Bánh phở", null, null },
                    { new Guid("0e22d30f-a43e-456c-9c5f-2ba4381adbb8"), 3, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "đậu tây", null, "Đậu trắng hạt ", "Đậu trắng hạt ", null, null },
                    { new Guid("0e6199ea-abed-45bb-b6a6-268d301153e1"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Lá sắn tươi", "Lá sắn tươi", null, null },
                    { new Guid("0e87c482-7c53-43e6-b049-faae1c18cfdf"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Men bia tươi", "Men bia tươi", null, null },
                    { new Guid("0e8a1e7d-0f37-4a42-92b0-9a93ba6e0f74"), 2, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Khoai lang", "Khoai lang", null, null },
                    { new Guid("0f3c92c2-6b41-40e9-862f-373048ddeb3c"), 1, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Mỳ sợi", "Mỳ sợi", null, null },
                    { new Guid("0f5db36b-d078-4ead-9080-5576d058aa96"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Ốc nhồi", "Ốc nhồi", null, null },
                    { new Guid("0f5f53b8-ec2c-41d9-b5c0-8f842e10aa96"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Tiết lợn luộc", "Tiết lợn luộc", null, null },
                    { new Guid("0f97a9c6-8042-4e6c-b32e-87a987fb1dc7"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Xúc xích", "Xúc xích", null, null },
                    { new Guid("0fe0872a-4211-4774-8580-399b1dd93c50"), 2, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Củ sắn dây", "Củ sắn dây", null, null },
                    { new Guid("105f3a5e-f8c2-4203-a511-68c5d908f5a8"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Bầu", "Bầu", null, null },
                    { new Guid("11a62581-25ce-4e33-84da-55eb7ba727e7"), 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Bột ca cao", "Bột ca cao", null, null },
                    { new Guid("120debab-e500-49d0-82d6-3211074f23a9"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cá thu đao", "Cá thu đao", null, null },
                    { new Guid("1252033e-f3e8-4733-ac7c-e43894863f4d"), 1, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Bỏng ngô", "Bỏng ngô", null, null },
                    { new Guid("125519eb-062d-4868-bbca-4ebbefed9efb"), 10, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Trứng cá", "Trứng cá", null, null },
                    { new Guid("12ef35d3-0220-49ed-8260-12a6ee5a41fd"), 2, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Khoai sọ", "Khoai sọ", null, null },
                    { new Guid("134061ce-66e3-4950-85ab-9c886c1c49f1"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Bầu dục lợn", "Bầu dục lợn", null, null },
                    { new Guid("136fef9b-49b9-4fd0-8b39-ca503f5c5f1f"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Đậu đũa", "Đậu đũa", null, null },
                    { new Guid("13c787e8-ad61-4314-9c92-622cd7f26900"), 2, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Trân châu sắn", "Trân châu sắn", null, null },
                    { new Guid("1402bbe0-e21d-4920-bd9f-bbb3f957c7a9"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Rươi", "Rươi", null, null },
                    { new Guid("146bf2b7-0d65-4225-99a2-88f50ae44968"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Rau má, má mơ", "Rau má, má mơ", null, null },
                    { new Guid("147e170f-1c64-4397-81d4-bae366c246ea"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Chuối tây", "Chuối tây", null, null },
                    { new Guid("15552610-8571-4822-ad8c-58520a9d20cb"), 14, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Mận nước đường", "Mận nước đường", null, null },
                    { new Guid("155abf33-9c95-46eb-b7d2-f68451ae1d5c"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Thịt dê, nạc", "Thịt dê, nạc", null, null },
                    { new Guid("1615b20a-ceb3-475c-9eff-ad59a3f1a91a"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cá đối", "Cá đối", null, null },
                    { new Guid("161e5033-cff3-40b7-a314-2ec80850868d"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Ớt xanh to", "Ớt xanh to", null, null },
                    { new Guid("164ac7f9-4d0a-4783-b86d-833e29565a14"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Mơ", "Mơ", null, null },
                    { new Guid("168b859f-5da8-4053-a828-f439b80f6813"), 14, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Nước dứa hộp", "Nước dứa hộp", null, null },
                    { new Guid("1703414d-dd3c-4f0b-a3b7-4a311245d126"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Lê", "Lê", null, null },
                    { new Guid("17f19052-dc06-4751-af31-93d6e5d464ae"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Xương sông", "Xương sông", null, null },
                    { new Guid("1880db4c-9e2f-4fee-a30e-bf092c7a494a"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cải soong", "Cải soong", null, null },
                    { new Guid("18b50e6e-dab1-4e19-b40c-fb4ef6a6b379"), 13, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Dầu cám gạo", "Dầu cám gạo", null, null },
                    { new Guid("194ca259-b3f0-442d-aac8-34ec16a1d2e9"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Rau diếp", "Rau diếp", null, null },
                    { new Guid("1969cb57-7f40-4396-b8dc-7e12bd6ec786"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Lá mơ lông", "Lá mơ lông", null, null },
                    { new Guid("197fea35-7df9-42fd-82fa-aa4f72358fb4"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Rau giền cơm", "Rau giền cơm", null, null },
                    { new Guid("1b275dd0-9bd1-40cd-bd1f-48584133334a"), 11, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "sữa người", null, "Sữa mẹ ", "Sữa mẹ ", null, null },
                    { new Guid("1b33b6c6-3bda-4403-aa6c-033f562bea96"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Lươn", "Lươn", null, null },
                    { new Guid("1b4fd41b-8f73-40f1-b622-f86606bba57b"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Rau rút", "Rau rút", null, null },
                    { new Guid("1c0fce1e-029a-4854-8696-0803496efce6"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cùi dừa già", "Cùi dừa già", null, null },
                    { new Guid("1c9df08f-6f2c-4972-88f7-81369f92f13f"), 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Kẹo bơ cứng", "Kẹo bơ cứng", null, null },
                    { new Guid("1ca31952-7ca9-4992-a213-69d37981b6b3"), 15, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "cồn 39 g", null, "Rượu trắng ", "Rượu trắng ", null, null },
                    { new Guid("1dac5887-b28a-464c-adb4-0230afefaafa"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Thịt bò, lưng, nạc", "Thịt bò, lưng, nạc", null, null },
                    { new Guid("1ee908a5-0685-48c0-985b-226d0b66a0bf"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Dọc mùng", "Dọc mùng", null, null },
                    { new Guid("1eee3bfe-3453-4d32-97a2-c3fa591314f9"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Nấm thường tươi", "Nấm thường tươi", null, null },
                    { new Guid("2063851b-db6f-435b-be8d-fd8385205650"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Dứa tây", "Dứa tây", null, null },
                    { new Guid("20b86d92-0280-41d2-aef1-97f673993193"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Ruốc tôm", "Ruốc tôm", null, null },
                    { new Guid("216f86f9-40ae-4a1e-a866-9758efa89b00"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Đầu lợn", "Đầu lợn", null, null },
                    { new Guid("219c357b-46bf-4fe5-87a6-6f9994dbe971"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Dưa cải bẹ", "Dưa cải bẹ", null, null },
                    { new Guid("21add5f7-9c89-46ed-976d-f0a053aae2a5"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "cải trắng", null, "Cải thìa ", "Cải thìa ", null, null },
                    { new Guid("21b118e2-c0ed-419f-a719-c9d2034f6279"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Thịt bò, lưng, nạc và mỡ", "Thịt bò, lưng, nạc và mỡ", null, null },
                    { new Guid("22276677-ba16-4140-bc1e-f88c865514ae"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Hạt dẻ khô", "Hạt dẻ khô", null, null },
                    { new Guid("22a195f6-8ebb-4135-9199-799d435cc48b"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Gân chân bò", "Gân chân bò", null, null },
                    { new Guid("22b5317b-4956-46ad-a772-f8ce712d5353"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Thịt trâu khô", "Thịt trâu khô", null, null },
                    { new Guid("22e65de2-1003-4b98-bf5b-d69305144d74"), 17, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Nghệ tươi", "Nghệ tươi", null, null },
                    { new Guid("22f326bd-a76b-48dc-8520-e80cfa599c48"), 10, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Lòng trắng trứng vịt", "Lòng trắng trứng vịt", null, null },
                    { new Guid("235e93df-1eda-4ff6-9876-ba7e152fa274"), 17, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Mắm tôm đặc", "Mắm tôm đặc", null, null },
                    { new Guid("23d8416d-f339-4ada-a0c8-8d6f17d837b1"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Trấm đen chín", "Trấm đen chín", null, null },
                    { new Guid("2523e50c-2b48-4be1-870d-2d0ad6bc1bf0"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cua ghẹ", "Cua ghẹ", null, null },
                    { new Guid("2524b2b5-db96-4b4c-ad7d-86a10a2412d8"), 10, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Trứng chim cút", "Trứng chim cút", null, null },
                    { new Guid("25dec0bc-03b8-4b4b-baa4-cfd39050232d"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "bỏ xương", null, "Sườn lợn ", "Sườn lợn ", null, null },
                    { new Guid("2634d200-21e2-4236-b522-83ee9cdb5510"), 13, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Bơ", "Bơ", null, null },
                    { new Guid("26b6efc2-26b4-4f19-91ee-f0ec5b1e63fa"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Tiết lợn sống", "Tiết lợn sống", null, null },
                    { new Guid("26bff982-4835-4571-a508-29ff73de980a"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Dưa hồng", "Dưa hồng", null, null },
                    { new Guid("27c1b514-f70e-44ca-b129-691f85395898"), 2, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Sắn khô", "Sắn khô", null, null },
                    { new Guid("27dd5499-36d1-445a-baa6-7b53de9c0f00"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Tim bò", "Tim bò", null, null },
                    { new Guid("280bf23a-193c-40df-930c-7a9e0cfdb25f"), 1, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Kê", "Kê", null, null },
                    { new Guid("2857a49b-d695-4937-8ae7-c7cc6fcd53d5"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Bánh phồng tôm sống", "Bánh phồng tôm sống", null, null },
                    { new Guid("2896a2ee-e42a-429d-9a65-c1e6b2ebe068"), 14, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Thịt lợn hộp", "Thịt lợn hộp", null, null },
                    { new Guid("28ed92d0-4e43-47ee-ba53-a9881eb4bac4"), 2, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Bột sắn dây", "Bột sắn dây", null, null },
                    { new Guid("29a1e6ed-de59-486e-9b1c-94ea0d8b2c2e"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Sấu xanh", "Sấu xanh", null, null },
                    { new Guid("29d9f14c-e0de-4e4d-905e-6c6a2a6a622f"), 13, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Mỡ lợn muối", "Mỡ lợn muối", null, null },
                    { new Guid("2a22e2ac-f0d7-4aa6-a2f2-52498a30a878"), 2, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Khoai tây khô", "Khoai tây khô", null, null },
                    { new Guid("2a531a66-1b75-4378-aa49-232c10abe816"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Quả trứng gà", "Quả trứng gà", null, null },
                    { new Guid("2ab225c1-bf04-4ef8-8ddc-6eb4494ffa5a"), 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "kẹo ngậm bạc hà", null, "Kẹo Pastille ", "Kẹo Pastille ", null, null },
                    { new Guid("2ae1bcb4-8482-49c6-80d1-67d06723c4b0"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Thịt gà tây", "Thịt gà tây", null, null },
                    { new Guid("2b83f631-8867-4977-92ff-ccd7a44802c9"), 17, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Xì dầu", "Xì dầu", null, null },
                    { new Guid("2b86582a-a2c8-4216-ac0b-f7a5da568ec9"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Rau sắng", "Rau sắng", null, null },
                    { new Guid("2b9fcaba-2326-42f0-b2f4-ecefbf12bd67"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cà bát", "Cà bát", null, null },
                    { new Guid("2c6d3e5c-bb15-4f3d-8db3-1165855876f5"), 17, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Ớt khô bột", "Ớt khô bột", null, null },
                    { new Guid("2ce53e97-2bef-4a31-b306-a09371cb4dd4"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Ốc vặn", "Ốc vặn", null, null },
                    { new Guid("2cea052f-db83-4c10-8334-3d9464df39b1"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Su hào khô", "Su hào khô", null, null },
                    { new Guid("2d517dbb-fcdb-4c6b-aa8f-d87753bd8990"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Đậu cô ve", "Đậu cô ve", null, null },
                    { new Guid("2d625097-25fa-4ba2-96aa-3835b1475e40"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Bầu dục bò", "Bầu dục bò", null, null },
                    { new Guid("2da5023c-4443-40c6-8f5c-0504632c06dd"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Rau mùi", "Rau mùi", null, null },
                    { new Guid("2dc78fd8-71dd-47cb-841a-c89c08e5acc0"), 10, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Trứng cá muối", "Trứng cá muối", null, null },
                    { new Guid("2ea4fb5e-1aa9-4219-a851-1cbf9ce3fee8"), 17, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Tương ngô", "Tương ngô", null, null },
                    { new Guid("2f308fa4-74dd-487e-b496-88d2df17457d"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Dưa chuột", "Dưa chuột", null, null },
                    { new Guid("2fe49dde-ac1c-4ccc-bf42-f99bf13c3c0f"), 1, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Gạo tẻ máy", "Gạo tẻ máy", null, null },
                    { new Guid("303fc42e-770e-4c11-bc48-e584010d949d"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Hành củ muối", "Hành củ muối", null, null },
                    { new Guid("30bfa00c-123b-4244-b8f9-a46b83606b8d"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cá ngừ", "Cá ngừ", null, null },
                    { new Guid("3123ccaf-068f-4dbe-8c77-d48a15578194"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cùi dừa non", "Cùi dừa non", null, null },
                    { new Guid("3142dcc7-dd15-4fc3-867a-dae82bf61a61"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Đuôi bò", "Đuôi bò", null, null },
                    { new Guid("3147a3c6-1cd5-4c8f-947d-edd78f9e2024"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Sò", "Sò", null, null },
                    { new Guid("31985e16-ca87-48b2-a440-dddb1bd394dd"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Mộc nhĩ", "Mộc nhĩ", null, null },
                    { new Guid("31b8a6ab-8a1b-4d9b-9450-0106bb3ed42c"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Bì lợn", "Bì lợn", null, null },
                    { new Guid("31b8b0b2-e4cf-4f8c-86f5-b891d040645d"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cải xanh", "Cải xanh", null, null },
                    { new Guid("326b0a3f-b31d-4aee-b2cd-256a266503da"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Nấm hương tươi", "Nấm hương tươi", null, null },
                    { new Guid("33a50ed9-1005-4512-a654-8f75ad3cacfa"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Nem chạo", "Nem chạo", null, null },
                    { new Guid("34b40945-6426-4a96-8d48-535d9fc3f308"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cá trắm cỏ", "Cá trắm cỏ", null, null },
                    { new Guid("35597084-9fab-49e4-84c2-0ab0f0319273"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Thịt bò khô", "Thịt bò khô", null, null },
                    { new Guid("35a4ca6b-0d84-4328-acc4-fb6e3ec96a3a"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Rau tàu bay", "Rau tàu bay", null, null },
                    { new Guid("35ae70c3-a954-42ee-8865-ad6ff0d7e976"), 1, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Bột gạo nếp", "Bột gạo nếp", null, null },
                    { new Guid("3686603b-0943-4e94-955a-d62ef9269086"), 15, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Nước quít tươi", "Nước quít tươi", null, null },
                    { new Guid("3732c05e-509d-4eb9-b8f5-0de23768d8fe"), 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Bánh khảo chay", "Bánh khảo chay", null, null },
                    { new Guid("37754b46-5aa9-4094-b3de-8a7b1a68496e"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Tim gà", "Tim gà", null, null },
                    { new Guid("378c9e63-f9fd-4ab7-b26e-64e478c659a1"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Dâu tây", "Dâu tây", null, null },
                    { new Guid("3791ce4e-a799-4f14-a7fb-94e002fae2c2"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Bột đậu xanh", "Bột đậu xanh", null, null },
                    { new Guid("37ac181e-1244-4101-82af-3976dcdd9d54"), 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Kẹo dứa mềm", "Kẹo dứa mềm", null, null },
                    { new Guid("3898fb28-3f4f-4ce2-bdf0-204f39e7469d"), 1, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Gạo nếp cái", "Gạo nếp cái", null, null },
                    { new Guid("39078d81-84a6-4ec1-b010-8b0fcfe43464"), 2, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Củ ấu", "Củ ấu", null, null },
                    { new Guid("3912ffa3-f783-40e6-b78b-8b7da8fa068c"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Ốc bươu", "Ốc bươu", null, null },
                    { new Guid("3a173308-8f65-4471-aea5-32a0cfb59010"), 2, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Khoai tây lát chiên", "Khoai tây lát chiên", null, null },
                    { new Guid("3b6e2c05-3a9e-4afe-baa5-84fb1b5f0e7f"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Tép gạo", "Tép gạo", null, null },
                    { new Guid("3b99334d-e818-4806-9a23-54159e70dfc9"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Dăm bông lợn", "Dăm bông lợn", null, null },
                    { new Guid("3ca52ec7-d4a7-4ebc-a3d1-3babc651aa93"), 2, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "bột đao", null, "Bột khoai riềng ", "Bột khoai riềng ", null, null },
                    { new Guid("3cd6e7fb-c5fd-41cf-ac02-5a56c81cc34a"), 13, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Dầu đậu tương", "Dầu đậu tương", null, null },
                    { new Guid("3d6da870-1ff7-41f6-9176-ca38453e2cf5"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Mực tươi", "Mực tươi", null, null },
                    { new Guid("3f298490-3c4a-4e7f-b5a8-ab5dece0ed7f"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Lá me", "Lá me", null, null },
                    { new Guid("3fcd43a7-71bc-4f15-a48e-c65689e73930"), 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Kẹo cà phê", "Kẹo cà phê", null, null },
                    { new Guid("4007274a-3c09-4239-acfe-d781dede057f"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Tào phớ", "Tào phớ", null, null },
                    { new Guid("40b2accd-8014-4dff-ab43-6ffaddae1e51"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Hạt dẻ tươi", "Hạt dẻ tươi", null, null },
                    { new Guid("40e4a0a9-4c71-4f43-82c8-38cfb33fcc8e"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cà muối sổi", "Cà muối sổi", null, null },
                    { new Guid("41904f33-a91c-44e8-9c83-d492e15d5609"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Ba tê", "Ba tê", null, null },
                    { new Guid("43535af9-0f26-437b-ad66-6d78b845c100"), 14, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Mứt chuối", "Mứt chuối", null, null },
                    { new Guid("43c21f02-5f46-4cc8-a75d-b57b90c8ba1e"), 3, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "đậu tắt", null, "Đậu xanh ", "Đậu xanh ", null, null },
                    { new Guid("43d208dc-ce2e-46e4-8b35-c36deb67993b"), 3, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "hạt", null, "Đậu Hà lan ", "Đậu Hà lan ", null, null },
                    { new Guid("44a1d99f-142b-4d55-8f1e-61c4637bf340"), 13, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Dầu ngô", "Dầu ngô", null, null },
                    { new Guid("456af7f5-6c7b-4d8e-a12d-370eb84a3abd"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Thịt lợn mỡ", "Thịt lợn mỡ", null, null },
                    { new Guid("45be3edf-056b-4913-8ee2-20b1d19b8160"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Mang tre", "Mang tre", null, null },
                    { new Guid("45f253da-9e1b-42e4-bf0d-c6876881e66c"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Vú sữa", "Vú sữa", null, null },
                    { new Guid("46ace5c4-0be5-4ece-a25e-010b889e3ef8"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "đậu tây", null, "Đậu trắng hạt ", "Đậu trắng hạt ", null, null },
                    { new Guid("46c5a200-3a09-4ea5-9f56-5d6eb9b98831"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Táo tây", "Táo tây", null, null },
                    { new Guid("47494e6c-0b49-4fda-817b-7ff777617a62"), 1, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Bánh đa nem", "Bánh đa nem", null, null },
                    { new Guid("47a0ea8d-490f-4290-b61e-f25eaa2d1a98"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Dưa hấu", "Dưa hấu", null, null },
                    { new Guid("48131e67-5119-4092-bd8c-f407ad8c86bf"), 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Bánh thỏi sô cô la", "Bánh thỏi sô cô la", null, null },
                    { new Guid("4846b30b-0084-49ed-a20f-885fc8f0ec0c"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Táo ta", "Táo ta", null, null },
                    { new Guid("484c5617-b287-4fa8-8b2b-e6f2c0f9ef62"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Men bia khô", "Men bia khô", null, null },
                    { new Guid("488b99c1-622d-4995-844c-2f3af749640b"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Quả thanh long", "Quả thanh long", null, null },
                    { new Guid("4a5602cd-56eb-495d-b922-3d7f0ab50fce"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "hạt", null, "Đậu cô ve ", "Đậu cô ve ", null, null },
                    { new Guid("4ad4af1b-d9d5-4cf7-bec2-5dc7eea83ee6"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Chuối xanh", "Chuối xanh", null, null },
                    { new Guid("4b1cb7c9-cab7-4cf7-8c7d-7d9cef3980f4"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Tôm đồng", "Tôm đồng", null, null },
                    { new Guid("4b936cbe-7472-4510-8885-f783025a93e0"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Hạt sen khô", "Hạt sen khô", null, null },
                    { new Guid("4bc16bbb-6f83-44fb-8cd5-5b3ac5c2db34"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cá hồi", "Cá hồi", null, null },
                    { new Guid("4bf9e357-0da8-48ce-bddf-0232ae22f5d9"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Gan bò", "Gan bò", null, null },
                    { new Guid("4c0bfb5b-48d5-484b-9465-0c1893993138"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Thịt bò loại II", "Thịt bò loại II", null, null },
                    { new Guid("4c2a9f77-5f27-4eac-9e39-060f88b572f9"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Bột lạc", "Bột lạc", null, null },
                    { new Guid("4cbe0144-1e2b-4de3-9dfd-86365af6c447"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Thịt cho vai", "Thịt cho vai", null, null },
                    { new Guid("4d008a84-7df6-43fc-8ed7-e9bd1ff16f39"), 14, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Thịt bò hộp", "Thịt bò hộp", null, null },
                    { new Guid("4d25227d-3f9f-4f3c-8015-edd376e4520d"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "cả bộ", null, "Lòng gà ", "Lòng gà ", null, null },
                    { new Guid("4f04b033-a772-4e66-9ed9-dd6cfd2af2dc"), 11, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Sữa dê tươi", "Sữa dê tươi", null, null },
                    { new Guid("4f5a082a-a5c2-41de-a74c-74e878ab9dfa"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cá trôi", "Cá trôi", null, null },
                    { new Guid("5004858c-08c4-4487-9672-5fa59535ab23"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cải bắp", "Cải bắp", null, null },
                    { new Guid("514ddd01-cfc7-43b5-a2b7-8e159da24390"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Hạt bí đỏ rang", "Hạt bí đỏ rang", null, null },
                    { new Guid("51b4cf84-5de0-41dc-a8e8-aa26307f81f9"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "cả vỏ", null, "Quất chín ", "Quất chín ", null, null },
                    { new Guid("524768a2-172d-47f2-b052-1c0dc6fdfa51"), 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Bánh chả", "Bánh chả", null, null },
                    { new Guid("5266685d-53ee-475c-ba99-883ff14990a8"), 2, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Củ cái", "Củ cái", null, null },
                    { new Guid("532bb198-075e-4ec3-95ad-9c6f38c448c9"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cải cúc", "Cải cúc", null, null },
                    { new Guid("5408a46a-7732-4417-8620-eaf5aa91a315"), 13, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Dầu cọ", "Dầu cọ", null, null },
                    { new Guid("544ce65b-b406-442a-9ab2-9b75ee5ee592"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Sầu riêng", "Sầu riêng", null, null },
                    { new Guid("550b1a5f-e9e6-4279-8ef1-2cac45d8e149"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Quả cọ tươi", "Quả cọ tươi", null, null },
                    { new Guid("551b6d2c-c7f9-45b4-a55c-ff932d8f1655"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Giá đậu tương", "Giá đậu tương", null, null },
                    { new Guid("56a41e6d-5a5b-4319-bee6-daca1ac97aea"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Chôm chôm", "Chôm chôm", null, null },
                    { new Guid("57973063-70ba-402b-8cc6-730898fddbce"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Nho ngọt", "Nho ngọt", null, null },
                    { new Guid("57ad9a43-d18e-4f6b-bcbd-ed58b5320216"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Quả bơ vỏ xanh", "Quả bơ vỏ xanh", null, null },
                    { new Guid("58ad4f22-ed52-4fc7-a62c-3480bc8b7aa5"), 10, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Lòng đỏ trứng gà", "Lòng đỏ trứng gà", null, null },
                    { new Guid("5960af09-e3ca-4139-a8af-b75f73e8c91b"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cá chép", "Cá chép", null, null },
                    { new Guid("59e798d0-7079-45be-b2f5-fcd2663eae63"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Xoài chín", "Xoài chín", null, null },
                    { new Guid("5a6df59c-b8f8-485c-b099-3c6ac1204668"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Vải", "Vải", null, null },
                    { new Guid("5b35c921-1355-42ef-bba0-993a5599da28"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Lạp xường", "Lạp xường", null, null },
                    { new Guid("5b6dbdc0-e17c-45c8-8dee-75735fb2792e"), 17, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Nước mắm cô", "Nước mắm cô", null, null },
                    { new Guid("5cffdc2b-eaa8-456e-acdd-b80d75b868d3"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Súp lơ xanh", "Súp lơ xanh", null, null },
                    { new Guid("5d5ddf33-9bd2-45f2-9aed-9d484d2201bd"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Thịt cho sấn", "Thịt cho sấn", null, null },
                    { new Guid("5df8cb3c-a80b-4519-9917-4481723f26ab"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "cá sardin", null, "Cá mòi ", "Cá mòi ", null, null },
                    { new Guid("5e0bf2ae-68ce-4cdc-9ba6-6338a31aa111"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Đầu bò", "Đầu bò", null, null },
                    { new Guid("5e27e6e6-6439-4d25-9eff-a85077dca9ea"), 15, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "80g/ 24 ml cồn 5 g", null, "Rượu nếp ", "Rượu nếp ", null, null },
                    { new Guid("5ec892ae-80e2-4c92-a220-ff4a935efd16"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Ruốc cá quả", "Ruốc cá quả", null, null },
                    { new Guid("5f2138ec-3a67-4539-8d3d-035386573d9e"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Hạt sen tươi", "Hạt sen tươi", null, null },
                    { new Guid("5f3fbc3e-f75f-4192-8577-1db2f63a0cc8"), 1, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Gạo tẻ giã", "Gạo tẻ giã", null, null },
                    { new Guid("5feee0fc-0ed8-46bd-8c0f-fbc66a6e23cd"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Nem chua", "Nem chua", null, null },
                    { new Guid("60031f14-bc96-407f-92dd-7ba25f566685"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Chanh", "Chanh", null, null },
                    { new Guid("600b48df-4f97-439b-a501-b9ff32e8e628"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Giò bò", "Giò bò", null, null },
                    { new Guid("608a6d35-397d-41d3-90dc-679218611e32"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Hải sâm", "Hải sâm", null, null },
                    { new Guid("61822957-2e08-4d69-8011-374b055a9123"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Ốc đá", "Ốc đá", null, null },
                    { new Guid("6284b6b1-814f-4fd4-b87d-b575a6051740"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Dưa cải sen", "Dưa cải sen", null, null },
                    { new Guid("6355f157-e11c-46b4-b94a-a12054237e84"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Rau giấp cá, diếp cá", "Rau giấp cá, diếp cá", null, null },
                    { new Guid("636b2af1-c955-4f3d-8f70-b71e9c6566a9"), 1, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Gạo nếp máy", "Gạo nếp máy", null, null },
                    { new Guid("638865b1-7eb1-4625-85e7-d77e8c2621ff"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Hồng đỏ", "Hồng đỏ", null, null },
                    { new Guid("6396df9a-655b-4968-954a-686cead60c42"), 14, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Mứt bí ngô", "Mứt bí ngô", null, null },
                    { new Guid("63b18c7d-3bab-41cd-840d-a51dac63c6ec"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Dạ dày lợn", "Dạ dày lợn", null, null },
                    { new Guid("642a7f5c-6f85-4575-92db-f4331070b217"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Tủy xương bò", "Tủy xương bò", null, null },
                    { new Guid("64e2e587-36a3-4b63-8f8d-8f6393e1aebe"), 1, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Bánh đúc", "Bánh đúc", null, null },
                    { new Guid("659c6cc9-02a3-4b2f-ab9b-b014fcd22d81"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cá mối", "Cá mối", null, null },
                    { new Guid("65d7a69e-7a91-4b4d-9b74-1549037489cb"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cá trích", "Cá trích", null, null },
                    { new Guid("65f64391-4106-4b85-be05-0f1960f47124"), 11, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Sữa chua", "Sữa chua", null, null },
                    { new Guid("670eb681-96d4-4936-a535-75925a189e63"), 2, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "lọc", null, "Bột khoai tây ", "Bột khoai tây ", null, null },
                    { new Guid("6711f020-3064-4392-bd05-a392e5206094"), 14, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cá trích hộp", "Cá trích hộp", null, null },
                    { new Guid("68c81c05-06e8-4711-a5c2-581d8cd8a66f"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Thịt cừu, nạc", "Thịt cừu, nạc", null, null },
                    { new Guid("694374d4-9109-422d-978b-743aa4f4f208"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Dưa lê", "Dưa lê", null, null },
                    { new Guid("69d37711-c590-4d31-9965-d2a7eab4ec46"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Mề gà", "Mề gà", null, null },
                    { new Guid("69fe5891-0e48-4da5-9810-4acdeaa8c6c2"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Quả kiwi", "Quả kiwi", null, null },
                    { new Guid("6b456e21-57f5-4dfb-befe-223f372f58aa"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cải bắp khô", "Cải bắp khô", null, null },
                    { new Guid("6ba8e641-1cf5-447d-93dc-0dfcb6bf45d5"), 13, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "Lạc, vừng, cám ... ", null, "Dầu thảo mộc ", "Dầu thảo mộc ", null, null },
                    { new Guid("6baf7fd8-85ea-45c5-bba0-85513d6cc446"), 10, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Lòng trắng trứng gà", "Lòng trắng trứng gà", null, null },
                    { new Guid("6bc1f84e-04e3-4ee8-aa36-e888fa4d9690"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cà muối nén", "Cà muối nén", null, null },
                    { new Guid("6bc6a663-b33e-448b-8867-0deab894ec05"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "quả non", null, "Đậu rồng ", "Đậu rồng ", null, null },
                    { new Guid("6d047733-f895-4462-9d75-2de2de5c79eb"), 3, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "đậu nành", null, "Đậu tương ", "Đậu tương ", null, null },
                    { new Guid("6d241124-aeaf-4b2e-a63f-aaf0aa47008b"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Mắc coọc", "Mắc coọc", null, null },
                    { new Guid("6dd5b940-2417-4da2-b961-6209f047e54b"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "ruột non", null, "Lòng lợn ", "Lòng lợn ", null, null },
                    { new Guid("6e36541f-6595-4818-b4c6-039b0941321e"), 1, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Bánh mỳ", "Bánh mỳ", null, null },
                    { new Guid("6e78880a-5e10-4010-ad1a-3d3fe08909ee"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Tim lợn", "Tim lợn", null, null },
                    { new Guid("6eae164d-40f8-4abc-97a8-c95bcca13f86"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Ruốc thịt lợn", "Ruốc thịt lợn", null, null },
                    { new Guid("7033d00a-2ee0-4339-b6d9-ca35c93a267b"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Gấc", "Gấc", null, null },
                    { new Guid("704dcc53-c0d5-4b24-be46-c45668a2ad8b"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Bột cóc", "Bột cóc", null, null },
                    { new Guid("7196477e-fff1-4afa-b9f4-0cb451b3c06c"), 14, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Thịt lợn, thịt bò xay hộp", "Thịt lợn, thịt bò xay hộp", null, null },
                    { new Guid("71f094f2-9390-4904-a8f6-f3e67b33ae0a"), 11, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Sữa bột tách béo", "Sữa bột tách béo", null, null },
                    { new Guid("730632b9-1a75-4645-a807-c13864024046"), 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Mạch nha", "Mạch nha", null, null },
                    { new Guid("7361a60b-fb02-4b62-a362-b13c09d58bd0"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Đậu Hà Lan", "Đậu Hà Lan", null, null },
                    { new Guid("7377ba44-9750-4e07-953c-57254fc5e1a1"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Tôm biển", "Tôm biển", null, null },
                    { new Guid("73a4c9ac-48c3-4e97-90b6-371496b659a9"), 1, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Bột gạo tẻ", "Bột gạo tẻ", null, null },
                    { new Guid("74244f14-cdad-4281-b411-78e7c1165576"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Bưởi", "Bưởi", null, null },
                    { new Guid("744eb4bf-076d-4476-aab6-6d9042db0b7c"), 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Bánh đậu xanh", "Bánh đậu xanh", null, null },
                    { new Guid("755147a1-5b1d-4570-b412-6e6dc9328a9e"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Đậu phụ", "Đậu phụ", null, null },
                    { new Guid("75a94139-74e6-4337-9fa6-488443fda198"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Lạc hạt", "Lạc hạt", null, null },
                    { new Guid("763f68d6-6769-4d27-a489-6af214906fd8"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Rau khoai lang", "Rau khoai lang", null, null },
                    { new Guid("7683f5d0-b287-463b-8448-230c325bc822"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Mực khô", "Mực khô", null, null },
                    { new Guid("76d94c59-964b-4dfb-8d2e-edab5990b825"), 1, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Ngô vàng hạt khô", "Ngô vàng hạt khô", null, null },
                    { new Guid("773355f7-bbfb-4e23-9ab3-9f5aaaea82fa"), 17, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Tương nếp", "Tương nếp", null, null },
                    { new Guid("783be57c-e228-4cce-9b63-876306576996"), 13, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Dầu mè", "Dầu mè", null, null },
                    { new Guid("78951f90-7645-41df-91f0-367847f2daba"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cá rô phi", "Cá rô phi", null, null },
                    { new Guid("79408e2e-a3ad-4c48-abed-7198583d3f11"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Chả quế lợn", "Chả quế lợn", null, null },
                    { new Guid("79ee0a41-83dc-47d9-a77d-abfd775836ff"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Mận", "Mận", null, null },
                    { new Guid("7a2cdfef-d049-4561-a49a-17a74655b1ce"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Củ cải trắng", "Củ cải trắng", null, null },
                    { new Guid("7b491975-d4aa-47bf-87a1-a99513992d30"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Ớt vàng to", "Ớt vàng to", null, null },
                    { new Guid("7b91272f-47d4-41fd-8084-9eb79ecd15cb"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Quít", "Quít", null, null },
                    { new Guid("7bce09c5-57b4-461d-9cd8-26cd65b4ccef"), 1, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cốm", "Cốm", null, null },
                    { new Guid("7d73a161-76f6-426b-96a2-228cfb4c1163"), 3, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "hạt", null, "Đậu đũa ", "Đậu đũa ", null, null },
                    { new Guid("7f17a7f6-0985-4c84-ae87-bab62cb6f00e"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Tủy xương lợn", "Tủy xương lợn", null, null },
                    { new Guid("7f2acd61-0641-43a9-bf13-8905395f53fc"), 13, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Dầu lạc", "Dầu lạc", null, null },
                    { new Guid("7f8fa0fd-2f54-49c8-9c95-c374f1595f56"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Quả bơ vỏ tím", "Quả bơ vỏ tím", null, null },
                    { new Guid("80b88a00-cb3d-4fe8-936c-1efff80ff0af"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Lưỡi lợn", "Lưỡi lợn", null, null },
                    { new Guid("80ff4803-1778-427c-b645-37afd2edb274"), 17, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Nghệ khô, bột", "Nghệ khô, bột", null, null },
                    { new Guid("81675d66-3a9e-46a1-9001-f7b0ae34a0d6"), 13, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Dầu oliu", "Dầu oliu", null, null },
                    { new Guid("832826e5-c480-4679-a638-1611e84d3a4f"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Hoa chuối", "Hoa chuối", null, null },
                    { new Guid("839147c4-9584-4237-81c1-acc26824cb24"), 11, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Pho mát", "Pho mát", null, null },
                    { new Guid("83b25061-81fb-447b-938a-bd17924e7f32"), 17, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Magi", "Magi", null, null },
                    { new Guid("83ee71bc-02ff-4774-b6bb-132a9bbab893"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "đậu nành", null, "Bột đậu tương đã loại béo ", "Bột đậu tương đã loại béo ", null, null },
                    { new Guid("84e35d27-c7fe-4a5d-b8fe-abddbdf83904"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Bí ngô", "Bí ngô", null, null },
                    { new Guid("85577fc6-e11f-45f6-a3ee-72611af363e0"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Mãng cầu xiêm", "Mãng cầu xiêm", null, null },
                    { new Guid("86190cfe-7305-4602-8684-a6634c2d578a"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Tôm khô", "Tôm khô", null, null },
                    { new Guid("861aab7f-e03e-4aa5-89fc-a711f9cde5ff"), 17, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Muối", "Muối", null, null },
                    { new Guid("870d1af2-d9b8-4094-959f-035b4da4cd5e"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Su hào", "Su hào", null, null },
                    { new Guid("87e70274-aecf-4c61-80b7-f51c5833777d"), 2, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Bột dong lọc", "Bột dong lọc", null, null },
                    { new Guid("881ee878-7ecd-4819-8ce2-1ee8a32a340f"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Đậu trứng cuốc", "Đậu trứng cuốc", null, null },
                    { new Guid("88a8f491-4946-45e4-85fa-5e3f5419320c"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Sữa bột đậu nành", "Sữa bột đậu nành", null, null },
                    { new Guid("88b95530-c706-473e-82c3-f2ee46a64bad"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Thịt trâu", "Thịt trâu", null, null },
                    { new Guid("8922f068-d8ff-4bbb-bd09-07d20b1de925"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cua đồng", "Cua đồng", null, null },
                    { new Guid("8938a49c-df22-4039-be82-e497c3f33277"), 11, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Sữa chua vớt béo", "Sữa chua vớt béo", null, null },
                    { new Guid("89783610-7188-4941-9815-2ff947f55012"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Mướp", "Mướp", null, null },
                    { new Guid("8a26ab8b-f057-42f1-ab15-a2b011c5dafe"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cá rô đồng", "Cá rô đồng", null, null },
                    { new Guid("8ac6e8ef-2a42-41dc-adcc-ab8ebc8eba49"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Đu đủ xanh", "Đu đủ xanh", null, null },
                    { new Guid("8aeea358-f8d5-4a63-b024-b86f029f78c0"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Mướp đắng", "Mướp đắng", null, null },
                    { new Guid("8b3a9a9b-60a1-4ebc-a2f1-b0ab44f3f75d"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Rau muống khô", "Rau muống khô", null, null },
                    { new Guid("8b4d69c6-d83f-4437-8b24-1f9a3ae53cc9"), 17, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Tương ớt", "Tương ớt", null, null },
                    { new Guid("8b6bb550-9f8c-48db-a331-22951e003402"), 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Bánh bích quy", "Bánh bích quy", null, null },
                    { new Guid("8ba96c03-5453-41dc-8795-c1f2b040eecc"), 17, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Gừng tươi", "Gừng tươi", null, null },
                    { new Guid("8c26169a-6dc1-4a29-9d9d-d1fbc0aa19eb"), 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Bánh quế", "Bánh quế", null, null },
                    { new Guid("8c58dc8c-b19a-44cb-9d58-ba49d67077b2"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Rau thơm", "Rau thơm", null, null },
                    { new Guid("8c7e1d5e-5d3c-4bcd-83f1-23edbd1f2d24"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Thìa là", "Thìa là", null, null },
                    { new Guid("8cea36e4-f405-4c97-b594-a4e5ca8b231b"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Măng chua", "Măng chua", null, null },
                    { new Guid("8cee0355-56ed-4116-ab0a-f458f34bdf88"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Quả me chua", "Quả me chua", null, null },
                    { new Guid("8f743833-92a4-4272-83c7-7b5bc753582b"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Mít khô", "Mít khô", null, null },
                    { new Guid("8f7d906a-6c3f-4e72-8048-6a1bdcfbbf7d"), 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Kẹo số cô la", "Kẹo số cô la", null, null },
                    { new Guid("8f8c3702-2891-48a0-8b53-a8a1b4b0a485"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cá nục", "Cá nục", null, null },
                    { new Guid("8f8ff33d-70ee-4da9-962b-7a0279fa913c"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Củ đậu", "Củ đậu", null, null },
                    { new Guid("8fbf5c4d-eef7-4c00-b261-8099d32a923c"), 15, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "cồn 9,5 g", null, "Rượu vang đô ", "Rượu vang đô ", null, null },
                    { new Guid("91028958-beef-42c5-a979-2ad7a6df5f7d"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Măng khô", "Măng khô", null, null },
                    { new Guid("9102cbbd-b835-4e84-8864-f03e38b4c7d5"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Hạt điều", "Hạt điều", null, null },
                    { new Guid("9124ff97-eeee-4380-ac75-02b5f2b4b51c"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cần ta", "Cần ta", null, null },
                    { new Guid("912d5720-9a7c-4fd6-b009-f6f1a6fe1ba7"), 11, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Sữa đặc có đường Việt Nam", "Sữa đặc có đường Việt Nam", null, null },
                    { new Guid("936e7362-edc0-4007-b709-fd44c0a3f00a"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Dưa gang", "Dưa gang", null, null },
                    { new Guid("937aaebf-977a-4650-b281-3643f4307874"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Lá lốt", "Lá lốt", null, null },
                    { new Guid("93e326a1-97dc-43d4-b22b-fc5951c901e6"), 14, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Chuối nước đường", "Chuối nước đường", null, null },
                    { new Guid("94e2b16d-98e4-44ea-802f-35de610a1461"), 14, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Thịt vịt hầm", "Thịt vịt hầm", null, null },
                    { new Guid("955418bf-6774-44dd-be40-f1e325b720f3"), 15, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "cồn 9,5 g", null, "Rượu vang trắng ", "Rượu vang trắng ", null, null },
                    { new Guid("95769ee3-c251-408a-8d72-cebea39de1c3"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cá trạch", "Cá trạch", null, null },
                    { new Guid("95cb2818-e58d-4190-8205-b6c977b7957d"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Tiết bò", "Tiết bò", null, null },
                    { new Guid("9736d3a5-adb6-41da-bdd6-e9d314f43b77"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cà pháo", "Cà pháo", null, null },
                    { new Guid("973c39c9-279c-4190-a89e-7f970077caa7"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Dứa ta", "Dứa ta", null, null },
                    { new Guid("97a296df-54fd-46d2-996d-778e55cb9c08"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Châu chấu", "Châu chấu", null, null },
                    { new Guid("981dca66-4b72-497b-9956-a6ee515756b7"), 14, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Mắc coọc nước đường", "Mắc coọc nước đường", null, null },
                    { new Guid("9838a769-d73a-47c6-9f05-c893b9208311"), 2, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Khoai môn", "Khoai môn", null, null },
                    { new Guid("987a6b3b-774d-48a9-a34e-f41f6a01e76d"), 10, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Lòng đỏ trứng vịt", "Lòng đỏ trứng vịt", null, null },
                    { new Guid("987f6936-c845-4dc0-9393-b3c9c4a0ea39"), 14, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cá thu hộp", "Cá thu hộp", null, null },
                    { new Guid("98f3aa2f-e4f9-4e4f-9901-e3354155740c"), 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Kẹo vừng viên", "Kẹo vừng viên", null, null },
                    { new Guid("9a604e2c-8ba5-46be-85f5-08a86bf1a1ff"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Hạt đen", "Hạt đen", null, null },
                    { new Guid("9b1d4b84-b0ca-43dd-be78-e83977aa872b"), 11, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Sữa bột toàn phần", "Sữa bột toàn phần", null, null },
                    { new Guid("9b283cca-e3a3-42a3-b5da-e703100038bf"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Lựu", "Lựu", null, null },
                    { new Guid("9c5da4cb-fcbc-4bd2-9d29-c3148fb28e08"), 1, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Ngô nếp luộc", "Ngô nếp luộc", null, null },
                    { new Guid("9d00fc4e-a415-4529-acb8-bec7cbc15904"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Thịt bò loại I", "Thịt bò loại I", null, null },
                    { new Guid("9d21a667-1e93-47b4-af51-b1d1c7df8581"), 2, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Củ từ", "Củ từ", null, null },
                    { new Guid("9d575994-6418-4a47-be2f-0acf5c75f1dd"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Khế", "Khế", null, null },
                    { new Guid("9d60aaeb-bb30-4eba-b951-cd8677433fec"), 15, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "cồn 10.2 g", null, "Rượu vang trắng ngọt ", "Rượu vang trắng ngọt ", null, null },
                    { new Guid("9d7c97a0-1054-4c58-9193-f03d962b82f8"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Ngó sen", "Ngó sen", null, null },
                    { new Guid("9d8797f0-fffe-4afd-8ce8-3d4f8e35ad7e"), 13, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Dầu dừa", "Dầu dừa", null, null },
                    { new Guid("9e32b7ab-308f-4b82-8b72-0f0451ccf31b"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Thịt trâu bắp", "Thịt trâu bắp", null, null },
                    { new Guid("9ed4740b-6d89-4f65-a82f-7eda19e427e3"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Súp lo trắng", "Súp lo trắng", null, null },
                    { new Guid("a07f5405-f19f-4355-a35a-f60e357e9edf"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Thịt bồ câu ra ràng", "Thịt bồ câu ra ràng", null, null },
                    { new Guid("a08c5722-2668-4a88-ae2e-2fab2874bd25"), 15, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Nước khoáng", "Nước khoáng", null, null },
                    { new Guid("a109c5ce-a384-4786-a86a-bc593767e0fd"), 17, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "bột", null, "Gừng khô ", "Gừng khô ", null, null },
                    { new Guid("a1582c0c-1716-4e87-819b-cbb8bd7121a7"), 2, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Khoai tây", "Khoai tây", null, null },
                    { new Guid("a178ec44-1cd5-4257-bbb5-806f8cb68c0d"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Thịt trâu thăn", "Thịt trâu thăn", null, null },
                    { new Guid("a1d63acd-52cd-4d1b-abba-d6f4c80f37f5"), 15, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "cồn 35,2 g", null, "Rượu Whisky ", "Rượu Whisky ", null, null },
                    { new Guid("a1f967eb-0479-4278-8cc9-49f1c507099a"), 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Kẹo lạc", "Kẹo lạc", null, null },
                    { new Guid("a2b8c100-7471-484e-93b5-6cd6953031d7"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Rau muống", "Rau muống", null, null },
                    { new Guid("a44d4820-90dc-4355-b523-45b5ce1a5a47"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Thịt hươu", "Thịt hươu", null, null },
                    { new Guid("a47073a7-f113-46c5-adbb-615b2d9f6624"), 14, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Nhãn nước đường", "Nhãn nước đường", null, null },
                    { new Guid("a55d567f-9745-40dc-8f84-61cb9f8c500e"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cà rốt khô", "Cà rốt khô", null, null },
                    { new Guid("a5ee9125-b510-48ce-b772-e6981492fbd3"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "bỏ xương", null, "Chân giò lợn ", "Chân giò lợn ", null, null },
                    { new Guid("a5ef7202-7080-47bb-ae35-a974464f34b0"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Rau mồng tơi", "Rau mồng tơi", null, null },
                    { new Guid("a6058af0-f6f0-4b6a-be39-ad8473edb83f"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Mít mật", "Mít mật", null, null },
                    { new Guid("a62e1a7d-e6c7-432d-befd-0507ed292c14"), 17, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Mắm tép chua", "Mắm tép chua", null, null },
                    { new Guid("a6db2505-3c2c-4d62-add6-32b16cff8059"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Ngô bao tử", "Ngô bao tử", null, null },
                    { new Guid("a71d6cb8-df0b-48e0-a5c2-fcf3cbac24c8"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "chim, thu, nụ, đé", null, "Cá khô", "Cá khô", null, null },
                    { new Guid("a80ecb3e-b6cc-4d48-9fe0-b9e420b4e375"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "đen, trắng", null, "Vừng ", "Vừng ", null, null },
                    { new Guid("a887b01f-f40f-4440-baa2-5bbfd67327a4"), 15, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Nước dừa non tươi", "Nước dừa non tươi", null, null },
                    { new Guid("a8c0c0ad-3f29-4729-8243-5243ca16d76f"), 10, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Trứng vịt", "Trứng vịt", null, null },
                    { new Guid("a9812105-ab32-4654-b316-0bd4fe1ae190"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cà chua", "Cà chua", null, null },
                    { new Guid("a9bf8565-4bfd-4a86-815e-c5ac5a69ba98"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cá nạc", "Cá nạc", null, null },
                    { new Guid("aa577961-6f1b-4520-ba7d-58a394f50ed9"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Na", "Na", null, null },
                    { new Guid("aa9918d6-7063-402d-8513-d18450fda1d3"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cần tây", "Cần tây", null, null },
                    { new Guid("aac42f99-a2cf-4f8f-9a49-c5def18de377"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "non", null, "Dọc củ cải ", "Dọc củ cải ", null, null },
                    { new Guid("ab3d91d4-381f-4577-a85c-efbab9f6a897"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Giá đậu xanh", "Giá đậu xanh", null, null },
                    { new Guid("ab476d34-bc96-452c-9efc-0f72eb232a08"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Chả lợn", "Chả lợn", null, null },
                    { new Guid("ab64ffd8-14b8-444b-8ba7-f99fc3b983ac"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "nho chua", null, "Nho ta ", "Nho ta ", null, null },
                    { new Guid("abd63df4-73bb-4021-89b3-64e4fd9cbae7"), 14, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Mứt dứa", "Mứt dứa", null, null },
                    { new Guid("abf09597-af9a-41ca-9e0a-b9fb90fa244a"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cua bể", "Cua bể", null, null },
                    { new Guid("ac3d3392-f225-4ebf-aaab-005698ae802f"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Bột cá", "Bột cá", null, null },
                    { new Guid("ac425875-ac21-43f6-a985-7d60044b46f7"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Óc lợn", "Óc lợn", null, null },
                    { new Guid("aca82f78-a97c-47cb-9e19-05f6335861e1"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Rau giền đỏ", "Rau giền đỏ", null, null },
                    { new Guid("acc3428f-f678-4351-8eb1-bb3716a909ad"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Giò thủ lợn", "Giò thủ lợn", null, null },
                    { new Guid("ace333f3-8d5c-4732-b794-cc380d61099c"), 14, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Mứt cam có vỏ", "Mứt cam có vỏ", null, null },
                    { new Guid("ae1d16ab-a64a-4679-801a-89e9eee0820a"), 2, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Bột sắn", "Bột sắn", null, null },
                    { new Guid("af0a7504-a04a-4bf6-90a2-89abbf56b8e7"), 13, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Mỡ lợn nước", "Mỡ lợn nước", null, null },
                    { new Guid("af18fb0b-9c4c-4f5c-9eb8-287cdb57cc7f"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Nhãn khô", "Nhãn khô", null, null },
                    { new Guid("b11c2226-5d69-4cc7-a7ce-a748959614f1"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Phổi lợn", "Phổi lợn", null, null },
                    { new Guid("b1262421-2e5b-4b83-ad58-78da1f0a3328"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Củ cải đỏ", "Củ cải đỏ", null, null },
                    { new Guid("b2593f9f-f010-4253-9da8-a3993ebced9c"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cá dầu", "Cá dầu", null, null },
                    { new Guid("b2f2811e-2695-46e2-a042-30980ae175bc"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Đu đủ chín", "Đu đủ chín", null, null },
                    { new Guid("b36f56a8-b05f-49b5-a1c4-ebf12b3ace13"), 1, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Bánh quẩy", "Bánh quẩy", null, null },
                    { new Guid("b57c07ed-5ccb-41ae-8711-1b09df4bf765"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Mướp Nhật bản", "Mướp Nhật bản", null, null },
                    { new Guid("b5b87052-65f9-4ea9-bb01-82244c101993"), 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Kẹo sữa", "Kẹo sữa", null, null },
                    { new Guid("b60070c6-5692-42ff-a34d-0f721147d73f"), 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Mật ong", "Mật ong", null, null },
                    { new Guid("b657895c-3b98-4117-9c9e-28e1650496bc"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Rau câu khô", "Rau câu khô", null, null },
                    { new Guid("b6a7a7da-af18-42b5-9966-3f5ab573cbba"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Gioi", "Gioi", null, null },
                    { new Guid("b6ba2566-8cc7-409e-afab-2d488fa531a3"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Dồi lợn", "Dồi lợn", null, null },
                    { new Guid("b7ca38a4-77dd-4e14-82f3-08564f5520ae"), 17, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Nước mắm loại II", "Nước mắm loại II", null, null },
                    { new Guid("b7e5fd62-0844-478f-9ee4-ddbb90cd4bdd"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Hẹ lá", "Hẹ lá", null, null },
                    { new Guid("b80fe6ee-9310-4eba-9412-87867ed9afb6"), 1, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Ngô bắp tươi", "Ngô bắp tươi", null, null },
                    { new Guid("b98ec7ad-b045-40d6-a639-508c93dd634c"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Rạm tươi", "Rạm tươi", null, null },
                    { new Guid("ba4c622d-9575-4406-b54c-2ef4701272bc"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Củ cải trắng khô", "Củ cải trắng khô", null, null },
                    { new Guid("bb491be6-5d27-4585-a635-648363eaefe6"), 2, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "đã bỏ vỏ", null, "Củ súng khô ", "Củ súng khô ", null, null },
                    { new Guid("bb5301cf-c173-4d70-9309-cfb4769a7531"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Thịt ngỗng", "Thịt ngỗng", null, null },
                    { new Guid("bb6eddc0-f39e-4564-952a-a4054426854a"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cá da", "Cá da", null, null },
                    { new Guid("bcfbf0ee-cc74-4c1f-8c64-d9e1a60c3676"), 14, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Dưa chuột hộp", "Dưa chuột hộp", null, null },
                    { new Guid("bdabbb62-b3d9-49b9-89c5-65ff8758692c"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Rau ngồ", "Rau ngồ", null, null },
                    { new Guid("bdd162a2-79f6-4fbc-a714-07476f2886a3"), 13, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Bơ thực vật", "Bơ thực vật", null, null },
                    { new Guid("bdd7bec8-0600-4106-ac5a-651167698080"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cá mè", "Cá mè", null, null },
                    { new Guid("befca2e2-657e-4a5a-bb2e-e2b8fdfb6024"), 1, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Bánh bao", "Bánh bao", null, null },
                    { new Guid("c08fe1e5-bccb-419a-9986-d06f98b4091d"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "hành hoa", null, "Hành lá ", "Hành lá ", null, null },
                    { new Guid("c20f5d03-243b-4311-927b-5b663bc1508b"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Thịt gà ta", "Thịt gà ta", null, null },
                    { new Guid("c265eaf5-2ac8-46bb-b25e-e23493abf9e1"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Dưa cải bắp", "Dưa cải bắp", null, null },
                    { new Guid("c297ca1a-bee0-4517-af21-e64e35c69e40"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Nhót", "Nhót", null, null },
                    { new Guid("c29d46aa-b0e4-4047-b089-fac0daddac97"), 1, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Bột ngô vàng", "Bột ngô vàng", null, null },
                    { new Guid("c2a9ae07-6c46-4cb0-967c-beb7d9dee418"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "củ đỏ, vàng", null, "Cà rốt ", "Cà rốt ", null, null },
                    { new Guid("c2bc1369-02fe-4890-bf8d-af7d4f187bad"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "cả lá", null, "Tỏi tây ", "Tỏi tây ", null, null },
                    { new Guid("c2e8b54e-eb59-49bd-981e-9627192177bf"), 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Bảnh bích cốt", "Bảnh bích cốt", null, null },
                    { new Guid("c3daa411-f9a2-4130-b988-964e9b1c21af"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Đào", "Đào", null, null },
                    { new Guid("c3ef078d-6144-43a2-b762-34756425cdaf"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Ớt đỏ to", "Ớt đỏ to", null, null },
                    { new Guid("c41e8b54-3eb3-4d60-b780-aeb1789f7bed"), 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Mứt lạc", "Mứt lạc", null, null },
                    { new Guid("c4e5185d-e943-4d02-ac43-dc76e1492a6c"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Đuôi lợn", "Đuôi lợn", null, null },
                    { new Guid("c4fb1867-2d9f-47c9-8ed4-01f15ec5d476"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Tai lợn", "Tai lợn", null, null },
                    { new Guid("c557736a-9dae-4bb6-b456-9c23530b2e4a"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cam", "Cam", null, null },
                    { new Guid("c6174246-afdc-42ae-9c81-12035b6dce99"), 14, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Dứa hộp", "Dứa hộp", null, null },
                    { new Guid("c7464e24-4687-4bae-9ab2-73264caa0cf1"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "hạt", null, "Đậu đen ", "Đậu đen ", null, null },
                    { new Guid("c7dd2a83-1e83-46c5-8194-844c978191fe"), 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Bánh con cá", "Bánh con cá", null, null },
                    { new Guid("c80ddf67-9dcc-4640-9700-932c2854c9e3"), 15, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "cồn 13 g", null, "Cốc tain ", "Cốc tain ", null, null },
                    { new Guid("c844df20-7146-4a46-95e3-305957f73d96"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Hạt dẻ to", "Hạt dẻ to", null, null },
                    { new Guid("c92cd2ad-256f-44bb-9f4e-c1bad5433ddb"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Su su", "Su su", null, null },
                    { new Guid("c94170a2-661f-4b1d-90c4-4605500df16b"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Quả đại hái tươi", "Quả đại hái tươi", null, null },
                    { new Guid("cad0833e-c07b-444c-b363-2eaf44185695"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Rau ngót", "Rau ngót", null, null },
                    { new Guid("cc06c453-7563-4f13-9133-08143f8e82de"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Rau má rừng", "Rau má rừng", null, null },
                    { new Guid("cc6ad072-e7c1-497c-8779-80fff086dbe1"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Quả dọc", "Quả dọc", null, null },
                    { new Guid("cc718f9f-319d-46b4-89f6-2189a2f69eeb"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cá đồng tiền", "Cá đồng tiền", null, null },
                    { new Guid("ccd3d2a5-83d0-4e87-ac21-10c93e667f0c"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Quả cóc", "Quả cóc", null, null },
                    { new Guid("ccebe49a-3530-4e21-a098-ae3f45708129"), 14, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Lạc chao dầu", "Lạc chao dầu", null, null },
                    { new Guid("cd86d3d5-047c-430d-8527-c7e25460b397"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Nhãn", "Nhãn", null, null },
                    { new Guid("cd9a68d7-f3ca-4016-82e1-6aac969631c8"), 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Kẹo cam chanh", "Kẹo cam chanh", null, null },
                    { new Guid("cdbc1f19-e7cb-426b-b1a0-bce80533b88b"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "đậu xanh", null, "Dưa giá ", "Dưa giá ", null, null },
                    { new Guid("ce0575e0-8d6e-406f-8b03-574119267482"), 15, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "cồn: 4,5 g", null, "Bia ", "Bia ", null, null },
                    { new Guid("cf7c9e26-22f2-4971-a04a-d139e879a846"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cá chày", "Cá chày", null, null },
                    { new Guid("cfb678e8-fe5d-4d81-826d-caaee5056a37"), 17, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Hạt tiêu", "Hạt tiêu", null, null },
                    { new Guid("cfd8f06b-d208-470c-90ae-ac1aae057e76"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Hồng ngâm", "Hồng ngâm", null, null },
                    { new Guid("d074bad9-edba-459f-82e3-f5fb46956ed8"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Thịt bê mỡ", "Thịt bê mỡ", null, null },
                    { new Guid("d09fb596-b512-4c68-9005-968bf695611f"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Giò lụa", "Giò lụa", null, null },
                    { new Guid("d0dc5658-2dbf-475f-bd24-1a8541b928aa"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Hến", "Hến", null, null },
                    { new Guid("d0dfcf28-560f-4c9c-97fb-c77921c9452e"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Rau húng", "Rau húng", null, null },
                    { new Guid("d0ffdd12-d028-45a9-9c31-14f8f348174e"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Dâu gia", "Dâu gia", null, null },
                    { new Guid("d3940beb-03bc-485c-bb37-f59df888a1a7"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Nấm hương khô", "Nấm hương khô", null, null },
                    { new Guid("d3af130f-d97b-4fce-b060-d988f568c541"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Rau bí", "Rau bí", null, null },
                    { new Guid("d3b73a2d-63d2-466e-80a9-e8500359b018"), 14, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Mứt đu đủ", "Mứt đu đủ", null, null },
                    { new Guid("d4700286-1ecd-4527-b9e6-eac3ea1fbdb8"), 1, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Bột mì", "Bột mì", null, null },
                    { new Guid("d4f72f11-5074-46d7-ae1c-d52c60a14bae"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Lưỡi bò", "Lưỡi bò", null, null },
                    { new Guid("d537498c-1f04-4524-9b36-44c5e60ca328"), 2, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Khoai lang khô", "Khoai lang khô", null, null },
                    { new Guid("d58e7c41-93a8-4132-ae59-174ba755d807"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Chuối khô", "Chuối khô", null, null },
                    { new Guid("d5b25f74-de46-410e-8e99-bc68200ed5c5"), 17, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Sốt mayonnaise", "Sốt mayonnaise", null, null },
                    { new Guid("d5da8f42-3eea-456a-8eba-367fea71f5dd"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Hạt mít", "Hạt mít", null, null },
                    { new Guid("d5ebd4ef-8493-4400-b004-f321c873da2b"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Mít dai", "Mít dai", null, null },
                    { new Guid("d7d4a8a2-7805-4553-ad52-f6aea9fdab90"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "thịt đùi", null, "Ếch ", "Ếch ", null, null },
                    { new Guid("d800f5d2-6586-4e9d-b129-477f8e73c967"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cá quả", "Cá quả", null, null },
                    { new Guid("d860d0b7-b4e1-45dd-8454-70af41094e61"), 2, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Bột khoai lang", "Bột khoai lang", null, null },
                    { new Guid("d86d6db3-8115-4c5b-9e4f-0720e3ebe071"), 17, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cary bột", "Cary bột", null, null },
                    { new Guid("d8e0487a-6282-4c28-9844-8454318b1509"), 10, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Trứng vịt lộn", "Trứng vịt lộn", null, null },
                    { new Guid("d91e1758-7b5c-41e7-b51e-95a4527091d6"), 14, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Thịt gà hộp", "Thịt gà hộp", null, null },
                    { new Guid("d9585bf7-f8c1-4d6a-94f8-55c5e6a95541"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Rau sam", "Rau sam", null, null },
                    { new Guid("d989da3d-e6f6-4bb1-be4d-19188df60bc7"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "dưa muối từ mít non,lá đậu xanh non ... ", null, "Nhút ", "Nhút ", null, null },
                    { new Guid("d99fe95e-14b0-49f0-b491-075a383aa127"), 17, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Mắm tôm loãng", "Mắm tôm loãng", null, null },
                    { new Guid("da783c63-b7a0-49bf-9bec-1bd71ee9e9c8"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "bí xanh", null, "Bí đao ", "Bí đao ", null, null },
                    { new Guid("dab6ff3b-17a5-4e07-985f-c824ca48675a"), 2, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Củ sắn", "Củ sắn", null, null },
                    { new Guid("dae8cd28-e293-4351-967d-9a9be24a4954"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Gan lợn", "Gan lợn", null, null },
                    { new Guid("dc0c4ed3-325d-4f46-ad4c-38c484ab99c9"), 17, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "loại đặc biệt", null, "Nước mắm cá ", "Nước mắm cá ", null, null },
                    { new Guid("dc241c23-9ee6-46ab-8368-121615298840"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Hồng bì", "Hồng bì", null, null },
                    { new Guid("dc49e6a2-5187-48ed-abf1-af21fe842fb7"), 15, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Coca cola", "Coca cola", null, null },
                    { new Guid("dc5d7b7f-0e1f-4332-a1fb-acf4c03bd964"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cá lác", "Cá lác", null, null },
                    { new Guid("dc765b90-a988-4c02-bafa-acd0a9c75cad"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Dạ dày bò", "Dạ dày bò", null, null },
                    { new Guid("dd02874c-fb81-48da-b341-b2a69ea7d296"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "hạt", null, "Đậu Hà lan ", "Đậu Hà lan ", null, null },
                    { new Guid("de2bbf54-32d1-45b4-908e-d9428992046b"), 15, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Nước cam tươi", "Nước cam tươi", null, null },
                    { new Guid("dfb1df3d-3690-4e0d-b5fc-ec52896d4154"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Thịt bê nạc", "Thịt bê nạc", null, null },
                    { new Guid("e01002e1-2d43-49e6-9ff8-7b0b5f80b85c"), 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Đường kính", "Đường kính", null, null },
                    { new Guid("e016ad0f-d4b5-49d5-8b82-a899d4f1434a"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Nấm rơm", "Nấm rơm", null, null },
                    { new Guid("e041e4c1-ed2c-4860-83d7-2334aa298cfb"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "100g đậu/lít", null, "Sữa đậu nành ", "Sữa đậu nành ", null, null },
                    { new Guid("e05ab504-3b6d-4c3c-be80-c169a6190c80"), 17, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Riềng", "Riềng", null, null },
                    { new Guid("e05e37d2-6be3-4b46-b6bf-cc1ccdc9d219"), 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Bánh số cô la", "Bánh số cô la", null, null },
                    { new Guid("e18378cd-7baf-43d2-b08d-924332d6a6aa"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Nhộng", "Nhộng", null, null },
                    { new Guid("e26838ee-7f72-46f8-aac5-021449921d31"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Trám xanh sống", "Trám xanh sống", null, null },
                    { new Guid("e2a5a36b-d0ae-427c-8400-1002bbfe6a45"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Thịt lợn nạc", "Thịt lợn nạc", null, null },
                    { new Guid("e304ae7c-2376-4d83-aee0-26dd8f3331b7"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cá đé", "Cá đé", null, null },
                    { new Guid("e38e91b8-cdac-4763-9e57-4caa82113391"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Củ niễng", "Củ niễng", null, null },
                    { new Guid("e443886f-9bc4-41c2-b781-d6ac97032c40"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Muỗm, quéo", "Muỗm, quéo", null, null },
                    { new Guid("e4603e9a-f19f-49d8-8d9a-455c860e7a20"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cá trê", "Cá trê", null, null },
                    { new Guid("e4a2e10a-3d34-4e6e-bc24-e67faa36f9fd"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cà chua muối", "Cà chua muối", null, null },
                    { new Guid("e56ddbac-faf8-4812-8528-2e622583e4ef"), 2, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Khoai lang nghệ", "Khoai lang nghệ", null, null },
                    { new Guid("e5da59d0-25f2-46b8-8a3f-a6e17af63265"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Thịt vịt", "Thịt vịt", null, null },
                    { new Guid("e61485de-f144-41ca-961c-18042686ddbe"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Thịt lợn nửa nạc, nửa mỡ", "Thịt lợn nửa nạc, nửa mỡ", null, null },
                    { new Guid("e68a267c-d93c-4e5c-902e-ebee568fa639"), 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Bánh kem xốp", "Bánh kem xốp", null, null },
                    { new Guid("e77789c9-941a-435f-b4a3-ae88a2560009"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Óc bò", "Óc bò", null, null },
                    { new Guid("e7c1095c-2bd6-45f5-bd59-a727b9ec37ed"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Thịt ngựa", "Thịt ngựa", null, null },
                    { new Guid("e7f7a67d-3416-4cd8-a3d9-c348c22b6a16"), 10, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Trứng gà", "Trứng gà", null, null },
                    { new Guid("e84e7ad0-0a9e-4308-85ad-fcf67d501d31"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Thịt trâu đùi", "Thịt trâu đùi", null, null },
                    { new Guid("e8c1e8e3-6733-4474-81fc-efe1e8bcce53"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Thịt gà rừng", "Thịt gà rừng", null, null },
                    { new Guid("e8c86a57-c7c1-4459-8cd0-b6d92801a3c2"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Đậu phụ chúc", "Đậu phụ chúc", null, null },
                    { new Guid("e996a9a6-efc4-4c7a-84f6-94cfb37e63df"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cải bắp đỏ", "Cải bắp đỏ", null, null },
                    { new Guid("ea2f9d84-7004-4575-9fce-45015f55614d"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Gan gà", "Gan gà", null, null },
                    { new Guid("ea38d603-032d-4b7d-a293-140abc1d20ed"), 3, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "hạt", null, "Đậu cô ve ", "Đậu cô ve ", null, null },
                    { new Guid("eba0dc29-3c67-4d70-9104-afb8866f2bd0"), 17, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Nước mắm cá", "Nước mắm cá", null, null },
                    { new Guid("ebcf53b2-8a99-4280-b563-0796b68e797b"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Gan vịt", "Gan vịt", null, null },
                    { new Guid("ecc68129-ba82-4f9c-82f2-19094875c07c"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cá thờn bơn", "Cá thờn bơn", null, null },
                    { new Guid("ed6ef503-311d-4759-999b-16be133baecf"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Rau mùi tàu", "Rau mùi tàu", null, null },
                    { new Guid("edaef922-0828-48d1-80f5-4fb75ce41bd4"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Rau câu tươi", "Rau câu tươi", null, null },
                    { new Guid("ee1015c1-c1ad-4e4f-be4e-578424641dc9"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Tía tô", "Tía tô", null, null },
                    { new Guid("ee1ac453-e042-4678-90c3-ef6d8b062de0"), 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Bánh trứng nhện", "Bánh trứng nhện", null, null },
                    { new Guid("ee7b0428-e304-43ac-a0b3-b062a004f169"), 3, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Đậu trứng cuốc", "Đậu trứng cuốc", null, null },
                    { new Guid("eeb3c0aa-5d51-44dd-a319-82581573792d"), 2, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Khoai nước", "Khoai nước", null, null },
                    { new Guid("ef7704ea-f64c-434e-a896-9c0ab422d967"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Mơ khô", "Mơ khô", null, null },
                    { new Guid("ef9e706d-e3b8-4573-a991-8413c29271df"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Thịt thỏ rừng", "Thịt thỏ rừng", null, null },
                    { new Guid("effff6b0-7ec3-40d4-b8ff-899ec261012d"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Hành tây", "Hành tây", null, null },
                    { new Guid("f07f79ae-4360-4c7f-855a-8a7a8db410cb"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "muối, đồ", null, "Rạm ", "Rạm ", null, null },
                    { new Guid("f13df5e1-eb9b-4025-b4cf-737df56dae9b"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Rau răm", "Rau răm", null, null },
                    { new Guid("f1f8cb5b-edd5-4a9d-af46-6f6f6dc893ab"), 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Đường cát", "Đường cát", null, null },
                    { new Guid("f233b50d-998e-45ec-87a6-e7295e7b4fa9"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Dưa chuột muối", "Dưa chuột muối", null, null },
                    { new Guid("f2e9bb79-58d2-4ddf-a4fa-7e106a84bcea"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Cà tím", "Cà tím", null, null },
                    { new Guid("f3a4e4b1-9015-411a-9817-5ab0e9d2f218"), 17, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Nước mắm loại I", "Nước mắm loại I", null, null },
                    { new Guid("f3e84eab-c85d-4672-96cb-aef3940c27af"), 2, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Miến dong", "Miến dong", null, null },
                    { new Guid("f46dacae-55ba-4c0d-8cb7-b40eab51e540"), 1, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Bún", "Bún", null, null },
                    { new Guid("f4cc1969-f5d7-4ec3-9b7c-f22a4b9c80fd"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Ngải cứu", "Ngải cứu", null, null },
                    { new Guid("f51a7209-7b3f-4cfb-ab6d-f93f567e36a5"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Hoa lý", "Hoa lý", null, null },
                    { new Guid("f6809be8-e149-46f3-995d-9e9178b69341"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Rau ngót khô", "Rau ngót khô", null, null },
                    { new Guid("f699fdd3-3d55-4787-8e98-95ab99e66674"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "Nấm tây", null, "Nấm mỡ ", "Nấm mỡ ", null, null },
                    { new Guid("f730a7b3-1f8e-4ecb-b224-84c2e8c9c79b"), 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Kẹo dừa mềm", "Kẹo dừa mềm", null, null },
                    { new Guid("f80abb87-090b-4c4e-a876-3b1cde336ea0"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Trai", "Trai", null, null },
                    { new Guid("f80ebb54-d5e2-4c4a-9fb5-a1a7f7378171"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Rau kinh giới", "Rau kinh giới", null, null },
                    { new Guid("f8c58a68-939b-4430-bc21-aa886c2d4d7b"), 14, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Vải nước đường", "Vải nước đường", null, null },
                    { new Guid("f8cf1185-c678-42f4-8d6f-a81f5b9b6072"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "dưa hấu", null, "Hạt da đỏ rang ", "Hạt da đỏ rang ", null, null },
                    { new Guid("f90874a0-3803-4fac-be67-61a3b9e8f119"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Bột đậu tương rang chín", "Bột đậu tương rang chín", null, null },
                    { new Guid("f98a1943-da09-4b78-b2e9-07830c1a7bb3"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Tỏi ta", "Tỏi ta", null, null },
                    { new Guid("f9a7668a-80da-4fbd-8a00-52d4718d2f47"), 15, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "cồn 32 g", null, "Cô nhắc ", "Cô nhắc ", null, null },
                    { new Guid("f9f532b3-8347-4ded-a7fd-de24ae8bd845"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "ruột già", null, "Lòng lợn ", "Lòng lợn ", null, null },
                    { new Guid("fa5634a8-db36-4da7-9eda-32789dc8d262"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Hồng xiêm", "Hồng xiêm", null, null },
                    { new Guid("fa7532e5-7e66-4f5c-9aca-0916de4eec34"), 10, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Bột trứng", "Bột trứng", null, null },
                    { new Guid("fa7b6cc3-ed94-42ea-a3f6-fc9ff980f6f5"), 13, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Dầu bông", "Dầu bông", null, null },
                    { new Guid("fb6cf83c-fee9-4a71-9588-5bd1e535e482"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Nụ mướp", "Nụ mướp", null, null },
                    { new Guid("fc674d4f-cc81-423d-be3f-56644e56872c"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Hành củ tươi", "Hành củ tươi", null, null },
                    { new Guid("fcb5bda7-964f-41d2-b45a-314511205f38"), 1, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Gạo lứt", "Gạo lứt", null, null },
                    { new Guid("fd0fb22d-124b-4a4e-adb7-cfb5523819c7"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Kiệu muối", "Kiệu muối", null, null },
                    { new Guid("fd125e12-88a8-4b97-bb8c-60043cc9591c"), 15, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Nước ép cà chua", "Nước ép cà chua", null, null },
                    { new Guid("fe295fdb-f50f-410b-97e4-1cb87b53012e"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Hạt điều khô, chiên dầu", "Hạt điều khô, chiên dầu", null, null },
                    { new Guid("fe728c82-df00-4ad9-93b1-22fafc9a0654"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Đậu phụ nướng", "Đậu phụ nướng", null, null },
                    { new Guid("fea408bf-63e4-4a70-a528-c26f053eb70a"), 2, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Củ dong", "Củ dong", null, null },
                    { new Guid("feb7f625-0903-4481-9dc1-544e94313517"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 15, 57, 35, 506, DateTimeKind.Unspecified).AddTicks(2673), new TimeSpan(0, 7, 0, 0, 0)), null, null, "", null, "Bánh phồng tôm rán", "Bánh phồng tôm rán", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ingredient_CategoryId",
                table: "ingredient",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ingredientrecipe_IngredientId",
                table: "ingredientrecipe",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_ingredientrecipe_RecipeId",
                table: "ingredientrecipe",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_recipe_UserAccountId",
                table: "recipe",
                column: "UserAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_step_RecipeId",
                table: "step",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_useraccountpermission_PermissionId",
                table: "useraccountpermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_useraccountpermission_UserAccountId",
                table: "useraccountpermission",
                column: "UserAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_userlogin_UserAccountId",
                table: "userlogin",
                column: "UserAccountId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ingredientrecipe");

            migrationBuilder.DropTable(
                name: "step");

            migrationBuilder.DropTable(
                name: "useraccountpermission");

            migrationBuilder.DropTable(
                name: "userlogin");

            migrationBuilder.DropTable(
                name: "ingredient");

            migrationBuilder.DropTable(
                name: "recipe");

            migrationBuilder.DropTable(
                name: "permission");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "useraccount");
        }
    }
}
