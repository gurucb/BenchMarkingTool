using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BenchMark.Entities;
using BenchMark.BasketActions;

namespace BenchMark.BasketActions
{
    public class SQLBasketAction:BasketActionBase
    {
        public override void CapturePerfStats()
        {
        }
        public override void CreateBasket(Dictionary<string, string> connParameters, Basket basket, int noOfBaskets)
        {
        }
    
    }
}
