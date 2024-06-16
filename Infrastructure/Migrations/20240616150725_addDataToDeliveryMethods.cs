using Core.Models.Orders;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Infrastructure.Migrations
{
    public partial class addDataToDeliveryMethods : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var data = File.ReadAllText("../Infrastructure/Data/SeedData/delivery.json");
            var methods = JsonSerializer.Deserialize<List<DeliveryMethod>>(data);
            foreach (var item in methods)
            {
                migrationBuilder.InsertData(
                    table: "DeliveryMethods",
                    columns: new [] { "Id", "ShortName", "Description", "DeliveryTime", "Price"},
                    values: new object[] { item.Id.ToString(), item.ShortName,item.Description,item.DeliveryTime,item.Price }
                    );
            }
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from DeliveryMethods");
        }
    }
}
