using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StackExchange.Redis;

using System.Web;
using BenchMark.Entities;
using System.IO.Compression;
using System.IO;
using ServiceStack.Redis;
using System.Runtime.Serialization.Formatters.Binary;



namespace BenchMark.BasketActions
{
    public class RedisService
    {
        private IRedisClient _client;
        public RedisService()
        {
            _client = new RedisClient("LocalHost");
        }
        
        public void Insert(Basket basket, List<PerfEntity> pe)
        {
           
           _client.Set<Basket>(basket.BasketHeader.BasketID.ToString(), basket);
           basket = null;   
        }
        
        protected static byte[] ConvertToByteStream(Basket b)
        {
            MemoryStream ms = null;

            try
            {
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

        protected static Basket ConvertFromByteStream(byte[] basketInMemory)
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
