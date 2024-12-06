using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Journal.Domain.Data.Migrations
{
    /// <inheritdoc />
    public partial class ToDoItemCompleteChangedToIsComplete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Completed",
                table: "ToDoItem",
                newName: "IsCompleted");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsCompleted",
                table: "ToDoItem",
                newName: "Completed");
        }
    }
}
