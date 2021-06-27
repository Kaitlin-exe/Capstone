﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


//#################################################
// Models.Ingredient
//
// Contains the elements of an ingredient
// 
//#################################################
namespace Reciplease.Models {
	public class Ingredient {
		public string id = string.Empty;
		public string name = string.Empty;
		public string amount = string.Empty;
		public string unit = string.Empty;
	}
}