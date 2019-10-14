using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _403DataStructuresWithGitHub.Controllers
{
    public class QueueController : Controller
    {
        static Queue<string> myQueue = new Queue<string>();

        string queueSearch = null;
        // GET: Queue
        public ActionResult Index()
        {
            ViewBag.MyQueue = myQueue;
            ViewBag.QueueSearch = queueSearch;
            return View();
        }

        public ActionResult AddOne()
        {
            myQueue.Enqueue("New Entry " + (myQueue.Count + 1));
            ViewBag.MyQueue = null;

            return View("Index");
        }

        public ActionResult AddMany()
        {
            myQueue.Clear();

            for (int iCount = 0; iCount < 2000; iCount++)
            {
                myQueue.Enqueue("New Entry " + (iCount + 1));
            }
            ViewBag.MyQueue = null;

            return View("Index");
        }

        public ActionResult Display()
        {
            ViewBag.MyQueue = myQueue;
            return View("Index");
        }

        public ActionResult Delete()
        {
            ViewBag.QueueDeletion = myQueue.Dequeue();
            ViewBag.MyQueue = null;
            return View("Index");
        }

        public ActionResult Clear()
        {
            myQueue.Clear();
            ViewBag.MyQueue = null;
            return View("Index");

        }

        public ActionResult Search()
        {
            queueSearch = "Not Found";
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            sw.Start();
            foreach (string item in myQueue)
            {
                if (item == "New Entry 1283")
                {
                    queueSearch = "Entry 1283 found.";
                }
            }
            sw.Stop();
            TimeSpan ts = sw.Elapsed;

            ViewBag.StopWatch = ts + " Elapsed";
            ViewBag.MyQueue = null;
            ViewBag.QueueSearch = queueSearch;
            return View("Index");
        }

        public ActionResult Return()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}