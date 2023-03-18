using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HashApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNameDateToInsertDateHashesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Hashes",
                newName: "InsertDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InsertDate",
                table: "Hashes",
                newName: "Date");
        }
    }
}
