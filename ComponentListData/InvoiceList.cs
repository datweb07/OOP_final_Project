using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OOP_finalProject
{
    [Serializable]
    public class InvoiceList : ISerializable
    {
        private List<Invoice> invoices = new List<Invoice>();

        public List<Invoice> Invoices { get { return invoices; } set { invoices = value; } }

        public InvoiceList()
        {
        }

        public InvoiceList(List<Invoice> invoices)
        {
            Invoices = invoices;
        }

        public InvoiceList(SerializationInfo info, StreamingContext context)
        {
            Invoices = (List<Invoice>)info.GetValue("Invoices", typeof(List<Invoice>));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Invoices", Invoices);
        }

        public void AddInvoice(Invoice invoice)
        {
            invoices.Add(invoice);
        }
    }
}
