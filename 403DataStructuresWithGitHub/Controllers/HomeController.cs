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
    public class HomeController : Controller
    {
        //Displays the index view
        public ActionResult Index()
        {
            return View();
        }
        //Redirects the webpage to the BYU homepage
        public ActionResult Exit()
        {
            return Redirect("https://www.byu.edu");
        }

    }
}