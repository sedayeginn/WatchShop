using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using ApplicationCore.Specifications;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Services.BasketServiceTest
{
   public class DeleteBasket
    {
        private readonly Mock<IAsyncRepository<Basket>> _mockBasketRepository;
        private readonly Mock<IAsyncRepository<BasketItem>> _mockBasketItemRepository;
        private readonly int _existingBasketId = 777;
        private readonly string _existingBuyerId = "ca8dfb01-a34a-43f6-a5fc-3141f0986f83";

        public DeleteBasket()
        {
            _mockBasketRepository = new Mock<IAsyncRepository<Basket>>();
            _mockBasketItemRepository = new Mock<IAsyncRepository<BasketItem>>();
        }

        [Fact]
        public async Task ShouldInvokeBasketRepositoryDeleteOnce()
        {
            _mockBasketRepository
                .Setup(x => x.FirstOrDefaultAsync(It.IsAny<BasketWithItemsSpecification>()))
                .ReturnsAsync(new Basket() { Id = _existingBasketId });

            var basketService = new BasketService(_mockBasketRepository.Object, _mockBasketItemRepository.Object);

            await basketService.DeleteBasketAsync(_existingBasketId);

            _mockBasketRepository.Verify(x => x.DeleteAsync(It.IsAny<Basket>()), Times.Once);
        }
    }
}
