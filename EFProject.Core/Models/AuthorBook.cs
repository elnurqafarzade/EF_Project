using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFProject.Core.Models
{
    public class AuthorBook
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int BookId { get; set; }

        public Book Books { get; set; }
        public Author Author { get; set; }
    }
}
