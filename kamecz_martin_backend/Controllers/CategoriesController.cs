using Microsoft.AspNetCore.Mvc;
using kamecz_martin_backend.Models;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly librarydbContext _context;

    public CategoriesController(librarydbContext context)
    {
        _context = context;
    }


    [HttpGet("feladat11")]
    public IActionResult GetCategoriesWithBooks()
    {
        try
        {
            var categories = _context.Categories
                .Include(c => c.Books)
                .ToList();

            return Ok(categories);
        }
        catch
        {
            return BadRequest(new { message = "Hiba történt a kategóriák lekérdezése során!" });
        }
    }
}
