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
				RecipesToDisplay = Get5RandomAPIRecipes( )
			};

			return View( h );
		}

		// Gets 5 random recipes from the api, this is very costly as it counts as 5 requests in the api
		private RecipeResultsList Get5RandomAPIRecipes( ) {

			RecipeResultsList Recipes;

			// get 
			var client = new RestClient( "https://spoonacular-recipe-food-nutrition-v1.p.rapidapi.com/recipes/random?number=5" );
			var request = new RestRequest( Method.GET );
			request.AddHeader( "x-rapidapi-key", "42b1ebc198msh0a6b9caf8b93dc9p1e52ccjsn888e76e0bd8a" );
			request.AddHeader( "x-rapidapi-host", "spoonacular-recipe-food-nutrition-v1.p.rapidapi.com" );
			IRestResponse response = client.Execute( request );

			// deserialize object
			if ( response.StatusCode == HttpStatusCode.OK )
			{
				Recipes = JsonConvert.DeserializeObject<RecipeResultsList>( response.Content );
				return Recipes;
			}
			else
			{
				return null;
			}
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