using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Publisher
    {
        public int id { get; set; }

        //[Required(ErrorMessage = "Ввведите название типографии")]
        public string Name { get; set; }

        public List<Publisher> MyPublishers = new List<Publisher>();

        public void AddPublisher(Publisher publisher)
        {
            publisher.id = (MyPublishers.Any() ? MyPublishers.Max(i => i.id) : 0) + 1;
            MyPublishers.Add(publisher);
        }

        public void DeletePublisher(string publisher)
        {
            foreach(var item in MyPublishers)
            {
                if (item.Name == publisher)
                {
                    MyPublishers.Remove(item);
                    break;
                }
            }
        }


    }
}