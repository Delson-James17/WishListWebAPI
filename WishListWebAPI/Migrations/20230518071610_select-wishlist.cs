using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WishListWebAPI.Migrations
{
    public partial class selectwishlist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE SelectAllWishlist
                        AS
                        BEGIN
                            select * from Wishlist;
                        END";

            migrationBuilder.Sql(sp);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DROP PROCEDURE SelectAllWishlist";
            migrationBuilder.Sql(sp);

        }
    }
}
