using ApplicationCore.Entities;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Specifications
{
    public class BasketWithItemsAndProductsSpecification : Specification<Basket>
    {
        public BasketWithItemsAndProductsSpecification(int basketId)
        {
            Query
                .Include(b => b.Items)
                .ThenInclude(i => i.Product)
                .Where(x => x.Id == basketId);
        }
    }
}
