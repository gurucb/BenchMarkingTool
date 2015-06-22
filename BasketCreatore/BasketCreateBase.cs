using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BenchMark.Entities;

namespace BenchMark.BasketCreator
{
    public abstract class BasketCreateBase
    {
        public string SourceType { get; set; }
        public string SrcString { get; set; }
        public abstract Basket CreateBasket(int itemCount, List<PerfEntity> pe);
                
    }
}