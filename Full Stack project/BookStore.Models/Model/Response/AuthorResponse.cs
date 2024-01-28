using System.Runtime.Serialization;
using UserManagement;

namespace UserManagement
{
    public class AuthorResponse
    {
        public int AuthorId { get; set; }
        public string? Name { get; set; }

        public List<BookResponse> Books { get; set; }
    }
}
