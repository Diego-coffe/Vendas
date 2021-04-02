using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendaWebMVC.Models;
using VendaWebMVC.Services;

namespace VendaWebMVC.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;

        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll();

            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }


        //Anotation >> Estou indicando que essa ação é de post e não de get (por padrão a ação é get) [HttpPost]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendedor vendedor)
        {
            _sellerService.Insert(vendedor);
            return RedirectToAction(nameof(Index));
        }
    }
}
