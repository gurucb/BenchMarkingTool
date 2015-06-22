using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BenchMark.BasketCreator;
using BenchMark.BasketActions;
using BenchMark.Entities;
using System.IO;
using System.Web;


namespace BenchMark.Controller
{
    public class BenchMarkController
    {
        private BasketAction bAction;
        private Dictionary<string, string> trgtConfiguration;

        public BenchMarkController()
        {
            bAction = new BasketAction();
            trgtConfiguration = new Dictionary<string, string>();
        }


        public Basket CreateBasketWithItems(SourceType sourcetype, int itemCount, List<PerfEntity> pe)
        {
            Basket basket = null;
            //todo: Though factory class is planned, yet to be implemented.
            if (sourcetype == SourceType.XML)
            {
                basket = CreateBasketWithItems_XML(itemCount, pe);
            }
            return basket;
        }
        //todo: Controller should not be aware of BasketCreateXML or BasketCreateSQL. Class should be instantiated through factory.
        //Parameter for source string should be taken from front end application.
        private Basket CreateBasketWithItems_XML(int itemCount, List<PerfEntity> pe)
        {
            BasketCreateBase bcXML = new BasketCreateXML();
            bcXML.SourceType = " XML";
            bcXML.SrcString = "D://Tool Codebase//BenchMarkingTool//BasketXML.xml" ;
            Basket basket = bcXML.CreateBasket(100,pe);
            return basket;
        }

        //todo:
        /*
         * 1. Create a separate project for forming connection strings.
         * 2. Configuration varies for each target types (SQL / Cassandra etc)
         * 3. Configuration could be passed from front end or from DB or Config Files.
         * 4. All scenarios should be handled.
         * 5. Create configuration dictionary for Target Type
         * */
        private void PopulateConnProperties(TargetType targetType)
        {
            if (targetType == TargetType.SQLGeneric)
            {
                trgtConfiguration.Add("Server", "UKDBT45SQLDB01V\\DBTCC");
                trgtConfiguration.Add("Database", "BenchMark");
                trgtConfiguration.Add("Trusted_Connection", "True");
            }
            if (targetType == TargetType.Cassandra)
            {
                trgtConfiguration.Add("Server", "127.0.0.1");
                trgtConfiguration.Add("KeySpace", "benchmarktest");
            }
        }

        public void PutBasket(TargetType targetType,Basket basket, int startBasket, int endBasket, List<PerfEntity> pe)
        {
            PopulateConnProperties(targetType);
            pe.Add(PerfEntity.CreateEntity("BenchMarkController.GenericSQL_Insert", "E", DateTime.Now + "." + DateTime.Now.Millisecond));
            bAction.InsertBasket(targetType, trgtConfiguration, basket, startBasket, endBasket, pe);
            pe.Add(PerfEntity.CreateEntity("BenchMarkController.PutBasket", "E", DateTime.Now + "." + DateTime.Now.Millisecond));
        }

        public void GetBaskets(TargetType targetType, int startBasketID,int endBasketID, List<PerfEntity> pe)
        {
            PopulateConnProperties(targetType);
            pe.Add(PerfEntity.CreateEntity("BenchMarkController.GenericSQL_Insert", "E", DateTime.Now + "." + DateTime.Now.Millisecond));
            bAction.GetBaskets(targetType,trgtConfiguration, startBasketID,endBasketID, pe);
            pe.Add(PerfEntity.CreateEntity("BenchMarkController.PutBasket", "E", DateTime.Now + "." + DateTime.Now.Millisecond));
        }

        
    }
}
