using Core.Models;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Infrastructure.Migrations
{
    public partial class seedProductData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
           var products = JsonSerializer.Deserialize<List<Product>>(productsData);


            int id = 1;

           foreach (var item in products)
           {
               migrationBuilder.InsertData(
                   table: "Products",
                   columns: new[] { "Id", "Name", "PictureUrl", "Price", "ProductBrandId", "ProductTypeId", "Description"},
                   values: new[] { (id++).ToString() , item.Name,item.PictureUrl , item.Price.ToString() , item.ProductBrandId.ToString() , item.ProductTypeId.ToString()
                   , item.Description }
                   );
           }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Products");
        }
    }
}
