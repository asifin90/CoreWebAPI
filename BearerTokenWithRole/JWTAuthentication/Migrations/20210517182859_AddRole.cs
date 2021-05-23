using Microsoft.EntityFrameworkCore.Migrations;

namespace JWTAuthentication.Migrations
{
    public partial class AddRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"Insert into AspNetRoles(Id, name, NormalizedName)  
                values ('e4d7b92e-488c-4a2c-b061-b1619be376e0', 'Admin', 'Admin')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"Delete from AspNetRoles where Id='e4d7b92e-488c-4a2c-b061-b1619be376e0'");
        }
    }
}
