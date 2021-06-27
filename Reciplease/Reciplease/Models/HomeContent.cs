using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


//#################################################
// Models.HomeContent
//
// Contains the fields passed to the Home View
// 
//#################################################
namespace Reciplease.Models {
	public class HomeContent {
		public RandomRecipesList RecipesToDisplay;
		public SearchResultsList SearchResults;
		
		public User User;
	}
}