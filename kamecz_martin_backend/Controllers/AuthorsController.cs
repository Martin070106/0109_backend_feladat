using Microsoft.AspNetCore.Mvc;
using kamecz_martin_backend.Models;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class AuthorsController : ControllerBase
{
    private readonly librarydbContext _context;

    public AuthorsController(librarydbContext context)
    {
        _context = context;
    }

    [HttpGet("feladat9/{name}")]
    public IActionResult GetAuthorWithBooks(string name)
    {
        var author = _context.Authors
            .Include(a => a.Books)
            .FirstOrDefault(a => a.Name == name);

        if (author == null)
            return NotFound(new { message = "Nincs ilyen szerző az adatbázisban!" });

        return Ok(author);
    }

    [HttpGet("feladat12")]
    public IActionResult GetAuthorCount()
    {
        try
        {
            int count = _context.Authors.Count();
            return Ok(new { authorsCount = count });
        }
        catch
        {
            return BadRequest(new { message = "Hiba történt a lekérdezés során!" });
        }
    }
}
