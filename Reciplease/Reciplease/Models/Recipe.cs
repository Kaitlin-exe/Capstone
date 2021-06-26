using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


//#################################################
// Models.Recipe
//
// Contains the elements of a recipe, directly tied 
// to the db fields 
// 
//#################################################
namespace Reciplease.Models {
	public class Recipe {
		public long id = 0;
		public string title = string.Empty;
		public int readyInMinutes = 0;
		public int servings = 0;
		public string image = string.Empty;
		//public List<Instructions> analyzedInstructions;
		public string instructions = string.Empty;
		public List<String> cuisines;
		public List<String> diets;
		public List<String> dishTypes;
		public List<Ingredient> extendedIngredients;
	}
}