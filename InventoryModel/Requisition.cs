using System;
using System.Collections.Generic;

namespace AIMS.Models
{
    public class Requisition : Account
    {
        public double DeliveryCharges { get; set; }

        public DateTime RequisitionDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime RequiredDate { get; set; }

        public int LocationId { get; set; }
        public int PartialDeliveryId { get; set; }
        public int PurchaseOrderId { get; set; }
        public int RequisitionId { get; set; }
        public int SupplierId { get; set; }

        public string DeliveryDateString { get; set; }
        public string DeliveryReceiptNo { get; set; }
        public string LocationAddress { get; set; }
        public string LocationName { get; set; }
        public string Reason { get; set; }
        public string ReasonForDeclined { get; set; }
        public string RequiredDateString { get; set; }
        public string RequisitionDateString { get; set; }
        public string RequisitionType { get; set; }
        public string SpecialInstruction { get; set; }
        public string Status {get; set; }
        public string SupplierInvoiceNo { get; set; }

        public Location Location { get; set; }
        public Supplier Supplier { get; set; }

        public List<RequisitionItem> RequisitionItems { get; set; }
    }

}