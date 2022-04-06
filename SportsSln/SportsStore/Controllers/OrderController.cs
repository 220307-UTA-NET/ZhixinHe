using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Controllers;
public class OrderController : Controller
{
    private IOrderRepository repository;
    private IStoreRepository storeRepository;
    private Cart cart;
    public OrderController(IOrderRepository repoService, Cart cartService, IStoreRepository srepoService)
    {
        repository = repoService;
        cart = cartService;
        storeRepository = srepoService;
    }
    public ViewResult Checkout() => View(new Order());

    [HttpPost]
    public IActionResult Checkout(Order order) 
    {
        if (cart.Lines.Count() == 0)
        {
            ModelState.AddModelError("", "Sorry, your cart is empty!");
        }
        if (ModelState.IsValid) 
        {
            order.Lines = cart.Lines.ToArray();
            repository.SaveOrder(order);
            foreach (var cartline in cart.Lines)
            {
                var nItems = cartline.Quantity;
                Product product = storeRepository.Products.FirstOrDefault(p => p.ProductID == cartline.Product.ProductID) ?? new();;
                product.Quantity -= nItems;
                storeRepository.SaveProduct(cartline.Product);
            }
            cart.Clear();
            return RedirectToPage("/Completed", new { orderId = order.OrderID });
        } else 
        {
            return View();
        }
    }
}