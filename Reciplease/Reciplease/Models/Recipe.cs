using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Reciplease.Models {
	//#################################################
	// Models.Recipe
	//
	// Contains the elements of a recipe returned by random recipes call to api
	// 
	//#################################################
	public class Recipe {
		public string id = string.Empty;
		public string title = string.Empty;
		public string readyInMinutes = string.Empty;
		public string servings = string.Empty;
		public string image = string.Empty;
		public string instructions = string.Empty;
		public List<String> cuisines;
		public List<String> diets;
		public List<String> dishTypes;
		public List<Ingredient> extendedIngredients;	
		public JsonObject nutrition;
		// create method to parse jsonobject

		
		public List<Nutrient> GetNutrients( ){
			List<Nutrient> nutrients = new List<Nutrient>();

			return nutrients;
		}

		
		public string[] SplitInstructions() {
			string pattern = @"(?<=[\.!\?])\s+";

			string cleanedInstructions = Regex.Replace( this.instructions, "<.*?>", String.Empty );
			string[] ainstructions = Regex.Split( cleanedInstructions, pattern );

			return ainstructions;
		}
	}

	// only supplied when you pull the recipe from the api directly, not in search results
	public class Nutrition {
		public List<Nutrient> nutrients;
	}
	
	public class Nutrient {
		public string name;
		public string title;
		public string amount;
		public string unit;
		public string percentOfDailyNeeds;
	}
}