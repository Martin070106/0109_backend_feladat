namespace kamecz_martin_backend.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;

        public int AuthorId { get; set; }
        public int CategoryId { get; set; }

        public Author? Author { get; set; }
        public Category? Category { get; set; }
    }
}
