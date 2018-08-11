using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class Author
    {
        public int id { get; set; }

        //[Required(ErrorMessage = "Введите имя автора")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите дату рождения автора")]
        public DateTime DateBirth { get; set; }
        public DateTime ? DateOfDeath { get; set; }

        public List<Author> listOfAuthors = new List<Author>();
        public void AddAuthor(Author author)
        {
            author.id = (listOfAuthors.Any() ? listOfAuthors.Max(i => i.id) : 0) + 1;
            listOfAuthors.Add(author);
        }

        public void DelAuthor(int id, Book book)
        {
            int count = listOfAuthors.Count();

            foreach (var item in listOfAuthors)
            {
                if (id == item.id)
                {
                    listOfAuthors.Remove(item);
                    book.DeleteBookOfAuthor(id);
                    break;
                }
            }

        }
        public Author GetAuthor(string AuthorDropList)
        {
            foreach (var item in listOfAuthors)
            {
                if (item.Name == AuthorDropList)
                {
                    return item;
                }
            }
            return null;
        }


    }
}