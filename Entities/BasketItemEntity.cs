using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BenchMark.Entities
{
    [Serializable]
    public class BasketItemEntity
    {
        public int BasketID { get; set; }
        public long ProductID {get;set;}
        public decimal ChoiceWeight { get; set; }
        public decimal ChoiceQuantity { get; set; }
        public long BaseProductID { get; set; }
        public decimal ProductInStorePrice { get; set; }
        public decimal ProductInStoreQuantity { get; set; }
        public decimal ProductInStoreTotalPrice { get; set; }
        public DateTime AddedDateTime { get; set; }
        public decimal ProductAverageWeight { get; set; }
        public decimal ProductMaxWeight { get; set; }
        public int IsNotRanged { get; set; }
        public int IsSelectedByQuantity { get; set; }
        public int MeasureTypeID { get; set; }
        public int ProductTypeID { get; set; }
        public int UnitSaleTypeID {get;set;}
        public int IsRestrictedDelivery { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public int ChoiceQuantityOriginal { get; set; }
        public decimal ChoiceWeightOriginal { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductWeight { get; set; }
        public decimal ProductVolume { get; set; }
        public int IsNewlyAdded { get; set; }
        public int ChargeProductTypeId { get; set; }
    }
}
