using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;

namespace Reciplease.Models {
	public class RecipeAPI {
		const string APIKEY = "42b1ebc198msh0a6b9caf8b93dc9p1e52ccjsn888e76e0bd8a";

		// Gets 5 random recipes from the api, this is very costly as it counts as 5 requests in the api
		public static RecipesList Get5RandomAPIRecipes( ) {


			RecipesList Recipes = new RecipesList( );

			// get 
			var client = new RestClient( "https://spoonacular-recipe-food-nutrition-v1.p.rapidapi.com/recipes/random?number=5" );
			var request = new RestRequest( Method.GET );
			request.AddHeader( "x-rapidapi-key", APIKEY );
			request.AddHeader( "x-rapidapi-host", "spoonacular-recipe-food-nutrition-v1.p.rapidapi.com" );
			IRestResponse response = client.Execute( request );

			// deserialize object
			if ( response.StatusCode == HttpStatusCode.OK )
			{
				Recipes = JsonConvert.DeserializeObject<RecipesList>( response.Content );
			}
			
			return Recipes;
			
		}


		public static Recipe GetRecipeById( string id ) {

			Recipe clsRecipe = new Recipe( );
			// get 
			var client = new RestClient( "https://spoonacular-recipe-food-nutrition-v1.p.rapidapi.com/recipes/" + id + "/information?includeNutrition=true" );
			var request = new RestRequest( Method.GET );
			request.AddHeader( "x-rapidapi-key", APIKEY );
			request.AddHeader( "x-rapidapi-host", "spoonacular-recipe-food-nutrition-v1.p.rapidapi.com" );
			IRestResponse response = client.Execute( request );

			// deserialize object
			if ( response.StatusCode == HttpStatusCode.OK )
			{
				clsRecipe = JsonConvert.DeserializeObject<Recipe>( response.Content );
			}

			return clsRecipe;

		}


		public static SearchResultsList RecipeSearch( string SearchQuery, string cuisine = "", string ingredients = "", string diets = "", string excludedIngredients ="", string intolerances = "", string type = "") {
			SearchResultsList Recipes = new SearchResultsList( );
			Regex RegexComma = new Regex( "," );
			Regex RegexSpace = new Regex( " " );


			SearchQuery = RegexComma.Replace( SearchQuery, "%2C%20" );
			SearchQuery = RegexSpace.Replace( SearchQuery, "%20" );
			cuisine = RegexComma.Replace( cuisine, "%2C%20" );
			cuisine = RegexSpace.Replace( cuisine, "%20" );
			ingredients = RegexComma.Replace( ingredients, "%2C%20" );
			ingredients = RegexSpace.Replace( ingredients, "%20" );
			excludedIngredients = RegexComma.Replace( excludedIngredients, "%2C%20" );
			excludedIngredients = RegexSpace.Replace( excludedIngredients, "%20" );
			intolerances = RegexComma.Replace( intolerances, "%2C%20" );
			intolerances = RegexSpace.Replace( intolerances, "%20" );
			type = RegexComma.Replace( type, "%2C%20" );
			type = RegexSpace.Replace( type, "%20" );


			var client = new RestClient( "https://spoonacular-recipe-food-nutrition-v1.p.rapidapi.com/recipes/search?query=" + SearchQuery +
									 "&diet=" +									diets +
									 "&excludeIngredients=" +					excludedIngredients +
									 "&intolerances=" +							intolerances +
									 "&number=20&type=" +						type +
									 "&instructionsRequired=true&cuisine=" +	cuisine
									 );

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
	}
}