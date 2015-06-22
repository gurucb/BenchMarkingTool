using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BenchMark.Entities;

namespace BenchMark.BasketCreator
{
    class BasketCreateSQL:BasketCreateBase
    {
         private Basket _basket;
        private BasketHeaderEntity _bHeader;
        private BasketItemEntity _bItem;

        BasketCreateSQL()
        {
                
                
        }
        public override Basket CreateBasket(int itemCount,List<PerfEntity> pe)
        {
            _basket = null;
            _bHeader = CreateBasketHeader(SrcString);
            _bItem = CreateBasketItem(SrcString);
            _basket = new Basket(_bHeader, _bItem, itemCount,pe);
            return _basket;
        }


        private BasketHeaderEntity CreateBasketHeader(string conString)
        {
            _bHeader = new BasketHeaderEntity();


            return _bHeader;
            //todo: Connect to Database and Get Records
        }

        private BasketItemEntity CreateBasketItem(string conString)
        {
            _bItem = new BasketItemEntity();


            return _bItem;
            //todo: Connect to Database and Get Records
        }
      
    }
}
