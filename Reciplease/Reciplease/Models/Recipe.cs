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

		public string SplitInstructions() {
			string pattern = @"(?:\.\' ')";

			string newString = Regex.Replace( this.instructions, pattern, "\r\n" ); 
			

			// working on replacing sentence ends with a new line


			return newString;
		}
	}

	// only supplied when you pull the recipe from the api directly, not in search results
	public class Nutrition {
		public JsonObject nutrients { get; set; }

	}
	
	public class Nutrient {
		public string name;
		public string title;
		public string amount;
		public string unit;
		public string percentOfDailyNeeds;
	}
}