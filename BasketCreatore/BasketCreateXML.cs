using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BenchMark.Entities;
using System.Xml;

namespace BenchMark.BasketCreator
{
    public class BasketCreateXML:BasketCreateBase
    {
        private Basket _basket;
        private BasketHeaderEntity _bHeader;
        private BasketItemEntity _bItem;
        private XmlDocument _xmlDoc;
        private XmlNodeList _xmlNodeList;

        public BasketCreateXML()
        {
              //todo:  
                
        }
        public override Basket CreateBasket(int itemCount, List<PerfEntity> pe)
        {
            _basket = null;
            pe.Add(PerfEntity.CreateEntity("BasketCreateXML.CreateBasket", "S", DateTime.Now + "." + DateTime.Now.Millisecond));
            _bHeader = CreateBasketHeader(SrcString,pe);
            _bItem = CreateBasketItem(SrcString,pe);
            _basket = new Basket(_bHeader, _bItem, itemCount,pe);
            pe.Add(PerfEntity.CreateEntity("BasketCreateXML.CreateBasket", "E", DateTime.Now + "." + DateTime.Now.Millisecond));
            return _basket;
        }


        private BasketHeaderEntity CreateBasketHeader(string xmlPath, List<PerfEntity> pe)
        {
            pe.Add(PerfEntity.CreateEntity("BasketCreateXML.CreateBasketHeader", "S", DateTime.Now + "." + DateTime.Now.Millisecond));
            _bHeader = new BasketHeaderEntity();
            _xmlDoc = new XmlDocument();
            _xmlDoc.Load(xmlPath);
            _bHeader.BasketID = int.Parse(_xmlDoc.DocumentElement.SelectSingleNode("/root/Basket/BasketID").InnerText.ToString());
            _bHeader.CustomerID = long.Parse(_xmlDoc.DocumentElement.SelectSingleNode("/root/Basket/CustomerID").InnerText.ToString());
            _bHeader.BranchID = int.Parse(_xmlDoc.DocumentElement.SelectSingleNode("/root/Basket/BranchID").InnerText.ToString());
            _bHeader.Name = _xmlDoc.DocumentElement.SelectSingleNode("/root/Basket/Name").InnerText.ToString();
            _bHeader.IsActive = int.Parse(_xmlDoc.DocumentElement.SelectSingleNode("/root/Basket/IsActive").InnerText);
            _bHeader.IsBeingAmended = int.Parse(_xmlDoc.DocumentElement.SelectSingleNode("/root/Basket/IsBeingAmended").InnerText.ToString());
            _bHeader.LastProductIDAdded = int.Parse(_xmlDoc.DocumentElement.SelectSingleNode("/root/Basket/LastProductIDAdded").InnerText.ToString());
            _bHeader.LastUpdatedDateTime = DateTime.Parse(_xmlDoc.DocumentElement.SelectSingleNode("/root/Basket/LastUpdatedDateTime").InnerText.ToString());
            _bHeader.RequiresRecalculation = int.Parse(_xmlDoc.DocumentElement.SelectSingleNode("/root/Basket/RequiresRecalculation").InnerText.ToString());
            _bHeader.GuidePrice = float.Parse(_xmlDoc.DocumentElement.SelectSingleNode("/root/Basket/GuidePrice").InnerText.ToString());
            _bHeader.AmendModeContractID = int.Parse(_xmlDoc.DocumentElement.SelectSingleNode("/root/Basket/AmendModeContractID").InnerText.ToString());
            _bHeader.AmendCutOffTime = DateTime.Parse(_xmlDoc.DocumentElement.SelectSingleNode("/root/Basket/AmendCutOffTime").InnerText.ToString());
            _bHeader.ApplyStaffDiscount = int.Parse(_xmlDoc.DocumentElement.SelectSingleNode("/root/Basket/ApplyStaffDiscount").InnerText.ToString());
            _bHeader.PaymentCardID = int.Parse(_xmlDoc.DocumentElement.SelectSingleNode("/root/Basket/PaymentCardID").InnerText.ToString());
            _bHeader.ECouponClubcardPoints = int.Parse(_xmlDoc.DocumentElement.SelectSingleNode("/root/Basket/ECouponClubcardPoints").InnerText.ToString());
            _bHeader.CreatedDateTime = DateTime.Parse(_xmlDoc.DocumentElement.SelectSingleNode("/root/Basket/CreatedDateTime").InnerText.ToString());
            _bHeader.IsDefault = int.Parse(_xmlDoc.DocumentElement.SelectSingleNode("/root/Basket/IsDefault").InnerText.ToString());
            _bHeader.RewardXML = _xmlDoc.DocumentElement.SelectSingleNode("/root/Basket/RewardXML").InnerXml.ToString();
            _bHeader.PaymentItemXML = _xmlDoc.DocumentElement.SelectSingleNode("/root/Basket/PaymentItemXML").InnerXml.ToString();
            _bHeader.ChargeXML = _xmlDoc.DocumentElement.SelectSingleNode("/root/Basket/ChargeXML").InnerXml.ToString();
            _bHeader.DeliveryLocationId = int.Parse(_xmlDoc.DocumentElement.SelectSingleNode("/root/Basket/DeliveryLocationId").InnerText.ToString());
            _bHeader.checkoutStatus = int.Parse(_xmlDoc.DocumentElement.SelectSingleNode("/root/Basket/checkoutStatus").InnerText.ToString());
            _bHeader.OrderID = int.Parse(_xmlDoc.DocumentElement.SelectSingleNode("/root/Basket/OrderID").InnerText.ToString());
            _bHeader.IsDefault = int.Parse(_xmlDoc.DocumentElement.SelectSingleNode("/root/Basket/IsDefault").InnerText.ToString());
            _xmlDoc = null;
            pe.Add(PerfEntity.CreateEntity("BasketCreateXML.CreateBasketHeader", "S", DateTime.Now + "." + DateTime.Now.Millisecond));
            return _bHeader;
            //todo: Read XML and get Basket Header
        }

