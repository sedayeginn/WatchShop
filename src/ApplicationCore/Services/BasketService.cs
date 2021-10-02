using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class BasketService : IBasketService
    {
        private readonly IAsyncRepository<Basket> _basketRepository;

        public BasketService(IAsyncRepository<Basket> basketRepository)
        {
            _basketRepository = basketRepository;
        }
        public async Task AddItemToBasketAsync(int basketId, int productId, int quantity)
        {
            // sepeti ögeleriyle getir
            var spec = new BasketWithItemSpecification(basketId);
            Basket basket = await _basketRepository.GetByIdAsync(basketId);
            if (basket == null)
                throw new BasketNotFoundException(basketId);
            // ögelerinde ürün zaten varsa adetini arttır
            BasketItem item = basket.Items.FirstOrDefault(x => x.ProductId == productId);
            if(item!=null)
            {
                item.Quantity += quantity;
            }
            else
            {
                item = new BasketItem()
                {
                    BasketId = basketId,
                    ProductId = productId,
                    Quantity = quantity
                };
                basket.Items.Add(item);
            }
            await _basketRepository.UpdateAsync(basket);
            //ögelerinde yoksa ürünü adetiyle öge olarak ekle
            //kaydet
            
        }
    }
}
