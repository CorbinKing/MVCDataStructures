using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _403DataStructuresWithGitHub.Controllers
{
    public class StackController : Controller
    {
        static Stack<string> myStack = new Stack<string>();

        string stackSearch = null;
        // GET: Stack
        public ActionResult Index()
        {
            ViewBag.MyStack = myStack;
            ViewBag.StackSearch = stackSearch;
            return View();
        }

        public ActionResult AddOne()
        {
            myStack.Push("New Entry " + (myStack.Count + 1));
            ViewBag.MyStack = null;

            return View("Index");
        }

        public ActionResult AddMany()
        {
            myStack.Clear();
            
            for (int iCount = 0; iCount < 2000; iCount++)
            {
                myStack.Push("New Entry " + (iCount + 1));
            }
            ViewBag.MyStack = null;

            return View("Index");
        }

        public ActionResult Display()
        {
            ViewBag.MyStack = myStack;
            return View("Index");
        }

        public ActionResult Delete()
        {
            if (myStack.Count == 0)
            {
                stackSearch = "Can't delete from an empty stack";
                ViewBag.StackSearch = stackSearch;
            }
            else
            {
                ViewBag.StackDeletion = myStack.Pop();
                ViewBag.MyStack = null;
            }
                return View("Index");
        }

        public ActionResult Clear()
        {
            myStack.Clear();
            ViewBag.MyStack = null;
            return View("Index");

        }

        public ActionResult Search()
        {
            stackSearch = "Not Found";
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            sw.Start();
            foreach (string item in myStack)
            {
                if (item == "New Entry 1283")
                {
                    stackSearch = "Entry 1283 found.";
                }
            }
            sw.Stop();
            TimeSpan ts = sw.Elapsed;

            ViewBag.StopWatch = ts + " Elapsed";
            ViewBag.MyStack = null;
            ViewBag.StackSearch = stackSearch;
            return View("Index");
        }

        public ActionResult Return()
        {
            return RedirectToAction("Index", "Home");
        }
    }
} 