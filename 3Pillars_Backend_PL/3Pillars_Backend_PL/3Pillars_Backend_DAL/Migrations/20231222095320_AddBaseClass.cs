using Microsoft.EntityFrameworkCore.Migrations;

namespace _3Pillars_Backend_DAL.Migrations
{
    public partial class AddBaseClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Active",
                table: "jobs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddedBy",
                table: "jobs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddedOn",
                table: "jobs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "jobs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedOn",
                table: "jobs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "jobs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedOn",
                table: "jobs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Active",
                table: "departments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddedBy",
                table: "departments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddedOn",
                table: "departments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "departments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedOn",
                table: "departments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "departments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedOn",
                table: "departments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Active",
                table: "addressBooks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddedBy",
                table: "addressBooks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddedOn",
                table: "addressBooks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "addressBooks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedOn",
                table: "addressBooks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "addressBooks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedOn",
                table: "addressBooks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "jobs");

            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "jobs");

            migrationBuilder.DropColumn(
                name: "AddedOn",
                table: "jobs");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "jobs");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "jobs");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "jobs");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "jobs");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "departments");

            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "departments");

            migrationBuilder.DropColumn(
                name: "AddedOn",
                table: "departments");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "departments");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "departments");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "departments");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "departments");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "addressBooks");

            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "addressBooks");

            migrationBuilder.DropColumn(
                name: "AddedOn",
                table: "addressBooks");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "addressBooks");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "addressBooks");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "addressBooks");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "addressBooks");
        }
    }
}
