using ApplicationCore.Entities;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Specifications
{
    public class BasketItemsSpecification : Specification<BasketItem>
    {
        public BasketItemsSpecification(int basketId)
        {
            Query.Where(x => x.BasketId == basketId);
        }
    }
}
