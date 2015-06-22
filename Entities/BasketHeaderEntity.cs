using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BenchMark.Entities
{
    [Serializable]
    public class BasketHeaderEntity
    {
        public int             BasketID     {get;set;}
        public long CustomerID { get; set; }
        public int BranchID { get; set; }
        public string Name { get; set; }
        public int IsActive { get; set; }
        public int IsBeingAmended { get; set; }
        public long            LastProductIDAdded{get;set;}
        public DateTime LastUpdatedDateTime { get; set; }
        public int RequiresRecalculation { get; set; }
        public float GuidePrice { get; set; }
        public int AmendModeContractID { get; set; }
        public DateTime AmendCutOffTime { get; set; }
        public int ApplyStaffDiscount { get; set; }
        public int PaymentCardID { get; set; }
        public int ECouponClubcardPoints { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int ContractVersionID { get; set; }
        public int IsDefault { get; set; }
        public string RewardXML { get; set; }
        public string PaymentItemXML { get; set; }
        public string ChargeXML { get; set; }
        public int DeliveryLocationId { get; set; }
        public int checkoutStatus { get; set; }
        public int OrderID { get; set; }
    }
}
