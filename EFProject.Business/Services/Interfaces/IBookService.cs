using EFProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFProject.Business.Services.Interfaces
{
    public interface IBookService
    {
        public void CreateBook(Book book);
        public void GetAllBook();
        public void EditBook(Book book, int id);
        public void DeleteBook(int id);
    }
}
