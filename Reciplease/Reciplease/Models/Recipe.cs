using System;
using System.Collections.Generic;
using System.Linq;
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
		public List<Nutrition> nutrition;
	}

	// only supplied when you pull the recipe from the api directly, not in search results
	public class Nutrition {
		public List<Nutrients> nutrients;
	}

	public class Nutrients {
		public string name;
		public string title;
		public string amount;
		public string unit;
		public string percentOfDailyNeeds;
	}
}