using Newtonsoft.Json;
using Reciplease.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reciplease.Models {
	[JsonObjectAttribute]
	public class RecipeResultsList : IEnumerable {
		public List<Recipe> recipes;

		// Implementation for the GetEnumerator method.
		IEnumerator IEnumerable.GetEnumerator( ) {
			return (IEnumerator)GetEnumerator( );
		}

		public IEnumerable GetEnumerator( ) {
			return this.recipes;
		}
	}	
}