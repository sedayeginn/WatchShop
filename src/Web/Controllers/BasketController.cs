using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Interfaces;

namespace Web.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketViewModelService _basketViewModelService;
        private readonly IBasketService _basketService;

        public BasketController(IBasketViewModelService basketViewModelService, IBasketService basketService)
        {
            _basketViewModelService = basketViewModelService;
            _basketService = basketService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _basketViewModelService.GetBasketViewModelAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddItem(int productId, int quantity = 1)
        {
            return Json(await _basketViewModelService.AddItemToBasketAsync(productId, quantity));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([ModelBinder(Name = "quantities")] Dictionary<int, int> quantities)
        {
            int basketId = await _basketViewModelService.GetOrCreateBasketIdAsync();
            await _basketService.SetQuantitiesAsync(basketId, quantities);
            TempData["result"] = "UpdateSuccess";
            return RedirectToAction("Index");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveItem(int basketItemId)
        {
            int basketId = await _basketViewModelService.GetOrCreateBasketIdAsync();
            await _basketService.RemoveBasketItemAsync(basketId, basketItemId);
            TempData["result"] = "RemoveSuccess";
            return RedirectToAction("Index");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete()
        {
            int basketId = await _basketViewModelService.GetOrCreateBasketIdAsync();
            await _basketService.DeleteBasketAsync(basketId);
            TempData["result"] = "DeleteSuccess";
            Response.Cookies.Delete(Constants.BASKET_COOKIENAME);
            return RedirectToAction("Index");
        }
    }
}