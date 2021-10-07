using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Exceptions
{
   public class BasketItemsNotFoundException :Exception
    {
        public BasketItemsNotFoundException(int basketId) : base($"The basket with id '${basketId}' has no items.")
        {

        }
    }
}
