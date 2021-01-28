namespace PinnacleSample
{
    public class PartInvoiceController
    {

        public ICustomerRepositoryDB customerRepositoryDB;

        public IPartInvoiceRepositoryDB partInvoiceRepositoryDB;

        public PartInvoiceController(ICustomerRepositoryDB customerRepositoryDB, IPartInvoiceRepositoryDB partInvoiceRepositoryDB)
        {
            this.customerRepositoryDB = customerRepositoryDB;
            this.partInvoiceRepositoryDB = partInvoiceRepositoryDB;
        }
    
        public CreatePartInvoiceResult CreatePartInvoice(string stockCode, int quantity, string customerName)
        {
            var invoiceResult = false;
            if (string.IsNullOrEmpty(stockCode))
            {
                invoiceResult = false;
              //  return new CreatePartInvoiceResult(false);
            }

            if (quantity <= 0)
            {
                invoiceResult = false;
               // return new CreatePartInvoiceResult(false);
            }

            Customer _Customer = customerRepositoryDB.GetByName(customerName);
            if (_Customer.ID <= 0)
            {
                invoiceResult = false;
               // return new CreatePartInvoiceResult(false);
            }

            using (PartAvailabilityServiceClient _PartAvailabilityService = new PartAvailabilityServiceClient())
            {
                int _Availability = _PartAvailabilityService.GetAvailability(stockCode);
                if (_Availability <= 0)
                {
                    invoiceResult = false;
                  //  return new CreatePartInvoiceResult(false);
                }
            }

            PartInvoice _PartInvoice = new PartInvoice
            {
                StockCode = stockCode,
                Quantity = quantity,
                CustomerID = _Customer.ID
            };


          //  PartInvoiceRepositoryDB _PartInvoiceRepository = new PartInvoiceRepositoryDB();
            partInvoiceRepositoryDB.Add(_PartInvoice);
            invoiceResult = true;
            return new CreatePartInvoiceResult(invoiceResult);
        }
    }
}
