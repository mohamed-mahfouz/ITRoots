using ITRoots.Models;
using ITRoots.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITRoots.Repositories
{
    public class InvoiceRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public InvoiceRepository()
        {
            this._dbContext = new ApplicationDbContext();
        }

       public bool AddInvoice(InvoiceViewModel invoiceViewModel)
        {
            var invoice = new Invoice();
            invoice.FinalTotal = invoiceViewModel.FinalTotal;
            _dbContext.Invoices.Add(invoice);
            _dbContext.SaveChanges();

            int invoiceId = invoice.Id;

            foreach(var item in invoiceViewModel.InvoiceDetailsList)
            {
                var inviceDetail = new InvoiceDetail
                {
                    InvoiceId = invoiceId,
                    Quantity = item.Quantity,
                    Total = item.Total,
                    UnitPrice = item.UnitPrice,
                    ProductId = item.ProductId
                };
                _dbContext.InvoiceDetails.Add(inviceDetail);        
            }
            _dbContext.SaveChanges();
            return true;
        }
    }
}