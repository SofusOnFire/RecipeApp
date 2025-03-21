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
        //public void AddRemoveProduceToNewRecipe(Produce produce);
        public List<int> GetCookTimes { get; }
        public List<Produce> GetAllProduces();
        public void AddProduceToNewRecipe(Produce produce);
        public void RemoveProduceFromNewRecipe(Produce produce);
        public string ValidateURL(string url);
        public string ValidateRecipeName(string adminNameInput);
        public bool AddRecipe(string recipeName, int cookTime, string uRL, List<Produce> produceList);
        public void ClearAddedProduces();

    }
}
