using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Exceptions
{
   public class BasketNotFoundException :Exception
    {
        public BasketNotFoundException(int basketId) :base($"No basket found with id {basketId}")
        {

        }
    }
}
