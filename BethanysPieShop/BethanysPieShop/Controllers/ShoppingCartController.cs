using BethanysPieShop.Models;
using BethanysPieShop.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers;

public class ShoppingCartController : Controller
{
    private readonly IPieRepository _pieRepository;
    private readonly IShoppingCart _shoppingCart;

    public ShoppingCartController(IPieRepository pieRepository, IShoppingCart shoppingCart)
    {
        _pieRepository = pieRepository;
        _shoppingCart = shoppingCart;
    }
}