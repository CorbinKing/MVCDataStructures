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
    public class StackController : Controller
    {
        static Stack<string> myStack = new Stack<string>(); //creates a new stack datatype 

        string stackSearch = null;
        
        public ActionResult Index()
        {
            ViewBag.MyStack = myStack;
            ViewBag.StackSearch = stackSearch;
            return View();
        }

        public ActionResult AddOne() //this adds a new entry into the stack
        {
            myStack.Push("New Entry " + (myStack.Count + 1));
            ViewBag.MyStack = null;

            return View("Index");
        }

        public ActionResult AddMany() //this clears the current data in the stack and loops 2000 times entering new data
        {
            myStack.Clear();
            
            for (int iCount = 0; iCount < 2000; iCount++)
            {
                myStack.Push("New Entry " + (iCount + 1));
            }
            ViewBag.MyStack = null;

            return View("Index");
        }

        public ActionResult Display() //shows the data in the stack. It does this by using a foreach loop in the view
        {
            ViewBag.MyStack = myStack;
            return View("Index");
        }

        public ActionResult Delete() //remove the most current data entry in the stack
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

        public ActionResult Clear() //clears the stack of all data
        {
            myStack.Clear();
            ViewBag.MyStack = null;
            return View("Index");
        }

        public ActionResult Search() //looks for the hardcoded input in the stack
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
            TimeSpan ts = sw.Elapsed; //calcuates the time spent searching the stack for the inputed data 

            ViewBag.StopWatch = ts + " Elapsed";
            ViewBag.MyStack = null;
            ViewBag.StackSearch = stackSearch;
            return View("Index");
        }

        public ActionResult Return() //returns to the home view
        {
            return RedirectToAction("Index", "Home");
        }
    }
} 