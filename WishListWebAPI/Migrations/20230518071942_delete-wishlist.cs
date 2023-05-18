using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WishListWebAPI.Migrations
{
    public partial class deletewishlist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE DeleteWishlist
                            @Id INT
                        AS
                        BEGIN
                            DELETE FROM Wishlist WHERE Id = @Id;
                        END";
            migrationBuilder.Sql(sp);


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DROP PROCEDURE DeleteWishlist";
            migrationBuilder.Sql(sp);

        }
    }
}
