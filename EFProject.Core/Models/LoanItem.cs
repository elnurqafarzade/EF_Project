using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFProject.Core.Models
{
    public class LoanItem
    {
        public int Id { get; set; }
        public Book Books { get; set; }
        public Book BookId { get; set; }
        public Borrower borrowerId { get; set; }
    }
}
