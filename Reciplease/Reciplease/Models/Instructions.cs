using System.Collections.Generic;

namespace Reciplease.Models {
	public class Instructions {
		public List<Instruction> recipeInstructions;
	}


	public class Instruction {
		public string name = string.Empty;
		public List<Steps> steps;
	}


	public class Steps {
		public int number;
		public string step = string.Empty;
		public List<Ingredient> ingredients;
	}
}