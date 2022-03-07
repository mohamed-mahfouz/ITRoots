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
            if ((string)Session["UserRole"] == "User" || (string)Session["UserRole"] == "Admin")
                return View();

            return RedirectToAction("Login", "Account");
        }
      
        public ActionResult Create()
        {
            if ((string)Session["UserRole"] == "Admin")
            {
                var products = _productRepository.GetProducts();
                var productsWithDefaultValue = new List<Product>
            {
                new Product { Name = "---Choose Product---" }
            };
                productsWithDefaultValue.AddRange(products);

                return View(productsWithDefaultValue);

            }

            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public JsonResult Create(InvoiceViewModel invoiceViewModel)
        {

            _invoiceRepository.AddInvoice(invoiceViewModel);
            return Json("",JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(int id)
        {
            var invoice = _invoiceRepository.GetInvoiceById(id);
            if (invoice == null)
                return HttpNotFound();

            var invoiceDetails = _invoiceRepository.GetInvoiceDetails(id);

            return View(invoiceDetails);
        }

        [HttpGet]
       public JsonResult GetProductUnitPrice(decimal productId )
        {
            var unitPrice = _productRepository.GetProducts().Single(p => p.Id == productId).Price;
            return Json(unitPrice, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetInvoices()
        {
            var invoices = _invoiceRepository.GetInvoices();

            return Json(new { data = invoices }, JsonRequestBehavior.AllowGet);
        }

    }
}
