using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BenchMark.Entities;

namespace BenchMark.BasketActions
{
    class CassendraBasketActions : BasketActionBase
    {
        public override void Insert(Dictionary<string, string> connParameters, Basket basket, int startBasketID, int endBasketID, List<PerfEntity> pe)
        {
            pe.Add(PerfEntity.CreateEntity("CassandraBasketActions.InsertBasket", "S", DateTime.Now + "." + DateTime.Now.Millisecond));
            CassandraBasketActionsInternal.Insert(connParameters, basket, startBasketID, endBasketID, pe);
            pe.Add(PerfEntity.CreateEntity("CassandraBasketActions.InsertBasket", "E", DateTime.Now + "." + DateTime.Now.Millisecond));
        }

        public override void Retrieve(Dictionary<string, string> connParameters, int startBasketID, int endBaskedID, List<PerfEntity> pe)
        {
            List<Basket> basket = null;
            pe.Add(PerfEntity.CreateEntity("CassandraBasketActions.InsertBasket", "S", DateTime.Now + "." + DateTime.Now.Millisecond));
                //Todo: Insert code to get Basket;
            CassandraBasketActionsInternal.Retrieve(connParameters, startBasketID, endBaskedID, pe);
            pe.Add(PerfEntity.CreateEntity("CassandraBasketActions.InsertBasket", "S", DateTime.Now + "." + DateTime.Now.Millisecond));
            
        }
    }

}
