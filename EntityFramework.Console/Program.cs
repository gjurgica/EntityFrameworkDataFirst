using EntityFrameworkHomework.Data;
using EntityFrameworkHomework.Data.Ineterfaces;
using EntityFrameworkHomework.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Console
{
    class Program
    {
        IAuthorRepository _authors = new AuthorRepository();
        IBookRepository _books = new BookRepository();
        static void Main(string[] args)
        {
            Program program = new Program();
            //program.GetAllAuthors();
            //program.GetAllBooks();
            //System.Console.WriteLine("Enter id");
            //string stringId = System.Console.ReadLine();
            //int id = int.Parse(stringId);
            //program.GetAuthorById(id);
            //program.GetBookById(id);
            //program.AddNewAuthor();
            //program.AddNewBook();
            //program.DeleteAuthor(id);
            //program.DeleteBook(id);
            //program.EditAuthor();
            program.EditBook();
            System.Console.ReadLine();
            
        }

        private void EditBook()
        {
            System.Console.WriteLine("Enter author id:");
            string stringid = System.Console.ReadLine();
            int bookId = int.Parse(stringid);
            System.Console.WriteLine("Enter book title:");
            string title = System.Console.ReadLine();
            System.Console.WriteLine("Enter genre:");
            string genre = System.Console.ReadLine();
            System.Console.WriteLine("Enter author id:");
            string id = System.Console.ReadLine();
            int authorId = int.Parse(id);
            Book book = new Book();
            book.Id = bookId;
            book.Title = title;
            book.Genre = genre;
            book.AuthorId = authorId;
            _books.EditBook(book);
        }

        private void EditAuthor()
        {
            System.Console.WriteLine("Enter author id:");
            string id = System.Console.ReadLine();
            int Id = int.Parse(id);
            Book book = new Book();
            System.Console.WriteLine("Enter author first name:");
            string firstName = System.Console.ReadLine();
            System.Console.WriteLine("Enter author last name:");
            string lasttName = System.Console.ReadLine();
            Author author = new Author();
            author.Id = Id;
            author.FirstName = firstName;
            author.LastName = lasttName;
            _authors.EditAuthor(author);
        }

        private void DeleteBook(int id)
        {
            _books.DeleteBook(id);
        }

        private void DeleteAuthor(int id)
        {
            _authors.DeleteAuthor(id);
        }

        private void AddNewBook()
        {
            System.Console.WriteLine("Enter book title:");
            string title = System.Console.ReadLine();
            System.Console.WriteLine("Enter genre:");
            string genre = System.Console.ReadLine();
            System.Console.WriteLine("Enter author id:");
            string id = System.Console.ReadLine();
            int authorId = int.Parse(id);
            Book book = new Book();
            book.Title = title;
            book.Genre = genre;
            book.AuthorId = authorId;
            _books.AddBook(book);
        }

        private void AddNewAuthor()
        {
            System.Console.WriteLine("Enter author first name:");
            string firstName = System.Console.ReadLine();
            System.Console.WriteLine("Enter author last name:");
            string lasttName = System.Console.ReadLine();
            Author author = new Author();
            author.FirstName = firstName;
            author.LastName = lasttName;
            _authors.AddAuthor(author);
        }

        private void GetAllBooks()
        {
            var books = _books.GetAllBooks().ToList();
            foreach(var book in books)
            {
                System.Console.WriteLine($"Book info:\n{book.Title} - {book.Genre}");
            }
        }

        private void GetBookById(int id)
        {
            var book = _books.GetBookById(id);
            if(book != null)
            {
                System.Console.WriteLine($"Book info:\n{book.Title} - {book.Genre}");
            }
            else
            {
                System.Console.WriteLine("This id don't exist");
            }
        }

        private void GetAllAuthors()
        {
            var authors = _authors.GetAllAuthors().ToList();
            foreach(var author in authors)
            {
                System.Console.WriteLine($"Author info:\n{author.FirstName} {author.LastName}"); 
            }
          
        }
        private void GetAuthorById(int id)
        {
            var author = _authors.GetAuthorById(id);
            if(author != null)
            {
                System.Console.WriteLine($"Author info:\n{author.FirstName} {author.LastName}");
            }
            else
            {
                System.Console.WriteLine("This id don't exist");
            }
        }
    }
}
