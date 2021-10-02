using ApplicationCore.Entities;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Specifications
{
   public class BasketWithItemSpecification :Specification<Basket>
    {
        public BasketWithItemSpecification(int basketId)
        {
            Query
                .Include(x=>x.Items)
                .Where(x => x.Id == basketId);
        }
    }
}
