using Newtonsoft.Json;
using Reciplease.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Reciplease.Controllers {
	public class HomeController : Controller {
		public ActionResult Index( ) {

			Models.HomeContent h = new Models.HomeContent
			{
				// get recipes to display
				RecipesToDisplay = RecipeAPI.Get5RandomAPIRecipes( )

				// get the user object when we set up users
			};

			return View( h );
		}

		public ActionResult Search( ) {
			Models.HomeContent h = new Models.HomeContent();

			return View( h );
		}

		[HttpPost]
		public ActionResult Search( FormCollection col ) {
			// update to search model when that is created
			Models.HomeContent h = new Models.HomeContent
			{
				// get recipes to display
				SearchResults = RecipeAPI.RecipeSearch( col[1].ToString( ) )

				// get the user object when we set up users
			};

			return View( h );
		}


		public ActionResult Recipe(  ) {
			// update to search model when that is created
			Models.HomeContent h = new Models.HomeContent
			{
				// get recipes to display
				SingleRecipe = RecipeAPI.GetRecipeById( Convert.ToString(RouteData.Values["id"]) )

				// get the user object when we set up users
			};

			return View( h );
		}



		public ActionResult About( ) {
			ViewBag.Message = "Your application description page.";

			return View( );
		}

		public ActionResult Contact( ) {
			ViewBag.Message = "Your contact page.";

			return View( );
		}

	}
}