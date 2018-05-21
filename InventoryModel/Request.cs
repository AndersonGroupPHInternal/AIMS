using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIMS.Models
{
    public class Request : Account
    {
        //Request
        public int RequestID { get; set; }
        public string RequestName { get; set; }
        public string RequestItem { get; set; }
        public string RequestLocation { get; set; }
        public int RequestQuanlity { get; set; }
        public string RequestDesciption { get; set; }
        public DateTime RequisitionDate { get; set; }

        public DateTime ? RequisitionDates { get; set; }

        public string RequisitionDateStrings => (RequisitionDates.Value == default(DateTime)) ?
          "No Transaction yet" :
          RequisitionDates.Value.ToString("MM/dd/yyyy");

        public DateTime RequiredDate { get; set; }

        public DateTime ? RequiredDates { get; set; }

        public string RequiredDateStrings => (RequiredDates.Value == default(DateTime)) ?
         "No Transaction yet" :
         RequiredDates.Value.ToString("MM/dd/yyyy");

        public string RequiredDateString { get; set; }
        public string RequisitionDateString { get; set; }

        public string RequisitionType { get; set; }
        public string SpecialInstruction { get; set; }
        public string Status{ get; set; }

        public string ReasonForDeclined { get; set; }

        public int LocationID { get; set; }
        public string LocationName { get; set; }

        public List<RequestItem> RequestItems { get; set; }

    }
}