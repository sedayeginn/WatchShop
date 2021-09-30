using ApplicationCore.Entities;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Specifications
{
   public class ProductsFilterPaginatedSpecification :Specification<Product>
    {
        public ProductsFilterPaginatedSpecification(int? categoryId, int? brandId, int skip, int take)
        {
            if (categoryId.HasValue)
                Query.Where(p => p.CategoryId == categoryId);
            if (brandId.HasValue)
                Query.Where(p => p.BrandId == brandId);
            Query.Skip(skip).Take(take);

        }
    }
}
