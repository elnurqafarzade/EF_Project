using EFProject.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFProject.Business.Services.Interfaces
{
    public interface IBorrowerService
    {
        public void CreateBorrower(Borrower borrower);
        public void GetAllBorrower();
        public void EditBorrower(Borrower borrower, int id);
        public void DeleteBorrower(int id);
        public List<Book> GetMostBorrowedBooks(int borrow);
        public List<Book> GetBooksBorrowedByBorrower(int borrowerId);

        public List<Borrower> GetBorrowersByAuthorName(string authorName);
       

    }
}
