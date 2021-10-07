using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Interfaces;
using Web.ViewModels;

namespace Web.Controllers
{
    public class BasketController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IBasketViewModelService _basketViewModelService;
        private readonly IBasketService _basketService;

        public BasketController(IBasketViewModelService basketViewModelService, IBasketService basketService, IOrderService orderService)
        {
            _orderService = orderService;
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
        [Authorize]
        public async Task<IActionResult> CheckOut()
        {
            var vm = new CheckOutViewModel();
            vm.Basket = await _basketViewModelService.GetBasketViewModelAsync();
            return View(vm);
        }
        [Authorize, HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CheckOut(CheckOutViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var basketId = await _basketViewModelService.GetOrCreateBasketIdAsync();
                try
                {
                    var orderId = await _orderService.CreateOrderAsync(basketId, new Address()
                    {
                        City = vm.City,
                        Country = vm.Country,
                        State = vm.State,
                        Street = vm.Street,
                        ZipCode = vm.ZipCode
                    });
                    await _basketService.DeleteBasketAsync(basketId);
                    return RedirectToAction("OrderCompleted", new { OrderId = orderId });
                }
                catch (BasketNotFoundException)
                {
                    ModelState.AddModelError("","Something went wrong!");
                }
                catch (BasketItemsNotFoundException)
                {
                    ModelState.AddModelError("", "Your basket is empty! Please add some items to your basket before checkout.");
                }

            }
            vm.Basket = await _basketViewModelService.GetBasketViewModelAsync();
            return View(vm);
        }
        public async Task<IActionResult> OrderCompleted(int orderId)
        {
            ViewBag.OrderId = orderId;
            return View();
        }
    }
}