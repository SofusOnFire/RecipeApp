using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    /// <summary>
    /// Exists to implement the user's add/remove functionality; when registering produce.
    /// </summary>
    public interface IUserProduceService
    {
        // Created in UserProduceService; added here because it is needed by other classes/interfaces.
        public List<Produce> TheUsersPersonalProduce { get; }
        
        // Used for the add/remove functionality between the user's personal list of produce and the ALL produce list.
        public void MoveProduceBetweenLists(Produce produce, List<Produce> listOfProduce);

	}
}