        private BasketItemEntity CreateBasketItem(string xmlPath, List<PerfEntity> pe)
        {
            pe.Add(PerfEntity.CreateEntity("BasketCreateXML.CreateBasketItem", "S", DateTime.Now + "." + DateTime.Now.Millisecond));
            _bItem = new BasketItemEntity();
            _xmlDoc = new XmlDocument();
            _xmlDoc.Load(xmlPath);
            _bItem.BasketID = int.Parse(_xmlDoc.DocumentElement.SelectSingleNode("/root/BasketItem/BasketID").InnerText.ToString());
            _bItem.ProductID = long.Parse(_xmlDoc.DocumentElement.SelectSingleNode("/root/BasketItem/ProductID").InnerText.ToString());
            _bItem.BaseProductID = int.Parse(_xmlDoc.DocumentElement.SelectSingleNode("/root/BasketItem/BaseProductID").InnerText.ToString());
            _bItem.ProductInStorePrice = decimal.Parse(_xmlDoc.DocumentElement.SelectSingleNode("/root/BasketItem/ProductInStorePrice").InnerText.ToString());
            _bItem.ProductInStoreQuantity = decimal.Parse(_xmlDoc.DocumentElement.SelectSingleNode("/root/BasketItem/ProductInStoreQuantity").InnerText.ToString());
            _bItem.ProductInStoreTotalPrice = decimal.Parse(_xmlDoc.DocumentElement.SelectSingleNode("/root/BasketItem/ProductInStoreTotalPrice").InnerText.ToString());
            _bItem.ChoiceQuantity = decimal.Parse(_xmlDoc.DocumentElement.SelectSingleNode("/root/BasketItem/ChoiceQuantity").InnerText.ToString());
            _bItem.ChoiceWeight = decimal.Parse(_xmlDoc.DocumentElement.SelectSingleNode("/root/BasketItem/ChoiceWeight").InnerText.ToString());
            _bItem.AddedDateTime = DateTime.Parse(_xmlDoc.DocumentElement.SelectSingleNode("/root/BasketItem/AddedDateTime").InnerText.ToString());
            _bItem.ProductAverageWeight = decimal.Parse(_xmlDoc.DocumentElement.SelectSingleNode("/root/BasketItem/ProductAverageWeight").InnerText.ToString());
            _bItem.ProductMaxWeight = decimal.Parse(_xmlDoc.DocumentElement.SelectSingleNode("/root/BasketItem/ProductMaxWeight").InnerText.ToString());
            _bItem.IsNotRanged =int.Parse(_xmlDoc.DocumentElement.SelectSingleNode("/root/BasketItem/IsNotRanged").InnerText.ToString());
            _bItem.IsSelectedByQuantity = int.Parse(_xmlDoc.DocumentElement.SelectSingleNode("/root/BasketItem/IsSelectedByQuantity").InnerText.ToString());
            _bItem.MeasureTypeID = int.Parse(_xmlDoc.DocumentElement.SelectSingleNode("/root/BasketItem/MeasureTypeID").InnerText.ToString());
            _bItem.ProductTypeID = int.Parse(_xmlDoc.DocumentElement.SelectSingleNode("/root/BasketItem/ProductTypeID").InnerText.ToString());
            _bItem.UnitSaleTypeID = int.Parse(_xmlDoc.DocumentElement.SelectSingleNode("/root/BasketItem/UnitSaleTypeID").InnerText.ToString());
            _bItem.IsRestrictedDelivery = int.Parse(_xmlDoc.DocumentElement.SelectSingleNode("/root/BasketItem/IsRestrictedDelivery").InnerText.ToString());
            _bItem.CreatedDateTime = DateTime.Parse(_xmlDoc.DocumentElement.SelectSingleNode("/root/BasketItem/CreatedDateTime").InnerText.ToString());
            _bItem.UpdatedDateTime = DateTime.Parse(_xmlDoc.DocumentElement.SelectSingleNode("/root/BasketItem/UpdatedDateTime").InnerText.ToString());
            _bItem.ChoiceQuantityOriginal = int.Parse(_xmlDoc.DocumentElement.SelectSingleNode("/root/BasketItem/ChoiceQuantityOriginal").InnerText.ToString());
            _bItem.ChoiceWeightOriginal = decimal.Parse(_xmlDoc.DocumentElement.SelectSingleNode("/root/BasketItem/ChoiceWeightOriginal").InnerText.ToString());
            _bItem.ProductDescription = _xmlDoc.DocumentElement.SelectSingleNode("/root/BasketItem/ProductDescription").InnerText.ToString();
            _bItem.ProductWeight = decimal.Parse(_xmlDoc.DocumentElement.SelectSingleNode("/root/BasketItem/ProductWeight").InnerText.ToString());
            _bItem.ProductVolume = decimal.Parse(_xmlDoc.DocumentElement.SelectSingleNode("/root/BasketItem/ProductVolume").InnerText.ToString());
            _bItem.IsNewlyAdded = int.Parse(_xmlDoc.DocumentElement.SelectSingleNode("/root/BasketItem/IsNewlyAdded").InnerText.ToString());
            _bItem.ChargeProductTypeId = int.Parse(_xmlDoc.DocumentElement.SelectSingleNode("/root/BasketItem/ChargeProductTypeId").InnerText.ToString());
            _xmlDoc = null;

            pe.Add(PerfEntity.CreateEntity("BasketCreateXML.CreateBasketItem", "E", DateTime.Now +  "." + DateTime.Now.Millisecond));
            return _bItem;
            //todo: Read XML and get Basket Item
        }
    }
}
