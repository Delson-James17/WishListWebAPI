using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WishListWebAPI.Migrations
{
    public partial class addwishlist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE AddWishList
                            @Name VARCHAR(50),
                            @Description VARCHAR(50),
                            @Price VARCHAR(50),
                            @IsCompleted VARCHAR(50)
                        AS
                        BEGIN
                            INSERT INTO Wishlist (Name,Description,Price,IsCompleted)
                            VALUES (@Name,
                            @Description,
                            @Price,
                            @IsCompleted);
                        END";
            migrationBuilder.Sql(sp);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DROP PROCEDURE AddWishList";
            migrationBuilder.Sql(sp);

        }
    }
}
