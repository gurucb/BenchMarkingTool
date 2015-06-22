using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.ApplicationServer.Caching;
using System.Web;
using BenchMark.Entities;
using System.IO.Compression;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;



namespace BenchMark.BasketActions
{
    public class AppFabricService
    {
        BasketContainer bc;
        DataCacheFactory cacheFactory;
        DataCache basketCache;
        string region = "stateregister";
        bool createRegionStatus = false;
        private void PrepareClient()
        {
            List<DataCacheServerEndpoint> servers = new List<DataCacheServerEndpoint>(1);
            servers.Add(new DataCacheServerEndpoint("LocalHost", 22233));
            DataCacheFactoryConfiguration configuration = new DataCacheFactoryConfiguration();
            configuration.Servers = servers;
            configuration.LocalCacheProperties = new DataCacheLocalCacheProperties();

            DataCacheClientLogManager.ChangeLogLevel(System.Diagnostics.TraceLevel.Off);
            cacheFactory = new DataCacheFactory(configuration);
            basketCache = cacheFactory.GetCache("default");


        }

        private bool CreateRegion(string regionName)
        {
         
            
            
            //Todo: Can timeout retry logic is needed here.
            createRegionStatus = basketCache.CreateRegion(regionName);
            return createRegionStatus;
        }
        public AppFabricService()
        {
            bc = new BasketContainer();
        }
        public void AddToAppFabricCache(Basket basket,List<PerfEntity> pe)
        {
            if (basketCache == null)
            {
                PrepareClient();
            }
            
            CreateRegion(region);
            
            
            bc.BasketInBytes = ConvertToByteStream(basket);
            pe.Add(PerfEntity.CreateEntity("AppFabricService.AddToAppFabricCache", "S", DateTime.Now + "." + DateTime.Now.Millisecond));
            basketCache.Put(basket.BasketHeader.BasketID.ToString(), ConvertToByteStream(basket));
            pe.Add(PerfEntity.CreateEntity("AppFabricService.AddToAppFabricCache", "E", DateTime.Now + "." + DateTime.Now.Millisecond));
            basket = null;
        }

        public Basket ReadFromAppFabricCache(int basketID, List<PerfEntity> pe)
        {
           
            byte[] result;
            PrepareClient();
            pe.Add(PerfEntity.CreateEntity("AppFabricService.ReadFromAppFabricCache", "S", DateTime.Now + "." + DateTime.Now.Millisecond));
            result = (byte[])basketCache.Get(basketID.ToString());
            pe.Add(PerfEntity.CreateEntity("AppFabricService.ReadFromAppFabricCache", "E", DateTime.Now + "." + DateTime.Now.Millisecond));
            Basket basket = ConvertFromByteStream(result);
            return basket;
        }

        internal byte [] ConvertToByteStream(Basket b)
        {
            MemoryStream ms = null;

            try{
                BinaryFormatter bFor = new BinaryFormatter();
                byte[] compressedData = null;
                using (MemoryStream baseStream = new MemoryStream())
                {
                    // Compress to GZip
                    using (GZipStream zip = new GZipStream(baseStream, CompressionMode.Compress))
                    {
                        // bFor.Serialize(zip, item);
                        using (BufferedStream buf = new BufferedStream(zip, 0x4000 /* 16kB */))
                        {
                            bFor.Serialize(buf, b);
                        }
                    }

                    return baseStream.ToArray();
                }
            }
            finally
            {
                if (ms != null) ms.Close();
            }
        }

        internal static Basket ConvertFromByteStream(byte[] basketInMemory)
        {
            MemoryStream ms = null;
            try
            {
                BinaryFormatter b = new BinaryFormatter();
                using (MemoryStream baseStream = new MemoryStream(basketInMemory))
                {
                    // Decompress from GZip
                    using (GZipStream zip = new GZipStream(baseStream, CompressionMode.Decompress))
                    {
                        // return (T)b.Deserialize(zip);
                        using (BufferedStream buf = new BufferedStream(zip, 0x4000 /* 16kB */))
                        {
                            return (Basket)b.Deserialize(buf);
                        }
                    }
                }
            }

            finally
            {
                if (ms != null) ms.Close();
            }
        }
    
    }
}
