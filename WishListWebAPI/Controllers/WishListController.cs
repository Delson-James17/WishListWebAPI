using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WishListWebAPI.Data;


namespace WishListWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishListController : Controller
    {
        private readonly WishListDbContext _context;
        public WishListController(WishListDbContext context)
        {
            _context = context; 
        }

        //Select All
        [HttpGet]
        public async Task<IActionResult> GetAllWishlist()
        {
            var result = await _context.Wishlist.FromSqlRaw("EXEC SelectAllWishlist").ToListAsync();
            return Ok(result);
        }

        // Add
        [HttpPost]
        public async Task<IActionResult> AddWishlist(string name, string description, string price, string iscompleted)
        {
            var parameters = new[] {
                new SqlParameter("@Name", name),
                new SqlParameter("@Description", description),
                new SqlParameter("@Price", price),
                new SqlParameter("@IsCompleted", iscompleted)
                };
            var result = await _context.Database.ExecuteSqlRawAsync("EXEC AddWishlist @Name, @Description,@Price,@IsCompleted ", parameters);
            await _context.SaveChangesAsync();
            return Ok(result);
        }

        // Update

        [HttpPut]
        public async Task<IActionResult> UpdateWishlist(int id, string name, string description, string price, string iscompleted)
        {
            var parameters = new[]
            {
                new SqlParameter("@Id", id),
                new SqlParameter("@Name", name),
                new SqlParameter("@Description", description),
                new SqlParameter("@Price", price),
                new SqlParameter("@IsCompleted", iscompleted)
            };
            await _context.Database.ExecuteSqlRawAsync("EXEC UpdateWishlist @Id, @Name, @Description, @Price, @IsCompleted", parameters);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // Delete
        [HttpDelete]
        public async Task<IActionResult> DeleteWishlist(int Id)
        {
            var parameter = new SqlParameter("@Id", Id);
            await _context.Database.ExecuteSqlRawAsync("EXEC DeleteWishlist @Id", parameter);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // Get By Id
        [HttpGet("{Id}")]
        public IActionResult GetWishlist (int Id)
        {
            var parameter = new SqlParameter("@Id", Id);
            var result = _context.Wishlist.FromSqlInterpolated($"EXEC SelectWhislistId {parameter}").AsEnumerable().FirstOrDefault();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
