namespace ITRoots.ViewModels
{
    public class InvoiceDetailViewModel
    {
        public int InvocieId { get; set; }

        public int ProductId { get; set; }
    
        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Total { get; set; }
    }
}