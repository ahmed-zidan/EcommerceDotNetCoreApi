using Core.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Infrastructure.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
            var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
            foreach(var item in brands)
            {
                migrationBuilder.InsertData(
                    table: "ProductBrands",
                    columns: new[] { "Id", "Name" },
                    values: new[] { item.Id.ToString(), item.Name }
                    );
            }

            var TypesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
            var types = JsonSerializer.Deserialize<List<ProductType>>(TypesData);
            foreach (var item in types)
            {
                migrationBuilder.InsertData(
                    table: "ProductTypes",
                    columns: new[] { "Id", "Name" },
                    values: new[] { item.Id.ToString(), item.Name }
                    );
            }

           

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from ProductBrands");
            migrationBuilder.Sql("Delete from ProductTypes");
            
        }
    }
}
