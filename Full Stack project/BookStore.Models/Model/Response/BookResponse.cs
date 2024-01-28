using UserManagement;

namespace UserManagement
{
    public class BookResponse
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; }

        public int AuthorId { get; set; }
        public AuthorResponse author { get; set; }
    }
}
