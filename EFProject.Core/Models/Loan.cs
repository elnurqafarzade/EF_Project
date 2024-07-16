using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFProject.Core.Models
{
    public class Loan
    {
        public string Name { get; set; }
        public int BorrowerId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime MustReturnDate { get; set; }
        public DateTime ReturnDate { get; set; }

    }
}
