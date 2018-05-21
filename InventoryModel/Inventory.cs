using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AIMS.Models
{
    public class Inventory
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string Location { get; set; }
        public int Quantity { get; set; }

    }
    public class Stocks
    {
       
        public int InventoryItemID { get; set; }
        public string ItemName { get; set; }
        public int TotalStock { get; set; }

        
          public int EndingBal 
        {
            get
            {
                return ((ItemBegBal + LatestQuantity) - (RequestedQuantity))  ;
            }
        }
        public int RequestedQuantity { get; set; }
        public string NewItemLimit { get; set; }
        public string UnitOfDescription { get; set; }
        public DateTime?  LastRequestedDate { get; set; }

        public string LastRequestedDateString => (LastRequestedDate.Value == default(DateTime)) ?
            "No Transaction yet":
            LastRequestedDate.Value.ToString("MM/dd/yyyy");


        
        public DateTime?  DeliveryDate { get; set; }

        public string DeliveryDateString => (DeliveryDate.Value == default(DateTime)) ?
           "No Transaction yet" :
           DeliveryDate.Value.ToString("MM/dd/yyyy");

        public string LastRequestedName { get; set; }
        //public int RemainingQuantity { get; set; }
        public int RemainingQuantity
        {
            get
            {
                return (TotalStock + RequestedQuantity);
            }
        }
        public string ItemCode { get; set; }
        public int ItemBegBal { get; set; }

        public int LatestQuantity { get; set; }


        //public string LatestQuantity { get; set; }


    }
}