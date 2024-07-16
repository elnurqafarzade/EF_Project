using EFProject.Business.Services.Interfaces;
using EFProject.Core.Models;
using EFProject.Data.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace EFProject.Business.Services.Implemetations
{
    public class BookService : IBookService
    {
        public void CreateBook(Book book)
        {
            DataContext datab = new();
            Console.WriteLine("Enter book title: ");
            string bookTitle = Console.ReadLine();
            Console.WriteLine("Enter description");
            string desc = Console.ReadLine();
            DateTime publishYear = DateTime.UtcNow;
            datab.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            DataContext data = new DataContext();
            var book = data.Books.Find(id);
            if (book != null)
            {
                data.Books.Remove(book);
                data.SaveChanges();
            }
        }

        public void EditBook(Book book, int id)
        {
            DataContext data = new DataContext();
            var existBook = data.Books.FirstOrDefault(b => b.Id == id);
            if (existBook is null)
            {
                throw new NullReferenceException("Null ola bilmez");
            }
            existBook.Title = book.Title;
            existBook.PublishedYear = book.PublishedYear;
            existBook.Description = book.Description;

        }

        public void GetAllBook()
        {
            DataContext data = new DataContext();

            data.Books.ToList().ForEach(Console.WriteLine);

        }

    }
}
