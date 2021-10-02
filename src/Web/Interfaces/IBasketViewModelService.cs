using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Interfaces
{
   public interface IBasketViewModelService
    {
        Task<int> GetOrCreateBasketIdAsync();
        

        Task<int> BasketItemsCountAsync();
        
    }
}
