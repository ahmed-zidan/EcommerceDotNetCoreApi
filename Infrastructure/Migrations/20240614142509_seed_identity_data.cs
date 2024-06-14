using Core.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Infrastructure.Migrations
{
    public partial class seed_identity_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var hash = new PasswordHasher<AppUser>();
            var id = Guid.NewGuid().ToString();
            
            //insert into user
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "Email", "UserName", "PasswordHash", "EmailConfirmed", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnabled", "AccessFailedCount" },
                values: new object[] { id, "zidan@gmail.com", "zidanzezo", hash.HashPassword(null, "Zidan@123"), true ,true,false,false,0}
                );

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id","FirstName", "LastName", "Street", "City", "ZipCode", "State", "AppUserId" },
                values: new[] { "1", "mohamed", "be", "giza", "Dukki", "021122", "Cairo", id }
                ) ;

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from AspNetUsers where UserName = zidanzezo");
            migrationBuilder.Sql("delete from Address where Id = 1");
            
        }
    }
}
