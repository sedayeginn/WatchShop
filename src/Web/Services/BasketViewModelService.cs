using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Web.Interfaces;

namespace Web.Services
{
    public class BasketViewModelService : IBasketViewModelService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAsyncRepository<Basket> _basketRepository;

        public BasketViewModelService(IHttpContextAccessor httpContextAccessor, IAsyncRepository<Basket> basketRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _basketRepository = basketRepository;
        }
        public Task<int> BasketItemsCountAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetOrCreateBasketIdAsync()
        {
            string userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //kullanıcı login mi
            if (!string.IsNullOrEmpty(userId))
            {
                //loginse sepeti var mı
                var spec = new BasketSpecification(userId);
                Basket basket =await _basketRepository.FirstOrDefaultAsync(spec);
                if (basket != null) return basket.Id;
                //loginse ve sepeti yoksa oluştur
                return (await CreateBasketAsync(userId)).Id;

            }
            //sepet id döndür
            //login değilse sepette cookie var mı
            var anonymousUserId = _httpContextAccessor.HttpContext.Request.Cookies[Constants.BASKET_COOKIENAME];
            if (anonymousUserId != null)
            {
                var spec = new BasketSpecification(anonymousUserId);
                Basket basket = await _basketRepository.FirstOrDefaultAsync(spec);
                return basket.Id;
            }
            //sepet cookie yoksa oluştur
            anonymousUserId = Guid.NewGuid().ToString();
            _httpContextAccessor.HttpContext.Response.Cookies.Append(Constants.BASKET_COOKIENAME, anonymousUserId, new CookieOptions() { Expires = DateTime.Now.AddMonths(1), IsEssential=true });
            //sepet id döndür
            return (await CreateBasketAsync(anonymousUserId)).Id;
        }

        private async Task<Basket> CreateBasketAsync(string buyerId)
        {
            Basket basket = new Basket()
            {
                BuyerId = buyerId
            };
            return await _basketRepository.AddAsync(basket);
        }
    }
}
