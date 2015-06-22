using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BenchMark.Entities;
namespace BenchMark.BasketActions
{
    internal class CassandraBasketActionsInternal
    {
        internal static void Insert(Dictionary<string, string> connParameters,Basket basket, int startBasket, int endBasket, List<PerfEntity> pe)
        {
            string qry = "";
            int pID = 1;
            GenerateCassandraQueries generateCassandraQueries = new GenerateCassandraQueries();
            for (; startBasket <= endBasket; startBasket++)
            {
                basket.BasketHeader.BasketID = startBasket;
                qry = generateCassandraQueries.InsertBasketHeader(basket);
                pe.Add(PerfEntity.CreateEntity("CassandraBasketActionInternal.BasketHeader", "S", DateTime.Now + "." + DateTime.Now.Millisecond));
                //Put this here so that every session can have a different server to connect
                CassandraHelper.Create(connParameters, qry);
                pe.Add(PerfEntity.CreateEntity("CassandraBasketActionInternal.BasketHeader", "E", DateTime.Now + "." + DateTime.Now.Millisecond));
                foreach (BasketItemEntity bi in basket.LBasketItems)
                {
                    bi.ProductID = pID++;
                    qry = generateCassandraQueries.InsertBasketItem(basket, bi);
                    pe.Add(PerfEntity.CreateEntity("CassandraBasketActionInternal.BasketItems", "S", DateTime.Now + "." + DateTime.Now.Millisecond));
                    CassandraHelper.Create(connParameters, qry);
                    pe.Add(PerfEntity.CreateEntity("CassandraBasketActionInternal.BasketItems", "E", DateTime.Now + "." + DateTime.Now.Millisecond));
                }
            }
        }


        internal static void Retrieve(Dictionary<string, string> connParameters, int startBasketID, int endBasketID, List<PerfEntity> pe)
        {
            GenerateCassandraQueries generateCassandraQueries = new GenerateCassandraQueries();
            string qry = "";
            for (; startBasketID <= endBasketID; startBasketID++)
            {
                qry = generateCassandraQueries.RetrieveBasketHeader(startBasketID);
                pe.Add(PerfEntity.CreateEntity("CassandraBasketActionInternal.BasketHeaderRead", "S", DateTime.Now + "." + DateTime.Now.Millisecond));
                //Put this here so that every session can have a different server to connect
                CassandraHelper.Read(connParameters, qry);
                pe.Add(PerfEntity.CreateEntity("CassandraBasketActionInternal.BasketHeader", "E", DateTime.Now + "." + DateTime.Now.Millisecond));
                
                qry = generateCassandraQueries.RetrieveBasketItem(startBasketID);
                pe.Add(PerfEntity.CreateEntity("CassandraBasketActionInternal.BasketItems", "S", DateTime.Now + "." + DateTime.Now.Millisecond));
                CassandraHelper.Create(connParameters, qry);
                pe.Add(PerfEntity.CreateEntity("CassandraBasketActionInternal.BasketItems", "E", DateTime.Now + "." + DateTime.Now.Millisecond));
            }
        }
    }
}

        

        
