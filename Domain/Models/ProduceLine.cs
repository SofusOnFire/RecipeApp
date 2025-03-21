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
        public int Amount { get; private set; }
        public Produce _Produce { get; private set; }

        public ProduceLine(int produceLineID, int recipeID, int produceID, int amount)
        {
            ProduceLineID = produceLineID;
            RecipeID = recipeID;
            ProduceID = produceID;
            Amount = amount;
        }

        public void SetProduce(Produce produce)
        {
            _Produce = produce;
        }
    }
}
