using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Eletrônicos");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Roupas");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Livros");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse non malesuada nunc. Sed ultricies interdum bibendum. Suspendisse placerat ipsum eu ullamcorper accumsan. Nulla sollicitudin faucibus ipsum, et dictum felis. Quisque tincidunt eros efficitur tellus congue molestie. Phasellus eu rutrum ante. Integer condimentum, elit et euismod porta, quam lectus venenatis urna, nec suscipit nisi nisl eget dui. Curabitur vehicula auctor eros, nec imperdiet odio tristique id. In sollicitudin sollicitudin augue, vitae tempor risus eleifend ut. Suspendisse tincidunt congue justo, et accumsan tortor suscipit vel. Sed sit amet gravida quam. Donec maximus nec nulla a gravida. Morbi ut lectus venenatis, hendrerit odio eu, varius ante. Vivamus feugiat sollicitudin turpis, ut auctor nisl molestie quis.", "Smartphone", 1500m },
                    { 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse non malesuada nunc. Sed ultricies interdum bibendum. Suspendisse placerat ipsum eu ullamcorper accumsan. Nulla sollicitudin faucibus ipsum, et dictum felis. Quisque tincidunt eros efficitur tellus congue molestie. Phasellus eu rutrum ante. Integer condimentum, elit et euismod porta, quam lectus venenatis urna, nec suscipit nisi nisl eget dui. Curabitur vehicula auctor eros, nec imperdiet odio tristique id. In sollicitudin sollicitudin augue, vitae tempor risus eleifend ut. Suspendisse tincidunt congue justo, et accumsan tortor suscipit vel. Sed sit amet gravida quam. Donec maximus nec nulla a gravida. Morbi ut lectus venenatis, hendrerit odio eu, varius ante. Vivamus feugiat sollicitudin turpis, ut auctor nisl molestie quis.", "Laptop", 2500m },
                    { 3, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse non malesuada nunc. Sed ultricies interdum bibendum. Suspendisse placerat ipsum eu ullamcorper accumsan. Nulla sollicitudin faucibus ipsum, et dictum felis. Quisque tincidunt eros efficitur tellus congue molestie. Phasellus eu rutrum ante. Integer condimentum, elit et euismod porta, quam lectus venenatis urna, nec suscipit nisi nisl eget dui. Curabitur vehicula auctor eros, nec imperdiet odio tristique id. In sollicitudin sollicitudin augue, vitae tempor risus eleifend ut. Suspendisse tincidunt congue justo, et accumsan tortor suscipit vel. Sed sit amet gravida quam. Donec maximus nec nulla a gravida. Morbi ut lectus venenatis, hendrerit odio eu, varius ante. Vivamus feugiat sollicitudin turpis, ut auctor nisl molestie quis.", "Camiseta", 10m },
                    { 4, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse non malesuada nunc. Sed ultricies interdum bibendum. Suspendisse placerat ipsum eu ullamcorper accumsan. Nulla sollicitudin faucibus ipsum, et dictum felis. Quisque tincidunt eros efficitur tellus congue molestie. Phasellus eu rutrum ante. Integer condimentum, elit et euismod porta, quam lectus venenatis urna, nec suscipit nisi nisl eget dui. Curabitur vehicula auctor eros, nec imperdiet odio tristique id. In sollicitudin sollicitudin augue, vitae tempor risus eleifend ut. Suspendisse tincidunt congue justo, et accumsan tortor suscipit vel. Sed sit amet gravida quam. Donec maximus nec nulla a gravida. Morbi ut lectus venenatis, hendrerit odio eu, varius ante. Vivamus feugiat sollicitudin turpis, ut auctor nisl molestie quis.", "Calça Jeans", 100m },
                    { 5, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse non malesuada nunc. Sed ultricies interdum bibendum. Suspendisse placerat ipsum eu ullamcorper accumsan. Nulla sollicitudin faucibus ipsum, et dictum felis. Quisque tincidunt eros efficitur tellus congue molestie. Phasellus eu rutrum ante. Integer condimentum, elit et euismod porta, quam lectus venenatis urna, nec suscipit nisi nisl eget dui. Curabitur vehicula auctor eros, nec imperdiet odio tristique id. In sollicitudin sollicitudin augue, vitae tempor risus eleifend ut. Suspendisse tincidunt congue justo, et accumsan tortor suscipit vel. Sed sit amet gravida quam. Donec maximus nec nulla a gravida. Morbi ut lectus venenatis, hendrerit odio eu, varius ante. Vivamus feugiat sollicitudin turpis, ut auctor nisl molestie quis.", "Livro de Romance", 30m },
                    { 6, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse non malesuada nunc. Sed ultricies interdum bibendum. Suspendisse placerat ipsum eu ullamcorper accumsan. Nulla sollicitudin faucibus ipsum, et dictum felis. Quisque tincidunt eros efficitur tellus congue molestie. Phasellus eu rutrum ante. Integer condimentum, elit et euismod porta, quam lectus venenatis urna, nec suscipit nisi nisl eget dui. Curabitur vehicula auctor eros, nec imperdiet odio tristique id. In sollicitudin sollicitudin augue, vitae tempor risus eleifend ut. Suspendisse tincidunt congue justo, et accumsan tortor suscipit vel. Sed sit amet gravida quam. Donec maximus nec nulla a gravida. Morbi ut lectus venenatis, hendrerit odio eu, varius ante. Vivamus feugiat sollicitudin turpis, ut auctor nisl molestie quis.", "Livro de Drama", 200m },
                    { 7, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse non malesuada nunc. Sed ultricies interdum bibendum. Suspendisse placerat ipsum eu ullamcorper accumsan. Nulla sollicitudin faucibus ipsum, et dictum felis. Quisque tincidunt eros efficitur tellus congue molestie. Phasellus eu rutrum ante. Integer condimentum, elit et euismod porta, quam lectus venenatis urna, nec suscipit nisi nisl eget dui. Curabitur vehicula auctor eros, nec imperdiet odio tristique id. In sollicitudin sollicitudin augue, vitae tempor risus eleifend ut. Suspendisse tincidunt congue justo, et accumsan tortor suscipit vel. Sed sit amet gravida quam. Donec maximus nec nulla a gravida. Morbi ut lectus venenatis, hendrerit odio eu, varius ante. Vivamus feugiat sollicitudin turpis, ut auctor nisl molestie quis.", "Fones de ouvido", 300m },
                    { 8, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse non malesuada nunc. Sed ultricies interdum bibendum. Suspendisse placerat ipsum eu ullamcorper accumsan. Nulla sollicitudin faucibus ipsum, et dictum felis. Quisque tincidunt eros efficitur tellus congue molestie. Phasellus eu rutrum ante. Integer condimentum, elit et euismod porta, quam lectus venenatis urna, nec suscipit nisi nisl eget dui. Curabitur vehicula auctor eros, nec imperdiet odio tristique id. In sollicitudin sollicitudin augue, vitae tempor risus eleifend ut. Suspendisse tincidunt congue justo, et accumsan tortor suscipit vel. Sed sit amet gravida quam. Donec maximus nec nulla a gravida. Morbi ut lectus venenatis, hendrerit odio eu, varius ante. Vivamus feugiat sollicitudin turpis, ut auctor nisl molestie quis.", "Smartwatch", 800m },
                    { 9, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse non malesuada nunc. Sed ultricies interdum bibendum. Suspendisse placerat ipsum eu ullamcorper accumsan. Nulla sollicitudin faucibus ipsum, et dictum felis. Quisque tincidunt eros efficitur tellus congue molestie. Phasellus eu rutrum ante. Integer condimentum, elit et euismod porta, quam lectus venenatis urna, nec suscipit nisi nisl eget dui. Curabitur vehicula auctor eros, nec imperdiet odio tristique id. In sollicitudin sollicitudin augue, vitae tempor risus eleifend ut. Suspendisse tincidunt congue justo, et accumsan tortor suscipit vel. Sed sit amet gravida quam. Donec maximus nec nulla a gravida. Morbi ut lectus venenatis, hendrerit odio eu, varius ante. Vivamus feugiat sollicitudin turpis, ut auctor nisl molestie quis.", "Jaqueta", 150m },
                    { 10, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse non malesuada nunc. Sed ultricies interdum bibendum. Suspendisse placerat ipsum eu ullamcorper accumsan. Nulla sollicitudin faucibus ipsum, et dictum felis. Quisque tincidunt eros efficitur tellus congue molestie. Phasellus eu rutrum ante. Integer condimentum, elit et euismod porta, quam lectus venenatis urna, nec suscipit nisi nisl eget dui. Curabitur vehicula auctor eros, nec imperdiet odio tristique id. In sollicitudin sollicitudin augue, vitae tempor risus eleifend ut. Suspendisse tincidunt congue justo, et accumsan tortor suscipit vel. Sed sit amet gravida quam. Donec maximus nec nulla a gravida. Morbi ut lectus venenatis, hendrerit odio eu, varius ante. Vivamus feugiat sollicitudin turpis, ut auctor nisl molestie quis.", "Livro de Biografia", 40m }
                });

            migrationBuilder.InsertData(
                table: "CategoryProduct",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 7 },
                    { 1, 8 },
                    { 2, 3 },
                    { 2, 4 },
                    { 2, 9 },
                    { 3, 5 },
                    { 3, 6 },
                    { 3, 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 1, 7 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 1, 8 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 2, 9 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 3, 10 });

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Electronics");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Clothings");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Books");
        }
    }
}
