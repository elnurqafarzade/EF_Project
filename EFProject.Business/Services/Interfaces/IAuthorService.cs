using EFProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFProject.Business.Services.Interfaces
{
    public interface IAuthorService
    {
        public void CreateAuthor(Author author);
        public void GetAllAuthor();
        public void EditAuthor(Author author, int id);
        public void DeleteAuthor(int id);
    }
}
