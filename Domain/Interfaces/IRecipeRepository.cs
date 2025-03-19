﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRecipeRepository
    {
        public IEnumerable<Recipe> GetAllRecipesFromDatabase();
        public int AdminAddRecipeToDB(string recipeName, int cookTime, string uRL, List<Produce> produces);
    }
}
