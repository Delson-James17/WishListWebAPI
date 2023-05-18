using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WishListWebAPI.Migrations
{
    public partial class selectidwishlist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE SelectWhislistId
                            @Id INT
                        AS
                        BEGIN
                            SELECT * FROM Wishlist WHERE Id = @Id;
                        END";
            migrationBuilder.Sql(sp);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DROP PROCEDURE SelectWhislistId";
            migrationBuilder.Sql(sp);
        }
    }
}
