using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _403DataStructuresWithGitHub.Controllers
{
    public class DictionaryController : Controller
    {
        static Dictionary<string,int> myDictionary = new Dictionary<string,int>(); //creates a new dictionay 

        string dictionarySearch = null;
        
        public ActionResult Index()  
        {
            ViewBag.MyDictionary = myDictionary;
            ViewBag.DictionarySearch = dictionarySearch;
            return View();
        }

        public ActionResult AddOne() //this adds a new entry into the dictioary 
        {
            myDictionary.Add("New Entry " + (myDictionary.Count + 1), (myDictionary.Count + 1));
            ViewBag.MyDictionary = null;

            return View("Index");
        }

        public ActionResult AddMany() //this clears the current dictionary and then loosps 2000 times adding new entrys into the dictionary
        {
            myDictionary.Clear();

            for (int iCount = 0; iCount < 2000; iCount++)
            {
                myDictionary.Add("New Entry " + (iCount + 1), (iCount + 1));
            }
            ViewBag.MyDictionary = null;

            return View("Index");
        }

        public ActionResult Display() //displays the current dictionary  through the viewbag. It has a foreach loop in the views folder
        {
            ViewBag.MyDictionary = myDictionary;
            return View("Index");
        }

        public ActionResult Delete() //this deletes the most recent entry into the dictioary
        {
            ViewBag.DictionaryDeletion = myDictionary.Remove("New Entry " + (myDictionary.Count));
            ViewBag.MyDictionary = null;
            return View("Index");
        }

        public ActionResult Clear() //this clears the dictioanry 
        {
            myDictionary.Clear();
            ViewBag.MyDictionary = null;
            return View("Index");

        }

        public ActionResult Search() //it seaches for the hardcoded entry from the programer and displays an entry or not.
        {
            dictionarySearch = "Not Found";
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            sw.Start();
            foreach (KeyValuePair<string,int> item in myDictionary)
            {
                if (item.Key == "New Entry 1283")
                {
                    dictionarySearch = "Entry 1283 found.";
                }
            }
            sw.Stop();
            TimeSpan ts = sw.Elapsed; //this calcuates how quickly a search for the hardcoded entry is found/not found in the dictionary

            ViewBag.StopWatch = ts + " Elapsed";
            ViewBag.MyDictionary = null;
            ViewBag.DictionarySearch = dictionarySearch;
            return View("Index");
        }

        public ActionResult Return() //returns to the home page view
        {
            return RedirectToAction("Index", "Home");
        }
    }
}