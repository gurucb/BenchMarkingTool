using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BenchMark.Entities;
namespace BenchMark.BasketActions
{
    class FactoryBasketAction
    {
        public static BasketActionBase GetTargetType(TargetType targetType)
        {
            BasketActionBase actionObj = null;
            if (targetType == TargetType.SQLGeneric)
            {
                actionObj = new SQLBasketAction();
                
            }
            if (targetType == TargetType.AppFabric)
            {
                 actionObj = new AppFabricBasketAction();
                
            }
            if (targetType == TargetType.Cassandra)
            {
                actionObj = new CassendraBasketActions();
            }

            if (targetType == TargetType.Redis)
            {
                actionObj = new RedisBasketAction(); ;
            }
            return actionObj;
        }
    }
}
