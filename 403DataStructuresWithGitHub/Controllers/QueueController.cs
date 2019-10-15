/*AUTHORS:
 * Corbin King
 * Jake Saylor
 * Michael Jenkins
 * Peter Madsen
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _403DataStructuresWithGitHub.Controllers
{
    public class QueueController : Controller
    {
        static Queue<string> myQueue = new Queue<string>(); //creates a new queue data storage

        string queueSearch = null;
        
        public ActionResult Index()
        {
            ViewBag.MyQueue = myQueue;
            ViewBag.QueueSearch = queueSearch;
            return View();
        }

        public ActionResult AddOne() //this adds a new entry into the queue
        {
            myQueue.Enqueue("New Entry " + (myQueue.Count + 1));
            ViewBag.MyQueue = null;

            return View("Index");
        }

        public ActionResult AddMany() //this clears the queue and loops 2000 times creating new entrys 
        {
            myQueue.Clear();

            for (int iCount = 0; iCount < 2000; iCount++)
            {
                myQueue.Enqueue("New Entry " + (iCount + 1));
            }
            ViewBag.MyQueue = null;

            return View("Index");
        }

        public ActionResult Display() //this displays the current data in the queue. It uses a foreach loop in the views folder
        {
            ViewBag.MyQueue = myQueue;
            return View("Index");
        }

        public ActionResult Delete() //remove the last entry into the queue
        {
            if (myQueue.Count == 0)
                {
                    queueSearch = "Can't delete from an empty queue";
                    ViewBag.QueueSearch = queueSearch;
                }
            else
                {
                    ViewBag.QueueDeletion = myQueue.Dequeue();
                    ViewBag.MyQueue = null;
                }
                return View("Index");
        }

        public ActionResult Clear() //clears the whole queue
        {
            myQueue.Clear();
            ViewBag.MyQueue = null;
            return View("Index");

        }

        public ActionResult Search() //searches the queue for the hardcoded input
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
            TimeSpan ts = sw.Elapsed; //this times the speed of the seach for the input in the queue

            ViewBag.StopWatch = ts + " Elapsed";
            ViewBag.MyQueue = null;
            ViewBag.QueueSearch = queueSearch;
            return View("Index");
        }

        public ActionResult Return() //returns to the home view
        {
            return RedirectToAction("Index", "Home");
        }
    }
}