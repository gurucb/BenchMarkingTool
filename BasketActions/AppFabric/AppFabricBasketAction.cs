using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BenchMark.Entities;


namespace BenchMark.BasketActions
{
    class AppFabricBasketAction:BasketActionBase
    {

        public override void Insert(Dictionary<string, string> connParameters, Basket basket, int startBasketID, int endBasketID, List<PerfEntity> pe)
        {
            AppFabricService appFabricService = new AppFabricService();
            pe.Add(PerfEntity.CreateEntity("AppFabricBasketAction.InsertBasket", "S", DateTime.Now + "." + DateTime.Now.Millisecond));
            for (; startBasketID <= endBasketID; startBasketID++)
            {
                basket.BasketHeader.BasketID = startBasketID;
                pe.Add(PerfEntity.CreateEntity("SQLBasketAction.InsertBasket: " + startBasketID.ToString(), "S", DateTime.Now + "." + DateTime.Now.Millisecond));

                appFabricService.AddToAppFabricCache(basket, pe);

                pe.Add(PerfEntity.CreateEntity("SQLBasketAction.InsertBasket: " + startBasketID.ToString(), "E", DateTime.Now + "." + DateTime.Now.Millisecond));
                
               
            }
            pe.Add(PerfEntity.CreateEntity("AppFabricBasketAction.InsertBasket", "E", DateTime.Now + "." + DateTime.Now.Millisecond));
                    
        }

        public override void Retrieve(Dictionary<string, string> connParameters,int startBasketID, int endBasketID, List<PerfEntity> pe)
        {
            AppFabricService appFabricService = new AppFabricService();
            pe.Add(PerfEntity.CreateEntity("AppFabricBasketAction.ReadBaskets", "S", DateTime.Now + "." + DateTime.Now.Millisecond));
            List<Basket> basket = new List<Basket>();
            for (; startBasketID <= endBasketID; startBasketID++)
            {

                Basket basketTemp = appFabricService.ReadFromAppFabricCache(startBasketID, pe);
                basket.Add(basketTemp);
                //ToDo: After basket is needed, should be process basket.
                basketTemp = null;
                startBasketID++;
            }
            pe.Add(PerfEntity.CreateEntity("AppFabricBasketAction.ReadBaskets", "E", DateTime.Now + "." + DateTime.Now.Millisecond));
        }
    }
}
