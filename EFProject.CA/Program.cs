using EFProject.Business.Services.Implemetations;
using EFProject.Business.Services.Interfaces;
using EFProject.Core.Models;
using EFProject.Data.DAL;
using Microsoft.EntityFrameworkCore;
using System.Xml.Serialization;

namespace EFProject.CA
{
    public class Program
    {
            static void Main(string[] args)
            {
            IAuthorService authorServices = new AuthorService();
            IBookService bookService = new BookService();
            IBorrowerService borrowerService = new BorrowerService();

                while (true)
                {
                    Console.WriteLine("Xahiş edirik servis seçin:");
                    Console.WriteLine("1 - Author actions");
                    Console.WriteLine("2 - Book actions");
                    Console.WriteLine("3 - Borrower actions");
                    Console.WriteLine("4 - BorrowBook");
                    Console.WriteLine("5 - ReturnBook");
                    Console.WriteLine("6 - En cox borrow olunan kitablar");
                    Console.WriteLine("7 - Kitabi gecikdiren Borrowerlerin listi");
                    Console.WriteLine("8 -  borrowerin borrow etdiyi kitablar");
                    Console.WriteLine("9 - Filter Books By Title");
                    Console.WriteLine("10 - Filte rBooks By Author");
                    Console.WriteLine("0 - Exit");

                    int mainChoice = int.Parse(Console.ReadLine());

                    switch (mainChoice)
                    {
                        case 1:
                            Console.WriteLine("Author actions:");
                            Console.WriteLine("1 - Butun authorlarin siyahisi");
                            Console.WriteLine("2 - Author yaratmaq");
                            Console.WriteLine("3 - Author editlemek");
                            Console.WriteLine("4 - Author silmek");
                            Console.WriteLine("0 - Exit");

                            int authorChoice = int.Parse(Console.ReadLine());

                            switch (authorChoice)
                            {
                                case 1:
                                    Console.WriteLine("Butun authorlarin siyahisi");
                                  authorServices.GetAllAuthor();
                                    break;
                                case 2:
                                    Console.WriteLine("Author yaratmaq");
                                Author author = new Author();
                                authorServices.CreateAuthor(author);
                                break;
                                case 3:
                                Author author2 = new Author();
                                
                                authorServices.EditAuthor(author2,2);

                                    break;
                                case 4:
                                    Console.WriteLine("Author silmek");
                                authorServices.DeleteAuthor(2);
                                    break;
                                case 0:
                                    Console.WriteLine("Exiting Author actions");
                                
                                    break;
                                default:
                                    Console.WriteLine("Səhv secim");

                                    break;
                            }
                            break;

                        case 2:
                            Console.WriteLine("Book actions:");
                            Console.WriteLine("1 - Butun booklarin siyahisi");
                            Console.WriteLine("2 - Book yaratmaq");
                            Console.WriteLine("3 - Book editlemek");
                            Console.WriteLine("4 - Book silmek");
                            Console.WriteLine("0 - Exit");

                            int bookChoice = int.Parse(Console.ReadLine());

                            switch (bookChoice)
                            {
                                case 1:
                                Book books = new Book();
                                 Console.WriteLine("Butun booklarin siyahisi");

                                bookService.GetAllBook();
                                    break;
                                case 2:
                                Book book = new Book();

                                    Console.WriteLine("Book yaratmaq");
                                bookService.CreateBook(book);
                                    break;
                                case 3:
                                    Console.WriteLine("Book editlemek");
                                Book bookss = new Book();

                                bookService.EditBook(bookss, 2);
                                    break;
                                case 4:
                                    Console.WriteLine("Book silmek");
                                bookService.DeleteBook(2);
                                    break;
                                case 0:
                                    Console.WriteLine("Exiting Book actions");
                                    break;
                                default:
                                    Console.WriteLine("Sehv secim");
                                    break;
                            }
                            break;

                        case 3:
                            Console.WriteLine("Borrower actions:");
                            Console.WriteLine("1 - Butun Borrowerlarin siyahisi");
                            Console.WriteLine("2 - Borrower yaratmaq");
                            Console.WriteLine("3 - Borrower editlemek");
                            Console.WriteLine("4 - Borrower silmek");
                            Console.WriteLine("0 - Exit");

                            int borrowerChoice = int.Parse(Console.ReadLine());

                            switch (borrowerChoice)
                            {
                                case 1:

                                    Console.WriteLine("Butun Borrowerlarin siyahisi");
                                borrowerService.GetAllBorrower();
                                     
                                    break;
                                case 2:
                                Borrower borrowers = new Borrower();

                                Console.WriteLine("Borrower yaratmaq");
                                borrowerService.CreateBorrower(borrowers);
                                    break;
                                case 3:
                                Borrower borrowerss = new Borrower();

                                Console.WriteLine("Borrower editlemek");
                                borrowerService.EditBorrower(borrowerss,2);
                                    break;
                                case 4:
                                    Console.WriteLine("Borrower silmek");
                                borrowerService.DeleteBorrower(2);
                                    break;
                                case 0:
                                    Console.WriteLine("Exiting Borrower actions");
                                    break;
                                default:
                                    Console.WriteLine("Sehv secim");
                                    break;
                            }
                            break;

                        case 4:
                            Console.WriteLine("BorrowBook:");
                            break;

                        case 5:
                            Console.WriteLine("ReturnBook:");
                             
                            break;

                        case 6:
                            Console.WriteLine("En cox borrow olunan kitabi getirin:");
                        Console.WriteLine("en cox borrow olunan nece kitab gelsin?");
                        borrowerService.GetMostBorrowedBooks(1);

                        break;

                        case 7:
                            Console.WriteLine("Kitabi gecikdiren Borrowerlerin listi:");
                             
                            break;

                        case 8:
                            Console.WriteLine("Hansi borrower indiye qeder hansi kitablari borrow edib:");
                        borrowerService.GetBooksBorrowedByBorrower(1);
                        int borrowerId = 1; 
                        var borrowedBooks = borrowerService.GetBooksBorrowedByBorrower(borrowerId);

                        Console.WriteLine($"Borrower {borrowerId}-in borrow aldigi kitablar:");
                        foreach (var book in borrowedBooks)
                        {
                            Console.WriteLine($"Title: {book.Title}");
                        }

                            break;

                        case 9:
                            Console.WriteLine("Kitab adına görə filter :");
                            Console.Write("ad daxiil edin: ");
                            string title = Console.ReadLine();
                           
                            break;

                        case 10:
                            Console.WriteLine("Author adına görə filtr:");
                            Console.Write("author adı daxil edin: ");
                            string authorName = Console.ReadLine();
                        var borrowers = borrowerService.GetBorrowersByAuthorName(authorName);

                        Console.WriteLine($"author adı '{authorName}' olan kitablar:");
                        foreach (var borrower in borrowers)
                        {
                            Console.WriteLine($"Name: {borrower.Name}");
                        }

                        break;

                        case 0:
                            Console.WriteLine("Proqramdan bağlanır...");
                            return;

                        default:
                            Console.WriteLine("Səhv seçim");
                            break;
                    }
                }
            }
        }
    }


