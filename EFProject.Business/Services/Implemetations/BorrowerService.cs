using EFProject.Business.Services.Interfaces;
using EFProject.Core.Models;
using EFProject.Data.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFProject.Business.Services.Implemetations
{
    public class BorrowerService : IBorrowerService
    {
        public void CreateBorrower(Borrower borrower)
        {
            DataContext datab = new();
            Console.WriteLine("Enter borrower name: ");
            string borrowerName = Console.ReadLine();
            Console.WriteLine("Enter borrowers email");
            string borrowerEmail = Console.ReadLine();
            datab.SaveChanges();
        }

        public void DeleteBorrower(int id)
        {
            DataContext data = new DataContext();
            var borrower = data.Borrowers.Find(id);
            if (borrower != null)
            {
                data.Borrowers.Remove(borrower);
                data.SaveChanges();
            }
        }

        public void EditBorrower(Borrower borrower, int id)
        {
            DataContext data = new DataContext();
            var existBorrower = data.Borrowers.FirstOrDefault(br => br.Id == id);
            if (existBorrower is null)
            {
                throw new NullReferenceException("Null ola bilmez");
            }
            existBorrower.Name = borrower.Name;
            existBorrower.Email = borrower.Email;
            existBorrower.Books = borrower.Books;

        }

        public void GetAllBorrower()
        {
            DataContext data = new DataContext();
            data.Borrowers.ToList().ForEach(Console.WriteLine);
        }

        public List<Book> GetMostBorrowedBooks(int borrow)
        {
            DataContext data = new DataContext();
            var mostBorrowedBooks = data.Borrowers
                .GroupBy(b => b.Books)
                .OrderByDescending(g => g.Count())
                .Take(borrow)
                .Select(g => new
                {
                    Book = g.Key,
                    BorrowCount = g.Count()
                })
                .ToList();

            return mostBorrowedBooks.Select(b => b.Book).ToList();
        }

        public List<Book> GetBooksBorrowedByBorrower(int borrowerId)
        {
            DataContext data = new DataContext();
            var borrowedBooks = data.Borrowers
                .Where(b => b.Id == borrowerId)
                .Select(b => b.Books)
                .Distinct()
                .ToList();

            return borrowedBooks;
        }
        //public List<Borrower> GetBorrowersByBookTitle(string bookTitle)
        //{
        //    DataContext data = new DataContext();
        //    var borrowedBooks = data.Borrowers
        //        .Where(b => b.Books.Title.Contains(bookTitle))
        //        .Select(b => b.Name)
        //        .Distinct()
        //        .ToList();

        //    return borrowedBooks;
        //}

        public List<Borrower> GetBorrowersByAuthorName(string authorName)
        {
            DataContext data = new DataContext();
            var borrowers = data.Borrowers
                .Where(b => b.Books.Title.Contains(authorName))
                .Select(b => b.Name)
                .Distinct()
                .ToList();

            return borrowers;
        }
    }
}
