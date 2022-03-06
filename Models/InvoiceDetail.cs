using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITRoots.Models
{
    public class InvoiceDetail
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        ICollection<Product> Products { get; set; }

        public int InvoiceId { get; set; }

        public Invoice Invoice { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Total { get; set; }

    }
}