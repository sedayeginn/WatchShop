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
    public class OrderService : IOrderService
    {
        private readonly IAsyncRepository<Basket> _basketRepository;
        private readonly IAsyncRepository<Order> _orderRepository;

        public OrderService(IAsyncRepository<Basket> basketRepository,IAsyncRepository<Order> orderRepository)
        {
            _basketRepository = basketRepository;
            _orderRepository = orderRepository;
        }
        public async Task<int> CreateOrderAsync(int basketId, Address address)
        {
            var specBasket = new BasketWithItemsAndProductsSpecification(basketId);
            var basket = await _basketRepository.FirstOrDefaultAsync(specBasket);
            if (basket == null) throw new BasketNotFoundException(basketId);
            if (basket.Items.Count == 0) throw new BasketItemsNotFoundException(basketId);

            Order order = new Order()
            {
                BuyerId = basket.BuyerId,
                ShipToAddress = address,
                OrderDetails = basket.Items.Select(x => new OrderDetail()
                {
                    PictureUri = x.Product.PictureUri,
                    Price = x.Product.Price,
                    ProductId = x.Product.Id,
                    ProductName = x.Product.ProductName,
                    Quantity = x.Quantity
                }).ToList()

            };
            order = await _orderRepository.AddAsync(order);
            return order.Id;
        }
    }
}
