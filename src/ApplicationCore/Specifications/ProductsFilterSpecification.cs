using ApplicationCore.Entities;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Specifications
{
   public class ProductsFilterSpecification : Specification<Product>
    {
        public ProductsFilterSpecification(int? categoryId, int? brandId)
        {
            if (categoryId.HasValue)
                Query.Where(p => p.CategoryId == categoryId);
            if (brandId.HasValue)
                Query.Where(p => p.BrandId == brandId);

        }
    }
}
