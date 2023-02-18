using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace users_api.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    identifier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type_identifier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    user = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

                migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "user", "password" , "created_date" },
                values: new object[] { Guid.NewGuid().ToString("N"), "admin", "admin", DateTime.Now });

                migrationBuilder.Sql(@"
                    CREATE PROCEDURE [dbo].[get_people]
                    AS
                    BEGIN
                       select *, CONCAT(first_name, last_name) as full_name, 
                                 CONCAT(type_identifier, identifier) as full_identifier
	                   from People
                    END
                ");

                migrationBuilder.Sql(@"
                    CREATE PROCEDURE [dbo].[get_users]
                    AS
                    BEGIN
                       select *
	                    from Users
                    END
                ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
