using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;

namespace Services
{
    public class AdminCreateRecipeService : IAdminCreateRecipeService
    {
        public List<Produce> AllProduceWhenAdminCreateRecipe { get; private set; } = new List<Produce>();
        public List<Produce> SelectedProduceWhenAdminCreateRecipe { get; private set; } = new List<Produce>();

        private readonly IProduceRepository _produceRepository; // Exists to use the GetAllProduce-method to retrieve all produce from DB.
        /// <summary>
        /// Retrieves all produce from DB and allows Admin to select the produce wanted for the new recipe.
        /// Also allows for the admin to remove produce if misselected.
        /// </summary>
        /// <param name="produce"></param>
        /// <param name="listOfProduce"></param>
        /// 

        public AdminCreateRecipeService(IProduceRepository produceRepository)
        {
            _produceRepository = produceRepository;
            AllProduceWhenAdminCreateRecipe = _produceRepository.GetAllProduce();
        }

        //public void AddRemoveProduceToNewRecipe(Produce produce)
        //{
        //    AllProduceWhenAdminCreateRecipe = _produceRepository.GetAllProduce();

        //    if (AllProduceWhenAdminCreateRecipe != null)
        //    {
        //        AllProduceWhenAdminCreateRecipe.Remove(produce);
        //        SelectedProduceWhenAdminCreateRecipe.Add(produce);
        //        SelectedProduceWhenAdminCreateRecipe.Sort();
        //    }

        //    else if (SelectedProduceWhenAdminCreateRecipe != null)
        //    {
        //        SelectedProduceWhenAdminCreateRecipe.Remove(produce);
        //        AllProduceWhenAdminCreateRecipe.Add(produce);
        //        AllProduceWhenAdminCreateRecipe.Sort();
        //    }
        //}

        public void AddProduceToNewRecipe(Produce produce)
        {
            foreach (var prod in AllProduceWhenAdminCreateRecipe)
            {
                if (prod == produce)
                {
                    AllProduceWhenAdminCreateRecipe.Remove(produce);
                    break;
                }
            }
            SelectedProduceWhenAdminCreateRecipe.Add(produce);
            SelectedProduceWhenAdminCreateRecipe.Sort();
        }

        public void RemoveProduceFromNewRecipe(Produce produce)
        {
            foreach (var prod in SelectedProduceWhenAdminCreateRecipe)
            {
                if (prod == produce)
                {
                    SelectedProduceWhenAdminCreateRecipe.Remove(produce);
                    break;
                }
            }
            AllProduceWhenAdminCreateRecipe.Add(produce);
            AllProduceWhenAdminCreateRecipe.Sort();
        }

    }
}
