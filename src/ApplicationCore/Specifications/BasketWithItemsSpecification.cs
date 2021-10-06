using ApplicationCore.Entities;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Specifications
{
    public class BasketWithItemsSpecification : Specification<Basket>
    {
        public BasketWithItemsSpecification(int basketId)
        {
            Query
                .Include(x => x.Items)
                .Where(x => x.Id == basketId);
        }
        public BasketWithItemsSpecification(string buyerId)
        {
            Query
                .Include(x => x.Items)
                .Where(x => x.BuyerId == buyerId);
        }
    }
}
