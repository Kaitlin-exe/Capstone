using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


//#################################################
// Models.Recipe
//
// Contains the elements of a recipe returned by random recipes call to api
// 
//#################################################
namespace Reciplease.Models {
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
	}
}