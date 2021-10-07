using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class CheckOutViewModel
    {
        public BasketViewModel Basket { get; set; }
        [Required, MaxLength(180)]
        public string Street { get; set; }
        [Required, MaxLength(100)]
        public string City { get; set; }
        [Required, MaxLength(60)]
        public string State { get; set; }
        [Required, MaxLength(18)]
        public string ZipCode { get; set; }
        [Required, MaxLength(90)]
        public string Country { get; set; }
        [Required, MaxLength(90)]
        public string CCOwner { get; set; }
        [Required, MaxLength(16), RegularExpression("^[0-9]{16}$", ErrorMessage = "INVALID CARD NUMBER")]
        public string CCNumber { get; set; }
        [Required, MaxLength(5), RegularExpression(@"^(0[1-9]|1[0-2])\/[0-9]{2}$", ErrorMessage ="INVALID EXPRESSİON DATE.")]
        public string CCExpiration { get; set; }
        [Required, MaxLength(3), RegularExpression("^[0-9]{3}$", ErrorMessage = "INVALID CVV NUMBER.")]
        public string CCCW { get; set; }
    }
}
