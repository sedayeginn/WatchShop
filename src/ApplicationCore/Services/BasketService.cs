using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class BasketService : IBasketService
    {
        private readonly IAsyncRepository<Basket> _basketRepository;
        private readonly IAsyncRepository<BasketItem> _basketItemRepository;

        public BasketService(IAsyncRepository<Basket> basketRepository, IAsyncRepository<BasketItem> basketItemRepository)
        {
            _basketRepository = basketRepository;
            _basketItemRepository = basketItemRepository;
        }

        public async Task AddItemToBasketAsync(int basketId, int productId, int quantity)
        {
            if (quantity < 1)
                throw new ArgumentOutOfRangeException("Quantity must be a positive number.");

            var basket = await GetBasketWithItemsAsync(basketId);
            var item = basket.Items.FirstOrDefault(x => x.ProductId == productId);

            if (item != null)
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
        }

        public async Task<int> BasketItemsCountAsync(int basketId)
        {
            var spec = new BasketItemsSpecification(basketId);
            return await _basketItemRepository.CountAsync(spec);
        }

        public async Task DeleteBasketAsync(int basketId)
        {
            var basket = await GetBasketWithItemsAsync(basketId);
            await _basketRepository.DeleteAsync(basket);
        }

        public async Task RemoveBasketItemAsync(int basketId, int basketItemId)
        {
            var basket = await GetBasketWithItemsAsync(basketId);
            basket.Items.RemoveAll(x => x.Id == basketItemId);
            await _basketRepository.UpdateAsync(basket);
        }

        public async Task SetQuantitiesAsync(int basketId, Dictionary<int, int> quantities)
        {
            var basket = await GetBasketWithItemsAsync(basketId);

            foreach (var item in basket.Items)
            {
                int newValue;
                if (quantities.TryGetValue(item.Id, out newValue))
                {
                    if (newValue < 1)
                        throw new ArgumentOutOfRangeException("Quantity must be a positive number.");
                    item.Quantity = newValue;
                }
            }
            await _basketRepository.UpdateAsync(basket);
        }

        public async Task TransferBasketAsync(string fromBuyerId, string toBuyerId)
        {
            //get fromBuyer basket(if null, return)
            var specFrom = new BasketWithItemsSpecification(fromBuyerId);
            Basket basketFrom = await _basketRepository.FirstOrDefaultAsync(specFrom);
            if (basketFrom == null) return;

            //get toBuyer basket (if null, create)
            var specTo = new BasketWithItemsSpecification(toBuyerId);
            Basket basketTo = await _basketRepository.FirstOrDefaultAsync(specTo);
            if (basketTo == null) basketTo = new Basket() { BuyerId = toBuyerId };

            //transfer items
            foreach (var item in basketFrom.Items)
            {
                var targetItem = basketTo.Items.FirstOrDefault(x => x.ProductId == item.ProductId);
                if (targetItem == null)
                {
                    basketTo.Items.Add(new BasketItem()
                    {
                        ProductId = item.ProductId,
                        Quantity = item.Quantity
                    });
                }
                else
                {
                    targetItem.Quantity += item.Quantity;
                }
            }
            await _basketRepository.UpdateAsync(basketTo);
            //delete fromBuyerBasket
            await _basketRepository.DeleteAsync(basketFrom);

        }

        private async Task<Basket> GetBasketWithItemsAsync(int basketId)
        {
            var spec = new BasketWithItemsSpecification(basketId);
            Basket basket = await _basketRepository.FirstOrDefaultAsync(spec);
            if (basket == null) throw new BasketNotFoundException(basketId);
            return basket;
        }
    }
}