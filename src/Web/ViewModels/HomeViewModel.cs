using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class HomeViewModel
    {
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }
        public List<ProductViewModel> Products { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        public IEnumerable<SelectListItem> Brands { get; set; }
        public PaginationInfoViewModel PaginationInfo { get; set; }
    }
}
