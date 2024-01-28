using UserManagement;

namespace UserManagement
{
    public class BookRequest
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; }
    }
}
