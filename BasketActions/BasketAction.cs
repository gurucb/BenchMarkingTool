using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BenchMark.Entities;


namespace BenchMark.BasketActions
{
    public class BasketAction
    {
        public void InsertBasket(TargetType targetType, Dictionary<string, string> connParameters, Basket basket, int startBasketID, int endBasketID,List<PerfEntity> pe)
        {
            pe.Add(PerfEntity.CreateEntity("BasketAction.InsertBasket", "S", DateTime.Now + "." + DateTime.Now.Millisecond));
            BasketActionBase bActionBase = FactoryBasketAction.GetTargetType(targetType);
            bActionBase.Insert(connParameters, basket, startBasketID, endBasketID,pe);
            pe.Add(PerfEntity.CreateEntity("BasketAction.InsertBasket", "E", DateTime.Now + "." + DateTime.Now.Millisecond));
        }

        public void GetBaskets(TargetType targetType, Dictionary<string, string> connParameters, int startBasketID, int endBasketID, List<PerfEntity> pe)
        {
            pe.Add(PerfEntity.CreateEntity("BasketAction.GetBaskets", "S", DateTime.Now + "." + DateTime.Now.Millisecond));  
            BasketActionBase bActionBase = FactoryBasketAction.GetTargetType(targetType);
            bActionBase.Retrieve(connParameters,startBasketID,endBasketID, pe);
            pe.Add(PerfEntity.CreateEntity("BasketAction.GetBaskets", "S", DateTime.Now + "." + DateTime.Now.Millisecond));  
            
        }
    }
}
