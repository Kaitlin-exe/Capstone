using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Reciplease.Models {
	public class RecipeAPI {
		const string APIKEY = "42b1ebc198msh0a6b9caf8b93dc9p1e52ccjsn888e76e0bd8a";

		// Gets 5 random recipes from the api, this is very costly as it counts as 5 requests in the api
		public static RandomRecipesList Get5RandomAPIRecipes( ) {


			RandomRecipesList Recipes = new RandomRecipesList( );

			// get 
			var client = new RestClient( "https://spoonacular-recipe-food-nutrition-v1.p.rapidapi.com/recipes/random?number=5" );
			var request = new RestRequest( Method.GET );
			request.AddHeader( "x-rapidapi-key", APIKEY );
			request.AddHeader( "x-rapidapi-host", "spoonacular-recipe-food-nutrition-v1.p.rapidapi.com" );
			IRestResponse response = client.Execute( request );

			// deserialize object
			if ( response.StatusCode == HttpStatusCode.OK )
			{
				Recipes = JsonConvert.DeserializeObject<RandomRecipesList>( response.Content );
			}
			
			return Recipes;
			
		}


		// basic search
		public static SearchResultsList BasicRecipeSearch( string SearchQuery ) {

			SearchResultsList Recipes = new SearchResultsList( );

			// get 
			var client = new RestClient( "https://spoonacular-recipe-food-nutrition-v1.p.rapidapi.com/recipes/search?query=" + SearchQuery  + "& number=20&offset=0&instructionsRequired=true" );
			var request = new RestRequest( Method.GET );
			request.AddHeader( "x-rapidapi-key", APIKEY );
			request.AddHeader( "x-rapidapi-host", "spoonacular-recipe-food-nutrition-v1.p.rapidapi.com" );
			IRestResponse response = client.Execute( request );

			// deserialize object
			if ( response.StatusCode == HttpStatusCode.OK )
			{
				Recipes = JsonConvert.DeserializeObject<SearchResultsList>( response.Content );
			}
			else if ( response.StatusCode == HttpStatusCode.Unauthorized )
			{
				// quota is gone
			}


			return Recipes;
		}


		public static SearchResultsList AdvancedSearch( string SearchQuery, string cuisine, string ingredients, string diets, string excludedIngredients, string intolerances, string type ) {
			SearchResultsList Recipes = new SearchResultsList( );

			return Recipes;
		}
	}
}