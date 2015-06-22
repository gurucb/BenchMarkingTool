using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BenchMark.Controller;
using BenchMark.Entities;
using System.IO;
using System.Web;

namespace BenchMarkingTool
{
    class Program
    {
        int operationType = 1;
        int sourceType = 1;
        int targetType = 3;
        int noOfBasketItems = 100;
        int startBasket = 1;
        int endBasket = 100;
        
        TargetType type;
        SourceType srcType;
        BenchMarkController controller;
        List<PerfEntity> pe;
        void Message()
        {
            System.Console.WriteLine("Usage: ");
            System.Console.WriteLine("***********************************************************************************************************");
            System.Console.WriteLine("BenchMarkingTool.exe OperationType BasketSource BasketTarget ItemsPerBasket StartBasket EndBasket");
            System.Console.WriteLine("Operation Type: 1=Create Basket | 2 = Read Basket | 3 = Remove Basket");
            System.Console.WriteLine("BasketSource: 1=XML");
            System.Console.WriteLine("BasketTarget: 1=SQL | 2=AppFabric | 3=Cassandra | 4=Redis | 5=MOT");
            System.Console.WriteLine("***********************************************************************************************************");
            System.Console.WriteLine("Sample: ");
            System.Console.WriteLine("BechMarkingTool.exe 1 (Create Basket)  1 (From XML)  3 (To Cassandra) 100 (Basket Items / Basket) 1 (Start Basket) 100 (End Basket)");
            System.Console.WriteLine("BechMarkingTool.exe 2 (Read Basket) 3 (From Cassandra) 1 (Start Basket) 100 (End Basket)");
            System.Console.WriteLine("***********************************************************************************************************");
        }
        Program()
        {
            controller = new BenchMarkController();
            pe = new List<PerfEntity>();
        }
        static void Main(string[] args)
        {

            //Todo: Validate input paramters and ensure correect parameters are passed.
            Program program = new Program();
            program.Message();

            program.operationType = int.Parse(args[0]);


            switch (program.operationType)
            {
                case 1:
                    program.sourceType = int.Parse(args[1]);
                    program.targetType = int.Parse(args[2]);
                    program.noOfBasketItems = int.Parse(args[3]);
                    program.startBasket = int.Parse(args[4]);
                    program.endBasket = int.Parse(args[5]);
                break;
                case 2:
                    program.targetType = int.Parse(args[1]);
                    program.startBasket = int.Parse(args[2]);
                    program.endBasket = int.Parse(args[3]);
                    break;
            }

            program.srcType = SourceType.XML;

            switch (program.targetType)
            {
                case 1:
                    program.type = TargetType.SQLGeneric;
                    break;
                case 2:
                    program.type = TargetType.AppFabric;
                    break;
                case 3:
                    program.type = TargetType.Cassandra;
                    break;
                case 4:
                    program.type = TargetType.Redis;
                    break;
            }

            System.Console.WriteLine("Started Load..... ");
            System.Console.WriteLine("Start Time: "+DateTime.Now.ToString());

            switch (program.operationType)
            {
                case 1:
                    {
                        program.CreateBaskets();
                        program.WriteStatistics();
                        break;
                    }
                case 2:
                    {
                        program.GetBaskets();
                        program.WriteStatistics();
                        break;
                    }
            }

            System.Console.WriteLine("End Time: " + DateTime.Now.ToString());
            System.Console.WriteLine("Completed Load ");

            
        }

        void CreateBaskets()
        {
            
            pe.Add(PerfEntity.CreateEntity("Main.CreateBaskets", "S", DateTime.Now + "." + DateTime.Now.Millisecond));  

            //Create Basket with Items
            Basket basket = controller.CreateBasketWithItems(SourceType.XML, noOfBasketItems, pe);

            //Putting Baskets to AppFabric
            controller.PutBasket(type, basket,startBasket , endBasket, pe);


            pe.Add(PerfEntity.CreateEntity("Main.CreateBaskets", "E", DateTime.Now + "." + DateTime.Now.Millisecond));  
            //Todo: Write a function to generate appropriate file Name.
            //string fileName = "SQL Generic Insertion_" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString() + "_" + DateTime.Now.Second.ToString() + ".csv";
        }
        void WriteStatistics()
        {
            string operation = "";
            switch (operationType)
            {
                case 1:
                    operation = "CreateBasket";
                    break;
                case 2:
                    operation = "ReadBasket";
                    break;
            }
            string fileName = operation+"_"+type + "_" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString() + "_" + DateTime.Now.Second.ToString() + ".csv";
            foreach (PerfEntity p in pe)
            {
                System.IO.File.AppendAllText(fileName, p.ModuleName + "," + p.TimeType + "," + p.ExecutionTimeStamp + "\n");
            }
        }

        //ToDO: Generate random numbers (Keys) and get those baskets.
        void GetBaskets()
        {
            pe.Add(PerfEntity.CreateEntity("Main.GetBaskets", "S", DateTime.Now + "." + DateTime.Now.Millisecond));  
            controller.GetBaskets(type, startBasket,endBasket, pe);
            pe.Add(PerfEntity.CreateEntity("Main.GetBaskets", "S", DateTime.Now + "." + DateTime.Now.Millisecond));    
        }
    }
}
