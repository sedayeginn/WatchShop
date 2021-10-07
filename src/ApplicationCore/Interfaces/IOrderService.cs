using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
   public interface IOrderService
    {
        Task<int> CreateOrderAsync(int basketId, Address address);
    }
}
