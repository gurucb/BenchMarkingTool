using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BenchMark.BasketActions;
using BenchMark.Entities;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;


namespace BenchMark.BasketActions
{
    class SQLBasketAction:BasketActionBase   
    {
        private string SP_INSERT_BASKET = "[BasketCreate]";
        private string SP_INSERT_BASKETITEMS = "[GroceryBasketItemSave]";

        private string SP_UPDATE_BASKET = "";
        private string SP_UPDATE_BASKETITEMS = "";


        private string SP_DELETE_BASKET = "";
        private string SP_DELETE_BASKETITEMS = "";
       
        public override void Insert(Dictionary<string, string> connParameters, Basket basket, int startBasketID, int endBasketID, List<PerfEntity> pe)
        {
            pe.Add(PerfEntity.CreateEntity("SQLBasketAction.InsertBasket", "S", DateTime.Now + "." + DateTime.Now.Millisecond));
            BasketHeaderEntity bh = basket.BasketHeader;
            int pID = 0;
            string conString = GenerateConString.GenerateConnectionString(connParameters);

            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = conString;
                con.Open();
                using (SqlCommand com = new SqlCommand())
                {
                    com.Connection = con;
                    com.CommandType = System.Data.CommandType.StoredProcedure;
                    
                    #region insert BasketHeader
                    for (; startBasketID <= endBasketID; startBasketID++)
                    {
                        pe.Add(PerfEntity.CreateEntity("SQLBasketAction.InsertBasket: " + startBasketID.ToString(), "S", DateTime.Now + "." + DateTime.Now.Millisecond));
                        com.CommandText = SP_INSERT_BASKET;
                        com.Parameters.Add("@BasketID", System.Data.SqlDbType.Int).Value = startBasketID;
                        com.Parameters.Add("@CustomerID", System.Data.SqlDbType.BigInt).Value = bh.CustomerID;
                        com.Parameters.Add("@BranchID", System.Data.SqlDbType.Int).Value = bh.BranchID;
                        com.Parameters.Add("@Name", System.Data.SqlDbType.VarChar).Value = bh.Name;
                        com.Parameters.Add("@IsActive", System.Data.SqlDbType.Bit).Value = bh.IsActive;
                        com.Parameters.Add("@IsBeingAmended", System.Data.SqlDbType.Bit).Value = bh.IsBeingAmended;
                        com.Parameters.Add("@LastProductIDAdded", System.Data.SqlDbType.BigInt).Value = bh.LastProductIDAdded;
                        com.Parameters.Add("@LastUpdatedDateTime", System.Data.SqlDbType.DateTime).Value = bh.LastUpdatedDateTime;
                        com.Parameters.Add("@RequiresRecalculation", System.Data.SqlDbType.Bit).Value = bh.RequiresRecalculation;
                        com.Parameters.Add("@GuidePrice", System.Data.SqlDbType.Money).Value = bh.GuidePrice;
                        com.Parameters.Add("@AmendModeContractID", System.Data.SqlDbType.Int).Value = bh.AmendModeContractID;
                        com.Parameters.Add("@AmendCutOffTime", System.Data.SqlDbType.DateTime).Value = bh.AmendCutOffTime;
                        com.Parameters.Add("@ApplyStaffDiscount", System.Data.SqlDbType.Bit).Value = bh.ApplyStaffDiscount;
                        com.Parameters.Add("@PaymentCardID", System.Data.SqlDbType.Int).Value = bh.PaymentCardID;
                        com.Parameters.Add("@ECouponClubcardPoints", System.Data.SqlDbType.Int).Value = bh.ECouponClubcardPoints;
                        com.Parameters.Add("@CreatedDateTime", System.Data.SqlDbType.DateTime).Value = bh.CreatedDateTime;
                        com.Parameters.Add("@ContractVersionID", System.Data.SqlDbType.TinyInt).Value = bh.ContractVersionID;
                        com.Parameters.Add("@IsDefault", System.Data.SqlDbType.Bit).Value = bh.IsDefault;
                        com.Parameters.Add("@RewardXML", System.Data.SqlDbType.Xml).Value = bh.RewardXML;
                        com.Parameters.Add("@PaymentItemXML", System.Data.SqlDbType.Xml).Value = bh.PaymentItemXML;
                        com.Parameters.Add("@ChargeXML", System.Data.SqlDbType.Xml).Value = bh.ChargeXML;
                        com.Parameters.Add("@DeliveryLocationId", System.Data.SqlDbType.Int).Value = bh.DeliveryLocationId;
                        com.Parameters.Add("@checkoutStatus", System.Data.SqlDbType.Bit).Value = bh.checkoutStatus;
                        com.Parameters.Add("@OrderID", System.Data.SqlDbType.Int).Value = bh.OrderID;
                        com.ExecuteNonQuery();
                        pe.Add(PerfEntity.CreateEntity("SQLBasketAction.InsertBasket: " + startBasketID.ToString(), "E", DateTime.Now + "." + DateTime.Now.Millisecond));
                        com.Parameters.Clear();
                    #endregion
                        #region Insert BasketItems
                        pID = 1;
                        foreach (BasketItemEntity b in basket.LBasketItems)
                        {
                            pe.Add(PerfEntity.CreateEntity("SQLBasketAction.InsertBasket:" + startBasketID.ToString() + ":" + pID.ToString(), "S", DateTime.Now + "." + DateTime.Now.Millisecond));
                            com.CommandText = SP_INSERT_BASKETITEMS;
                            com.Parameters.Add("@BasketID", System.Data.SqlDbType.Int).Value = startBasketID;
                            com.Parameters.Add("@ProductID", System.Data.SqlDbType.BigInt).Value = pID;
                            com.Parameters.Add("@BaseProductID", System.Data.SqlDbType.BigInt).Value = b.BaseProductID;
                            com.Parameters.Add("@ProductInStorePrice", System.Data.SqlDbType.Money).Value = b.ProductInStorePrice;
                            com.Parameters.Add("@ProductInStoreQuantity", System.Data.SqlDbType.Decimal).Value = b.ProductInStoreQuantity;
                            com.Parameters.Add("@ProductInStoreTotalPrice", System.Data.SqlDbType.Money).Value = b.ProductInStoreTotalPrice;
                            com.Parameters.Add("@ChoiceQuantity", System.Data.SqlDbType.Int).Value = b.ChoiceQuantity;
                            com.Parameters.Add("@ChoiceWeight", System.Data.SqlDbType.Decimal).Value = b.ChoiceWeight;
                            com.Parameters.Add("@AddedDateTime", System.Data.SqlDbType.DateTime).Value = b.AddedDateTime;
                            com.Parameters.Add("@ProductAverageWeight", System.Data.SqlDbType.Decimal).Value = b.ProductAverageWeight;
                            com.Parameters.Add("@ProductMaxWeight", System.Data.SqlDbType.Decimal).Value = b.ProductMaxWeight;
                            com.Parameters.Add("@IsNotRanged", System.Data.SqlDbType.Bit).Value = b.IsNotRanged;
                            com.Parameters.Add("@IsSelectedByQuantity", System.Data.SqlDbType.Bit).Value = b.IsSelectedByQuantity;
                            com.Parameters.Add("@MeasureTypeID", System.Data.SqlDbType.Int).Value = b.MeasureTypeID;
                            com.Parameters.Add("@ProductTypeID", System.Data.SqlDbType.Int).Value = b.ProductTypeID;
                            com.Parameters.Add("@UnitSaleTypeID", System.Data.SqlDbType.Int).Value = b.UnitSaleTypeID;
                            com.Parameters.Add("@IsRestrictedDelivery", System.Data.SqlDbType.Bit).Value = b.IsRestrictedDelivery;
                            com.Parameters.Add("@CreatedDateTime", System.Data.SqlDbType.DateTime).Value = b.CreatedDateTime;
                            com.Parameters.Add("@UpdatedDateTime", System.Data.SqlDbType.DateTime).Value = b.UpdatedDateTime;
                            com.Parameters.Add("@ChoiceQuantityOriginal", System.Data.SqlDbType.Int).Value = b.ChoiceQuantityOriginal;
                            com.Parameters.Add("@ChoiceWeightOriginal", System.Data.SqlDbType.Decimal).Value = b.ChoiceWeightOriginal;
                            com.Parameters.Add("@ProductDescription", System.Data.SqlDbType.VarChar).Value = b.ProductDescription;
                            com.Parameters.Add("@ProductWeight", System.Data.SqlDbType.Decimal).Value = b.ProductWeight;
                            com.Parameters.Add("@ProductVolume", System.Data.SqlDbType.Decimal).Value = b.ProductVolume;
                            com.Parameters.Add("@IsNewlyAdded", System.Data.SqlDbType.Bit).Value = b.IsNewlyAdded;
                            com.Parameters.Add("@ChargeProductTypeId", System.Data.SqlDbType.Int).Value = b.ChargeProductTypeId;
                            com.ExecuteNonQuery();
                            pe.Add(PerfEntity.CreateEntity("SQLBasketAction.InsertBasket:" + startBasketID.ToString() + ":" + pID.ToString(), "E", DateTime.Now + "." + DateTime.Now.Millisecond));
                            com.Parameters.Clear();
                            pID++;
                        }
                        #endregion
                    }

                }
                con.Close();
            }
            pe.Add(PerfEntity.CreateEntity("SQLBasketAction.InsertBasket", "E", DateTime.Now + "." + DateTime.Now.Millisecond));



        }


        public override void Retrieve(Dictionary<string, string> connParameters,int startBasketID,int endBaskeID, List<PerfEntity> pe)
        {
            List<Basket> basket = null;

            for (; startBasketID <= endBaskeID; startBasketID++)
            {
                //Todo: Code to get eeach basket
            }

         
        }
    }
}
