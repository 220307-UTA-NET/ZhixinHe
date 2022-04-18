using Microsoft.AspNetCore.Mvc;
using Moq;
using SportsStore.Controllers;
using SportsStore.Models;
using Xunit;

namespace SportsStore.Tests;
public class OrderControllerTests
{
    [Fact]
    public void CannotCheckoutEmptyCart()
    {
        // Arrange - create a mock repository
        Mock<IOrderRepository> mock = new();
        Mock<IStoreRepository> mockStoreRepository = new();
        // Arrange - create an empty cart
        Cart cart = new();
        // Arrange - create the order
        Order order = new();
        // Arrange - create an instance of the controller
        OrderController target = new(mock.Object, cart, mockStoreRepository.Object);

        // Act
        ViewResult? result = target.Checkout(order) as ViewResult;

        // Assert - check that the order hasn't been stored
        mock.Verify(m => m.SaveOrder(It.IsAny<Order>()), Times.Never);
        // Assert - check that the method is returning the default view
        Assert.True(string.IsNullOrEmpty(result?.ViewName));
        // Assert - check that I am passing an invalid model to the view
        Assert.False(result?.ViewData.ModelState.IsValid);
    }
    [Fact]
    public void CannotCheckoutInvalidShippingDetails()
    {
        // Arrange
        Mock<IOrderRepository> mock = new();
        Mock<IStoreRepository> mockStoreRepository = new();
        Cart cart = new();
        cart.AddItem(new Product(), 1);
        OrderController target = new(mock.Object, cart, mockStoreRepository.Object);
        target.ModelState.AddModelError("error", "error");
        // Act - try to checkout
        ViewResult? result = target.Checkout(new Order()) as ViewResult;
        // Assert - check that the order hasn't been passed stored
        mock.Verify(m => m.SaveOrder(It.IsAny<Order>()), Times.Never);
        Assert.True(string.IsNullOrEmpty(result?.ViewName));
        Assert.False(result?.ViewData.ModelState.IsValid);
    }
    [Fact]
    public void CanCheckoutAndSubmitOrder()
    {
        // Arrange
        Mock<IOrderRepository> mock = new();
        Mock<IStoreRepository> mockStoreRepository = new();
        Cart cart = new();
        cart.AddItem(new Product(), 1);
        OrderController target = new(mock.Object, cart, mockStoreRepository.Object);
        // Act
        RedirectToPageResult? result = target.Checkout(new Order()) as RedirectToPageResult;
        // Assert
        mock.Verify(m => m.SaveOrder(It.IsAny<Order>()), Times.Once);
        Assert.Equal("/Completed", result?.PageName);
    }
}