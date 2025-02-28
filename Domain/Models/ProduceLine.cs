using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ProduceLine
    {
        public int ProduceLineID { get; private set; }
        public int RecipeID { get; private set; }
        public int ProduceID { get; private set; }
    }
}
