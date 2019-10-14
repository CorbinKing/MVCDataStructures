using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _403DataStructuresWithGitHub.Controllers
{
    public class DictionaryController : Controller
    {
        static Dictionary<string,int> myDictionary = new Dictionary<string,int>();

        string dictionarySearch = null;
        // GET: Dictionary
        public ActionResult Index()
        {
            ViewBag.MyDictionary = myDictionary;
            ViewBag.DictionarySearch = dictionarySearch;
            return View();
        }

        public ActionResult AddOne()
        {
            myDictionary.Add("New Entry " + (myDictionary.Count + 1), (myDictionary.Count + 1));
            ViewBag.MyDictionary = null;

            return View("Index");
        }

        public ActionResult AddMany()
        {
            myDictionary.Clear();

            for (int iCount = 0; iCount < 2000; iCount++)
            {
                myDictionary.Add("New Entry " + (iCount + 1), (iCount + 1));
            }
            ViewBag.MyDictionary = null;

            return View("Index");
        }

        public ActionResult Display()
        {
            ViewBag.MyDictionary = myDictionary;
            return View("Index");
        }

        public ActionResult Delete()
        {
            ViewBag.DictionaryDeletion = myDictionary.Remove("New Entry " + (myDictionary.Count));
            ViewBag.MyDictionary = null;
            return View("Index");
        }

        public ActionResult Clear()
        {
            myDictionary.Clear();
            ViewBag.MyDictionary = null;
            return View("Index");

        }

        public ActionResult Search()
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
            TimeSpan ts = sw.Elapsed;

            ViewBag.StopWatch = ts + " Elapsed";
            ViewBag.MyDictionary = null;
            ViewBag.DictionarySearch = dictionarySearch;
            return View("Index");
        }

        public ActionResult Return()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}