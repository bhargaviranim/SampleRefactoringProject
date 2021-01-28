namespace PinnacleSample
{
    public class PinnacleClient
    {
        private PartInvoiceController __Controller;

        public PinnacleClient()
        {
            __Controller = new PartInvoiceController(new CustomerRepositoryDB(),new PartInvoiceRepositoryDB());
        }

        public CreatePartInvoiceResult CreatePartInvoice(string stockCode, int quantity, string customerName)
        {
            return __Controller.CreatePartInvoice(stockCode, quantity, customerName);
        }
    }
}
