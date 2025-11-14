using OOP_finalProject.Data;
using System.Collections.Generic;

namespace OOP_finalProject
{
    public class InvoiceData : BaseDataRepository<InvoiceList, Invoice>
    {
        public InvoiceData() : base() { }
        public override List<Invoice> GetData()
        {
            InvoiceList invoiceList = Load();
            return invoiceList.Invoices ?? new List<Invoice>();
        }
        public override void SaveData(List<Invoice> invoices)
        {
            InvoiceList invoiceList = new InvoiceList(invoices);
            Save(invoiceList);
        }
    }
}
