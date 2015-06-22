using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BenchMark.Entities
{
    [Serializable]
    public class Basket
    {
        public BasketHeaderEntity BasketHeader;
        public List<BasketItemEntity> LBasketItems;
        BasketItemEntity bItemTemp;
       
        public Basket(BasketHeaderEntity bHeader, BasketItemEntity bItem, int itemCount, List<PerfEntity> pe)
        {
            this.BasketHeader = bHeader;
            pe.Add(PerfEntity.CreateEntity("Basket", "S", DateTime.Now+"."+DateTime.Now.Millisecond));
            LBasketItems = new List<BasketItemEntity>();
            

            for (int cntr = 1; cntr <= itemCount; cntr++)
            {
                bItemTemp = new BasketItemEntity();
                bItemTemp = bItem;
                bItemTemp.ProductID = cntr;
                this.LBasketItems.Add(bItemTemp);
                bItemTemp = null;
            }
            pe.Add(PerfEntity.CreateEntity("Basket", "E", DateTime.Now + "." + DateTime.Now.Millisecond));
        }
    }
}
