using Microsoft.EntityFrameworkCore.Migrations;

namespace mvcMovie.Migrations
{
    public partial class CreateIdentitySchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                column: "Password",
                value: "Rfc2898DeriveBytes$50000$kS3mdZUenLg0RIaCMtm60w==$tgpYPlgOazlHp+HHFNC15NhfBwc8RfF0IAsghdDL+bo=");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                column: "Password",
                value: "Rfc2898DeriveBytes$50000$zG5GXD8DZZQ6JuVvaiwYgQ==$b1z2w57bf5zB57vWGLhYxC8F4Q5zTl8jij5bJ2I5Dfo=");
        }
    }
}
