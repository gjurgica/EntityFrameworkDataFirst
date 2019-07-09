using EntityFrameworkHomework.Data.Ineterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkHomework.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        public void AddBook(Book book)
        {
            using (AdoNetDBEntities context = new AdoNetDBEntities())
            {
                context.Books.Add(book);
            }
        }

        public void DeleteBook(int id)
        {
            using (AdoNetDBEntities context = new AdoNetDBEntities())
            {
                var book = context.Books.FirstOrDefault(x => x.Id == id);
                if (book != null)
                {
                    context.Books.Remove(book);
                }
            }
        }

        public void EditBook(Book book)
        {
            using (AdoNetDBEntities context = new AdoNetDBEntities())
            {
                var edited = context.Books.FirstOrDefault(x => x.Id == book.Id);
                book.Title = edited.Title;
                book.Genre = edited.Genre;
            }
        }

        public List<Book> GetAllBooks()
        {
            using (AdoNetDBEntities context = new AdoNetDBEntities())
            {
                return context.Books.ToList();
            }
        }

        public Book GetBookById(int id)
        {
            using (AdoNetDBEntities context = new AdoNetDBEntities())
            {
                return context.Books.FirstOrDefault(X => X.Id == id);
            }
        }
    }
}
