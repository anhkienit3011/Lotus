using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyKhoaHocAPI.Migrations
{
    /// <inheritdoc />
    public partial class capnhat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "HocViens",
                type: "varchar(40)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HoTen",
                table: "HocViens",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NgaySinh",
                table: "HocViens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhuongXa",
                table: "HocViens",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuanHuyen",
                table: "HocViens",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SDT",
                table: "HocViens",
                type: "varchar(11)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SoNha",
                table: "HocViens",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TinhThanh",
                table: "HocViens",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "HocViens");

            migrationBuilder.DropColumn(
                name: "HoTen",
                table: "HocViens");

            migrationBuilder.DropColumn(
                name: "NgaySinh",
                table: "HocViens");

            migrationBuilder.DropColumn(
                name: "PhuongXa",
                table: "HocViens");

            migrationBuilder.DropColumn(
                name: "QuanHuyen",
                table: "HocViens");

            migrationBuilder.DropColumn(
                name: "SDT",
                table: "HocViens");

            migrationBuilder.DropColumn(
                name: "SoNha",
                table: "HocViens");

            migrationBuilder.DropColumn(
                name: "TinhThanh",
                table: "HocViens");
        }
    }
}
