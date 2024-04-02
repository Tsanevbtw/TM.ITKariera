using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NESHTO.Data.Migrations
{
    /// <inheritdoc />
    public partial class TaskListSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TaskListId",
                table: "ToDoTask",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TaskList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskList", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToDoTask_TaskListId",
                table: "ToDoTask",
                column: "TaskListId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoTask_TaskList_TaskListId",
                table: "ToDoTask",
                column: "TaskListId",
                principalTable: "TaskList",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoTask_TaskList_TaskListId",
                table: "ToDoTask");

            migrationBuilder.DropTable(
                name: "TaskList");

            migrationBuilder.DropIndex(
                name: "IX_ToDoTask_TaskListId",
                table: "ToDoTask");

            migrationBuilder.DropColumn(
                name: "TaskListId",
                table: "ToDoTask");
        }
    }
}
