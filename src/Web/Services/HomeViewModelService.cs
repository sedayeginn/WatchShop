using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Interfaces;
using Web.ViewModels;

namespace Web.Services
{
    public class HomeViewModelService : IHomeViewModelService
    {
        private readonly IAsyncRepository<Product> _productRepository;

        public HomeViewModelService(IAsyncRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<HomeViewModel> GetHomeViewModelAsync()
        {
            var products = await _productRepository.ListAllAsync();
            var vm = new HomeViewModel()
            {
                Products =products.Select(p=>new ProductViewModel()
                {
                    Id=p.Id,
                    ProductName=p.ProductName,
                    PictureUri=p.PictureUri,
                    Price=p.Price
                }).ToList()
            };

            return vm;
        }
    }
}
