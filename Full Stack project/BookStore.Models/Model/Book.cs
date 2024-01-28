using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using UserManagement;

namespace UserManagement
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }
        public string? Name { get; set; }
        //public string? Author { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; }

        public int AuthorId { get; set; }
        public Author author { get; set; }

    }
}
