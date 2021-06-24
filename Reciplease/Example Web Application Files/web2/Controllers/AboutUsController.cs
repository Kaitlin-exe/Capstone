using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace web2.Controllers
{
    public class AboutUsController : Controller
    {
        // GET: AboutUs
        public ActionResult Index()
        {
			Models.User u = new Models.User( );
			u = u.GetUserSession( );
			u.UID = 4; // my UID

			// load with my info
			Models.Database db = new Models.Database( );

			db.GetDeveloperUserInfo( ref u );

			return View( u );
        }


		[HttpPost]
		public ActionResult Index( FormCollection col ) {

			if ( col["btnSubmit"] == "close" )
			{
				return RedirectToAction( "Index", "Home" );
			}

			if ( col["btnSubmit"] == "more" )
			{
				return RedirectToAction( "More", new { @id = Convert.ToInt64( RouteData.Values["id"] ) } );
			}
			return View( );
		}

		// GET: AboutUs
		public ActionResult More( ) {
			Models.User u = new Models.User( );
			u = u.GetUserSession( );
			u.UID = 4; // my UID

			// load with my info
			Models.Database db = new Models.Database( );

			db.GetDeveloperUserInfo( ref u );

			return View( u );
		}


		[HttpPost]
		public ActionResult More( FormCollection col ) {

			if ( col["btnSubmit"] == "close" )
			{
				return RedirectToAction( "Index", "AboutUs" );
			}

			return View( );
		}

	}
}