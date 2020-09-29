using Microsoft.EntityFrameworkCore.Migrations;

namespace DWMS.Web.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DSSQLServer",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),//注解
                    DStype = table.Column<int>(nullable: true),
                    DSName = table.Column<string>(nullable: true),
                    DSDesc = table.Column<string>(nullable: true),
                    IsActive = table.Column<string>(nullable: true),
                    DBHost = table.Column<string>(nullable: true),
                    DBName = table.Column<string>(nullable: true),
                    UseId = table.Column<string>(nullable: true),
                    Pwd = table.Column<string>(nullable: true)
                },
                //添加约束
                constraints: table =>
                {
                    table.PrimaryKey("PK_DSSQLServer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SysUser",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysUser", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DSSQLServer");

            migrationBuilder.DropTable(
                name: "SysUser");
        }
    }
}
