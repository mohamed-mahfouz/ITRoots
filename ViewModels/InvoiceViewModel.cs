using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITRoots.ViewModels
{
    public class InvoiceViewModel
    {
       
        public decimal FinalTotal { get; set; }

        public IEnumerable<InvoiceDetailViewModel> InvoiceDetailsList { get; set; }
    }
}