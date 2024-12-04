using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class AddRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                 columns: new[]
                {
                    "Id","Name","NormalizedName","ConcurrencyStamp"
                },
                 values: new object[,]
                 {
                      { Guid.NewGuid().ToString(), "Employee", "EMPLOYEE", Guid.NewGuid().ToString() },
                      { Guid.NewGuid().ToString(), "Manager", "MANAGER", Guid.NewGuid().ToString() },
                      { Guid.NewGuid().ToString(), "Admin", "ADMIN", Guid.NewGuid().ToString() }
                 }

                 );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
        table: "AspNetRoles",
        keyColumn: "Name",
        keyValues: new object[] { "Employee", "Manager", "Admin" }
    );

        }
    }
}
