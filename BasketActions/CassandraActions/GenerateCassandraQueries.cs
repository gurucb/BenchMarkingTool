using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BenchMark.Entities;

namespace BenchMark.BasketActions
{
    internal class GenerateCassandraQueries
    {
        string timestamp = "";
        BasketHeaderEntity bh;
        StringBuilder bQuery;
        StringBuilder bIQuery;
       internal GenerateCassandraQueries()
        {
            bQuery = new StringBuilder();
            timestamp = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + " " + DateTime.Now.ToLongTimeString() + "." + DateTime.Now.Millisecond;
             bIQuery= new StringBuilder();
        }

        internal string InsertBasketHeader(Basket basket)
        {
            
            bh = basket.BasketHeader;
            bQuery.Clear();
            //Basket Insertion
            bQuery.Append("insert into BasketHeader(BasketID,CustomerID,BranchID,Name,IsActive");
            bQuery.Append(",IsBeingAmended,LastProductIDAdded,LastUpdatedDateTime,RequiresRecalculation,GuidePrice");
            bQuery.Append(",AmendModeContractID,AmendCutoffTime,ApplyStaffDiscount,PaymentCardID,ECouponClubcardPoints,CreatedDateTime");
            bQuery.Append(",ContractVersionID,IsDefault,DeliveryLocationId,checkoutStatus,OrderID,RewardXML,PaymentItemXML,ChargeXML");
            bQuery.Append(") values(");
            bQuery.Append("'" + bh.BasketID.ToString() + "',");
            bQuery.Append("'" + bh.CustomerID.ToString() + "',");
            bQuery.Append("'" + bh.BranchID.ToString() + "',");
            bQuery.Append("'" + bh.Name + "',");
            bQuery.Append("'" + bh.IsActive + "',");
            bQuery.Append("'" + bh.IsBeingAmended + "',");
            bQuery.Append("'" + bh.LastProductIDAdded + "',");
            //bQuery.Append("'" + basket.LastUpdatedDateTime + "',");
            bQuery.Append("'" + timestamp + "',");
            bQuery.Append("'" + bh.RequiresRecalculation + "',");
            bQuery.Append("'" + bh.GuidePrice + "',");
            bQuery.Append("'" + bh.AmendModeContractID + "',");
            bQuery.Append("'" + bh.AmendCutOffTime + "',");
            bQuery.Append("'" + bh.ApplyStaffDiscount + "',");
            bQuery.Append("'" + bh.PaymentCardID + "',");
            bQuery.Append("'" + bh.ECouponClubcardPoints + "',");
            //bQuery.Append(basket.CreatedDateTime+"',");
            bQuery.Append("'" + timestamp + "',");
            bQuery.Append("'" + bh.ContractVersionID + "',");
            bQuery.Append("'" + bh.IsDefault + "',");
            bQuery.Append("'" + bh.DeliveryLocationId + "',");
            bQuery.Append("'" + bh.checkoutStatus + "',");
            bQuery.Append("'" + bh.OrderID + "',");
            bQuery.Append("'" + bh.RewardXML + "',");
            bQuery.Append("'" + bh.PaymentItemXML + "',");
            bQuery.Append("'" + bh.ChargeXML + "'");
            bQuery.Append(")");
            bh = null;
            return bQuery.ToString();
        }

        internal string InsertBasketItem(Basket basket, BasketItemEntity bItems)
        {

            
           
            #region Basket Metadata
            bIQuery.Clear();
            //Basket Insertion
            bIQuery.Append("insert into Grocerybasketitem(BasketID,ProductID,BaseProductID,ProductInStorePrice,ProductInStoreQuantity");
            bIQuery.Append(",ProductInStoreTotalPrice,ChoiceQuantity,ChoiceWeight,AddedDateTime,ProductAverageWeight");
            bIQuery.Append(",ProductMaxWeight,IsNotRanged,IsSelectedByQuantity,MeasureTypeID,ProductTypeID,UnitSaleTypeID");
            bIQuery.Append(",IsRestrictedDelivery,CreatedDateTime,UpdatedDateTime,ChoiceQuantityOriginal,ChoiceWeightOriginal,ProductDescription,ProductWeight,ProductVolume,IsNewlyAdded,ChargeProductTypeId");
            bIQuery.Append(") values(");
            bIQuery.Append("'" + basket.BasketHeader.BasketID + "',");
            bIQuery.Append("'" + bItems.ProductID + "',");
            bIQuery.Append("'" + bItems.BaseProductID + "',");
            bIQuery.Append("'" + bItems.ProductInStorePrice + "',");
            bIQuery.Append("'" + bItems.ProductInStoreQuantity + "',");
            bIQuery.Append("'" + bItems.ProductInStoreTotalPrice + "',");
            bIQuery.Append("'" + bItems.ChoiceQuantity + "',");
            bIQuery.Append("'" + bItems.ChoiceWeight + "',");
            //bIQuery = bIQuery + bItems.AddedDateTime+"',";
            bIQuery.Append("'" + timestamp + "',");
            bIQuery.Append("'" + bItems.ProductAverageWeight + "',");
            bIQuery.Append("'" + bItems.ProductMaxWeight + "',");
            bIQuery.Append("'" + bItems.IsNotRanged + "',");
            bIQuery.Append("'" + bItems.IsSelectedByQuantity + "',");
            bIQuery.Append("'" + bItems.MeasureTypeID + "',");
            bIQuery.Append("'" + bItems.ProductTypeID + "',");
            bIQuery.Append("'" + bItems.UnitSaleTypeID + "',");
            bIQuery.Append("'" + bItems.IsRestrictedDelivery + "',");
            //bIQuery = bIQuery + bItems.CreatedDateTime+"',";
            bIQuery.Append("'" + timestamp + "',");
            //bIQuery = bIQuery + bItems.UpdatedDateTime+"',";
            bIQuery.Append("'" + timestamp + "',");
            bIQuery.Append("'" + bItems.ChoiceQuantityOriginal + "',");
            bIQuery.Append("'" + bItems.ChoiceWeightOriginal + "',");
            bIQuery.Append("'" + bItems.ProductDescription + "',");
            bIQuery.Append("'" + bItems.ProductWeight + "',");
            bIQuery.Append("'" + bItems.ProductVolume + "',");
            bIQuery.Append("'" + bItems.IsNewlyAdded + "',");
            bIQuery.Append("'" + bItems.ChargeProductTypeId + "'");
            bIQuery.Append(")");
#endregion
            return bIQuery.ToString();

        }


        public  string RetrieveBasketHeader(int basketID)
        {
            string query = "select * from BasketHeader where BasketID =" + "'" + basketID.ToString() + "';";
            return query;
        }


        public  string RetrieveBasketItem(int basketID)
        {
            string query = "select * from GroceryBasketItem where BasketID =" + "'" + basketID.ToString() + "';";
            return query;
        }
    }
}
