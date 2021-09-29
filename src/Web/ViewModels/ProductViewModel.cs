using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class ProductViewModel
    {
        //anasayfada product'ın hangi özelliklerini görmek istiyorsak onu yazacağız
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string PictureUri { get; set; }  

    }
}
