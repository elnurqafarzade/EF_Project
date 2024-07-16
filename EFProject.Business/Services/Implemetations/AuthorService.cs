using EFProject.Business.Services.Interfaces;
using EFProject.Core.Models;
using EFProject.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFProject.Business.Services.Implemetations
{
    public class AuthorService : IAuthorService
    {
        public void CreateAuthor(Author author)
        {
            DataContext data = new DataContext();

            Console.WriteLine("Author name daxil edin");
            string AuthorTitle = Console.ReadLine();

            Author authors = new Author()
            {
                Name = AuthorTitle,
            };

            data.Authors.Add(author);
            data.SaveChanges();
        }

        public void DeleteAuthor(int id)
        {
            DataContext data = new DataContext();
            var author = data.Authors.Find(id);
            if (author != null)
            {
                data.Authors.Remove(author);
                data.SaveChanges();
            }
        }

        public void EditAuthor(Author author, int id)
        {
            DataContext data = new DataContext();
            var existAuthor = data.Authors.FirstOrDefault(a => a.Id == id);
            if (existAuthor is null)
            {
                throw new NullReferenceException("Null ola bilmez");
            }
            existAuthor.Name = author.Name;
            existAuthor.Books = author.Books;
        }

        public void GetAllAuthor()
        {
            DataContext data = new DataContext();
            data.Authors.ToList().ForEach(Console.WriteLine);
        }
    }

    public List<Book> GetBooksByAuthorName(string authorName)
    {
        DataContext data = new DataContext();
        var books = data.Books
            .Where(b => b.Author.Name.Contains(authorName))
            .ToList();

        return books;
    }

}