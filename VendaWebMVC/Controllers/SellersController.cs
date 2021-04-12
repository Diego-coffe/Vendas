using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VendaWebMVC.Models;
using VendaWebMVC.Models.ViewModels;
using VendaWebMVC.Services;
using VendaWebMVC.Services.Exceptions;
using VendaWebMVC.Views.Departments;

namespace VendaWebMVC.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll();

            return View(list);
        }

        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel {Departments = departments};
            return View(viewModel);
        }


        //Anotation >> Estou indicando que essa ação é de post e não de get (por padrão a ação é get) [HttpPost]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendedor vendedor)
        {
            if (!ModelState.IsValid)
            {
                var departments = _departmentService.FindAll();
                var viewModel = new SellerFormViewModel { Vendedor = vendedor, Departments = departments };
                return View(viewModel);
            }
            _sellerService.Insert(vendedor);
            return RedirectToAction(nameof(Index));
        }

        //int?  >> ? indica que a ação é opcional
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }
            var obj = _sellerService.FindById(id.Value);
            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details (int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }
            var obj = _sellerService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }
            var obj = _sellerService.FindById(id.Value);
            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            List<Department> department = _departmentService.FindAll();
            SellerFormViewModel viewModel = new SellerFormViewModel { Vendedor = obj, Departments = department };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Vendedor vendedor)
        {
            if (!ModelState.IsValid)
            {
                var departments = _departmentService.FindAll();
                var viewModel = new SellerFormViewModel { Vendedor = vendedor, Departments = departments };
                return View(viewModel);
            }
            if (id != vendedor.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }
            try
            {
                _sellerService.Update(vendedor);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
            catch (DbConcurrencyException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }
        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }

    }
}
