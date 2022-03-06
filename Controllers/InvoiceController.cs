using ITRoots.Models;
using ITRoots.Repositories;
using ITRoots.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITRoots.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly ProductRepository _productRepository;
        private readonly InvoiceRepository _invoiceRepository;
        public InvoiceController()
        {
            _productRepository = new ProductRepository();
            _invoiceRepository = new InvoiceRepository();

        }

      
        public ActionResult Index()
        {
            var products = _productRepository.GetProducts();
            var productsWithDefaultValue = new List<Product>
            {
                new Product { Name = "---Choose Product---" }
            };
            productsWithDefaultValue.AddRange(products);

            return View(productsWithDefaultValue);
        }

        [HttpPost]
        public JsonResult Index(InvoiceViewModel invoiceViewModel)
        {

            _invoiceRepository.AddInvoice(invoiceViewModel);
            return Json("",JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
       public JsonResult GetProductUnitPrice(decimal productId )
        {
            var unitPrice = _productRepository.GetProducts().Single(p => p.Id == productId).Price;
            return Json(unitPrice, JsonRequestBehavior.AllowGet);
        }
    }
}
