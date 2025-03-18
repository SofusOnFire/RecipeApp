using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Interfaces
{
    public interface IAdminCreateRecipeService
    {
        public List<Produce> AllProduceWhenAdminCreateRecipe { get; }
        public List<Produce> SelectedProduceWhenAdminCreateRecipe { get; }
        public void AddRemoveProduceToNewRecipe(Produce produce);
    }
}
