using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    internal class Recipe
    {
        public int? RecipeID { get; private set; }
        public string? Name { get; private set; }
        public int? CookTime { get; private set; }
        public string? URL { get; private set; }
        public List<ProduceLine>? ProduceLines { get; private set; }
    }
}
