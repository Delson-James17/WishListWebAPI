using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WishListWebAPI.Migrations
{
    public partial class updatewishlist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE UpdateWishlist
                    @Id INT,
                    @Name VARCHAR(50),
                    @Description VARCHAR(50),
                    @Price VARCHAR(50),
                    @IsCompleted VARCHAR(50)
                AS
                BEGIN
                    UPDATE Wishlist
                    SET Name = @Name,
                        Description = @Description,
                        Price = @Price,
                        IsCompleted = @IsCompleted
                    WHERE Id = @Id;
                END";
            migrationBuilder.Sql(sp);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DROP PROCEDURE UpdateWishlist";
            migrationBuilder.Sql(sp);

        }
    }
}
