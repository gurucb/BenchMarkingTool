using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BenchMark.Entities;

namespace BenchMark.BasketActions
{
    abstract class BasketActionBase
    {
        //Insert Basket
        public abstract void Insert(Dictionary<string, string> connParameters, Basket basket, int startBasketID, int endBasketID,List<PerfEntity> pe);
        //void RemoveBasket(Dictionary<string, string> connParameters, int sBasketID, int eBasketID);
        
        //Read Basket
        public abstract void Retrieve(Dictionary<string, string> connParameters,int startBasketID,int endBaskedID, List<PerfEntity> pe);
    }
}
