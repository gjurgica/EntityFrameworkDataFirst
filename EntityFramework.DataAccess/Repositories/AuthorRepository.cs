using EntityFrameworkHomework.Data.Ineterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EntityFrameworkHomework.Data.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {

        public void AddAuthor(Author author)
        {
            using(AdoNetDBEntities context = new AdoNetDBEntities())
            {
                context.Authors.Add(author);
                context.SaveChanges();
            }
        }

        public void DeleteAuthor(int id)
        {
            using (AdoNetDBEntities context = new AdoNetDBEntities())
            {
                var author = context.Authors.FirstOrDefault(x => x.Id == id);
                if (author != null)
                {
                    context.Authors.Remove(author);
                    context.SaveChanges();
                }
            }
        }

        public void EditAuthor(Author author)
        {
            using (AdoNetDBEntities context = new AdoNetDBEntities())
            {
                var edited = context.Authors.FirstOrDefault(x => x.Id == author.Id);
                author.FirstName = edited.FirstName;
                author.LastName = edited.LastName;
                context.SaveChanges();
            } 
        }

        public List<Author> GetAllAuthors()
        {
            using (AdoNetDBEntities context = new AdoNetDBEntities())
            {
                return context.Authors.ToList();
            }
        }

        public Author GetAuthorById(int id)
        {
            using (AdoNetDBEntities context = new AdoNetDBEntities())
            {
                return context.Authors.FirstOrDefault(x => x.Id == id);
            }

        }
    }
}
