using Microsoft.AspNetCore.Mvc;
using kamecz_martin_backend.Models;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly librarydbContext _context;
    private readonly string UID = "FKB3F4FEA09CE43C";

    public BooksController(librarydbContext context)
    {
        _context = context;
    }


    [HttpGet("feladat10")]
    public IActionResult GetAllBooks()
    {
        try
        {
            var books = _context.Books.ToList();
            return Ok(books);
        }
        catch
        {
            return BadRequest(new { message = "Hiba történt a könyvek lekérdezése során!" });
        }
    }

    [HttpPost("feladat13")]
    public IActionResult AddBook([FromQuery] string uid, [FromBody] Book book)
    {
        if (uid != UID)
            return Unauthorized(new { message = "Nincs jogosultsága új könyv felvételéhez!" });

        try
        {
            _context.Books.Add(book);
            _context.SaveChanges();

            return StatusCode(201, new { message = "Könyv hozzáadása sikeresen megtörtént." });
        }
        catch
        {
            return BadRequest(new { message = "Hiba történt a könyv rögzítése során!" });
        }
    }
}
