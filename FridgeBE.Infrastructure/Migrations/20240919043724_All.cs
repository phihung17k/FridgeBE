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
                    { 1, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 23, 369, DateTimeKind.Unspecified).AddTicks(9479), new TimeSpan(0, 7, 0, 0, 0)), null, null, "Cereals", "Ngũ cốc", "Cereals", null, null },
                    { 2, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 23, 369, DateTimeKind.Unspecified).AddTicks(9479), new TimeSpan(0, 7, 0, 0, 0)), null, null, "Roots, tubers and plantains", "Khoai củ", "RootsTubersPlantains", null, null },
                    { 3, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 23, 369, DateTimeKind.Unspecified).AddTicks(9479), new TimeSpan(0, 7, 0, 0, 0)), null, null, "Legumes", "Đậu", "Legumes", null, null },
                    { 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 23, 369, DateTimeKind.Unspecified).AddTicks(9479), new TimeSpan(0, 7, 0, 0, 0)), null, null, "Vegetables", "Rau quả", "Vegetables", null, null },
                    { 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 23, 369, DateTimeKind.Unspecified).AddTicks(9479), new TimeSpan(0, 7, 0, 0, 0)), null, null, "Fruits", "Trái cây", "Fruits", null, null },
                    { 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 23, 369, DateTimeKind.Unspecified).AddTicks(9479), new TimeSpan(0, 7, 0, 0, 0)), null, null, "Seeds and nuts", "Hạt", "SeedsNuts", null, null },
                    { 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 23, 369, DateTimeKind.Unspecified).AddTicks(9479), new TimeSpan(0, 7, 0, 0, 0)), null, null, "Meat", "Thịt", "Meat", null, null },
                    { 8, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 23, 369, DateTimeKind.Unspecified).AddTicks(9479), new TimeSpan(0, 7, 0, 0, 0)), null, null, "Insects and grubs", "Côn trùng và sâu bọ", "InsectsGrubs", null, null },
                    { 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 23, 369, DateTimeKind.Unspecified).AddTicks(9479), new TimeSpan(0, 7, 0, 0, 0)), null, null, "Fish and shellfish", "Thủy sản", "FishShellfish", null, null },
                    { 10, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 23, 369, DateTimeKind.Unspecified).AddTicks(9479), new TimeSpan(0, 7, 0, 0, 0)), null, null, "Eggs", "Trứng", "Eggs", null, null },
                    { 11, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 23, 369, DateTimeKind.Unspecified).AddTicks(9479), new TimeSpan(0, 7, 0, 0, 0)), null, null, "Milk and dairy products", "Sữa", "MilkDairy", null, null },
                    { 12, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 23, 369, DateTimeKind.Unspecified).AddTicks(9479), new TimeSpan(0, 7, 0, 0, 0)), null, null, "Snacks", "Đồ ăn vặt", "Snacks", null, null },
                    { 13, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 23, 369, DateTimeKind.Unspecified).AddTicks(9479), new TimeSpan(0, 7, 0, 0, 0)), null, null, "Fats and oils", "Dầu, mỡ và bơ", "FatsOils", null, null },
                    { 14, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 23, 369, DateTimeKind.Unspecified).AddTicks(9479), new TimeSpan(0, 7, 0, 0, 0)), null, null, "Canned Food", "Đồ đóng hộp", "CannedFood", null, null },
                    { 15, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 23, 369, DateTimeKind.Unspecified).AddTicks(9479), new TimeSpan(0, 7, 0, 0, 0)), null, null, "Beverages", "Đồ uống", "Beverages", null, null },
                    { 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 23, 369, DateTimeKind.Unspecified).AddTicks(9479), new TimeSpan(0, 7, 0, 0, 0)), null, null, "Sweets and sugars", "Đồ ngọt", "SweetsSugars", null, null },
                    { 17, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 23, 369, DateTimeKind.Unspecified).AddTicks(9479), new TimeSpan(0, 7, 0, 0, 0)), null, null, "Spices, herbs and condiments", "Gia vị và nước chấm", "SpicesHerbsCondiments", null, null },
                    { 18, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 23, 369, DateTimeKind.Unspecified).AddTicks(9479), new TimeSpan(0, 7, 0, 0, 0)), null, null, "Food additives", "Phụ gia", "FoodAdditives", null, null }
                });

            migrationBuilder.InsertData(
                table: "ingredient",
                columns: new[] { "Id", "CategoryId", "CreateBy", "CreateTime", "DeleteBy", "DeleteTime", "Description", "ImageUrl", "LocalName", "Name", "UpdateBy", "UpdateTime" },
                values: new object[,]
                {
                    { new Guid("003c1cb8-6c20-4eb7-99b7-95bb757e5590"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cà muối sổi", "Cà muối sổi", null, null },
                    { new Guid("00b33bd7-3031-4946-9fb6-68fb9bb1e872"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Nụ mướp", "Nụ mướp", null, null },
                    { new Guid("00c33e1f-7c92-4714-b208-312ed6d47127"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Giò lụa", "Giò lụa", null, null },
                    { new Guid("00d5025d-9425-4d01-a127-7fadd201bb43"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Lạp xường", "Lạp xường", null, null },
                    { new Guid("00e3803d-34b2-4d40-9ee7-3a395de51077"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cá rô phi", "Cá rô phi", null, null },
                    { new Guid("0124b21d-77b4-4491-aa8c-9c0629598610"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cùi dừa già", "Cùi dừa già", null, null },
                    { new Guid("01614fe1-5d31-4977-bdd4-1535fb65ac6e"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Tim lợn", "Tim lợn", null, null },
                    { new Guid("01c45e14-17f5-45b7-9c65-82f61f1a5065"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Bầu dục lợn", "Bầu dục lợn", null, null },
                    { new Guid("01f65b04-c797-4ca6-b5f4-4e0826d3b145"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Muỗm, quéo", "Muỗm, quéo", null, null },
                    { new Guid("02ae00c8-1a50-4006-9cb0-1b54ce24fb12"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "mít non,lá đậu xanh", "mít non,lá đậu xanh", null, null },
                    { new Guid("034aa965-0064-407f-b73e-636e72e3238d"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Gan vịt", "Gan vịt", null, null },
                    { new Guid("047410d0-5a19-45f9-9075-7c65aaee3b2b"), 17, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Riềng", "Riềng", null, null },
                    { new Guid("066be650-cd45-4135-ae4f-0558bdc59cf5"), 3, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Đậu trứng cuốc", "Đậu trứng cuốc", null, null },
                    { new Guid("067c52d4-fd53-41ab-913a-8a6e80a23d9d"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Nho ngọt", "Nho ngọt", null, null },
                    { new Guid("06fbf9d9-1284-4833-901e-e2850e2541a3"), 1, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Gạo tẻ giã", "Gạo tẻ giã", null, null },
                    { new Guid("073169fa-4398-4d0a-828e-a5d1531023b3"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cải bắp", "Cải bắp", null, null },
                    { new Guid("083c8c08-9c91-4ec9-a458-988edc476273"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Mộc nhĩ", "Mộc nhĩ", null, null },
                    { new Guid("08894c07-42e4-46a3-b311-4a16de5a848c"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Thịt cừu, nạc", "Thịt cừu, nạc", null, null },
                    { new Guid("089c8a02-f079-4a68-a705-17e88a8dcdf5"), 13, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Dầu dừa", "Dầu dừa", null, null },
                    { new Guid("09e143f8-295a-4417-96bb-7bd097c67812"), 11, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Sữa dê tươi", "Sữa dê tươi", null, null },
                    { new Guid("0a0c6614-2124-4faf-a1e0-bebe1cf9cbe7"), 17, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Gừng tươi", "Gừng tươi", null, null },
                    { new Guid("0bc31547-9e67-4316-aef4-5ae2315340de"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Tỏi ta", "Tỏi ta", null, null },
                    { new Guid("0c7e698d-c173-446f-8858-a26e687807c6"), 2, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Củ cái", "Củ cái", null, null },
                    { new Guid("0cb475e4-f0c4-4cf3-b0d3-722aaf3e8a10"), 3, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Đậu cô ve (hạt)", "Đậu cô ve (hạt)", null, null },
                    { new Guid("0df41b7d-8eaa-46cc-81dc-c91e641bbb6f"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Rau má rừng", "Rau má rừng", null, null },
                    { new Guid("0e7ce30f-0030-4d3b-a071-9ae555af4619"), 10, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Trứng vịt", "Trứng vịt", null, null },
                    { new Guid("0ec0643b-aadb-4aa6-af36-ccc3b5f030ad"), 10, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Lòng trắng trứng gà", "Lòng trắng trứng gà", null, null },
                    { new Guid("10d4c7f5-fb5d-4d7f-9b1a-89f4a313f993"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Lưỡi lợn", "Lưỡi lợn", null, null },
                    { new Guid("10dbde8f-7417-4fa1-bde9-bc7b9b9e1464"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Hồng đỏ", "Hồng đỏ", null, null },
                    { new Guid("1144220f-4d22-4a28-85c0-3a881e3fe975"), 14, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cá trích hộp", "Cá trích hộp", null, null },
                    { new Guid("11558bc3-fe52-4ca3-8a4b-28c65c0dcf8d"), 15, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Nước khoáng", "Nước khoáng", null, null },
                    { new Guid("1305dc74-fd94-464c-bad0-360224ee39f3"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cải cúc", "Cải cúc", null, null },
                    { new Guid("136543cd-083d-4b65-922b-910c3655b6d6"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Rau sam", "Rau sam", null, null },
                    { new Guid("138c0013-e452-4858-9d47-8fab3c0a6a4b"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Thịt bê mỡ", "Thịt bê mỡ", null, null },
                    { new Guid("1492655a-d188-46ca-b036-d8dd0846e6bb"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cá trôi", "Cá trôi", null, null },
                    { new Guid("15bee9d5-ec83-4c25-a1f6-d5b9dc869c68"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Tai lợn", "Tai lợn", null, null },
                    { new Guid("16c215d3-b715-418a-b9ab-c2e8b71936dc"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Rau giền trắng", "Rau giền trắng", null, null },
                    { new Guid("175716da-c1db-4960-91ff-47e6c22a2c94"), 2, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Củ súng khô (đã bỏ vỏ)", "Củ súng khô (đã bỏ vỏ)", null, null },
                    { new Guid("1778a027-3df0-4ddb-8375-161f6db725db"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Quả đại hái tươi", "Quả đại hái tươi", null, null },
                    { new Guid("178be222-f0b8-4874-8d5d-65df84394bc0"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Tiết bò", "Tiết bò", null, null },
                    { new Guid("17dd496e-4587-4ff1-b729-3b51cbcaf4ef"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "non ... )", "non ... )", null, null },
                    { new Guid("1868e5b4-781e-43a8-8e89-59e92f980def"), 13, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Dầu oliu", "Dầu oliu", null, null },
                    { new Guid("1a04d3cb-fa0e-440d-b528-366500e83751"), 14, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Dưa chuột hộp", "Dưa chuột hộp", null, null },
                    { new Guid("1ab40938-6445-4288-9d73-fcf69b3b2052"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Đậu cô ve", "Đậu cô ve", null, null },
                    { new Guid("1adeb9bc-42a8-4c8f-a508-15cf22f58af5"), 1, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Gạo lứt", "Gạo lứt", null, null },
                    { new Guid("1aec76a6-5fd6-4913-94a2-68ada5e8a587"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Gan bò", "Gan bò", null, null },
                    { new Guid("1b183788-1f25-4cf5-b693-7f974af2d587"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cà chua muối", "Cà chua muối", null, null },
                    { new Guid("1bb683ad-69bd-41a4-92f3-70d0e39b8d16"), 17, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Nước mắm cô", "Nước mắm cô", null, null },
                    { new Guid("1bbaa811-5ca7-47b1-ab63-f35f722d4574"), 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Đường kính", "Đường kính", null, null },
                    { new Guid("1c673511-3383-4f6c-ac99-1113328d4904"), 1, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Gạo nếp cái", "Gạo nếp cái", null, null },
                    { new Guid("1d8218c9-8845-4fcc-9b16-b35ed3aa6ffa"), 13, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Dầu bông", "Dầu bông", null, null },
                    { new Guid("1dbef9bc-0764-4d22-9ef8-6c45b899b4d5"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Bột cá", "Bột cá", null, null },
                    { new Guid("1e71faf7-5c95-4150-803a-6f2fd44f840c"), 17, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Gừng khô (bột)", "Gừng khô (bột)", null, null },
                    { new Guid("1f1f1b06-855b-4a4d-badd-1c012f81a008"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Nấm hương tươi", "Nấm hương tươi", null, null },
                    { new Guid("1f6c4270-6d5d-4f1e-9fcd-6d65c602daa6"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Hến", "Hến", null, null },
                    { new Guid("1fabd5f7-4d87-4b4a-a611-086484bc2200"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Thịt dê, nạc", "Thịt dê, nạc", null, null },
                    { new Guid("2040817c-bfab-4ce0-9593-0eced6aa91db"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Chanh", "Chanh", null, null },
                    { new Guid("21b5738c-9999-4232-84bf-be7990af8349"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Dưa hồng", "Dưa hồng", null, null },
                    { new Guid("221fadf4-18ba-4d90-8587-5405be79066b"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cua đồng", "Cua đồng", null, null },
                    { new Guid("224533c8-f3da-4df5-8b58-bd06c7ec57a5"), 3, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Đậu đen (hạt)", "Đậu đen (hạt)", null, null },
                    { new Guid("2260158e-9162-4a0f-89aa-8308ae2a8101"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Mãng cầu xiêm", "Mãng cầu xiêm", null, null },
                    { new Guid("23141715-3a61-4b9c-a744-0170f6f2a774"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Rau diếp", "Rau diếp", null, null },
                    { new Guid("232a7173-467c-4633-b1db-476db41b9dc1"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Nhãn khô", "Nhãn khô", null, null },
                    { new Guid("2351ecad-7794-441f-9c5a-ad0077370100"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Gioi", "Gioi", null, null },
                    { new Guid("23bda2c0-80f6-4143-a575-e32649d10af4"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Hành tây", "Hành tây", null, null },
                    { new Guid("25243242-63f9-43d6-a8b3-a8565ed15563"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cá quả", "Cá quả", null, null },
                    { new Guid("2536d769-1109-469a-90a9-f3b87773f524"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Dạ dày lợn", "Dạ dày lợn", null, null },
                    { new Guid("26b77c6d-5c36-47d2-8982-26b3fbf7cd9a"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Dọc củ cải (non)", "Dọc củ cải (non)", null, null },
                    { new Guid("27d7d211-a1ef-4c9f-87e8-1040b50afbbc"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Hạt sen khô", "Hạt sen khô", null, null },
                    { new Guid("2836c1e2-1d86-4339-bdae-9c2bce16166f"), 2, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Miến dong", "Miến dong", null, null },
                    { new Guid("2845b453-7974-4ce9-aa3d-f216b20a801d"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cà muối nén", "Cà muối nén", null, null },
                    { new Guid("28847694-7eef-4d2a-a36f-5cafb33a3de3"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Hạt bí đỏ rang", "Hạt bí đỏ rang", null, null },
                    { new Guid("29c13c68-583a-4ba1-b382-bd013a723bc0"), 17, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Nước mắm cá (loại đặc biệt)", "Nước mắm cá (loại đặc biệt)", null, null },
                    { new Guid("2abb81d6-b97c-4e68-953d-3f333a6c9254"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cá thu", "Cá thu", null, null },
                    { new Guid("2b48a80f-4d5e-414a-b3a8-2f39ac2e8c01"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Quít", "Quít", null, null },
                    { new Guid("2c71a1d0-a398-4da2-bbdf-2faf4af64827"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Quả trứng gà", "Quả trứng gà", null, null },
                    { new Guid("2cc220d1-92ac-4371-88dc-bf47be8b736b"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cá thờn bơn", "Cá thờn bơn", null, null },
                    { new Guid("2dbff430-527e-43b4-8f43-b7b35a8c2849"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Ruốc thịt lợn", "Ruốc thịt lợn", null, null },
                    { new Guid("2e5bb1a9-c150-4639-9978-f2b0b202248e"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Tôm biển", "Tôm biển", null, null },
                    { new Guid("2e5e8dfd-12ad-406f-8858-bf48cc734d0d"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Đào", "Đào", null, null },
                    { new Guid("2ea46d54-085f-4c89-9071-b6678542e127"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Ớt xanh to", "Ớt xanh to", null, null },
                    { new Guid("2eb5d422-3942-47f6-b93f-38341415aeff"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Nhót", "Nhót", null, null },
                    { new Guid("2eba008b-14b6-48df-a9f6-00c105eee155"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Rau giấp cá, diếp cá", "Rau giấp cá, diếp cá", null, null },
                    { new Guid("30a86c45-f7f6-4c10-9123-62658196fc4f"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Sấu xanh", "Sấu xanh", null, null },
                    { new Guid("3197a19b-bfa7-40f5-bac0-9d2994176072"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Thịt trâu cổ", "Thịt trâu cổ", null, null },
                    { new Guid("321d0001-7588-484f-b891-86c5f240c900"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cần tây", "Cần tây", null, null },
                    { new Guid("32287977-3a92-4277-a7fb-41dd3b3397ba"), 2, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Củ từ", "Củ từ", null, null },
                    { new Guid("32bcd87e-3b6d-46af-995f-bc07d5956360"), 15, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Nước ép cà chua", "Nước ép cà chua", null, null },
                    { new Guid("338e8557-1e98-4b58-b195-cdf6d0bf57ee"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Mít dai", "Mít dai", null, null },
                    { new Guid("3463c4bd-b7db-4d66-9ab2-7cb44b41ddb8"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cá đao", "Cá đao", null, null },
                    { new Guid("34cf5d95-3b20-4ccf-aeaa-fdb3df181c58"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Thịt hươu", "Thịt hươu", null, null },
                    { new Guid("35b9f1d0-1328-4a80-b362-d7951468ea12"), 10, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Trứng vịt lộn", "Trứng vịt lộn", null, null },
                    { new Guid("364bd828-546a-4ade-825e-61d1e6af3a70"), 17, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Nghệ khô, bột", "Nghệ khô, bột", null, null },
                    { new Guid("3667820b-9985-4cbd-8806-1a0731123e48"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Rau húng", "Rau húng", null, null },
                    { new Guid("367828d3-27d8-4969-af55-bb8001570359"), 14, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Lạc chao dầu", "Lạc chao dầu", null, null },
                    { new Guid("369da8a8-5868-4b7e-a613-85854da52cc9"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Phổi bò", "Phổi bò", null, null },
                    { new Guid("36c24db6-3cc8-44f4-b9c1-1b3e0d5f59fb"), 10, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Trứng chim cút", "Trứng chim cút", null, null },
                    { new Guid("37d80ce2-1d39-4b92-bdbb-16c01f9e6c5b"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Thịt thỏ nhà", "Thịt thỏ nhà", null, null },
                    { new Guid("3850ee6d-33a0-4681-ad99-37bd69b2836a"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Đậu phụ", "Đậu phụ", null, null },
                    { new Guid("38b354d8-e73b-46ce-81d7-d14c237516e8"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Tủy xương bò", "Tủy xương bò", null, null },
                    { new Guid("3901bb20-7763-46f3-9db1-034556125ca6"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Hạt da đỏ rang (dưa hấu)", "Hạt da đỏ rang (dưa hấu)", null, null },
                    { new Guid("39c01e18-5ace-4d35-8251-da7999ef2a32"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Lá lốt", "Lá lốt", null, null },
                    { new Guid("39d7d9b6-2235-401e-8e0a-de4de1bfaf2a"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Đầu bò", "Đầu bò", null, null },
                    { new Guid("3afe9a1a-9ce5-4238-b027-9fe41986621d"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Chuối tây", "Chuối tây", null, null },
                    { new Guid("3c1d3664-b518-468f-b575-d9655e31e4be"), 14, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Mứt bí ngô", "Mứt bí ngô", null, null },
                    { new Guid("3c556666-0e1f-41dd-b451-97e589250cf5"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Tép khô", "Tép khô", null, null },
                    { new Guid("3c8f13a4-24e2-4633-b254-ac878e7e452b"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Ruốc tôm", "Ruốc tôm", null, null },
                    { new Guid("3ca5546b-1a64-4fcd-92ca-b93c652241cc"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Đậu Hà lan (hạt)", "Đậu Hà lan (hạt)", null, null },
                    { new Guid("3cc5b700-578f-4900-8d31-ade7f6773677"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Thịt ngỗng", "Thịt ngỗng", null, null },
                    { new Guid("3cc70c65-f698-4d4f-8452-c30ea5b390b6"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Nho ta (nho chua)", "Nho ta (nho chua)", null, null },
                    { new Guid("3cfa15d6-82b1-4aed-b8d1-ffaa4160b3ec"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cải soong", "Cải soong", null, null },
                    { new Guid("3d2383a9-051b-43fa-b995-6fbcfb33387a"), 10, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Lòng đỏ trứng gà", "Lòng đỏ trứng gà", null, null },
                    { new Guid("3f49b564-58ac-470d-9c13-a9ffc9141d69"), 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Bánh đậu xanh", "Bánh đậu xanh", null, null },
                    { new Guid("3f8a3d09-18ec-4fc0-9d4e-712c617ca927"), 14, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Thịt gà hộp", "Thịt gà hộp", null, null },
                    { new Guid("3fe605f5-94f7-4fa3-ad3b-974e5e795c8d"), 10, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Lòng trắng trứng vịt", "Lòng trắng trứng vịt", null, null },
                    { new Guid("3ff4a59c-6e5a-454c-8e13-03321bc03096"), 15, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Rượu cam, chanh (cồn 24,2 g)", "Rượu cam, chanh (cồn 24,2 g)", null, null },
                    { new Guid("4006a7f6-e1c4-4e39-ab26-e1809a7a965a"), 17, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Magi", "Magi", null, null },
                    { new Guid("40c368c7-592d-4c50-98c0-47c353a8a303"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Bí ngô", "Bí ngô", null, null },
                    { new Guid("40d3386f-b5fb-49bf-a4c2-004d5209277e"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Quả bơ vỏ xanh", "Quả bơ vỏ xanh", null, null },
                    { new Guid("411a3ace-65cf-4fb6-89bf-4e048a7433dc"), 14, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Mứt chuối", "Mứt chuối", null, null },
                    { new Guid("41636d58-2bc1-4fbe-b75b-aa976a081e34"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Ngô bao tử", "Ngô bao tử", null, null },
                    { new Guid("41d06482-9d5e-473d-9ed9-f024be26b8e7"), 17, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Hạt tiêu", "Hạt tiêu", null, null },
                    { new Guid("41eaa4a3-73db-47c8-b85d-0721e8b06dfc"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Lòng lợn (ruột non)", "Lòng lợn (ruột non)", null, null },
                    { new Guid("42ac570c-f51f-4b77-9c9a-56592614dc78"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Ớt đỏ to", "Ớt đỏ to", null, null },
                    { new Guid("42b507b4-6b54-4baa-99d9-98a03825e3a1"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Chả quế lợn", "Chả quế lợn", null, null },
                    { new Guid("43d1744a-a091-4aa1-8741-e9770ad183fb"), 17, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Ớt khô bột", "Ớt khô bột", null, null },
                    { new Guid("447c1797-2a69-4be3-97d6-1ae990d512c7"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Lạc hạt", "Lạc hạt", null, null },
                    { new Guid("44893d35-07cc-49a4-8f36-a8b429258cda"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Mít khô", "Mít khô", null, null },
                    { new Guid("44b80258-1475-47c5-a092-0aedc305fd70"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Bột đậu tương rang chín", "Bột đậu tương rang chín", null, null },
                    { new Guid("44beeaf6-e18f-45c8-a03b-935e174e91fb"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Lưỡi bò", "Lưỡi bò", null, null },
                    { new Guid("463ba70e-59b6-473e-aca2-13e57236b6c5"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Nhút (dưa muối từ", "Nhút (dưa muối từ", null, null },
                    { new Guid("46a7bc21-dd54-455d-af3a-e2113829b94d"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Đậu phụ nướng", "Đậu phụ nướng", null, null },
                    { new Guid("471b60ce-4e61-4e8e-9f9e-a95cab7a3cc0"), 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Kẹo sữa", "Kẹo sữa", null, null },
                    { new Guid("482a7039-f15f-4465-a3e5-51c6c404339a"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Hồng bì", "Hồng bì", null, null },
                    { new Guid("484fb97c-fe08-4c23-bd78-7693863a6f57"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Dưa gang", "Dưa gang", null, null },
                    { new Guid("485d58f5-1a49-4cbc-bc8d-baa35c140ef0"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Hạt dẻ khô", "Hạt dẻ khô", null, null },
                    { new Guid("49a751b1-64ad-47f8-ace9-47b00129d7ac"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cà bát", "Cà bát", null, null },
                    { new Guid("4a2491b6-1119-4fbc-a9c6-9e97580bedf2"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Lá me", "Lá me", null, null },
                    { new Guid("4a47c3d3-9076-4a4a-b1c1-a026a3a6ced6"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Ớt vàng to", "Ớt vàng to", null, null },
                    { new Guid("4a923838-b87b-43cf-bf06-e781a5467be0"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Mơ khô", "Mơ khô", null, null },
                    { new Guid("4ae60a67-606f-4c5a-98eb-a15a5ebdae8c"), 13, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Dầu đậu tương", "Dầu đậu tương", null, null },
                    { new Guid("4b1035bc-e5d2-46a1-9fec-d65deee467cd"), 1, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Bột ngô vàng", "Bột ngô vàng", null, null },
                    { new Guid("4ce94180-721e-482d-af46-f4687cc8d095"), 15, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Coca cola", "Coca cola", null, null },
                    { new Guid("4ddaa5c4-9d01-4a47-bc1d-67bbedd88ac0"), 14, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Thịt lợn, thịt bò xay hộp", "Thịt lợn, thịt bò xay hộp", null, null },
                    { new Guid("4e0a6468-2938-40f7-b844-213c535c4367"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Đậu đũa", "Đậu đũa", null, null },
                    { new Guid("4ecebb38-4a2f-4d57-ad58-e3de7de61c7e"), 13, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Dầu cám gạo", "Dầu cám gạo", null, null },
                    { new Guid("4ff90540-425f-4a6a-bbf8-5d47b316f6c0"), 17, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Tương ớt", "Tương ớt", null, null },
                    { new Guid("507f12f7-114d-4780-84d4-68a7bea302c7"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Hồng xiêm", "Hồng xiêm", null, null },
                    { new Guid("50b06307-fdaf-48e0-9ac2-92a3f282cb22"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Nhộng", "Nhộng", null, null },
                    { new Guid("50b5b9d9-33d7-46f6-9070-129c485428db"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Xoài chín", "Xoài chín", null, null },
                    { new Guid("50dec69d-f087-42f3-a6fd-a5994180eef5"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Củ cải trắng", "Củ cải trắng", null, null },
                    { new Guid("5193837e-26fa-4ad6-8777-e82a5af84e88"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cá mòi (cá sardin)", "Cá mòi (cá sardin)", null, null },
                    { new Guid("52198698-7587-4492-835c-2c12e90752e5"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cá rô đồng", "Cá rô đồng", null, null },
                    { new Guid("523dd468-25ac-48ef-8563-1ce000b79866"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Lòng gà (cả bộ)", "Lòng gà (cả bộ)", null, null },
                    { new Guid("530cf135-2925-4b92-8eae-b15623640b8c"), 14, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cá thu hộp", "Cá thu hộp", null, null },
                    { new Guid("5331f87d-f626-4451-8c6c-bfa3c62d984a"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Chân giò lợn (bỏ xương)", "Chân giò lợn (bỏ xương)", null, null },
                    { new Guid("54a4a33e-6b8d-4575-b69d-19269838ab7b"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Hạt sen tươi", "Hạt sen tươi", null, null },
                    { new Guid("54c17bfd-8e4d-4523-91b3-339066a58deb"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Sầu riêng", "Sầu riêng", null, null },
                    { new Guid("553f8fde-bc8a-4a7c-ad00-a93f6b55b3be"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Thịt ngựa", "Thịt ngựa", null, null },
                    { new Guid("560f5944-908e-438f-a922-4035410f5da3"), 13, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Mỡ lợn nước", "Mỡ lợn nước", null, null },
                    { new Guid("56f0dcd2-b387-4d91-a694-37270211e1f7"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Quả kiwi", "Quả kiwi", null, null },
                    { new Guid("57b7dd9d-5ae9-456f-a52d-bc8d1fe282c8"), 1, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Bánh quẩy", "Bánh quẩy", null, null },
                    { new Guid("58851e42-77f3-46f1-a8e6-20a9e7db0547"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Su hào khô", "Su hào khô", null, null },
                    { new Guid("590536c5-1097-4ab5-a63e-ae80a5c45ab1"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cá dầu", "Cá dầu", null, null },
                    { new Guid("59155616-18be-48a9-81ca-77bb141a1895"), 2, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Bột khoai riềng (bột đao)", "Bột khoai riềng (bột đao)", null, null },
                    { new Guid("592682c3-b717-4d67-b73b-3a584e1f0b34"), 2, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Củ sắn", "Củ sắn", null, null },
                    { new Guid("5951b209-2b83-4646-b169-b61e09d48de7"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Bưởi", "Bưởi", null, null },
                    { new Guid("5a2c10f9-00db-4b24-ac36-83d68e9299fa"), 2, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Khoai lang nghệ", "Khoai lang nghệ", null, null },
                    { new Guid("5ab9c7a0-2fd2-466f-8674-e3daff59d594"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Lá mơ lông", "Lá mơ lông", null, null },
                    { new Guid("5bebb8c3-5507-4fb2-8bac-b475e07b3885"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Thịt bò loại II", "Thịt bò loại II", null, null },
                    { new Guid("5c212385-ead8-4ed0-9b7d-bfb220cc2b80"), 15, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cốc tain (cồn 13 g)", "Cốc tain (cồn 13 g)", null, null },
                    { new Guid("5c833aac-d07e-4e32-8dd4-1054ca1aac09"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Đậu cô ve (hạt)", "Đậu cô ve (hạt)", null, null },
                    { new Guid("5ca86a41-24b0-4c3a-a6bd-812fdde3d1ee"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cá trê", "Cá trê", null, null },
                    { new Guid("5ceb79c0-5cc4-4fcb-99c0-4e45d272fa53"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Đậu tương (đậu nành)", "Đậu tương (đậu nành)", null, null },
                    { new Guid("5cf666cc-85af-4983-a6cf-b31711cfc02c"), 14, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Thịt vịt hầm", "Thịt vịt hầm", null, null },
                    { new Guid("5d41a606-a18d-4637-8089-1c00f86c20aa"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Thịt lợn nửa nạc, nửa mỡ", "Thịt lợn nửa nạc, nửa mỡ", null, null },
                    { new Guid("5daf78d8-15c5-4e77-baac-03dee73048ed"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Tim gà", "Tim gà", null, null },
                    { new Guid("5dba5442-4331-4325-ac15-57a42f50d769"), 2, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Bột khoai lang", "Bột khoai lang", null, null },
                    { new Guid("5e310289-cd4d-48fc-9e95-46292478b2d7"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Mực tươi", "Mực tươi", null, null },
                    { new Guid("5e479a74-986b-42f2-b086-c1e69a86f0e0"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Su hào", "Su hào", null, null },
                    { new Guid("5e73ecfb-3d52-48a0-aca3-11320841f22a"), 1, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Bánh mỳ", "Bánh mỳ", null, null },
                    { new Guid("5e76facf-2ffd-42f0-9c5a-e6c2186b49ce"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Đậu xanh (đậu tắt)", "Đậu xanh (đậu tắt)", null, null },
                    { new Guid("5f6c6762-990b-40f2-84dd-4f656c639c9b"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Hạt dẻ to", "Hạt dẻ to", null, null },
                    { new Guid("5f9fbf33-fdda-4ccd-bade-1c174391cef1"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Măng tây", "Măng tây", null, null },
                    { new Guid("605f407f-0434-445e-82ae-91a0ebd84ea1"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Ốc đá", "Ốc đá", null, null },
                    { new Guid("617ab8ea-a786-4a0d-b17d-605a2d7e3add"), 2, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Khoai tây lát chiên", "Khoai tây lát chiên", null, null },
                    { new Guid("6212190f-33e9-451b-83e7-9b44fa9f28a9"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cá trắm cỏ", "Cá trắm cỏ", null, null },
                    { new Guid("62127693-94f3-465f-b33b-6ef2e54677ae"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Dăm bông lợn", "Dăm bông lợn", null, null },
                    { new Guid("62343fbf-ade7-4eb5-be36-c2fa86df2006"), 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Bảnh bích cốt", "Bảnh bích cốt", null, null },
                    { new Guid("624ffb7b-d2ea-4fe1-9244-5ad83e5ae01e"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Nem chua", "Nem chua", null, null },
                    { new Guid("625e249e-7f21-46aa-ae94-01cf6efdcde9"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cá mối", "Cá mối", null, null },
                    { new Guid("62bf808f-82c0-499f-b5fc-e054e4b42f35"), 15, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Nước dừa non tươi", "Nước dừa non tươi", null, null },
                    { new Guid("630365b5-6d1d-4682-975d-e72f44dac6eb"), 10, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Trứng cá muối", "Trứng cá muối", null, null },
                    { new Guid("63210951-88b8-4e14-9aaa-2ae1c0f615c7"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Dưa cải bắp", "Dưa cải bắp", null, null },
                    { new Guid("63977ec1-6006-41ee-9c74-11b7a6d3fe10"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Hồng ngâm", "Hồng ngâm", null, null },
                    { new Guid("63ae393a-a671-4823-bb89-1f52608369eb"), 13, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Dầu cọ", "Dầu cọ", null, null },
                    { new Guid("63bc244a-4d1a-47b5-8dba-fabfc0ebf83f"), 15, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Nước quít tươi", "Nước quít tươi", null, null },
                    { new Guid("6436a1e2-ffa5-4dd3-9c3b-bdb66ee565de"), 17, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Nước mắm loại II", "Nước mắm loại II", null, null },
                    { new Guid("644947c7-97b2-4732-90b9-809b77c3c4a9"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cá đé", "Cá đé", null, null },
                    { new Guid("64848d04-fe8c-4446-a479-0a3ffa4df401"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cà pháo", "Cà pháo", null, null },
                    { new Guid("64d32335-b0c6-481d-ab46-1c559740a8cd"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Chuối khô", "Chuối khô", null, null },
                    { new Guid("65d58ad7-f4e0-445f-b8b7-b1d1e32c51bc"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Óc bò", "Óc bò", null, null },
                    { new Guid("6693f9b3-dd61-48f8-8a5b-cbf3cac3efe8"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Rau câu khô", "Rau câu khô", null, null },
                    { new Guid("672c7a38-5389-45bf-955c-287d48ccfed2"), 3, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Đậu đũa (hạt)", "Đậu đũa (hạt)", null, null },
                    { new Guid("679cf7ee-1714-4ae8-9340-1dbe60e17a22"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Men bia khô", "Men bia khô", null, null },
                    { new Guid("67b1fcb7-db94-4290-9674-504c1e7c4613"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Nhãn", "Nhãn", null, null },
                    { new Guid("696cea2a-fd3f-4751-817c-fcb6618b6a08"), 14, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Vải nước đường", "Vải nước đường", null, null },
                    { new Guid("6976289c-808a-48b2-99bc-c3e98e8a4b79"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cá chày", "Cá chày", null, null },
                    { new Guid("699a36c2-cb9f-43a4-acb4-be6c0bd578ab"), 17, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Muối", "Muối", null, null },
                    { new Guid("69cf6dc8-5b1b-48a8-9f6c-26524ac2c6ae"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Quả bơ vỏ tím", "Quả bơ vỏ tím", null, null },
                    { new Guid("69fbe5cd-2a7e-4d0b-b8ac-d1698bb407df"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Giá đậu xanh", "Giá đậu xanh", null, null },
                    { new Guid("6a23856d-1b87-4d37-a6f6-62a1d2d4fbe5"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Rạm tươi", "Rạm tươi", null, null },
                    { new Guid("6ad9dd24-e482-4ad6-845d-9f41decf03bd"), 1, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Bột gạo nếp", "Bột gạo nếp", null, null },
                    { new Guid("6b6ccbc9-65e3-49ad-95e3-b5a2b0e38cb8"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Ếch (thịt đùi)", "Ếch (thịt đùi)", null, null },
                    { new Guid("6c4a00eb-5238-4e58-a193-2958536a9ef1"), 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Kẹo vừng viên", "Kẹo vừng viên", null, null },
                    { new Guid("6c595260-05be-463c-b2bc-c5585135a972"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Hạt đen", "Hạt đen", null, null },
                    { new Guid("6ca32c5a-6415-4361-839f-51fc133811b3"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Đậu đen (hạt)", "Đậu đen (hạt)", null, null },
                    { new Guid("6d01b0eb-23ee-4431-919c-8caeaaa60734"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Mít mật", "Mít mật", null, null },
                    { new Guid("6d4d15de-08a2-4138-a379-f66d716708de"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Rau thơm", "Rau thơm", null, null },
                    { new Guid("6d6d5467-5c18-499a-aa01-20b6c9d3485a"), 11, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Sữa chua vớt béo", "Sữa chua vớt béo", null, null },
                    { new Guid("6ed394bd-1c0c-4b5d-afda-7fcd90d41236"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Gấc", "Gấc", null, null },
                    { new Guid("6f14575a-ac3e-48c0-a371-4109f5578259"), 3, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Đậu trắng hạt (đậu tây)", "Đậu trắng hạt (đậu tây)", null, null },
                    { new Guid("6f163bf0-89ff-48ca-a7ca-a84b55ed6df3"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Rau muống khô", "Rau muống khô", null, null },
                    { new Guid("6f6ecd01-403e-4436-9c6f-57a8277e0826"), 17, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Mắm tép chua", "Mắm tép chua", null, null },
                    { new Guid("6f803f56-e7ec-40af-bfb3-71b7f9e9c2f3"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Xương sông", "Xương sông", null, null },
                    { new Guid("7048d1e7-8c13-4ddd-a059-215e68b9192e"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Lê", "Lê", null, null },
                    { new Guid("70842822-5caa-4b7c-9395-1f6e33afa906"), 1, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Mỳ sợi", "Mỳ sợi", null, null },
                    { new Guid("708f7ff7-2816-4219-a40f-989aeaed4d71"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Thịt cho sấn", "Thịt cho sấn", null, null },
                    { new Guid("713bce16-4827-4787-aa48-207cd9e001b6"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Mận", "Mận", null, null },
                    { new Guid("71820681-341c-46da-9707-5a2c96ac9591"), 17, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Nước mắm loại I", "Nước mắm loại I", null, null },
                    { new Guid("71b68841-5004-4f0d-8259-d63f8807fa59"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Nấm hương khô", "Nấm hương khô", null, null },
                    { new Guid("71bd5331-b384-472f-b837-1dfceb72dc27"), 14, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Mắc coọc nước đường", "Mắc coọc nước đường", null, null },
                    { new Guid("72048171-2bba-4b12-b7b7-b5f8e03f7fee"), 15, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Rượu vang trắng (cồn 9,5 g)", "Rượu vang trắng (cồn 9,5 g)", null, null },
                    { new Guid("7205c8ec-8c2c-4168-89c5-002ca7aa217b"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Quả thanh long", "Quả thanh long", null, null },
                    { new Guid("7241d9e2-e0ca-4d36-94a7-805380a833bc"), 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Bánh trứng nhện", "Bánh trứng nhện", null, null },
                    { new Guid("728f8f33-cb5b-44e2-97ab-695f8f905fc7"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cá khô(chim, thu, nụ, đé)", "Cá khô(chim, thu, nụ, đé)", null, null },
                    { new Guid("73e6f7a3-6bc4-4941-a1d9-97637845b897"), 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Bánh bích quy", "Bánh bích quy", null, null },
                    { new Guid("75288fcc-b841-408a-a8bf-88a7442d9e82"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Rau bí", "Rau bí", null, null },
                    { new Guid("753a8430-98dc-4109-8671-aba5e53f3fea"), 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Mật ong", "Mật ong", null, null },
                    { new Guid("7541e65b-0c5e-4ffd-8ee2-e821b5f85920"), 2, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Bột sắn", "Bột sắn", null, null },
                    { new Guid("759a54f1-3899-4e3b-8774-6cbff6ee88cd"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Tào phớ", "Tào phớ", null, null },
                    { new Guid("766d2aad-5df5-4394-8fdf-437f798fd1d5"), 10, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Bột trứng", "Bột trứng", null, null },
                    { new Guid("767cfca9-ebd0-4666-8f34-88c55f7ce348"), 2, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Khoai tây", "Khoai tây", null, null },
                    { new Guid("76e04a25-0bbe-43c5-9051-76eee049bfe7"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Thịt lợn mỡ", "Thịt lợn mỡ", null, null },
                    { new Guid("77004d9b-f65e-482b-aceb-631402730ea4"), 14, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Nhãn nước đường", "Nhãn nước đường", null, null },
                    { new Guid("772787b9-6296-43e1-9306-9c20679d9d2a"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Tỏi tây (cả lá)", "Tỏi tây (cả lá)", null, null },
                    { new Guid("772e01d5-cb4f-4fec-8d6d-ed6ca1b21c19"), 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Kẹo cà phê", "Kẹo cà phê", null, null },
                    { new Guid("77555c5f-8df4-46b6-bba2-508405963979"), 10, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Lòng đỏ trứng vịt", "Lòng đỏ trứng vịt", null, null },
                    { new Guid("77fdd81a-0e48-4de8-a257-8967c4fddfd8"), 14, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Mứt dứa", "Mứt dứa", null, null },
                    { new Guid("781d4368-1ce0-4724-bd22-5f7a95c8dae6"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Bột lạc", "Bột lạc", null, null },
                    { new Guid("78801e0f-793f-4063-9e8b-235859ead8c1"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Thịt gà ta", "Thịt gà ta", null, null },
                    { new Guid("78a95a29-cbcc-40e1-95fa-2e5d4227d25b"), 17, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Tương nếp", "Tương nếp", null, null },
                    { new Guid("7a380bd3-1df9-4cd5-b8f1-1cbdcf56c969"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Tôm khô", "Tôm khô", null, null },
                    { new Guid("7a76692c-6a8d-47d0-8e17-b562aea7cde0"), 13, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Mỡ lợn muối", "Mỡ lợn muối", null, null },
                    { new Guid("7a82b7ea-2c58-4482-b629-01b2c6ad833e"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Rau kinh giới", "Rau kinh giới", null, null },
                    { new Guid("7b19a628-d0d3-4490-9296-e4c8db73540d"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cải bắp khô", "Cải bắp khô", null, null },
                    { new Guid("7c72c8e3-dcf8-4e79-9fcf-309b591c8c9b"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Thịt bê nạc", "Thịt bê nạc", null, null },
                    { new Guid("7d362b83-1c84-4335-8517-89cfd42d4126"), 1, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cốm", "Cốm", null, null },
                    { new Guid("7da5f494-c113-4e20-b0aa-5eedcb894c93"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Trấm đen chín", "Trấm đen chín", null, null },
                    { new Guid("7e09f41d-e8de-4667-b342-203801f33fc4"), 1, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Ngô bắp tươi", "Ngô bắp tươi", null, null },
                    { new Guid("7e8e9872-3f12-4142-bd24-fc726b0a0cbe"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Dưa chuột muối", "Dưa chuột muối", null, null },
                    { new Guid("7e903b90-10f1-4c39-8bf9-94789f93f30a"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Vú sữa", "Vú sữa", null, null },
                    { new Guid("7fa090fd-a841-4c2c-8583-24497423c33f"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Sườn lợn (bỏ xương)", "Sườn lợn (bỏ xương)", null, null },
                    { new Guid("81017baa-35c6-49a8-a527-1e6f4ca200fe"), 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Bánh thỏi sô cô la", "Bánh thỏi sô cô la", null, null },
                    { new Guid("81069075-8751-49d3-8eca-8a00ad7abe37"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Rau mồng tơi", "Rau mồng tơi", null, null },
                    { new Guid("822bdbdd-b73a-464c-9c2f-0b8345958064"), 13, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Dầu thảo mộc (Lạc, vừng, cám ... )", "Dầu thảo mộc (Lạc, vừng, cám ... )", null, null },
                    { new Guid("829d997b-9d77-448f-8279-d5ebd7f85374"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Sấu chín", "Sấu chín", null, null },
                    { new Guid("83284ad9-0eef-437e-84a7-633b092eff2a"), 15, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Rượu nếp (80g/ 24 ml) (cồn 5 g)", "Rượu nếp (80g/ 24 ml) (cồn 5 g)", null, null },
                    { new Guid("845e129e-d66b-4d02-b5ae-851d2d7dc39b"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Vải", "Vải", null, null },
                    { new Guid("851b7ba4-cce0-46ed-b9ce-ecb789c66ab8"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Rau câu tươi", "Rau câu tươi", null, null },
                    { new Guid("8612d958-995e-4019-a7eb-e50b04cbc2c4"), 15, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Bia (cồn: 4,5 g)", "Bia (cồn: 4,5 g)", null, null },
                    { new Guid("8645f188-b905-446f-9c7e-d89ce6d0c281"), 2, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Trân châu sắn", "Trân châu sắn", null, null },
                    { new Guid("87179632-07e6-455b-8351-60428f5b1cd7"), 14, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Mứt đu đủ", "Mứt đu đủ", null, null },
                    { new Guid("879bfab7-2c1e-47d8-bd2e-d60d74548fe1"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Ngải cứu", "Ngải cứu", null, null },
                    { new Guid("87ad88b0-c061-4529-b068-8161534e88e2"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Thịt gà tây", "Thịt gà tây", null, null },
                    { new Guid("87bdc764-b826-4bb4-9b46-8f37824eeae4"), 14, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Nước dứa hộp", "Nước dứa hộp", null, null },
                    { new Guid("88239300-b724-4cd0-8bba-fc60a4ec3074"), 10, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Trứng gà", "Trứng gà", null, null },
                    { new Guid("88985b8c-e86c-479c-bd29-4f59081b023f"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Củ cải trắng khô", "Củ cải trắng khô", null, null },
                    { new Guid("89211daf-9bef-49cf-b46e-9e6f894930af"), 1, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Gạo tẻ máy", "Gạo tẻ máy", null, null },
                    { new Guid("893534ac-cd9e-4618-a5fd-bf715372a62a"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Gan gà", "Gan gà", null, null },
                    { new Guid("89cbbf04-778f-4770-be88-c013eac1d81a"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Bột đậu tương đã loại béo (đậu nành)", "Bột đậu tương đã loại béo (đậu nành)", null, null },
                    { new Guid("89ea1022-4bcc-484b-aae6-2abfe51f0ebc"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Đậu Hà Lan", "Đậu Hà Lan", null, null },
                    { new Guid("8a244c8e-991e-411b-b76f-a2214b942374"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Men bia tươi", "Men bia tươi", null, null },
                    { new Guid("8a66c55e-0726-4dc1-9f5e-2289f8400cfc"), 3, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Đậu Hà lan (hạt)", "Đậu Hà lan (hạt)", null, null },
                    { new Guid("8ad7f06c-d894-4014-9ee1-1ed84306d7b2"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Giò bò", "Giò bò", null, null },
                    { new Guid("8b24b9f5-49a1-40af-87d2-f0e19de46e00"), 2, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Bột khoai tây (lọc)", "Bột khoai tây (lọc)", null, null },
                    { new Guid("8b2c1214-e012-4e9a-b409-8f9217a5986d"), 14, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Mứt cam có vỏ", "Mứt cam có vỏ", null, null },
                    { new Guid("8bc8d63b-5513-4d66-ada3-ed94c438623e"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Thịt bò, lưng, nạc và mỡ", "Thịt bò, lưng, nạc và mỡ", null, null },
                    { new Guid("8bc903e2-c84e-44db-a2dc-7e2ac0c80c55"), 14, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Thịt bò hộp", "Thịt bò hộp", null, null },
                    { new Guid("8c66425b-7fe3-47c7-944d-feb2ab4aa828"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Thịt bò khô", "Thịt bò khô", null, null },
                    { new Guid("8c6676f9-7127-4983-a577-18ee605e14fa"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Thịt bò, lưng, nạc", "Thịt bò, lưng, nạc", null, null },
                    { new Guid("8c7445a8-6a1d-41bb-a889-9b98b2d531fc"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Tiết lợn sống", "Tiết lợn sống", null, null },
                    { new Guid("8ccbc1e8-8c92-4358-a62f-0edaac6c55c7"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Bầu dục bò", "Bầu dục bò", null, null },
                    { new Guid("8d31ae7a-b239-4421-8806-469949baabc5"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Mướp Nhật bản", "Mướp Nhật bản", null, null },
                    { new Guid("8d5b99f5-bd6b-4450-bcfa-16386ccb7b8c"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Óc lợn", "Óc lợn", null, null },
                    { new Guid("8da26758-21a4-498a-9f98-9fdbd4acc9a3"), 2, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Củ dong", "Củ dong", null, null },
                    { new Guid("8fe5ab5c-1862-410a-a088-c9891d3ca475"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Dứa tây", "Dứa tây", null, null },
                    { new Guid("906496ca-35bc-4f73-ac4c-53b68d0a6ad6"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Dưa hấu", "Dưa hấu", null, null },
                    { new Guid("9192edc0-b13a-46df-a8a5-097b1d7a2785"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cá bống", "Cá bống", null, null },
                    { new Guid("92032363-80a1-42ea-9912-0626ac134b45"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Dâu gia", "Dâu gia", null, null },
                    { new Guid("921220e1-fc37-4833-bbd1-1773016b8ba7"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Hành lá (hành hoa)", "Hành lá (hành hoa)", null, null },
                    { new Guid("925848dc-a17f-49f0-99db-8b5b9c5a6c09"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Rau má, má mơ", "Rau má, má mơ", null, null },
                    { new Guid("9313d89a-7315-4175-82ee-4b176773a593"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Thịt trâu khô", "Thịt trâu khô", null, null },
                    { new Guid("93911782-4c83-42a6-8f31-d7fe9da13844"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Mực khô", "Mực khô", null, null },
                    { new Guid("93cc3013-96b2-491b-83c7-51fa2d9e34d3"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Thịt trâu bắp", "Thịt trâu bắp", null, null },
                    { new Guid("946d7f95-f9d2-4a90-b530-0e31057f5ab6"), 11, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Sữa bột toàn phần", "Sữa bột toàn phần", null, null },
                    { new Guid("94fc9390-ce71-4618-a1af-cbe97d2370db"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Chả lợn", "Chả lợn", null, null },
                    { new Guid("95004451-278a-43fa-9e33-b91c814b3e6d"), 1, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Bánh đa nem", "Bánh đa nem", null, null },
                    { new Guid("9562702b-1a1d-47cb-b4b1-481555f062da"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Rau giền đỏ", "Rau giền đỏ", null, null },
                    { new Guid("95735ec8-41dd-4f6e-afeb-e9e3db8f6093"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cùi dừa non", "Cùi dừa non", null, null },
                    { new Guid("95d12de0-e331-4442-a0b1-c37a507dc3cf"), 13, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Dầu mè", "Dầu mè", null, null },
                    { new Guid("95da1ecc-3192-4534-b61c-a3eaad8e6093"), 13, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Bơ thực vật", "Bơ thực vật", null, null },
                    { new Guid("95f5e2cb-b808-4932-9ebb-d09bc93a0abc"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Bánh phồng tôm sống", "Bánh phồng tôm sống", null, null },
                    { new Guid("96bd63e9-fa50-4061-9345-101b55cd3e58"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cá mỡ", "Cá mỡ", null, null },
                    { new Guid("96ee92b8-dc9a-4498-8a4c-daed108b2bf2"), 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Kẹo dứa mềm", "Kẹo dứa mềm", null, null },
                    { new Guid("97744c98-0632-44ee-b0c2-ae528d5519ae"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Rau giền cơm", "Rau giền cơm", null, null },
                    { new Guid("97da7455-3314-4a2a-a1eb-997690ee4d15"), 11, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Pho mát", "Pho mát", null, null },
                    { new Guid("9878340c-bac5-4a07-a393-b7de645e9ca7"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Gan lợn", "Gan lợn", null, null },
                    { new Guid("988c757c-f33f-47d2-8823-7ed38e726787"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Sò", "Sò", null, null },
                    { new Guid("991e9211-ed75-4c6e-a23a-0bac59125278"), 11, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Sữa chua", "Sữa chua", null, null },
                    { new Guid("99b39fab-4d68-473e-b240-852fbc622096"), 1, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Bún", "Bún", null, null },
                    { new Guid("99f30366-32b1-49bd-8944-e60b5729bd8e"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Đậu rồng (quả non)", "Đậu rồng (quả non)", null, null },
                    { new Guid("99ff64ba-742f-4b6f-a2f6-70262515d922"), 17, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Xì dầu", "Xì dầu", null, null },
                    { new Guid("9a747278-b5f9-49e8-810c-80e5499bd909"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Lá sắn tươi", "Lá sắn tươi", null, null },
                    { new Guid("9a7da737-be8a-4dd6-840a-90e4b3bf9941"), 2, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Sắn khô", "Sắn khô", null, null },
                    { new Guid("9ac576cd-f932-4906-890a-657f6dd0f457"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Giá đậu tương", "Giá đậu tương", null, null },
                    { new Guid("9ad04c09-590e-4615-a8b4-2cb17c79c445"), 2, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Củ ấu", "Củ ấu", null, null },
                    { new Guid("9be54068-a5b0-44a1-9fa5-d60074a3f1c0"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Thịt trâu thăn", "Thịt trâu thăn", null, null },
                    { new Guid("9c6be64a-51b7-49dd-906c-f0189d025b4b"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "trám trắng", "trám trắng", null, null },
                    { new Guid("9d42772b-c679-4591-81f2-d2059e694dd1"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Dứa ta", "Dứa ta", null, null },
                    { new Guid("9e3a9693-4ee1-4446-80e3-8ff745e92f4b"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cà rốt (củ đỏ, vàng)", "Cà rốt (củ đỏ, vàng)", null, null },
                    { new Guid("9e6d230e-5ed1-4646-9a90-897089b71678"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Súp lơ xanh", "Súp lơ xanh", null, null },
                    { new Guid("9ebfc552-0983-4c5e-8be3-9d8d5a30b51e"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Tủy xương lợn", "Tủy xương lợn", null, null },
                    { new Guid("9f4a75aa-aafe-43b0-b4ea-6b7a9b1eb21e"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Lươn", "Lươn", null, null },
                    { new Guid("9fbe2c15-59a9-4738-b5f7-3c6edeab8ce1"), 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Kẹo số cô la", "Kẹo số cô la", null, null },
                    { new Guid("a07cabad-7541-4877-9716-f2e212e91354"), 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Bánh con cá", "Bánh con cá", null, null },
                    { new Guid("a1e16ae8-5d69-48cb-98ad-6756b077197a"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Rau ngồ", "Rau ngồ", null, null },
                    { new Guid("a24eb45e-e487-4097-9512-7f4ba10a3c41"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Dưa giá (đậu xanh)", "Dưa giá (đậu xanh)", null, null },
                    { new Guid("a2598404-a13a-4d89-a2bc-3937db6277a6"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Dưa cải sen", "Dưa cải sen", null, null },
                    { new Guid("a3110826-3eb1-4f10-b04b-34e130ddfe44"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Mang tre", "Mang tre", null, null },
                    { new Guid("a3afe16e-365c-4ec8-889e-66025e188efe"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cá lác", "Cá lác", null, null },
                    { new Guid("a3bc3a90-4edf-454b-bff4-8ce342c06415"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Đuôi bò", "Đuôi bò", null, null },
                    { new Guid("a3c68a02-90f2-4471-88e7-4d933bf2478b"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cá đối", "Cá đối", null, null },
                    { new Guid("a4b87e38-ef9b-472e-b67e-1b4aa354f5f9"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Rau tàu bay", "Rau tàu bay", null, null },
                    { new Guid("a4d5ca49-e9b9-4a64-b225-59d8219cdc4f"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cá thu đao", "Cá thu đao", null, null },
                    { new Guid("a5146361-4101-4ce5-aad8-97f3d2408576"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Vải khô", "Vải khô", null, null },
                    { new Guid("a547a492-94dc-455c-ab53-4f19e6a82168"), 15, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cô nhắc (cồn 32 g)", "Cô nhắc (cồn 32 g)", null, null },
                    { new Guid("a5a46ca2-9a28-4278-b02c-862d6d59b63c"), 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Bánh chả", "Bánh chả", null, null },
                    { new Guid("a660b0d8-24ba-4ac4-8ff5-a123af03ab32"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Dưa chuột", "Dưa chuột", null, null },
                    { new Guid("a6bae2b0-79f0-46b8-a801-334134a0d438"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Rau mùi tàu", "Rau mùi tàu", null, null },
                    { new Guid("a71f88fa-777c-4583-9a4e-22ba2f4d833b"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Mướp", "Mướp", null, null },
                    { new Guid("a78c439c-8a0d-4a0d-92a4-0680c279192c"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cá ngừ", "Cá ngừ", null, null },
                    { new Guid("a79e4d1b-0b4f-42d3-a219-a3f853860f9c"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Tim bò", "Tim bò", null, null },
                    { new Guid("a9427866-6965-4a30-9bac-923f0831734d"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Thịt trâu", "Thịt trâu", null, null },
                    { new Guid("a9d047b1-564d-4415-b289-d7b37b26dabe"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Đu đủ chín", "Đu đủ chín", null, null },
                    { new Guid("aafeb2b1-1858-4392-8292-4fff53f2871f"), 15, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Rượu vang đô (cồn 9,5 g)", "Rượu vang đô (cồn 9,5 g)", null, null },
                    { new Guid("ab54b510-f5f1-49d5-b777-5f4537e0a377"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Thịt bò loại I", "Thịt bò loại I", null, null },
                    { new Guid("aba8e492-dbc8-4849-b5c4-16c4ec7c7922"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Rau ngót", "Rau ngót", null, null },
                    { new Guid("abb670af-a205-4f85-a79c-00c9b18921f2"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Bánh phồng tôm rán", "Bánh phồng tôm rán", null, null },
                    { new Guid("abe7150b-5cef-4980-826c-5ea3fcc532a0"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cần ta", "Cần ta", null, null },
                    { new Guid("acb5193d-0a7a-48cd-90d1-0766e25cd7c8"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Dâu tây", "Dâu tây", null, null },
                    { new Guid("acd75186-cd89-4a11-a24f-94d17bec36e3"), 17, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Nghệ tươi", "Nghệ tươi", null, null },
                    { new Guid("acd993d6-7a99-4714-a52b-948720bb5898"), 11, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Sữa mẹ (sữa người)", "Sữa mẹ (sữa người)", null, null },
                    { new Guid("acdb053b-0bdf-4ed9-b427-de5e5b3a4a9c"), 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Kẹo Pastille (kẹo ngậm bạc hà)", "Kẹo Pastille (kẹo ngậm bạc hà)", null, null },
                    { new Guid("adf0804e-bc1c-4e9c-b78c-b699cf1e9fa1"), 13, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Bơ", "Bơ", null, null },
                    { new Guid("ae518255-aedb-4e26-a19e-71e042c8735a"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cá trích", "Cá trích", null, null },
                    { new Guid("ae544533-ff49-4c3f-a428-6e39d806640a"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Hẹ lá", "Hẹ lá", null, null },
                    { new Guid("ae8c2f12-e6d6-4fbb-89bd-3973b88c0236"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Lựu", "Lựu", null, null },
                    { new Guid("aeec2575-4ec5-4cac-b286-69c36028a0ab"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Đu đủ xanh", "Đu đủ xanh", null, null },
                    { new Guid("b0809c59-8361-4009-8c1f-ad202131609b"), 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Đường cát", "Đường cát", null, null },
                    { new Guid("b08281cc-d3f0-4824-b704-1d5497490270"), 2, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Khoai lang khô", "Khoai lang khô", null, null },
                    { new Guid("b0abed68-09b2-4f8e-a007-6f95c37b2581"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Ốc nhồi", "Ốc nhồi", null, null },
                    { new Guid("b0af1978-2819-4f93-a070-306b7e1023b5"), 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Kẹo bơ cứng", "Kẹo bơ cứng", null, null },
                    { new Guid("b1033a76-8129-4ea3-b4d5-079853509b81"), 17, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Sốt mayonnaise", "Sốt mayonnaise", null, null },
                    { new Guid("b155b4a7-f5a1-4c23-9ea7-f2657d1682b6"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cà chua", "Cà chua", null, null },
                    { new Guid("b18cbd82-b18d-4a2f-8be3-50231a7d260d"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Đậu đũa (hạt)", "Đậu đũa (hạt)", null, null },
                    { new Guid("b1aaa2db-fbc4-45da-8bfc-626b541f034d"), 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Bánh kem xốp", "Bánh kem xốp", null, null },
                    { new Guid("b215d825-ce00-4ede-8382-bbf1c4f33069"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Hành củ tươi", "Hành củ tươi", null, null },
                    { new Guid("b29db148-ab26-4445-853c-92d6b2735e65"), 1, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Bánh bao", "Bánh bao", null, null },
                    { new Guid("b2a1caf2-bbe1-4858-8d7f-1e1f96980b73"), 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Bánh quế", "Bánh quế", null, null },
                    { new Guid("b2e4a199-261b-4ddf-9c06-5d5d9105203f"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Nấm mỡ (Nấm tây)", "Nấm mỡ (Nấm tây)", null, null },
                    { new Guid("b2e577d1-dad3-4fb6-8d78-62e3c241a1ef"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Rau sắng", "Rau sắng", null, null },
                    { new Guid("b382812a-2413-4900-8776-5125da5fe4a8"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Dọc mùng", "Dọc mùng", null, null },
                    { new Guid("b44ee341-2320-4b19-9fad-cee3c08e9dcb"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Thịt gà rừng", "Thịt gà rừng", null, null },
                    { new Guid("b4c28dc5-7304-4126-9d49-66ac35d065b1"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Măng khô", "Măng khô", null, null },
                    { new Guid("b5107a80-03e4-4f11-92c5-ed676e0c267a"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Quất chín (cả vỏ)", "Quất chín (cả vỏ)", null, null },
                    { new Guid("b53877ae-ba62-45ff-8df5-038829696156"), 11, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Sữa bột tách béo", "Sữa bột tách béo", null, null },
                    { new Guid("b5491af8-52c9-4a07-a2b0-0b1aa1bdc984"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Đậu phụ chúc", "Đậu phụ chúc", null, null },
                    { new Guid("b652bdaa-502c-4e0d-ae0b-0d3ab071cac2"), 17, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cary bột", "Cary bột", null, null },
                    { new Guid("b958e53c-678e-4ff3-bd0c-9a6565021cbf"), 17, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Mắm tôm loãng", "Mắm tôm loãng", null, null },
                    { new Guid("b96deb72-e938-4399-880a-26d13e103eda"), 3, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Đậu xanh (đậu tắt)", "Đậu xanh (đậu tắt)", null, null },
                    { new Guid("b98fcb66-fdce-4df9-8a5a-7864d06e9f07"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cà tím", "Cà tím", null, null },
                    { new Guid("b9bfc5a0-dc53-4bf0-a09c-6dd0ae48b3d4"), 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Kẹo lạc", "Kẹo lạc", null, null },
                    { new Guid("b9c86a3f-33f4-4889-b4ab-f44e112b4114"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cải thìa (cải trắng)", "Cải thìa (cải trắng)", null, null },
                    { new Guid("ba6967e6-8b23-4231-9249-2fb205030fd3"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Nấm thường tươi", "Nấm thường tươi", null, null },
                    { new Guid("bb5d9426-0e07-4d75-b211-b0fb143ef083"), 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Bánh số cô la", "Bánh số cô la", null, null },
                    { new Guid("bbb480c2-ba8c-40cf-80eb-a993dae74776"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Dưa bở", "Dưa bở", null, null },
                    { new Guid("bd11912e-83de-461f-81f7-cb3e5f00abad"), 2, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Khoai môn", "Khoai môn", null, null },
                    { new Guid("bd16d80d-89da-4a85-bf13-8dcdb7f64648"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Quả me chua", "Quả me chua", null, null },
                    { new Guid("bd836393-b551-410a-a9b3-609fcc7f4e2c"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cá mè", "Cá mè", null, null },
                    { new Guid("bdbd0141-e019-4c86-98b8-9b58ffc7d24d"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cá đồng tiền", "Cá đồng tiền", null, null },
                    { new Guid("bdd1eeb6-75b4-4273-8600-0a79d541138f"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cà rốt khô", "Cà rốt khô", null, null },
                    { new Guid("bdd44df5-2a1a-4c03-824d-f620893b5f54"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Ruốc cá quả", "Ruốc cá quả", null, null },
                    { new Guid("beb2ac27-ed94-4220-a7a0-30f1f30a5176"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Quả cóc", "Quả cóc", null, null },
                    { new Guid("bf5b57b1-7125-49ff-b83c-85039ffb6d7e"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Bì lợn", "Bì lợn", null, null },
                    { new Guid("bfa35941-fdf0-4d8a-b74c-75bb2d8d0d0d"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Củ cải đỏ", "Củ cải đỏ", null, null },
                    { new Guid("c044bc41-45cc-497e-a111-32711eac5ddf"), 3, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Đậu tương (đậu nành)", "Đậu tương (đậu nành)", null, null },
                    { new Guid("c08954e3-33bc-448e-8121-15b6b98c091e"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Súp lo trắng", "Súp lo trắng", null, null },
                    { new Guid("c0c6b6aa-8605-4ad0-a761-563bc7baa88e"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Dưa lê", "Dưa lê", null, null },
                    { new Guid("c0fe6d46-f135-42dc-9fdc-84f485a02088"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cá trạch", "Cá trạch", null, null },
                    { new Guid("c28bcaea-230d-4fed-a87e-07e79cd8038d"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Sữa bột đậu nành", "Sữa bột đậu nành", null, null },
                    { new Guid("c2de77af-665e-4e6e-a014-4edb4d41d40b"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Tía tô", "Tía tô", null, null },
                    { new Guid("c3ceef4f-e2fd-4f77-a225-9f8fb0a23c7b"), 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Bột ca cao", "Bột ca cao", null, null },
                    { new Guid("c405367e-1d5c-494e-ab41-c79d77a9b469"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Ôi", "Ôi", null, null },
                    { new Guid("c43eabe9-2c1b-43a7-bbb8-219bf1f35576"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Chôm chôm", "Chôm chôm", null, null },
                    { new Guid("c46d2d2f-2b02-40df-b42a-afa7b86914cc"), 2, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Khoai sọ", "Khoai sọ", null, null },
                    { new Guid("c4985d64-36cc-43a7-a704-72ac5f347589"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Mắc coọc", "Mắc coọc", null, null },
                    { new Guid("c4e1c89d-41fe-4263-9a2c-bbb81a064390"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Tiết lợn luộc", "Tiết lợn luộc", null, null },
                    { new Guid("c4fda541-4cc8-4036-ab4a-b145a0646f37"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Xúc xích", "Xúc xích", null, null },
                    { new Guid("c581d0ac-694c-4d21-acbf-e958cce3e847"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Su su", "Su su", null, null },
                    { new Guid("c632a038-7dc6-4b42-8695-b1297f13f77a"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cá chép", "Cá chép", null, null },
                    { new Guid("c71074eb-4b4f-4c54-9ef8-693be73fac1c"), 1, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Bỏng ngô", "Bỏng ngô", null, null },
                    { new Guid("c75f7865-040a-4d9f-bc30-ab8d54160938"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Vừng (đen, trắng)", "Vừng (đen, trắng)", null, null },
                    { new Guid("c762c8fb-8e66-4834-920d-966258d9dd9a"), 17, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Tương ngô", "Tương ngô", null, null },
                    { new Guid("c768bcf1-0931-40b1-92f7-1963591cfbc3"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Bột cóc", "Bột cóc", null, null },
                    { new Guid("c7f2c1c2-d1b9-4cc5-b5bc-56fe9265d854"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Na", "Na", null, null },
                    { new Guid("c82aa051-bd80-4285-8296-ffe60a22b56c"), 11, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Sữa bò tươi", "Sữa bò tươi", null, null },
                    { new Guid("c88a3a92-cb46-4831-aff1-2a9a80540a29"), 15, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Nước cam tươi", "Nước cam tươi", null, null },
                    { new Guid("c89d69d6-3478-4194-b2ae-6677cbcab45e"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Chuối xanh", "Chuối xanh", null, null },
                    { new Guid("c8bf1807-f3eb-41fb-add4-f748bc7f5faf"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Củ đậu", "Củ đậu", null, null },
                    { new Guid("c901bc94-ee7f-4a41-9122-59ad81b1cebf"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Đầu lợn", "Đầu lợn", null, null },
                    { new Guid("c940f39d-8266-4fd4-bfd9-2b096a71dae4"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Trai", "Trai", null, null },
                    { new Guid("c9d15a3a-c50e-4ca1-a413-5a8b79a6fbe2"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cá phèn", "Cá phèn", null, null },
                    { new Guid("c9d36937-93b1-4599-b8f3-08a09cca7db4"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cua bể", "Cua bể", null, null },
                    { new Guid("c9fbaf22-3e74-4a07-a44c-a93941300587"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Ba tê", "Ba tê", null, null },
                    { new Guid("ca02e0ce-cc72-4a5f-ac8d-8f791fcc3cc2"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Dồi lợn", "Dồi lợn", null, null },
                    { new Guid("caec4064-1350-4a80-ac0f-decec1f74785"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Thịt vịt", "Thịt vịt", null, null },
                    { new Guid("caf891e2-196d-4333-acbd-c6294cae9374"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Bí đao (bí xanh)", "Bí đao (bí xanh)", null, null },
                    { new Guid("cb0948ab-df19-4046-b3ec-3e7ead5eee7e"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Rau rút", "Rau rút", null, null },
                    { new Guid("cb172c35-6923-4c3c-a82b-ecf20e66b3ba"), 1, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Ngô nếp luộc", "Ngô nếp luộc", null, null },
                    { new Guid("cb49caff-a68c-4ad2-9521-c965a26b0849"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Phổi lợn", "Phổi lợn", null, null },
                    { new Guid("cb4ff0c8-0919-49db-a868-b80e9d20bc84"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Thịt trâu đùi", "Thịt trâu đùi", null, null },
                    { new Guid("cbd79b19-3e0a-4ec3-9465-e57f12c301a2"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Giò thủ lợn", "Giò thủ lợn", null, null },
                    { new Guid("cc9fd5f5-6ccd-4495-a63c-ca2f53c42603"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Chuối tiêu", "Chuối tiêu", null, null },
                    { new Guid("cceb642d-a116-46c3-bb90-4a2e761d132e"), 14, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Mận nước đường", "Mận nước đường", null, null },
                    { new Guid("ccec5626-b537-4f5c-8cb9-d1b880cb571e"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Rau sà lách", "Rau sà lách", null, null },
                    { new Guid("ce07dbca-adc8-4723-b601-8b3689420671"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Kiệu muối", "Kiệu muối", null, null },
                    { new Guid("ceb61e4e-8d26-4381-bce1-f542e9c519c4"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Rau đay", "Rau đay", null, null },
                    { new Guid("cf13785e-2037-4eb5-9c52-507524584d58"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Lòng lợn (ruột già)", "Lòng lợn (ruột già)", null, null },
                    { new Guid("d1c10504-b8a9-42dd-a21e-519a13032154"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Đuôi lợn", "Đuôi lợn", null, null },
                    { new Guid("d1dbe236-f24c-4ec4-a89e-b402bf571fc1"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Thịt lợn nạc", "Thịt lợn nạc", null, null },
                    { new Guid("d3002c6d-fc34-4166-afc6-b92623f7fb40"), 15, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Rượu trắng (cồn 39 g)", "Rượu trắng (cồn 39 g)", null, null },
                    { new Guid("d31d98d7-aa45-4022-ad51-e847b5477fc3"), 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Mứt lạc", "Mứt lạc", null, null },
                    { new Guid("d3fc6ccf-4ed0-46b5-95b8-88a591f5eb51"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Thịt bồ câu ra ràng", "Thịt bồ câu ra ràng", null, null },
                    { new Guid("d4ff4ac3-13fc-4fe5-bb07-0f862245327e"), 1, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Ngô vàng hạt khô", "Ngô vàng hạt khô", null, null },
                    { new Guid("d551c4ef-c456-4a52-8cdc-e1367c97f999"), 2, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Củ sắn dây", "Củ sắn dây", null, null },
                    { new Guid("d55a0368-6c2f-4d8b-9ed9-0e424da9b807"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Hạt điều khô, chiên dầu", "Hạt điều khô, chiên dầu", null, null },
                    { new Guid("d58c149f-9e19-4f05-8668-8d9af24b8d7c"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Rạm (muối, đồ)", "Rạm (muối, đồ)", null, null },
                    { new Guid("d5ec095f-b87e-4382-bd1e-72a7cdf002c8"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Măng chua", "Măng chua", null, null },
                    { new Guid("d5fafe15-a6b5-470d-b15e-9f865174b073"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Đậu trứng cuốc", "Đậu trứng cuốc", null, null },
                    { new Guid("d5fff0c5-35be-41f9-b998-bf7cbfb657d7"), 14, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Thịt lợn hộp", "Thịt lợn hộp", null, null },
                    { new Guid("d7338e1b-63c8-49a1-92e6-7950c79131cf"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cải xanh", "Cải xanh", null, null },
                    { new Guid("d79ca90f-224f-4e70-8bc8-8d7ce7ebd27d"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Rau mùi", "Rau mùi", null, null },
                    { new Guid("d82ff48f-a30c-47bc-8aac-91847f0fe084"), 2, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Bột dong lọc", "Bột dong lọc", null, null },
                    { new Guid("d96d252f-f846-4211-b2cc-7efb537497ab"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cá da", "Cá da", null, null },
                    { new Guid("d9cf83b6-356c-41d6-8abd-1f330037f0d1"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Hạt điều", "Hạt điều", null, null },
                    { new Guid("da04c904-de4e-4dce-b5b2-0604212545a0"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Rau răm", "Rau răm", null, null },
                    { new Guid("da9014b8-6605-47bd-81b1-57e45ce13738"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cá nạc", "Cá nạc", null, null },
                    { new Guid("db56c136-c5db-417c-aa77-3c37b4ce97b4"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Táo ta", "Táo ta", null, null },
                    { new Guid("db9ca133-700d-41be-a8f7-ea95e762bf15"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Đậu trắng hạt (đậu tây)", "Đậu trắng hạt (đậu tây)", null, null },
                    { new Guid("dcc36c1d-b9e4-4467-95d3-fda65d8a827a"), 17, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Mắm tôm đặc", "Mắm tôm đặc", null, null },
                    { new Guid("dcfd3c2d-add9-47f4-b8d1-af1020dc3f7d"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Quả dọc", "Quả dọc", null, null },
                    { new Guid("ddb07cab-c827-4000-acc1-9776e2a5657d"), 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Mạch nha", "Mạch nha", null, null },
                    { new Guid("de4dba78-88fd-4884-b8ce-9242570ad242"), 2, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Khoai tây khô", "Khoai tây khô", null, null },
                    { new Guid("dffdfa95-8656-43aa-ab81-5421bd4bb62d"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Nấm rơm", "Nấm rơm", null, null },
                    { new Guid("e023309e-089c-49e8-962e-919e64306933"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Ốc bươu", "Ốc bươu", null, null },
                    { new Guid("e0bd26c7-307b-48aa-b8c3-48ed00231eb2"), 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Bánh khảo chay", "Bánh khảo chay", null, null },
                    { new Guid("e11e97c8-6235-4d98-bc2b-c23ec9ae8a1c"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Sữa đậu nành (100g đậu/lít)", "Sữa đậu nành (100g đậu/lít)", null, null },
                    { new Guid("e37b7552-e04f-440e-a6b3-90a6487d308b"), 14, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Chuối nước đường", "Chuối nước đường", null, null },
                    { new Guid("e3b3e76e-ba7e-4ff7-899d-9a3d8beb3141"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Ngó sen", "Ngó sen", null, null },
                    { new Guid("e45f21b7-e2d5-433a-bef3-1b9ded43f3b7"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cá hồi", "Cá hồi", null, null },
                    { new Guid("e4c823cf-403c-40f7-ad21-42b7d8e3b699"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Thìa là", "Thìa là", null, null },
                    { new Guid("e5052e02-26be-4000-9f23-ff7af1125f8d"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cá diếc", "Cá diếc", null, null },
                    { new Guid("e588845c-db29-4672-80db-991d320de9ee"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Hải sâm", "Hải sâm", null, null },
                    { new Guid("e5b8afc5-32b7-431c-bf20-e46500b8aed2"), 2, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Khoai riềng", "Khoai riềng", null, null },
                    { new Guid("e5f2163b-acaa-41f2-aa9f-8259fcfd6a4b"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cải bắp đỏ", "Cải bắp đỏ", null, null },
                    { new Guid("e67a74a7-093f-4c7b-a0f8-7f2546a4bfe3"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Mướp đắng", "Mướp đắng", null, null },
                    { new Guid("e6ab316c-9273-438a-af26-3b55be9d5c7e"), 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Kẹo cam chanh", "Kẹo cam chanh", null, null },
                    { new Guid("e6d3d333-574f-4480-8575-6d8e6d939ac6"), 14, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Dứa hộp", "Dứa hộp", null, null },
                    { new Guid("e7101286-ba1e-4315-ba8a-18360ede4231"), 15, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Rượu Whisky (cồn 35,2 g)", "Rượu Whisky (cồn 35,2 g)", null, null },
                    { new Guid("e879a989-417a-410c-a3d5-fc31c192f049"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Quả cọ tươi", "Quả cọ tươi", null, null },
                    { new Guid("e8c6b9cb-8b87-4175-b823-353ccaed2ecb"), 1, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Bột mì", "Bột mì", null, null },
                    { new Guid("e901d071-c385-420e-a58a-23f0dc94518b"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cá nục", "Cá nục", null, null },
                    { new Guid("e99730f4-f269-4f23-9043-4b869059f9f5"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Hoa chuối", "Hoa chuối", null, null },
                    { new Guid("ea7238a8-691b-430e-8b9c-e44e7aff6a64"), 2, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Bột sắn dây", "Bột sắn dây", null, null },
                    { new Guid("ea7ac15b-dd90-427d-9ba3-65efb0d20457"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Ốc vặn", "Ốc vặn", null, null },
                    { new Guid("ea803d40-e82e-4c56-9d6e-3f169c932c74"), 1, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Bột gạo tẻ", "Bột gạo tẻ", null, null },
                    { new Guid("ec00b0f2-b628-45d9-9e3c-e470e714193b"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Hành củ muối", "Hành củ muối", null, null },
                    { new Guid("ed2def0a-1913-494b-9d63-56077567a282"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Táo tây", "Táo tây", null, null },
                    { new Guid("ed4aa575-c6c8-4a35-b04b-e86d214d6f90"), 2, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Khoai lang", "Khoai lang", null, null },
                    { new Guid("ed835445-7493-4ab9-923a-81975aa40e43"), 13, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Dầu lạc", "Dầu lạc", null, null },
                    { new Guid("ed99f44b-c949-4931-b34e-ba220acfddf2"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Mơ", "Mơ", null, null },
                    { new Guid("eda16a61-9cb3-4674-a8e0-7dc21a18ef65"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Châu chấu", "Châu chấu", null, null },
                    { new Guid("ee5cf060-327d-4391-822e-15f0a9e51b34"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Nem chạo", "Nem chạo", null, null },
                    { new Guid("ee642b31-bb9e-42c4-a09f-d3d522f5f784"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Rau muống", "Rau muống", null, null },
                    { new Guid("eff8ab35-5e9e-4e46-b750-5076434b674e"), 16, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Kẹo dừa mềm", "Kẹo dừa mềm", null, null },
                    { new Guid("f079ef32-835c-4bf6-8309-68242241ab48"), 1, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Gạo nếp máy", "Gạo nếp máy", null, null },
                    { new Guid("f13b2870-35ba-40ea-a944-c219557daf28"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Rươi", "Rươi", null, null },
                    { new Guid("f1573408-15d1-4127-bec0-1faa49be7e89"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Bột đậu xanh", "Bột đậu xanh", null, null },
                    { new Guid("f1d75202-a23b-45c7-94f6-580a8abd8b53"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Mề gà", "Mề gà", null, null },
                    { new Guid("f2890594-d612-4124-9ea6-77bf5d53fe7b"), 1, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Kê", "Kê", null, null },
                    { new Guid("f3398190-3dc9-4160-a772-2df72fda912d"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Tép gạo", "Tép gạo", null, null },
                    { new Guid("f355d1b0-0886-4d50-ad25-b49c927b4164"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Củ niễng", "Củ niễng", null, null },
                    { new Guid("f3ea5ffb-0041-4dd1-ba2d-766e765c135a"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Gân chân bò", "Gân chân bò", null, null },
                    { new Guid("f41013c5-154f-4269-96fa-1e3ffe73cf96"), 10, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Trứng cá", "Trứng cá", null, null },
                    { new Guid("f4168353-c494-4e15-a1c3-3befd481df1f"), 13, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Dầu ngô", "Dầu ngô", null, null },
                    { new Guid("f4c6013f-8e04-4626-a2e9-806ef38e6e73"), 15, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Rượu vang trắng ngọt (cồn 10.2 g)", "Rượu vang trắng ngọt (cồn 10.2 g)", null, null },
                    { new Guid("f544ebd7-85f6-478b-8a29-8313d1074927"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Trám xanh sống,", "Trám xanh sống,", null, null },
                    { new Guid("f69f2922-7774-49cc-9ebe-161ddfa87f60"), 1, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Bánh đúc", "Bánh đúc", null, null },
                    { new Guid("f6f4db96-7081-4ffc-9641-d2b1e5c6ffbf"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Dạ dày bò", "Dạ dày bò", null, null },
                    { new Guid("f74bb482-05c1-4d85-9a3b-39a23617cf97"), 17, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Nước mắm cá", "Nước mắm cá", null, null },
                    { new Guid("f7bf597d-d9c1-412c-8d75-48bcf4eb3205"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Bầu", "Bầu", null, null },
                    { new Guid("f7fb75a6-9cb2-49b8-89f4-a292ae471d91"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Thịt thỏ rừng", "Thịt thỏ rừng", null, null },
                    { new Guid("f87c7194-687f-4135-a9e7-5b74720ec50d"), 2, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Khoai nước", "Khoai nước", null, null },
                    { new Guid("f9c57e12-24c8-4cda-b089-50355bdb6e35"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Tôm đồng", "Tôm đồng", null, null },
                    { new Guid("fa5456a1-a6da-4c69-b3bd-18299f11e4de"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Rau ngót khô", "Rau ngót khô", null, null },
                    { new Guid("fae05926-8707-444c-8a69-394e8fd1ebcc"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Rau khoai lang", "Rau khoai lang", null, null },
                    { new Guid("fc12b1a5-afbc-4f77-96e2-73ebe101a30a"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Hạt mít", "Hạt mít", null, null },
                    { new Guid("fc33e964-b88a-4d42-9447-2ee81ae17955"), 7, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Thịt cho vai", "Thịt cho vai", null, null },
                    { new Guid("fc5aa659-c77b-424b-89ae-ab0788fec893"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Dưa cải bẹ", "Dưa cải bẹ", null, null },
                    { new Guid("fcbc233f-6669-4ad9-ae74-400f16527d7b"), 1, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Bánh phở", "Bánh phở", null, null },
                    { new Guid("fd84c453-461c-419e-8981-3293d0031580"), 9, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cua ghẹ", "Cua ghẹ", null, null },
                    { new Guid("fe1d30aa-141e-4f65-a72c-dc1dcddff5b2"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Khế", "Khế", null, null },
                    { new Guid("fe87958d-78cf-4296-8901-b87c71ba9f5f"), 5, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Cam", "Cam", null, null },
                    { new Guid("fea57822-da41-4fa9-9902-fc1b5b345f41"), 11, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Sữa đặc có đường Việt Nam", "Sữa đặc có đường Việt Nam", null, null },
                    { new Guid("ff5b2ca4-56b8-44a1-9183-f235027361ef"), 4, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Hoa lý", "Hoa lý", null, null },
                    { new Guid("ff9ac8a2-7e3d-44e6-8af8-95e7930c482e"), 6, "admin", new DateTimeOffset(new DateTime(2024, 9, 19, 11, 37, 24, 38, DateTimeKind.Unspecified).AddTicks(2181), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, null, "Hạt dẻ tươi", "Hạt dẻ tươi", null, null }
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
