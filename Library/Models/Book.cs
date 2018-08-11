using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Publisher Publisher { get; set; }

        //public IEnumerable<Author> Authors;

        public Author AuthorBook { get; set; }

        [Required(ErrorMessage = "Введите дату выпуска")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Введите число страниц")]
        public int PageCount { get; set; }

        [Required(ErrorMessage = "Введите ISBN")]
        public string ISBN { get; set; }

        public List<Book> books = new List<Book>();

        public Book()
        {
            if(AuthorBook==null)
            AuthorBook = new Author();
        }

        public void AddBook(Book book, Author authors, Publisher publisher)
        {

            book.Id = (books.Any() ? books.Max(i => i.Id) : 0) + 1;

            foreach (var item in authors.listOfAuthors)
            {

                if (item.id == book.AuthorBook.id)
                {
                    book.AuthorBook = item;
                }

            }
            foreach (var item in publisher.MyPublishers)
            {
                if (item.id == book.Publisher.id)
                {
                    book.Publisher = item;
                }
            }

            books.Add(book);
        }
      
        public void DeleteBook(int BookId)
        {
            for(int i=0;i<books.Count();i++)
            {
                if(BookId==books[i].Id)
                {
                    books.Remove(books[i]);
                    //i = 0;
                    DeleteBook(BookId);
                }
            }
        }

        public void DeleteBookOfAuthor(int AuthorId)
        {
            for (int i = 0; i < books.Count(); i++)
            {
                if (AuthorId == books[i].AuthorBook.id)
                {
                    books.Remove(books[i]);
                    //i = 0;
                    DeleteBookOfAuthor(AuthorId);
                }
            }
        }

    }
}