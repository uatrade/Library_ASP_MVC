using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class AuthBookPublish
    {
        public Author author { get; set; }
        public Book book { get; set; }
        public Publisher publisher { get; set; }
    }
}