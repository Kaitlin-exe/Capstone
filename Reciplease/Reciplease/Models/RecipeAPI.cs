using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Reciplease.Models {
	public class RecipeAPI {
		// Gets 5 random recipes from the api, this is very costly as it counts as 5 requests in the api
		public static RecipeResultsList Get5RandomAPIRecipes( ) {

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
	}
}