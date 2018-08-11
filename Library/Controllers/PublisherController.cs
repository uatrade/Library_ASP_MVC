using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Models;

namespace Library.Controllers
{
    public class PublisherController : Controller
    {
        // GET: Publisher

        static Publisher publisher = new Publisher();

        static Author authors = new Author();

        static Book book = new Book();

        static List<SelectListItem> mylist;

        static List<SelectListItem> mylistPublish;
        public ActionResult Index()
        {
            AllViewBag();

            return View();
        }

        public ActionResult DelIndex(string delpublisher)
        {
            publisher.DeletePublisher(delpublisher);

            AllViewBag();

            return RedirectToAction("Index");
        }

        public ActionResult DelAuthor(int id)
        {
            authors.DelAuthor(id, book);

            AllViewBag();


            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult IndexPublisher(AuthBookPublish model)
        {
            if(ModelState.IsValid)
            {
                publisher.AddPublisher(model.publisher);
                AllViewBag();
                return View("Index");
            }
            else
            {
                AllViewBag();
                return View("Index");
            }
        }

        [HttpPost]
        public ActionResult IndexAuthor(AuthBookPublish model)
        {
            if(ModelState.IsValid)
            {
                authors.AddAuthor(model.author);
                AllViewBag();
                return View("Index");
            }
            else
            {
                AllViewBag();
                return View("Index");
            }

        }

        [HttpPost]
        public ActionResult IndexBook(AuthBookPublish model, FormCollection form)
        {
            if(ModelState.IsValid)
            {
                //string strDDL = form["NameAuthor"].ToString();
                //string strDDLPublish = form["NamePublish"].ToString();
                book.AddBook(model.book, authors, publisher);
                //book.AddBook(model.book, strDDL, strDDLPublish, authors, publisher);
                AllViewBag();

                return View("Index");
            }

            else
            {
                AllViewBag();

                return View("Index");
            }
        }

        public ActionResult DelBook(int id)
        {
            book.DeleteBook(id);

            AllViewBag();

            return View("Index");
        }

        public void AllViewBag()
        {
            ViewBag.ListPublisher = publisher.MyPublishers;
            ViewBag.ListAuthors = authors.listOfAuthors;
            ViewBag.Books = book.books;

                mylist = new List<SelectListItem>();
                for (int i = 0; i < authors.listOfAuthors.Count(); i++)
                    mylist.Add(new SelectListItem { Text = authors.listOfAuthors[i].Name, Value = authors.listOfAuthors[i].id.ToString() });

            mylistPublish = new List<SelectListItem>();
            for (int i = 0; i < publisher.MyPublishers.Count(); i++)
                mylistPublish.Add(new SelectListItem { Text = publisher.MyPublishers[i].Name, Value = publisher.MyPublishers[i].id.ToString() });

            ViewBag.ListPublishSelect = mylistPublish;
            ViewBag.listSelect = mylist;
            ViewBag.listBooks = book.books;
        }
    }
}