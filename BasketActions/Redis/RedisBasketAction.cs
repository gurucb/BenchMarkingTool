using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BenchMark.Entities;

namespace BenchMark.BasketActions
{
    class RedisBasketAction : BasketActionBase
    {
        public override void Insert(Dictionary<string, string> connParameters, Basket basket, int startBasketID, int endBasketID, List<PerfEntity> pe)
        {
            RedisService redisService = new RedisService();
            pe.Add(PerfEntity.CreateEntity("AppFabricBasketAction.InsertBasket", "S", DateTime.Now + "." + DateTime.Now.Millisecond));
            for (; startBasketID <= endBasketID; startBasketID++)
            {
                basket.BasketHeader.BasketID = startBasketID;
                pe.Add(PerfEntity.CreateEntity("SQLBasketAction.InsertBasket: " + startBasketID.ToString(), "S", DateTime.Now + "." + DateTime.Now.Millisecond));

                redisService.Insert(basket, pe);

                pe.Add(PerfEntity.CreateEntity("SQLBasketAction.InsertBasket: " + startBasketID.ToString(), "E", DateTime.Now + "." + DateTime.Now.Millisecond));

            }
            pe.Add(PerfEntity.CreateEntity("AppFabricBasketAction.InsertBasket", "E", DateTime.Now + "." + DateTime.Now.Millisecond));

        }


        public override void Retrieve(Dictionary<string, string> connParameters, int startBasketID, int endBasketID, List<PerfEntity> pe)
        {

        }
    }
}

